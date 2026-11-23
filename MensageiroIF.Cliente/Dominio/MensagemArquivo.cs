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

namespace MensageiroIF.Cliente.Dominio
{
    internal class MensagemArquivo
    {
        public static void GaranteDiretorio()
        {
            string pasta = "C:\\MensageiroIF.Cliente";
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
        }
        public static void Ler()
        {
            GaranteDiretorio();
            string caminho = @"C:\MensageiroIF.Cliente\entrada.txt";

            if (!File.Exists(caminho))
            {
                File.Create(caminho).Close();
                MessageBox.Show("O arquivo 'entrada.txt' não existia e foi criado vazio.");
                return;
            }

            using (Stream arquivo = File.Open(caminho, FileMode.Open))
            using (StreamReader leitor = new StreamReader(arquivo))
            {
                string linha = leitor.ReadLine();
                while (linha != null)
                {
                    MessageBox.Show(linha);
                    linha = leitor.ReadLine();
                }
            }
        }
        public static void Gravar()
        {
            GaranteDiretorio();
            string caminho = "C:\\MensageiroIF.Cliente\\historico.txt";

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
                string caminho = "C:\\MensageiroIF.Cliente\\arquivo.txt";
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
