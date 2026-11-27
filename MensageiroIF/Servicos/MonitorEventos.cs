
using MensageiroIF.Excecoes;
using MensageiroIF.Servidor;
using System;
using System.IO;
using System.Threading;

namespace MensageiroIF.Servicos
{
    public static class MonitorEventos
    {
        private static readonly string caminhoArquivo = @"C:\MensageiroIF\eventos.txt";

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
                    Console.WriteLine("Erro ao processar evento: " + ex.Message);
                }
                Thread.Sleep(500);
            }
        }
    }
}
