using MensageiroIF.Contratos;
using MensageiroIF.Dominio;
using MensageiroIF.Infraestrutura;
using MensageiroIF.Servicos;
using MensageiroIF.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensageiroIF.Infraestrutura
{
    public class RepositorioFalso : IRepositorioDeMensagens
    {
        public int ContadorChamadas { get; private set; } = 0;

        public void Guardar(Mensagem m)
        {
            ContadorChamadas++;
        }
        public List<Mensagem> Listar()
        {
            Usuario usuario1 = new Usuario("Teste1");
            Usuario usuario2 = new Usuario("Teste2");
            List<Mensagem> fixas = new List<Mensagem>
            {
                new MensagemTexto("Mensagem fixa 1", usuario1, usuario2, DateTime.Now),
                new MensagemTexto("Mensagem fixa 2", usuario2, usuario1, DateTime.Now)
            };
            return fixas;
        }
    }
}
