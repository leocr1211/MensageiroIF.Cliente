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
