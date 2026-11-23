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

namespace MensageiroIF.Cliente.Dominio
{
    class Conversa
    {
        private Usuario participanteA;
        private Usuario participanteB;
        private List<Mensagem> mensagens = new List<Mensagem>();
        public override bool Equals(object obj)
        {
            if (obj is Usuario generico)
                return this.participanteA == generico;
            return false;
        }
        public override int GetHashCode()
        {
            try
            {
                return participanteB.GetHashCode();
            }
            catch 
            {
                return 0;
            }
        }
        public Conversa(Usuario a, Usuario b)
        {
            participanteA = a;
            participanteB = b;
        }
        public void Enviar(string texto, Usuario de, Usuario para)
        {
            mensagens.Add(new MensagemTexto(texto, de, para, DateTime.Now));
        }
    }
}
