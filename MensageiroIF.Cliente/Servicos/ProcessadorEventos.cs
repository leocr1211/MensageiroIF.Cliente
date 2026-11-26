using System;
using System.IO;
using System.Threading;
using MensageiroIF.Cliente.Excecoes;

namespace MensageiroIF.Servidor
{
    public static class ProcessadorEventos
    {
        public static void Processar(string linha)
        {
            string[] dados = linha.Split('|');
            if (dados.Length < 3)
                return;
            switch (dados[0])
            {
                case "CADASTRO":
                    Console.WriteLine(dados[1] + " se cadastrou no sistema.");
                    break;
                case "ENTROU":
                    Console.WriteLine(dados[1] + " entrou no sistema.");
                    break;
                case "SAIU":
                    Console.WriteLine(dados[1] + " saiu do sistema.");
                    break;
                case "ENVIOU":
                    if (dados.Length >= 5)
                    {
                        Console.WriteLine(dados[1] + " enviou uma mensagem para " + dados[2] + " No momento : " + dados[3]);
                    }
                    break;
                default:
                    Console.WriteLine("Evento desconhecido: " + linha);
                    break;
            }
        }
    }

    public static class MonitorEventos
    {
        private static readonly string caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"MensageiroIF","eventos.txt");
        public static void Iniciar()
        {
            Console.WriteLine("Servidor iniciado!");
            Console.WriteLine("Monitorando eventos...\n");

            int ultimaLinha = 0;

            while (true)
            {
                try
                {
                    if (File.Exists(caminhoArquivo))
                    {
                        string[] linhas =
                            File.ReadAllLines(caminhoArquivo);

                        while (ultimaLinha < linhas.Length)
                        {
                            ProcessadorEventos.Processar(linhas[ultimaLinha]);
                            ultimaLinha++;
                        }
                    }
                }
                catch (ProtocoloInvalidoException ex)
                {
                    Console.WriteLine("Erro ao acessar eventos: " + ex.Message);
                }
                Thread.Sleep(500);
            }
        }
    }

}
