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
    public class RepositorioEmMemoria : IRepositorioDeMensagens
    {
        private List<Mensagem> _mensagens = new List<Mensagem>();
        public void Guardar(Mensagem m)
        {
            _mensagens.Add(m);
        }
        public List<Mensagem> Listar()
        {
            return _mensagens;
        }
    }
}