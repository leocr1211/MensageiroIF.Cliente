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
