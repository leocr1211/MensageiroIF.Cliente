using MensageiroIF.Cliente.Apresentação;
using MensageiroIF.Cliente.Contratos;
using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Infraestrutura;
using MensageiroIF.Cliente.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MensageiroIF.Cliente
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try 
            {
                /*IRepositorioDeMensagens repo = new RepositorioEmMemoria();
                ServicoDeHistorico historico = new ServicoDeHistorico(repo);
                Usuario Rafael = new Usuario("rafael");
                Usuario Leonardo = new Usuario("leonardo");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormEnvio(historico, Rafael, Leonardo));
                */
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormCadastro());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
