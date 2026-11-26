using MensageiroIF.Cliente.Contratos;
using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Excecoes;
using MensageiroIF.Cliente.Infraestrutura;
using MensageiroIF.Cliente.Servicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MensageiroIF.Cliente.Infraestrutura
{
    public class RepositorioEmArquivo : IRepositorioDeMensagens
    {
        private readonly CanalArquivo canal;
        public RepositorioEmArquivo()
        {
            canal = new CanalArquivo("historico.txt");
        }
        public void Guardar(Mensagem mensagem)
        {
            string linha = $"ENVIAR|{mensagem.Remetente}|{mensagem.Destinatario}|{mensagem.Data:yyyy-MM-ddTHH:mm:ss}|{mensagem.Corpo}";
            canal.Enviar(linha);
        }
        public List<Mensagem> Listar()
        {
            List<Mensagem> mensagens = new List<Mensagem>();
            AnalisadorDeProtocolo analisador = new AnalisadorDeProtocolo();
            foreach (string linha in canal.ReceberTodas())
            {
                if (string.IsNullOrWhiteSpace(linha)) continue;
                try
                {
                    mensagens.Add(analisador.Analisar(linha));
                }
                catch(ProtocoloInvalidoException ex)
                {
                    MessageBox.Show("Erro ao analisar linha: " + ex.Message);
                }
            }
            return mensagens;
        }
    }
}
