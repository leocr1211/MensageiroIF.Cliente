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
namespace MensageiroIF.Infraestrutura
{
    class CanalArquivo
    {
        private readonly string caminho;
        public CanalArquivo(string nomeArquivo)
        {
            caminho = nomeArquivo;

            if (!File.Exists(caminho))
            {
                File.WriteAllText(caminho, string.Empty);
            }
        }
        public void Enviar(string linha)
        {
            File.AppendAllText(caminho, linha + Environment.NewLine);
        }
        public List<string> ReceberTodas()
        {
            if (!File.Exists(caminho))
            {
                return new List<string>();
            }
            return new List<string>(File.ReadAllLines(caminho));
        }
    }
}

