using MensageiroIF.Cliente.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MensageiroIF.Cliente.Apresentação
{
    public partial class ControleDeLogin : UserControl
    {
        private static Dictionary<string, string> usuarios = new Dictionary<string, string>();
        public string NomeDoUsuario
        {
            get { return txtNomedoUsuario.Text; }
            set { txtNomedoUsuario.Text = value; }
        }

        public string SenhaDoUsuario
        {
            get { return txtSenhaDoUsuario.Text; }
            set { txtSenhaDoUsuario.Text = value; }
        }
        public Button BotaoEntrar
        {
            get { return btnEntra; }
            set { btnEntra = value; }
        }

        public Button BotaoCadastro
        {
            get { return btnCasdastra; }
            set { btnCasdastra = value; }
        }
        
        public ControleDeLogin()
        {
            InitializeComponent();

            BotaoEntrar.Click += btnEntra_Click;
            BotaoCadastro.Click += btnCasdastra_Click;
        }

        private void grpCaixaDeLogin_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnEntra_Click(object sender, EventArgs e)
        {
            string nome = NomeDoUsuario.Trim();
            string senha = SenhaDoUsuario;

            if (string.IsNullOrWhiteSpace(nome) || nome.Count() < 6 ||
                string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha o nome e a senha, e o nome deve ter pelo menos 6 caracteres.");
                return;
            }

            if (usuarios.ContainsKey(nome))
            {
                MessageBox.Show("Usuário já cadastrado.");
                return;
            }

            usuarios.Add(nome, senha);

            MessageBox.Show("Cadastro realizado com sucesso!");
        }

        private void btnCasdastra_Click(object sender, EventArgs e)
        {

        }
    }
}
