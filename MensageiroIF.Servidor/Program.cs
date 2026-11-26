using MensageiroIF.Cliente.Excecoes;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MensageiroIF.Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            MonitorEventos.Iniciar();
        }
    }
}

