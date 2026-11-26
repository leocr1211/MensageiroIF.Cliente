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

