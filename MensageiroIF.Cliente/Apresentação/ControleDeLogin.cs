using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Servicos;
using MensageiroIF.Cliente.Infraestrutura;
using MensageiroIF.Cliente.Contratos;
using MensageiroIF.Cliente.Excecoes;
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
        }

        private void grpCaixaDeLogin_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnEntra_Click(object sender, EventArgs e)
        {
            string nome = NomeDoUsuario.Trim();
            string senha = SenhaDoUsuario;

            if (string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha o nome e a senha.");
                return;
            }

            if (!usuarios.TryGetValue(nome, out string senhaCadastrada))
            {
                MessageBox.Show("Usuário não encontrado.");
                return;
            }

            if (senhaCadastrada != senha)
            {
                MessageBox.Show("Senha incorreta.");
                return;
            }

            MessageBox.Show("Login realizado com sucesso!");

            Usuario remetente = new Usuario(nome);
            IRepositorioDeMensagens repo = new RepositorioEmArquivo();
            ServicoDeHistorico servico = new ServicoDeHistorico(repo);
            Form formularioLogin = FindForm();
            FormEnvio formularioEnvio = new FormEnvio(servico, remetente, new Usuario(""));
            formularioEnvio.FormClosed += (s, args) =>{ formularioLogin.Close(); };
            formularioEnvio.Show();
        }

        private void btnCasdastra_Click(object sender, EventArgs e)
        {
            string nome = NomeDoUsuario.Trim();
            string senha = SenhaDoUsuario;

            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 6 ||
                string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha o nome e a senha. O nome deve ter pelo menos 6 caracteres.");
                return;
            }

            if (usuarios.ContainsKey(nome))
            {
                MessageBox.Show("Este usuário já está cadastrado.");
                return;
            }

            usuarios.Add(nome, senha);

            MessageBox.Show("Cadastro realizado com sucesso!");
        }
    }
}
