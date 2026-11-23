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

namespace MensageiroIF.Cliente.Servicos
{
    class Pedido // tem um serviço de email
    {
        private ServicoDeEmail email;
        public Pedido(ServicoDeEmail email)
        {
            this.email = email;
        }
        public void Confirmar()
        {
            email.EnviarConfirmacao(this);
        }
    }
    class ServicoDeEmail // tem um usuario que é dono
    {
        private Usuario dono;
        private string email;

        public string EnviarConfirmacao(Pedido pedido) 
        {
            return "Confirmação enviada!";
        }

        public ServicoDeEmail(string email, Usuario dono)
        {
            this.email = email;
            this.dono = dono;
        }
    }
}
