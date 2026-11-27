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
    public abstract class Mensagem
    {
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public DateTime Data { get; set; }
        public string Corpo { get; set; }

        public override int GetHashCode()
        {
            return Remetente.GetHashCode();
        }
        public bool Equals(Mensagem outra)
        {
            return Remetente == outra.Remetente;
        }
        public abstract void Exibir();

        public override string ToString()
        {
            return $"{Remetente} {Destinatario} ({Data:HH:mm}): {Corpo}";
        }
    }
}
