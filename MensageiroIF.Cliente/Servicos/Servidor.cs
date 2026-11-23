using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MensageiroIF.Cliente.Servicos
{
    internal class Servidor
    {
        private TcpClient cliente;
        private StreamWriter escritor;

        public async Task ConectarAsync(string ip, int porta)
        {
            cliente = new TcpClient();

            await cliente.ConnectAsync(ip, porta);

            NetworkStream stream = cliente.GetStream();

            escritor = new StreamWriter(stream, Encoding.UTF8);

            escritor.AutoFlush = true;
        }

        public async Task EnviarAsync(string mensagem)
        {
            if (cliente == null || !cliente.Connected)
                throw new InvalidOperationException(
                    "Não existe conexão com o servidor."
                );

            await escritor.WriteLineAsync(mensagem);
        }

        public void Desconectar()
        {
            if (cliente != null)
            {
                cliente.Close();
                cliente = null;
                escritor = null;
            }
        }

    }
}
