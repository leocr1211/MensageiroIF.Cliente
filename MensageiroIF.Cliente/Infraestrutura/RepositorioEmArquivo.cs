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

namespace MensageiroIF.Cliente.Infraestrutura
{
    class RepositorioEmArquivo
    {
        public static List<Mensagem> Historico()
        {
            Usuario ana = new Usuario("ana");
            Usuario bruno = new Usuario("bruno");
            Usuario carla = new Usuario("carla");
            return new List<Mensagem>
            {
                new MensagemTexto("bom dia",                               ana,   bruno, new DateTime(2026, 10, 20, 14, 32, 0)),
                new MensagemTexto("bom dia, tudo certo por ai?",           bruno, ana,   new DateTime(2026, 10, 20, 14, 35, 0)),
                new MensagemTexto("a prova e quinta ou sexta?",            ana,   carla, new DateTime(2026, 10, 20, 15, 2, 0)),
                new MensagemTexto("quinta",                                carla, ana,   new DateTime(2026, 10, 20, 15, 10, 0)),
                new MensagemTexto("alguem terminou o exercicio da prova?", bruno, carla, new DateTime(2026, 10, 21, 8, 15, 0)),
                new MensagemTexto("eu terminei ontem a noite",             ana,   bruno, new DateTime(2026, 10, 21, 8, 20, 0)),
                new MensagemTexto("vou fazer hoje",                        carla, bruno, new DateTime(2026, 10, 21, 9, 0, 0)),
                new MensagemTexto("obrigado",                              bruno, ana,   new DateTime(2026, 10, 21, 9, 30, 0))
            };
            
        }
        public static List<Mensagem> Listar()
        {
            List<Mensagem> historico = Historico();

            Func<Mensagem, bool> ehDaAna = m => m.Remetente == "ana";
            foreach (Mensagem m in historico)
            {
                if (ehDaAna(m))
                    Console.WriteLine(m.Remetente + " : " + m.Data + " - " + m.Corpo);
            }
            var daAna = historico.Where(m => m.Remetente == "ana");
            var NumeroDeMensagensdana = historico.Where(m => m.Remetente == "ana").Count();
            var NumeroDeMensagensdobruno = historico.Where(m => m.Remetente == "bruno").Count();
            var NumeroDeMensagensdocarla = historico.Where(m => m.Remetente == "carla").Count();
            var longas = historico.Where(m => m.Corpo.Length > 20);

            Console.WriteLine("Da ana: " + daAna.Count());
            Console.WriteLine("Numero de mensagens da ana: " + NumeroDeMensagensdana);
            Console.WriteLine("Numero de mensagens do bruno: " + NumeroDeMensagensdobruno);
            Console.WriteLine("Numero de mensagens da carla: " + NumeroDeMensagensdocarla);
            Console.WriteLine("Mensagens longas com mais de 20 caracteres: " + longas.Count());
            return historico;
        }
    }
}
