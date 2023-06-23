namespace WindowsFormsApp1
{
    partial class Secretar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Secretar));
            this.groupBox_studenti = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grupe_button = new System.Windows.Forms.Button();
            this.btnCursuri = new System.Windows.Forms.Button();
            this.select_program_btn = new System.Windows.Forms.Button();
            this.groupBox_profesori = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.viewProfesori = new System.Windows.Forms.Button();
            this.groupBox_studenti.SuspendLayout();
            this.groupBox_profesori.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_studenti
            // 
            this.groupBox_studenti.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox_studenti.Controls.Add(this.label1);
            this.groupBox_studenti.Controls.Add(this.grupe_button);
            this.groupBox_studenti.Controls.Add(this.btnCursuri);
            this.groupBox_studenti.Controls.Add(this.select_program_btn);
            this.groupBox_studenti.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_studenti.Location = new System.Drawing.Point(12, 12);
            this.groupBox_studenti.Name = "groupBox_studenti";
            this.groupBox_studenti.Size = new System.Drawing.Size(438, 492);
            this.groupBox_studenti.TabIndex = 1;
            this.groupBox_studenti.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "STUDENTI";
            // 
            // grupe_button
            // 
            this.grupe_button.BackColor = System.Drawing.SystemColors.Window;
            this.grupe_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupe_button.ForeColor = System.Drawing.Color.Navy;
            this.grupe_button.Location = new System.Drawing.Point(66, 307);
            this.grupe_button.Name = "grupe_button";
            this.grupe_button.Size = new System.Drawing.Size(286, 68);
            this.grupe_button.TabIndex = 3;
            this.grupe_button.Text = "Grupe";
            this.grupe_button.UseVisualStyleBackColor = false;
            this.grupe_button.Click += new System.EventHandler(this.grupe_button_Click);
            // 
            // btnCursuri
            // 
            this.btnCursuri.BackColor = System.Drawing.SystemColors.Window;
            this.btnCursuri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCursuri.ForeColor = System.Drawing.Color.Navy;
            this.btnCursuri.Location = new System.Drawing.Point(66, 211);
            this.btnCursuri.Name = "btnCursuri";
            this.btnCursuri.Size = new System.Drawing.Size(286, 65);
            this.btnCursuri.TabIndex = 2;
            this.btnCursuri.Text = "Cursuri";
            this.btnCursuri.UseVisualStyleBackColor = false;
            this.btnCursuri.Click += new System.EventHandler(this.btnCursuri_Click);
            // 
            // select_program_btn
            // 
            this.select_program_btn.BackColor = System.Drawing.SystemColors.Window;
            this.select_program_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_program_btn.ForeColor = System.Drawing.Color.Navy;
            this.select_program_btn.Location = new System.Drawing.Point(65, 117);
            this.select_program_btn.Name = "select_program_btn";
            this.select_program_btn.Size = new System.Drawing.Size(287, 62);
            this.select_program_btn.TabIndex = 1;
            this.select_program_btn.Text = "Program de studii";
            this.select_program_btn.UseVisualStyleBackColor = false;
            this.select_program_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox_profesori
            // 
            this.groupBox_profesori.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox_profesori.Controls.Add(this.label2);
            this.groupBox_profesori.Controls.Add(this.viewProfesori);
            this.groupBox_profesori.Location = new System.Drawing.Point(456, 12);
            this.groupBox_profesori.Name = "groupBox_profesori";
            this.groupBox_profesori.Size = new System.Drawing.Size(480, 492);
            this.groupBox_profesori.TabIndex = 2;
            this.groupBox_profesori.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(174, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "PROFESORI";
            // 
            // viewProfesori
            // 
            this.viewProfesori.BackColor = System.Drawing.Color.White;
            this.viewProfesori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewProfesori.ForeColor = System.Drawing.Color.Navy;
            this.viewProfesori.Location = new System.Drawing.Point(101, 312);
            this.viewProfesori.Name = "viewProfesori";
            this.viewProfesori.Size = new System.Drawing.Size(286, 59);
            this.viewProfesori.TabIndex = 3;
            this.viewProfesori.Text = "Vizualizare profesori";
            this.viewProfesori.UseVisualStyleBackColor = false;
            this.viewProfesori.Click += new System.EventHandler(this.viewProfesori_Click);
            // 
            // Secretar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 516);
            this.Controls.Add(this.groupBox_profesori);
            this.Controls.Add(this.groupBox_studenti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Secretar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secretar";
            this.groupBox_studenti.ResumeLayout(false);
            this.groupBox_studenti.PerformLayout();
            this.groupBox_profesori.ResumeLayout(false);
            this.groupBox_profesori.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox_studenti;
        private System.Windows.Forms.GroupBox groupBox_profesori;
        private System.Windows.Forms.Button select_program_btn;
        private System.Windows.Forms.Button btnCursuri;
        private System.Windows.Forms.Button viewProfesori;
        private System.Windows.Forms.Button grupe_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}