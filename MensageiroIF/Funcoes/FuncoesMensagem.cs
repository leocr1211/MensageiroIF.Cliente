using System.Collections.Generic;
using MensageiroIF.Dominio;
using MensageiroIF.Infraestrutura;

namespace MensageiroIF.Funcoes
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
