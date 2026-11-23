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

namespace MensageiroIF.Cliente
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
        }
        private async void FormEnvio_Load(object sender, EventArgs e)
        {
            try
            {
                string ip = ObterIpLocal();
                await conexao.ConectarAsync(ip, 5000);
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
                string texto = txtMensagem.Text;
                servico.Registrar(texto, usuarioAtual, usuarioDestinatario, DateTime.Now);
                await conexao.EnviarAsync(texto);
                AtualizarHistorico();
                txtMensagem.Clear();
            }
            catch (ProtocoloInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Mensagem inválida");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao enviar");
            }
        }

        public void AtualizarHistorico()
        {
            lstHistorico.Items.Clear();
            foreach (Mensagem m in servico.ObterHistorico())
                lstHistorico.Items.Add(m.ToString());
        }
        static string ObterIpLocal()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipEncontrado = host.AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            return ipEncontrado != null ? ipEncontrado.ToString() : "127.0.0.1";
        }
    }
}
