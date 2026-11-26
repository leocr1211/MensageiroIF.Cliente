namespace MensageiroIF.Cliente.Apresentação
{
    partial class FormEnvio
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
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.lstHistorico = new System.Windows.Forms.ListBox();
            this.cmbDestinatario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(432, 323);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 47);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtMensagem
            // 
            this.txtMensagem.Location = new System.Drawing.Point(12, 323);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(414, 47);
            this.txtMensagem.TabIndex = 1;
            // 
            // lstHistorico
            // 
            this.lstHistorico.FormattingEnabled = true;
            this.lstHistorico.Location = new System.Drawing.Point(13, 13);
            this.lstHistorico.Name = "lstHistorico";
            this.lstHistorico.Size = new System.Drawing.Size(520, 277);
            this.lstHistorico.TabIndex = 2;
            this.lstHistorico.SelectedIndexChanged += new System.EventHandler(this.lstHistorico_SelectedIndexChanged);
            // 
            // cmbDestinatario
            // 
            this.cmbDestinatario.FormattingEnabled = true;
            this.cmbDestinatario.Location = new System.Drawing.Point(216, 296);
            this.cmbDestinatario.Name = "cmbDestinatario";
            this.cmbDestinatario.Size = new System.Drawing.Size(317, 21);
            this.cmbDestinatario.TabIndex = 3;
            this.cmbDestinatario.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Escolha o seu Destinatário : ";
            // 
            // FormEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 388);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDestinatario);
            this.Controls.Add(this.lstHistorico);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.btnEnviar);
            this.Name = "FormEnvio";
            this.Text = "MensageiroIF.Cliente - Canal de Mensagens";
            this.Load += new System.EventHandler(this.FormEnvio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.ListBox lstHistorico;
        private System.Windows.Forms.ComboBox cmbDestinatario;
        private System.Windows.Forms.Label label1;
    }
}