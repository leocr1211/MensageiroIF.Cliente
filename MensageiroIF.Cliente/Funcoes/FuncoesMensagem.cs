using System.Collections.Generic;
using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Infraestrutura;

namespace MensageiroIF.Cliente.Funcoes
{
    public class FuncoesMensagem
    {
        private static readonly RepositorioEmArquivo repositorio = new RepositorioEmArquivo();

        public static void Enviar(Mensagem mensagem)
        {
            repositorio.Guardar(mensagem);
        }

        public static List<Mensagem> ObterMensagens()
        {
            return repositorio.Listar();
        }
    }
}
