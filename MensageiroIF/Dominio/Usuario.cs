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

namespace MensageiroIF.Dominio
{
    public class Usuario
    {
        public string Apelido { get; set; } = string.Empty;
        private List<Usuario> contatos = new List<Usuario>();
        public void AdicionarContato(Usuario outro)
        {
            contatos.Add(outro);
        }
        public Usuario(string apelido)
        {
            Apelido = apelido;
        }
    }
}
