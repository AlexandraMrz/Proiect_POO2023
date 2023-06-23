using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public string usernames;

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (username_tb.Text != string.Empty && password_tb.Text != string.Empty)
            {
                checkAccount(username_tb.Text, password_tb.Text);
            }
        }

        private void checkAccount(string mail, string password)
        {
            Autentificare autentificare;
            autentificare = new Autentificare();
            autentificare.getConnection();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(autentificare.connectionString))
                {
                    conn.Open();
                    string querys = "SELECT * FROM Profesori WHERE mail = @Mail and Parola = @Parola";

                    using (SQLiteCommand cmd = new SQLiteCommand(querys, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mail", mail);
                        cmd.Parameters.AddWithValue("@Parola", password);

                        int count = 0;

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;
                            }

                            switch (count)
                            {
                                case 0:
                                    // Nu există nicio înregistrare care să corespundă
                                    break;

                                case 1:
                                    MessageBox.Show("Autentificare reușită pentru utilizatorul " + mail + " ca profesor");

                                    Profesor profesor = new Profesor();
                                    profesor.Show();
                                    this.Hide();

                                    return;

                                default:
                                    MessageBox.Show("Există mai multe înregistrări care corespund.");
                                    break;
                            }
                        }
                    }
                }

                using (SQLiteConnection conn = new SQLiteConnection(autentificare.connectionString))
                {
                    conn.Open();
                    string queryss = "SELECT * FROM Secretari WHERE mail = @Mail and Parola = @Parola";

                    using (SQLiteCommand cmd = new SQLiteCommand(queryss, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mail", mail);
                        cmd.Parameters.AddWithValue("@Parola", password);

                        int count = 0;

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;
                            }

                            switch (count)
                            {
                                case 0:
                                    // Nu există nicio înregistrare care să corespundă
                                    break;

                                case 1:
                                    MessageBox.Show("Autentificare reușită pentru utilizatorul " + mail + " ca secretar");

                                    Secretar secretar = new Secretar();
                                    secretar.Show();
                                    this.Hide();

                                    return;

                                default:
                                    MessageBox.Show("Există mai multe înregistrări care corespund.");
                                    break;
                            }
                        }
                    }
                }

                using (SQLiteConnection conn = new SQLiteConnection(autentificare.connectionString))
                {
                    conn.Open();
                    string queryss = "SELECT * FROM Admin WHERE mail = @Mail and Parola = @Parola";

                    using (SQLiteCommand cmd = new SQLiteCommand(queryss, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mail", mail);
                        cmd.Parameters.AddWithValue("@Parola", password);

                        int count = 0;

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;
                            }

                            switch (count)
                            {
                                case 0:
                                    // Nu există nicio înregistrare care să corespundă
                                    break;

                                case 1:
                                    MessageBox.Show("Autentificare reușită pentru utilizatorul " + mail + " ca administrator");

                                    Administrator admin = new Administrator();
                                    admin.Show();
                                    this.Hide();

                                    return;

                                default:
                                    MessageBox.Show("Există mai multe înregistrări care corespund.");
                                    break;
                            }
                        }
                    }
                }

                MessageBox.Show("Nu există nicio înregistrare care să corespundă.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
