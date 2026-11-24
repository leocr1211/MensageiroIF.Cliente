
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
        private StreamReader leitor;
        public event Action<string> MensagemRecebida;
        public async Task ConectarAsync(string ip, int porta, string apelido)
        {
            cliente = new TcpClient();
            await cliente.ConnectAsync(ip, porta);
            NetworkStream stream = cliente.GetStream();
            escritor = new StreamWriter(stream, Encoding.UTF8);
            leitor = new StreamReader(stream, Encoding.UTF8);
            escritor.AutoFlush = true;
            await escritor.WriteLineAsync("LOGIN|" + apelido);
            _ = ReceberMensagensAsync();
        }
        public async Task EnviarAsync(string mensagem)
        {
            if (cliente == null || !cliente.Connected)
                throw new InvalidOperationException("Não existe conexão com o servidor.");
            await escritor.WriteLineAsync(mensagem);
        }
        private async Task ReceberMensagensAsync()
        {
            try
            {
                string mensagem;
                while ((mensagem = await leitor.ReadLineAsync()) != null)
                {
                    MensagemRecebida?.Invoke(mensagem);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        public void Desconectar()
        {
            if (cliente != null)
            {
                cliente.Close();
                cliente = null;
                escritor = null;
                leitor = null;
            }
        }
    }
}
