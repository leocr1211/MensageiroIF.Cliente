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