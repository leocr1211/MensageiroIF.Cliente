using MensageiroIF.Cliente.Apresentação;
using MensageiroIF.Cliente.Contratos;
using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Infraestrutura;
using MensageiroIF.Cliente.Servicos;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MensageiroIF.Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            int porta = 5000;
            TcpListener servidor = new TcpListener(IPAddress.Any, porta);

            servidor.Start();

            Console.WriteLine("================================");
            Console.WriteLine("       MENSAGEIROIF SERVER      ");
            Console.WriteLine("================================");
            Console.WriteLine("Servidor iniciado!");
            Console.WriteLine("Porta: " + porta);
            Console.WriteLine("Aguardando clientes...\n");

            while (true)
            {
                TcpClient cliente = servidor.AcceptTcpClient();
                Console.WriteLine("Novo cliente conectado!");
                Task.Run(() => AtenderCliente(cliente));
            }
        }
        
        static void AtenderCliente(TcpClient cliente)
        {
            try
            {
                NetworkStream stream = cliente.GetStream();
                StreamReader leitor = new StreamReader(stream, Encoding.UTF8);
                string mensagem;
                while ((mensagem = leitor.ReadLine()) != null)
                {
                    Console.WriteLine("Mensagem recebida: " + mensagem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                cliente.Close();
                Console.WriteLine("Cliente desconectado.");
            }
        }
    }
}
