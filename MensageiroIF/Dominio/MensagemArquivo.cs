using MensageiroIF.Contratos;
using MensageiroIF.Dominio;
using MensageiroIF.Excecoes;
using MensageiroIF.Infraestrutura;
using MensageiroIF.Servicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MensageiroIF.Dominio
{
    internal class MensagemArquivo
    {
        private static readonly string caminhoArquivo = "C:\\MensageiroIF";
        public static void GaranteDiretorio()
        {
            string pasta = "C:\\MensageiroIF";
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
        }
        public static void Ler()
        {
            GaranteDiretorio();
            string caminho = "C:\\MensageiroIF\\entrada.txt";

            if (!File.Exists(caminho))
            {
                File.Create(caminho).Close(); 
                System.Diagnostics.Debug.WriteLine("O arquivo 'entrada.txt' não existia e foi criado vazio.");
                return;
            }

            using (Stream arquivo = File.Open(caminho, FileMode.Open))
            using (StreamReader leitor = new StreamReader(arquivo))
            {
                string linha = leitor.ReadLine();
                while (linha != null)
                {
                    System.Diagnostics.Debug.WriteLine(linha);
                    linha = leitor.ReadLine();
                }
            }
        }
        public static void Gravar()
        {
            GaranteDiretorio();
            string caminho = "C:\\MensageiroIF\\historico.txt";

            using (Stream saida = File.Open(caminho, FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(saida))
            {
                escritor.WriteLine("minha mensagem");
            }
        }
       public static void Historico()
       {
            try
            {
                GaranteDiretorio();
                string caminho = "C:\\MensageiroIF\\arquivo.txt";
                if (!File.Exists(caminho))
                {
                    File.Create(caminho).Close();
                }
                
                using (Stream arquivo = File.Open(caminho, FileMode.Open, FileAccess.Read))
                using (StreamReader leitor = new StreamReader(arquivo))
                {
                    string linha = leitor.ReadLine();
                    while (linha != null)
                    {
                        linha = leitor.ReadLine();
                    }
                }
            }
            catch (ProtocoloInvalidoException ex)
            {
                throw new ProtocoloInvalidoException($"Ocorreu um erro inesperado de {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
