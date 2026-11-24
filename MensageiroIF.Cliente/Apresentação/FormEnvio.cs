using MensageiroIF.Cliente.Contratos;
using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Excecoes;
using MensageiroIF.Cliente.Infraestrutura;
using MensageiroIF.Cliente.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MensageiroIF.Cliente.Apresentação
{
    public partial class FormEnvio : Form
    {
        private readonly Servidor conexao = new Servidor();
        private readonly ServicoDeHistorico servico;
        private readonly Usuario usuarioAtual;
        private readonly Usuario usuarioDestinatario;
        public FormEnvio(ServicoDeHistorico servico, Usuario usuarioAtual, Usuario usuarioDestinatario)
        {
            InitializeComponent();
            this.servico = servico;
            this.usuarioAtual = usuarioAtual;
            this.usuarioDestinatario = usuarioDestinatario;
            conexao.MensagemRecebida += ReceberMensagem;
            FormClosed += (s, e) => conexao.Desconectar();
            AtualizarHistorico();
            CarregarDestinatarios();
        }
        public void CarregarDestinatarios()
        {
            cmbDestinatario.Items.Clear();

            cmbDestinatario.Items.Add("Chat Geral");

            foreach (string usuario in ControleDeLogin.ObterUsuariosCadastrados())
            {
                if (usuario != usuarioAtual.Apelido)
                {
                    cmbDestinatario.Items.Add(usuario);
                }
            }
            if (cmbDestinatario.Items.Count > 0)
            {
                cmbDestinatario.SelectedIndex = 0;
            }
        }
        public void AtualizarHistorico()
        {
            lstHistorico.Items.Clear();
            if (cmbDestinatario.SelectedItem == null)
                return;
            string selecionado = cmbDestinatario.SelectedItem.ToString();
            foreach (Mensagem m in servico.ObterHistorico())
            {
                if (selecionado == "Chat Geral")
                {
                    if (m.Destinatario == "Chat Geral")
                    {
                        lstHistorico.Items.Add(m.ToString());
                    }
                }
                else
                {
                    bool mensagemEnviada = m.Remetente == usuarioAtual.Apelido && m.Destinatario == selecionado;
                    bool mensagemRecebida = m.Remetente == selecionado && m.Destinatario == usuarioAtual.Apelido;
                    if (mensagemEnviada || mensagemRecebida)
                    {
                        lstHistorico.Items.Add(m.ToString());
                    }
                }
            }
        }
        static string ObterIpLocal()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipEncontrado = host.AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            return ipEncontrado != null ? ipEncontrado.ToString() : "127.0.0.1";
        }
        public void ReceberMensagem(string linha)
        {
            try
            {
                AnalisadorDeProtocolo analisador = new AnalisadorDeProtocolo();

                MensagemTexto mensagem = analisador.Analisar(linha);
                if (IsDisposed || !IsHandleCreated)
                    return;
                BeginInvoke(new Action(() =>{ servico.AdicionarMensagem(mensagem); AtualizarHistorico(); }));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private async void FormEnvio_Load(object sender, EventArgs e)
        {
            try
            {
                string ip = ObterIpLocal();
                await conexao.ConectarAsync("127.0.0.1", 5000, usuarioAtual.Apelido);
                MessageBox.Show("Conectado ao servidor!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível conectar: " + ex.Message);
            }
        }
        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDestinatario.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um destinatário.");
                    return;
                }
                string destinatario = cmbDestinatario.SelectedItem.ToString();
                string texto = txtMensagem.Text.Trim();
                if (string.IsNullOrWhiteSpace(destinatario))
                {
                    MessageBox.Show("Informe o destinatário.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(texto))
                {
                    MessageBox.Show("Digite uma mensagem.");
                    return;
                }
                usuarioDestinatario.Apelido = destinatario;
                DateTime data = DateTime.Now;
                texto = texto.Replace("\r", " ").Replace("\n", " ");
                string protocolo = $"ENVIAR|{usuarioAtual.Apelido}|{destinatario}|{data:yyyy-MM-dd'T'HH:mm}|{texto}";
                await conexao.EnviarAsync(protocolo);
                servico.Registrar(texto, usuarioAtual, usuarioDestinatario, data);
                AtualizarHistorico();
                txtMensagem.Clear();
            }
            catch (ProtocoloInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Mensagem inválida");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar mensagem: " + ex.Message);
            }
        }
        private void lstHistorico_SelectedIndexChanged(object sender, EventArgs e){}
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarHistorico();
        }
    }
}
