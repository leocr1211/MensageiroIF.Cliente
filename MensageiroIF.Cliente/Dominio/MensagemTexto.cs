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
    public class MensagemTexto : Mensagem
    {
        private string texto;
        private Usuario de;
        private Usuario para;
        private DateTime? data;

        public MensagemTexto(string texto, Usuario de, Usuario para, DateTime data)
        {
            Corpo = texto;
            Remetente = de.Apelido;
            this.para = para;
            Data = data;
        }

        public override void Exibir()
        {
            Console.WriteLine($"\n[TEXTO] - {Remetente} para {para} ({Data:HH:mm}): {Corpo}");
        }
    }
}
