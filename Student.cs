using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace WindowsFormsApp1
{
    public partial class Studii : Form
    {
        public Studii()
        {
            InitializeComponent();
        }

        string username;
        private void MainArea_load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Hide();
        }

        //afisarea studentilor in functie de specializare, in ordine descrescatoare

        // Tehnologia Informatiei
        private void tehnologiaInformatieiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE [ProgramStudii] = 'Tehnologia Informatiei' ORDER BY [MediaAdmitere] DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                datesGrid.DataSource = dataTable;
            }
        }

        //Calculatoare
        private void calculatoareToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE [ProgramStudii] = 'Calculatoare' ORDER BY [MediaAdmitere] DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                datesGrid.DataSource = dataTable;
            }
        }

        //Robotica
        private void roboticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE [ProgramStudii] = 'Robotica' ORDER BY [MediaAdmitere] DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                datesGrid.DataSource = dataTable;
            }

        }

        //Automatica si Informatica Aplicata
        private void automaticaSiInformaticaAplicataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE [ProgramStudii] = 'Automatica si Informatica Aplicata' ORDER BY [MediaAdmitere] DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                datesGrid.DataSource = dataTable;
            }
        }
        // SAATI
        private void sAATIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE [ProgramStudii] = 'SAATI' ORDER BY [MediaAdmitere] DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                datesGrid.DataSource = dataTable;
            }
        }
        
        //SECI
        private void sECIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE [ProgramStudii] = 'SECI' ORDER BY [MediaAdmitere] DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                datesGrid.DataSource = dataTable;
            }
        }

        //SEA
        private void sEAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE [ProgramStudii] = 'SEA' ORDER BY [MediaAdmitere] DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                datesGrid.DataSource = dataTable;

                datesGrid.SelectionChanged += SelectionChanged;
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // butonul pentru Edit
            //nume gresit
            //nu face nimic
        }

        //butonul de adaugare
        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdaugaStudenti adaugare = new AdaugaStudenti();
            adaugare.Show();
            this.Hide();
        }

        //butonul de back
        private void backToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Secretar secretar = new Secretar();
            secretar.Show();
            this.Hide();
        }

        //afisarea studentilor in textbox
        private void SelectionChanged(object sender, EventArgs e)
        {
            if (datesGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow row = datesGrid.SelectedRows[0];

                idLabel.Text = row.Cells["ID"].Value.ToString();
                nrMatricol_tb.Text = row.Cells["NrMatricol"].Value.ToString();
                nume_tb.Text = row.Cells["Nume"].Value.ToString();
                prenume_tb.Text = row.Cells["Prenume"].Value.ToString();
                initialaTata_tb.Text = row.Cells["InitialaTatalui"].Value.ToString();
                cnp_tb.Text = row.Cells["CNP"].Value.ToString();
                dataInscriere_tb.Text = row.Cells["DataInscriere"].Value.ToString();
                cicluInvatamant_tb.Text = row.Cells["CicluInvatamant"].Value.ToString(); 
                anStudiu_tb.Text = row.Cells["An studiu"].Value.ToString();
                mail_tb.Text = row.Cells["mail"].Value.ToString();
                medieAdmitere_tb.Text = row.Cells["MediaAdmitere"].Value.ToString();
                programStudii_tb.Text = row.Cells["ProgramStudii"].Value.ToString();
                parola_tb.Text = row.Cells["Parola"].Value.ToString();
                confirmareParola_tb.Text = row.Cells["ConfirmareParola"].Value.ToString();
                grupa_textBox.Text = row.Cells["Grupa"].Value.ToString();

            }
        }

        // modificarea studentilor
        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (datesGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow row = datesGrid.SelectedRows[0];

                // Preluare valori
                string id = row.Cells["ID"].Value.ToString();
                string newNrMat = nrMatricol_tb.Text;
                string newNume = nume_tb.Text;
                string newPrenume = prenume_tb.Text;
                string newInitiala = initialaTata_tb.Text;
                string new_cnp = cnp_tb.Text;
                string newDataInscriere = dataInscriere_tb.Text;
                string newCicluInvatamant = cicluInvatamant_tb.Text;
                string newCAn = anStudiu_tb.Text;
                string newAdresaMail = mail_tb.Text;
                string newMedie = medieAdmitere_tb.Text;
                string newProgramStudii = programStudii_tb.Text;
                string newParola = parola_tb.Text;
                string newCParola = confirmareParola_tb.Text;
                string newGrupa = grupa_textBox.Text;

                // Actualizarea bazei de date
                UpdateInDatabase(id, newNrMat, newNume, newPrenume, newInitiala, new_cnp, newDataInscriere, newCicluInvatamant,
                    newCAn ,newAdresaMail, newMedie, newProgramStudii, newParola, newCParola, newGrupa);

                // Actualizarea celulelor din DataGridView
                row.Cells["NrMatricol"].Value = newNrMat;
                row.Cells["Nume"].Value = newNume;
                row.Cells["Prenume"].Value = newPrenume;
                row.Cells["InitialaTatalui"].Value = newInitiala;
                row.Cells["CNP"].Value = new_cnp;
                row.Cells["DataInscriere"].Value = newDataInscriere;
                row.Cells["CicluInvatamant"].Value = newCicluInvatamant;
                row.Cells["An studiu"].Value = newCAn;
                row.Cells["mail"].Value = newAdresaMail;
                row.Cells["MediaAdmitere"].Value = newMedie;
                row.Cells["ProgramStudii"].Value = newProgramStudii;
                row.Cells["Parola"].Value = newParola;
                row.Cells["ConfirmareParola"].Value = newCParola;
                row.Cells["Grupa"].Value = newGrupa;

                MessageBox.Show("Actualizare reușită!");
            }
        }
        //actualizarea bazei de date
        public void UpdateInDatabase(string id, string newNrMat, string newNume, string newPrenume, string newInitiala, 
            string new_cnp, string newDataInscriere, string newCicluInvatamant, string newCAn, string newAdresaMail, 
            string newMedie, string newProgramStudii, string newParola, string newCParola,string newGrupa)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";

            string query = "UPDATE Student SET NrMatricol = @newNrMat, Nume = @newNume, Prenume = @newPrenume, " +
                "InitialaTatalui = @newInitiala," +" CNP = @new_cnp, DataInscriere = @newDataInscriere, " +
                "CicluInvatamant = @newCicluInvatamant,\"An studiu\"=@newCAn , mail = @newAdresaMail," + " MediaAdmitere = @newMedie," +
                " ProgramStudii = @newProgramStudii, Parola = @newParola," +
                " Grupa=@newGrupa,ConfirmareParola = @newCParola WHERE ID = @newID";


            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@newNrMat", newNrMat);
                    command.Parameters.AddWithValue("@newNume", newNume);
                    command.Parameters.AddWithValue("@newPrenume", newPrenume);
                    command.Parameters.AddWithValue("@newInitiala", newInitiala);
                    command.Parameters.AddWithValue("@new_cnp", new_cnp);
                    command.Parameters.AddWithValue("@newDataInscriere", newDataInscriere);
                    command.Parameters.AddWithValue("@newCicluInvatamant", newCicluInvatamant);
                    command.Parameters.AddWithValue("@newCAn", newCAn);
                    command.Parameters.AddWithValue("@newAdresaMail", newAdresaMail);
                    command.Parameters.AddWithValue("@newMedie", newMedie);
                    command.Parameters.AddWithValue("@newProgramStudii", newProgramStudii);
                    command.Parameters.AddWithValue("@newParola", newParola);
                    command.Parameters.AddWithValue("@newCParola", newCParola);
                    command.Parameters.AddWithValue("@newID", id);
                    command.Parameters.AddWithValue("@newGrupa", newGrupa);
                    command.ExecuteNonQuery(); // Execută comanda SQL de actualizare

                    MessageBox.Show("Actualizare reușită!");
                }
            }
        }
        // Funcție pentru ștergerea unui student din baza de date
        private void DeleteFromDatabase(string id)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "DELETE FROM Student WHERE ID = @id";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery(); // Execută comanda SQL de ștergere

                    MessageBox.Show("Ștergere reușită!");
                }
            }
        }

        // Funcție pentru a șterge un student din DataGridView și din baza de date
        private void DeleteSelectedStudent()
        {
            if (datesGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow row = datesGrid.SelectedRows[0];

                string id = row.Cells["ID"].Value.ToString();

                // Confirmare ștergere
                DialogResult result = MessageBox.Show("Ești sigur că vrei să ștergi acest student?", "Confirmare ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Șterge rândul din DataGridView
                    datesGrid.Rows.Remove(row);

                    // Șterge rândul din baza de date
                    DeleteFromDatabase(id);
                }
            }
        }
        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedStudent();
        }

        private void cyberSecurityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE [ProgramStudii] = 'Cyber Security' ORDER BY [MediaAdmitere] DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                datesGrid.DataSource = dataTable;

                datesGrid.SelectionChanged += SelectionChanged;
            }
        }
    }

}
