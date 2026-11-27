using MensageiroIF.Dominio;
using MensageiroIF.Servicos;
using MensageiroIF.Funcoes;
using MensageiroIF.Excecoes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace MensageiroIF.Cliente.Apresentação
{
    public partial class FormEnvio : Form
    {
        private readonly ServicoDeHistorico servico;
        private readonly Usuario usuarioAtual;
        private readonly Timer temporizador = new Timer();
        private int quantidadeMensagens;
        public FormEnvio(ServicoDeHistorico servico, Usuario usuarioAtual, Usuario usuarioDestinatario)
        {
            InitializeComponent();
            this.servico = servico;
            this.usuarioAtual = usuarioAtual;
            CarregarDestinatarios();
            AtualizarHistorico();
            quantidadeMensagens = servico.Resumo();
            temporizador.Interval = 1000;
            temporizador.Tick += Temporizador_Tick;
            temporizador.Start();
            FormClosed += FormEnvio_FormClosed;
        }
        private bool CarregarDestinatarios()
        {
            string selecionado = "Chat Geral";
            if (cmbDestinatario.SelectedItem != null)
            {
                selecionado = cmbDestinatario.SelectedItem.ToString();
            }
            List<string> novosUsuarios = FuncoesUsuario.ObterUsuarios();
            novosUsuarios.RemoveAll(usuario => usuario == usuarioAtual.Apelido);
            novosUsuarios.Insert(0, "Chat Geral");
            List<string> usuariosAtuais = cmbDestinatario.Items.Cast<object>().Select(item => item.ToString()).ToList();
            if (novosUsuarios.SequenceEqual(usuariosAtuais))
            {
                return false;
            }
            cmbDestinatario.BeginUpdate();
            try
            {
                cmbDestinatario.Items.Clear();
                foreach (string usuario in novosUsuarios)
                {
                    cmbDestinatario.Items.Add(usuario);
                }
                int indice = novosUsuarios.IndexOf(selecionado);
                if (indice >= 0)
                {
                    cmbDestinatario.SelectedIndex = indice;
                }
                else if (cmbDestinatario.Items.Count > 0)
                {
                    cmbDestinatario.SelectedIndex = 0;
                }
            }
            finally
            {
                cmbDestinatario.EndUpdate();
            }
            return true;
        }
        public void AtualizarHistorico()
        {
            lstHistorico.Items.Clear();
            if (cmbDestinatario.SelectedItem == null)
                return;
            string selecionado = cmbDestinatario.SelectedItem.ToString();
            List<Mensagem> mensagens = servico.ObterHistorico();
            foreach (Mensagem mensagem in mensagens)
            {
                if (selecionado == "Chat Geral")
                {
                    if (mensagem.Destinatario == "Chat Geral")
                    {
                        lstHistorico.Items.Add(mensagem.ToString());
                    }
                }
                else
                {
                    bool enviada = mensagem.Remetente == usuarioAtual.Apelido && mensagem.Destinatario == selecionado;
                    bool recebida = mensagem.Remetente == selecionado && mensagem.Destinatario == usuarioAtual.Apelido;
                    if (enviada || recebida)
                    {
                        lstHistorico.Items.Add(mensagem.ToString());
                    }
                }
            }
            if (lstHistorico.Items.Count > 0)
            {
                lstHistorico.TopIndex = lstHistorico.Items.Count - 1;
            }
        }
        private void Temporizador_Tick(object sender, EventArgs e)
        {
            try
            {
                bool usuariosAlterados = CarregarDestinatarios();
                int totalMensagens = servico.Resumo();
                if (usuariosAlterados || totalMensagens != quantidadeMensagens)
                {
                    quantidadeMensagens = totalMensagens;
                    AtualizarHistorico();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar histórico: " + ex.Message);
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
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
                Usuario usuarioDestinatario = new Usuario(destinatario);
                DateTime data = DateTime.Now;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    MessageBox.Show("Digite uma mensagem.");
                    return;
                }
                servico.Registrar(texto,usuarioAtual,usuarioDestinatario,data);
                FuncoesEventos.RegistrarEnvio(usuarioAtual.Apelido, destinatario, texto);
                quantidadeMensagens = servico.Resumo();
                AtualizarHistorico();
            }
            catch (ProtocoloInvalidoException ex)
            {
                MessageBox.Show("Erro ao enviar mensagem: " + ex.Message);
            }
        }
        private void FormEnvio_FormClosed(object sender, FormClosedEventArgs e)
        {
            temporizador.Stop();
            FuncoesEventos.RegistrarSaida(usuarioAtual.Apelido);
        }
        private void FormEnvio_Load(object sender, EventArgs e)
        {
            CarregarDestinatarios();
            AtualizarHistorico();
        }
        private void lstHistorico_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarHistorico();
        }
    }
}
