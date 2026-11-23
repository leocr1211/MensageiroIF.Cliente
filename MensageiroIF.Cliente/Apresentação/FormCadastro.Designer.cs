namespace MensageiroIF.Cliente.Apresentação
{
    partial class FormCadastro
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
            this.controleDeLogin1 = new MensageiroIF.Cliente.Apresentação.ControleDeLogin();
            this.SuspendLayout();
            // 
            // controleDeLogin1
            // 
            this.controleDeLogin1.Location = new System.Drawing.Point(12, 12);
            this.controleDeLogin1.Name = "controleDeLogin1";
            this.controleDeLogin1.NomeDoUsuario = "";
            this.controleDeLogin1.SenhaDoUsuario = "";
            this.controleDeLogin1.Size = new System.Drawing.Size(527, 343);
            this.controleDeLogin1.TabIndex = 0;
            this.controleDeLogin1.Load += new System.EventHandler(this.controleDeLogin1_Load);
            // 
            // FormCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 367);
            this.Controls.Add(this.controleDeLogin1);
            this.Name = "FormCadastro";
            this.Text = "MensageiroIF.Cliente - Login";
            this.Load += new System.EventHandler(this.FormCadastro_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControleDeLogin controleDeLogin1;
    }
}