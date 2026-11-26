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
        public MensagemTexto(string texto, Usuario de, Usuario para, DateTime data)
        {
            Corpo = texto;
            Remetente = de.Apelido;
            Destinatario = para.Apelido;
            Data = data;
        }

        public override void Exibir()
        {
            Console.WriteLine($"\n[TEXTO] - {Remetente} para {Destinatario} ({Data:HH:mm}): {Corpo}");
        }
    }
}
