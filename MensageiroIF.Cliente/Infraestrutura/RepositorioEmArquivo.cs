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
        private const string CAMINHO = "historico.txt";

        public void Guardar(Mensagem m)
        {
            string linha = $"ENVIAR|{m.Remetente}|{m.Destinatario}|{m.Data:yyyy-MM-ddTHH:mm:ss}|{m.Corpo}";

            using (Stream arquivo = File.Open(CAMINHO, FileMode.Append))
            using (StreamWriter escritor = new StreamWriter(arquivo))
            {
                escritor.WriteLine(linha);
            }
        }

        public List<Mensagem> Listar()
        {
            List<Mensagem> mensagens = new List<Mensagem>();

            if (!File.Exists(CAMINHO)) return mensagens;

            AnalisadorDeProtocolo analisador = new AnalisadorDeProtocolo();

            using (Stream arquivo = File.Open(CAMINHO, FileMode.Open))
            using (StreamReader leitor = new StreamReader(arquivo))
            {
                string linha = leitor.ReadLine();

                while (linha != null)
                {
                    if (!string.IsNullOrWhiteSpace(linha))
                    {
                        mensagens.Add(analisador.Analisar(linha));
                    }

                    linha = leitor.ReadLine();
                }
            }
            return mensagens;
        }
    }
}
