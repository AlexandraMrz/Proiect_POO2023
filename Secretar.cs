using System.Data.SQLite;
using System;
using System.Windows.Forms;
using System.Runtime.ConstrainedExecution;

namespace WindowsFormsApp1
{
    public partial class Secretar : Form
    {
        public Secretar()
        {
            InitializeComponent();
        }

        // butonul pentru programele de studii
        private void button1_Click(object sender, System.EventArgs e)
        {
            Studii studii = new Studii();
            studii.Show();
            this.Hide();
        }

        // butonul pentru vizualizarea cursurilor
        private void btnCursuri_Click(object sender, System.EventArgs e)
        {
            FormCursSpec cursSpec = new FormCursSpec();
            cursSpec.Show();
            this.Hide();
        }
        // butonul pentru vizualizarea profesorilor
        private void viewProfesori_Click(object sender, System.EventArgs e)
        {
            Cadre_didactice cadre = new Cadre_didactice();
            cadre.Show();
            this.Hide();
        }
        // butonul pentru vizualizarea grupelor
        private void grupe_button_Click(object sender, EventArgs e)
        {
          Grupe grupe = new Grupe();
            grupe.Show();
            this.Hide();
        }
    }
}

 