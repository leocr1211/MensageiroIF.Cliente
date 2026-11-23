namespace MensageiroIF.Cliente.Apresentação
{
    partial class ControleDeLogin
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpCaixaDeLogin = new System.Windows.Forms.GroupBox();
            this.txtNomedoUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSenhaDoUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEntra = new System.Windows.Forms.Button();
            this.btnCasdastra = new System.Windows.Forms.Button();
            this.grpCaixaDeLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCaixaDeLogin
            // 
            this.grpCaixaDeLogin.Controls.Add(this.btnCasdastra);
            this.grpCaixaDeLogin.Controls.Add(this.btnEntra);
            this.grpCaixaDeLogin.Controls.Add(this.txtNomedoUsuario);
            this.grpCaixaDeLogin.Controls.Add(this.label2);
            this.grpCaixaDeLogin.Controls.Add(this.txtSenhaDoUsuario);
            this.grpCaixaDeLogin.Controls.Add(this.label1);
            this.grpCaixaDeLogin.Location = new System.Drawing.Point(4, 4);
            this.grpCaixaDeLogin.Name = "grpCaixaDeLogin";
            this.grpCaixaDeLogin.Size = new System.Drawing.Size(519, 336);
            this.grpCaixaDeLogin.TabIndex = 0;
            this.grpCaixaDeLogin.TabStop = false;
            this.grpCaixaDeLogin.Text = "Cadastro/Login";
            this.grpCaixaDeLogin.Enter += new System.EventHandler(this.grpCaixaDeLogin_Enter);
            // 
            // txtNomedoUsuario
            // 
            this.txtNomedoUsuario.Location = new System.Drawing.Point(59, 68);
            this.txtNomedoUsuario.Multiline = true;
            this.txtNomedoUsuario.Name = "txtNomedoUsuario";
            this.txtNomedoUsuario.Size = new System.Drawing.Size(376, 46);
            this.txtNomedoUsuario.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Login:";
            // 
            // txtSenhaDoUsuario
            // 
            this.txtSenhaDoUsuario.Location = new System.Drawing.Point(59, 170);
            this.txtSenhaDoUsuario.Multiline = true;
            this.txtSenhaDoUsuario.Name = "txtSenhaDoUsuario";
            this.txtSenhaDoUsuario.Size = new System.Drawing.Size(376, 46);
            this.txtSenhaDoUsuario.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome :";
            // 
            // btnEntra
            // 
            this.btnEntra.Location = new System.Drawing.Point(59, 268);
            this.btnEntra.Name = "btnEntra";
            this.btnEntra.Size = new System.Drawing.Size(116, 47);
            this.btnEntra.TabIndex = 6;
            this.btnEntra.Text = "Entrar";
            this.btnEntra.UseVisualStyleBackColor = true;
            this.btnEntra.Click += new System.EventHandler(this.btnEntra_Click);
            // 
            // btnCasdastra
            // 
            this.btnCasdastra.Location = new System.Drawing.Point(322, 268);
            this.btnCasdastra.Name = "btnCasdastra";
            this.btnCasdastra.Size = new System.Drawing.Size(113, 47);
            this.btnCasdastra.TabIndex = 7;
            this.btnCasdastra.Text = "Cadastrar";
            this.btnCasdastra.UseVisualStyleBackColor = true;
            this.btnCasdastra.Click += new System.EventHandler(this.btnCasdastra_Click);
            // 
            // ControleDeLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCaixaDeLogin);
            this.Name = "ControleDeLogin";
            this.Size = new System.Drawing.Size(526, 343);
            this.grpCaixaDeLogin.ResumeLayout(false);
            this.grpCaixaDeLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCaixaDeLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomedoUsuario;
        private System.Windows.Forms.TextBox txtSenhaDoUsuario;
        private System.Windows.Forms.Button btnCasdastra;
        private System.Windows.Forms.Button btnEntra;
    }
}
