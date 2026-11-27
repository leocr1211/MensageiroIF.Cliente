using System;
using System.Collections.Generic;
using System.IO;

namespace MensageiroIF.Funcoes
{
    public static class FuncoesEventos
    {
        private static readonly string pastaDados =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"MensageiroIF");

        private static readonly string caminhoArquivo = Path.Combine(pastaDados, "eventos.txt");

        static FuncoesEventos()
        {
            Directory.CreateDirectory(pastaDados);

            if (!File.Exists(caminhoArquivo))File.WriteAllText(caminhoArquivo, "");
        }

        private static string LimparTexto(string texto)
        {
            return (texto ?? "").Replace("|", " ").Replace("\r", " ").Replace("\n", " ");
        }

        private static void Registrar(string linha)
        {
            File.AppendAllText(caminhoArquivo, linha + Environment.NewLine);
        }

        public static void RegistrarEntrada(string usuario)
        {
            Registrar($"ENTROU|{LimparTexto(usuario)}|{DateTime.Now:yyyy-MM-ddTHH:mm:ss}");
        }

        public static void RegistrarSaida(string usuario)
        {
            Registrar($"SAIU|{LimparTexto(usuario)}|{DateTime.Now:yyyy-MM-ddTHH:mm:ss}");
        }

        public static void RegistrarCadastro(string usuario)
        {
            Registrar($"CADASTRO|{LimparTexto(usuario)}|{DateTime.Now:yyyy-MM-ddTHH:mm:ss}");
        }

        public static void RegistrarEnvio(string remetente,string destinatario,string mensagem)
        {
            Registrar($"ENVIOU|{LimparTexto(remetente)}|" +$"{LimparTexto(destinatario)}|" +$"{DateTime.Now:yyyy-MM-ddTHH:mm:ss}|" +$"{LimparTexto(mensagem)}");
        }

        public static List<string> ObterEventos()
        {
            if (!File.Exists(caminhoArquivo))
                return new List<string>();

            return new List<string>(File.ReadAllLines(caminhoArquivo));
        }
    }
}
