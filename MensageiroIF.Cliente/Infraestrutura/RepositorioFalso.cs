using MensageiroIF.Cliente.Contratos;
using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Infraestrutura;
using MensageiroIF.Cliente.Servicos;
using MensageiroIF.Cliente.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensageiroIF.Cliente.Infraestrutura
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
