using System.Data.SQLite;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Profesor : Form
    {
        public Profesor()
        {
            InitializeComponent();
        }

        //butonul de back
        private void backBtn_Click(object sender, System.EventArgs e)
        {
            Secretar secretar = new Secretar();
            secretar.Show();
            this.Close();
        }

        // autentificarea utilizatorului
        Autentificare autentificare;

        //butonul de creare cont
        private void createBtn_Click(object sender, System.EventArgs e)
        {
            if (numeProf_tb.Text != string.Empty && prenumeProf_tb.Text != string.Empty && marcaAngajat_tb.Text != string.Empty &&
                titlu_tb.Text != string.Empty && post_tb.Text != string.Empty && materie_tb.Text != string.Empty &&
                titular_tb.Text != string.Empty && mailProf_tb.Text != string.Empty && parola_tb.Text != string.Empty && confirmareParola_tb.Text != string.Empty)
            {
                if (parola_tb.Text == confirmareParola_tb.Text)
                {
                    checkAccount(marcaAngajat_tb.Text);
                }
                else
                {
                    MessageBox.Show("Parolele nu se potrivesc!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //verificare daca utilizatorul exista
        private void checkAccount(string username)
        {
            autentificare = new Autentificare();

            autentificare.CreateDataBase();
            autentificare.getConnection();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(autentificare.ConnectionString))
                {
                    con.Open();

                    int count = 0;
                    string query = @"SELECT * FROM Profesori";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;
                            }
                        }
                    }

                    if (count != 0)
                    {
                        insertData(numeProf_tb.Text, prenumeProf_tb.Text, marcaAngajat_tb.Text, titlu_tb.Text, post_tb.Text, materie_tb.Text, titular_tb.Text, mailProf_tb.Text, parola_tb.Text, confirmareParola_tb.Text);
                        return;
                    }
                    else if (count == 0)
                    {
                        MessageBox.Show("Cont existent!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //inserarea in baza de date
        private void insertData(string nume, string prenume, string marcaAngajat, string titlu, string post, string materie, string titular, string email, string password, string confirmpass)
        {
            autentificare = new Autentificare();
            autentificare.getConnection();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(autentificare.ConnectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO Profesori (Nume, Prenume, MarcaAngajat, Titlu, Post, Materie, Titular, Mail, Parola , ConfirmareParola) VALUES (@nume, @prenume, @marcaangajat, @titlu, @post, @materie, @titular, @mail, @password, @confirmpass)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nume", nume);
                        cmd.Parameters.AddWithValue("@prenume", prenume);
                        cmd.Parameters.AddWithValue("@marcaangajat", marcaAngajat);
                        cmd.Parameters.AddWithValue("@titlu", titlu);
                        cmd.Parameters.AddWithValue("@post", post);
                        cmd.Parameters.AddWithValue("@materie", materie);
                        cmd.Parameters.AddWithValue("@titular", titular);
                        cmd.Parameters.AddWithValue("@mail", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@confirmpass", confirmpass);

                        cmd.ExecuteNonQuery();

                        // Adaugă valoarea în tabela "Cursuri"
                        AddProfesorToCursuri();

                        MessageBox.Show("Cont creat cu succes!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        numeProf_tb.Clear();
                        prenumeProf_tb.Clear();
                        marcaAngajat_tb.Clear();
                        titlu_tb.Clear();
                        post_tb.Clear();
                        materie_tb.Clear();
                        titular_tb.Clear();
                        mailProf_tb.Clear();
                        parola_tb.Clear();
                        confirmareParola_tb.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //metoda pentru adaugarea profesorului in tabela "Cursuri"
        public void AddProfesorToCursuri()
        {
            autentificare = new Autentificare();
            autentificare.getConnection();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(autentificare.ConnectionString))
                {
                    con.Open();
                    string query = "UPDATE Cursuri SET Profesor = (SELECT Nume FROM Profesori WHERE Profesori.Titular = Cursuri.Cod) WHERE EXISTS (SELECT 1 FROM Profesori WHERE Profesori.Titular = Cursuri.Cod)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Valorile au fost adăugate cu succes în coloana specificată!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}