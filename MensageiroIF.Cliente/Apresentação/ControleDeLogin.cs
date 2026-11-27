using MensageiroIF.Contratos;
using MensageiroIF.Dominio;
using MensageiroIF.Excecoes;
using MensageiroIF.Funcoes;
using MensageiroIF.Infraestrutura;
using MensageiroIF.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MensageiroIF.Cliente.Apresentação
{
    public partial class ControleDeLogin : UserControl
    {
        private static Dictionary<string, string> usuarios = new Dictionary<string, string>();

        private static string caminhoArquivo = "usuarios.txt";
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
        static ControleDeLogin()
        {
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (string linha in linhas)
                {
                    string[] dados = linha.Split('|');

                    if (dados.Length == 2)
                    {
                        string nome = dados[0];
                        string senha = dados[1];

                        if (!usuarios.ContainsKey(nome))
                        {
                            usuarios.Add(nome, senha);
                        }
                    }
                }
            }
        }
        private void grpCaixaDeLogin_Enter(object sender, EventArgs e)
        {

        }
        private void btnEntra_Click(object sender, EventArgs e)
        {
            string nome = NomeDoUsuario.Trim();
            string senha = SenhaDoUsuario;

            if (FuncoesUsuario.VerificarLogin(nome, senha))
            {
                MessageBox.Show("Login realizado!");
                FuncoesEventos.RegistrarEntrada(nome);

                Usuario remetente = new Usuario(nome);
                IRepositorioDeMensagens repo = new RepositorioEmArquivo();
                ServicoDeHistorico servico = new ServicoDeHistorico(repo);
                Form formularioLogin = FindForm();
                FormEnvio formularioEnvio = new FormEnvio(servico, remetente, new Usuario(""));
                formularioEnvio.FormClosed += (s, args) => { formularioLogin.Close(); };
                formularioEnvio.Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.");
            }
        }
        private void btnCasdastra_Click(object sender, EventArgs e)
        {
            try
            {
                FuncoesUsuario.Cadastrar(NomeDoUsuario.Trim(), SenhaDoUsuario);
                FuncoesEventos.RegistrarCadastro(NomeDoUsuario.Trim());
                MessageBox.Show("Cadastro realizado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
    }
}
