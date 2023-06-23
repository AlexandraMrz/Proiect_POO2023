using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
namespace WindowsFormsApp1
{
    public partial class Grupe : Form
    {
        public Grupe()
        {
            InitializeComponent();
        }


        private void automaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // generare grupe

        public static void GenerateStudentGroups(string connectionString)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT * FROM Student ORDER BY MediaAdmitere ASC", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int grupaCount = 3; // Numărul de grupe pentru fiecare program de studii
                        int grupaIndex = 1; // Indexul grupei curente
                        double grupaMedie = 0; // Media de referință pentru împărțirea în grupe

                        while (reader.Read())
                        {
                            string numeStudent = reader["Nume"].ToString();
                            int anStudii = reader["An studiu"] != DBNull.Value ? Convert.ToInt32(reader["An studiu"]) : 0;
                            string cicluInvatamant = reader["CicluInvatamant"].ToString();
                            string dataInscriere = reader["DataInscriere"].ToString();

                            //Medie->MediaAdmitere
                            double medie = reader["MediaAdmitere"] != DBNull.Value ? Convert.ToDouble(reader["MediaAdmitere"]) : 0;

                            char C = cicluInvatamant[0];
                            char F = 'F';
                            string A = dataInscriere.Substring(dataInscriere.Length - 1);

                            int P = GetProgramStudiiCode(reader["ProgramStudii"].ToString());
                            int contor = grupaIndex;

                            string Grupa = $"4{C}{F}{P}{A}{contor}";

                            using (var updateCommand = new SQLiteCommand("UPDATE Student SET Grupa = @Grupa WHERE ID = @ID", connection))
                            {
                                updateCommand.Parameters.AddWithValue("@Grupa", Grupa);
                                updateCommand.Parameters.AddWithValue("@ID", reader["ID"]);
                                updateCommand.ExecuteNonQuery();
                            }

                            grupaMedie += medie;
                            grupaIndex++;

                            if (grupaIndex > grupaCount)
                            {
                                grupaMedie /= grupaCount;
                                grupaIndex = 1;
                            }
                        }
                    }
                }
            }
        }

        // functie pentru selectarea programului de studii dorit
        public static int GetProgramStudiiCode(string programStudii)
        {
            switch (programStudii)
            {
                case "Automatica si Informatica Aplicata":
                    return 1;
                case "Tehnologia Informatiei":
                    return 2;
                case "Robotica":
                    return 3;
                case "Calculatoare":
                    return 4;
                case "Cyber Security":
                    return 5;
                case "SAATI":
                    return 6;
                case "SECI":
                    return 7;
                case "SEA":
                    return 8;

                default:
                    return 0;
            }
        }

        // butonul pentru generarea grupelor
        private void btn_grupe_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            //string tableName = "Student";

            GenerateStudentGroups(connectionString);

            MessageBox.Show("Generarea numelor grupelor a fost finalizată.");
        }

        //butonul de back
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Secretar secretar = new Secretar();
            secretar.Show();
            this.Hide();
        }

        //GRUPA 1 TI anul 1
        private void grupa1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string Grupa = $"4{C}{F}{P}{A}{contor}";
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_1' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //ti anul 1 grupa 2
        private void grupa2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_2' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        //ti anul 1 grupa 3
        private void grupa3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_3' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        //ti anul 2 grupa 1
        private void grupa1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_1' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //ti anul 2 grupa 2
        private void grupa2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_2' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //ti anul 2 grupa 3
        private void grupa3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_3' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //automatica an 1 grupa 1
        //actually nu e automatica an 1 grupa 1 =))))))
        private void anul1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        //ti an 3 grupa 1
        private void grupa1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_1' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //ti an 3 grupa 2
        private void grupa2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_2' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //ti an 3 grupa 2
        private void grupa3ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_3' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //ti an 4 grupa 1
        private void grupa1ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_1' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //ti an 4 grupa 2
        private void grupa2ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_2' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //ti an 4 grupa 3
        private void grupa3ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_2_3' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //asta e automatica an 1 gr 1
        private void grupa1ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_1' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //automatica an 1 gr 2
        private void grupa2ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_2' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //automatica an 1 gr 3
        private void grupa3ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_3' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //automatica an 2 gr 1
        private void grupa1ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_1' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //auto an 2 gr 2
        private void grupa2ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_2' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //aia an 2 gr 3
        private void grupa3ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_3' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        // aia an 3 gr 1
        private void grupa1ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_1' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //aia an 3 gr 2
        private void grupa2ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_2' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //aia an 3 gr 3
        private void grupa3ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_3' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //aia an 4 gr 1
        private void grupa1ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_1' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //aia an 4 gr 2
        private void grupa2ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_2' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        // aia an 4 gr 3
        private void grupa3ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_1_3' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //calc an 1 gr 1
        private void grupa1ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_1' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //calc an 1 gr 2
        private void grupa2ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_2' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //calc an 1 gr 3
        private void grupa3ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_3' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //calc an 2 gr 1
        private void grupa1ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_1' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        private void grupa2ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_2' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //calc an 2 gr 3
        private void grupa3ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_3' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //calc an 3 gr 1
        private void grupa1ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_1' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //calc an 3 gr 2
        private void grupa2ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_2' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //calc an 3 gr 3
        private void grupa3ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_3' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //calc an 4 gr 1
        private void grupa1ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_1' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //calc an 4 gr 2
        private void grupa2ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_2' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        // calc an 4 gr 3
        private void grupa3ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_4_3' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 1 gr 1
        private void grupa1ToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_1' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 1 gr 2
        private void grupa2ToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_2' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 1 gr 3
        private void grupa3ToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_3' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 2 gr 1
        private void grupa1ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_1' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 2 gr 2
        private void grupa2ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_2' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 2 gr 3
        private void grupa3ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_3' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 3 gr 1
        private void grupa1ToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_1' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 3 gr 2
        private void grupa2ToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_2' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        // robo an 3 gr 3
        private void grupa3ToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_3' AND [An studiu] = '3'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 4 gr 1
        private void grupa1ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_1' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        // robo an 4 gr 2
        private void grupa2ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_2' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //robo an 4 gr 3
        private void grupa3ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_3_3' AND [An studiu] = '4'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        // cyber an 1 gr 1
        private void grupa1ToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_5_1' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        // cyber an 1 gr 2
        private void grupa2ToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_5_2' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //cyber an 1 gr 3
        private void grupa3ToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_5_3' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //cyber ann 2 gr 1
        private void grupa1ToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_5_1' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        private void grupa2ToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_5_2' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //cyber an 2 gr 3
        private void grupa3ToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_5_3' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        // saati an 1 gr 1
        private void grupa1ToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_6_1' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        // saati an 1 gr 2
        private void grupa2ToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_6_2' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //saati an 1 gr 3
        private void grupa3ToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_6_3' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //saati an 2 gr 1
        private void grupa1ToolStripMenuItem19_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_6_1' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //saati an 2 gr 2
        private void grupa2ToolStripMenuItem19_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_6_2' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //saati an 2 gr 3
        private void grupa3ToolStripMenuItem19_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_6_3' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //seci an 1 gr 1
        private void grupa1ToolStripMenuItem20_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_7_1' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //seci an 1 gr 2
        private void grupa2ToolStripMenuItem20_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_7_2' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //seci an 1 gr 3
        private void grupa3ToolStripMenuItem20_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_7_3' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //seci an 2 gr 1
        private void grupa1ToolStripMenuItem21_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_7_1' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //seci an 2 gr 2
        private void grupa2ToolStripMenuItem21_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_7_2' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //seci an 2 gr 3
        private void grupa3ToolStripMenuItem21_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_7_3' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //iar am apasat gresit imi pare scz e de la visinata <3 si ca sta andreea langa mine 
        private void anul1ToolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }
        //sea an 1 gr 1
        private void grupa1ToolStripMenuItem22_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_8_1' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //sea an 1 gr 2
        private void grupa2ToolStripMenuItem22_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_8_2' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //sea an 1 gr 3
        private void grupa3ToolStripMenuItem22_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_8_3' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //sea an 2 gr 1
        private void grupa1ToolStripMenuItem23_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_8_1' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

        }
        //sea an 2 gr 2
        private void grupa2ToolStripMenuItem23_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_8_2' AND [An studiu] = '2'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        //sea an 2 gr 3 doamne 2000 de linii de cod sa intepeneasca=)))))))
        private void grupa3ToolStripMenuItem23_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=C:\Users\user\Desktop\database.db;Version=3;";
            string query = "SELECT * FROM Student WHERE Grupa LIKE '%_8_3' AND [An studiu] = '1'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dataTable = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        private void ExportToExcel(DataGridView dataGridView1)
        {
            // Creare unei instanțe Excel
            var excelApp = new Excel.Application();
            excelApp.Visible = false;

            // Creare un nou workbook Excel
            var workbook = excelApp.Workbooks.Add();
            var sheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Adăugare antet coloane
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                sheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            // Adăugare date în fișierul Excel
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    var cellValue = dataGridView1.Rows[i].Cells[j].Value;
                    if (cellValue != null)
                    {
                        sheet.Cells[i + 2, j + 1] = cellValue.ToString();
                    }
                }
            }

            // Salvare fișier Excel
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
            }

            // Închidere workbook și aplicație Excel
            workbook.Close();
            excelApp.Quit();
        }
        // butonul de generare fisiere XML
        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }

        
    }
}
