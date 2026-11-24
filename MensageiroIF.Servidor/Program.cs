
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MensageiroIF.Servidor
{
    class Program
    {
        static ConcurrentDictionary<string, StreamWriter> clientes = new ConcurrentDictionary<string, StreamWriter>();

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

        static async Task AtenderCliente(TcpClient cliente)
        {
            string apelido = null;

            try
            {
                NetworkStream stream = cliente.GetStream();

                StreamReader leitor = new StreamReader(stream, Encoding.UTF8);

                StreamWriter escritor = new StreamWriter(stream, Encoding.UTF8);

                escritor.AutoFlush = true;

                string login = await leitor.ReadLineAsync();

                if (login == null || !login.StartsWith("LOGIN|"))
                    return;

                apelido = login.Substring(6).Trim();

                if (apelido == "")
                    return;

                clientes[apelido] = escritor;

                Console.WriteLine(apelido + " conectado!");
                string mensagem;
                while ((mensagem = await leitor.ReadLineAsync()) != null)
                {
                    Console.WriteLine("Mensagem recebida: " + mensagem);
                    string[] campos = mensagem.Split('|');
                    if (campos.Length < 5 || campos[0] != "ENVIAR")
                        continue;

                    string destinatario = campos[2].Trim();

                    if (destinatario == "Chat Geral")
                    {
                        foreach (var usuario in clientes)
                        {
                            if (usuario.Key != apelido)
                            {
                                await usuario.Value.WriteLineAsync(mensagem);
                            }
                        }
                        Console.WriteLine("Mensagem enviada para o Chat Geral!");
                    }
                    else if (clientes.TryGetValue(destinatario, out StreamWriter destino))
                    {
                        await destino.WriteLineAsync(mensagem);
                        Console.WriteLine("Mensagem encaminhada para " + destinatario);
                    }
                    else
                    {
                        Console.WriteLine("Destinatario nao conectado: " + destinatario);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                if (apelido != null)
                {
                    clientes.TryRemove(apelido, out StreamWriter removido);
                    Console.WriteLine(apelido + " desconectado.");
                }
                cliente.Close();
            }
        }
    }
}
