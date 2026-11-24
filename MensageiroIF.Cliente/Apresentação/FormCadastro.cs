using MensageiroIF.Cliente.Contratos;
using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Infraestrutura;
using MensageiroIF.Cliente.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MensageiroIF.Cliente.Apresentação
{
    public partial class FormCadastro : Form
    {
        private static Dictionary<string, string> usuarios = new Dictionary<string, string>();
        private ServicoDeHistorico historico;
        public FormCadastro()
        {
            InitializeComponent();
            IRepositorioDeMensagens repo = new RepositorioEmMemoria();
            historico = new ServicoDeHistorico(repo);
        }
        private void FormCadastro_Load(object sender, EventArgs e){}
        private void controleDeLogin1_Load(object sender, EventArgs e){}
    }
}
