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

namespace MensageiroIF.Excecoes
{
    internal class MensagemInvalidaException : Exception
    {
        public MensagemInvalidaException(string mensagem) : base(mensagem) { }
    }
}
