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
