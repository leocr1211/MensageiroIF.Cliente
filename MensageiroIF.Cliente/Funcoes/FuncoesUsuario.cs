
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MensageiroIF.Cliente.Funcoes
{
    public static class FuncoesUsuario
    {
        private static readonly string pastaDados =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"MensageiroIF");

        private static readonly string caminhoArquivo = Path.Combine(pastaDados, "usuarios.txt");

        static FuncoesUsuario()
        {
            Directory.CreateDirectory(pastaDados);

            if (!File.Exists(caminhoArquivo))
            {
                File.WriteAllText(caminhoArquivo, "");
            }
        }

        public static void Cadastrar(string nome, string senha)
        {
            nome = nome.Trim();

            if (string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrWhiteSpace(senha))
            {
                throw new Exception("Preencha todos os campos.");
            }

            if (nome.Contains("|") || senha.Contains("|"))
            {
                throw new Exception("Não utilize o caractere |.");
            }

            if (Existe(nome))
            {
                throw new Exception("Usuário já cadastrado.");
            }

            File.AppendAllText(caminhoArquivo, nome + "|" + senha + Environment.NewLine);
        }

        public static bool VerificarLogin(string nome, string senha)
        {
            return File.ReadAllLines(caminhoArquivo).Any(linha =>
            {
                string[] dados = linha.Split('|');
                return dados.Length == 2 && dados[0] == nome && dados[1] == senha;
            });
        }
        public static bool Existe(string nome)
        {
            return ObterUsuarios().Contains(nome);
        }
        public static List<string> ObterUsuarios()
        {
            return File.ReadAllLines(caminhoArquivo).Where(linha => linha.Contains("|")).Select(linha => linha.Split('|')[0]).Distinct().ToList();
        }
    }
}
