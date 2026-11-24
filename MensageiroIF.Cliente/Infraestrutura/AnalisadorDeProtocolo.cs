using MensageiroIF.Cliente.Contratos;
using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Infraestrutura;
using MensageiroIF.Cliente.Servicos;
using MensageiroIF.Cliente.Excecoes;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;


namespace MensageiroIF.Cliente.Infraestrutura
{
    /// <summary>
    /// Testando strings e comandos para mexer em strings.
    /// </summary>
    public class AnalisadorDeProtocolo
    {
        private const string PADRAO = @"^ENVIAR\|[^|]+\|[^|]+\|\d\d\d\d-\d\d-\d\dT\d\d:\d\d\|.*$";

        public MensagemTexto Analisar(string linha)
        {
            linha = linha.Trim();

            if (!Regex.IsMatch(linha, PADRAO))
            {
                throw new ProtocoloInvalidoException(linha);
            }

            string[] campos = linha.Split('|');

            Usuario Remetente = new Usuario(campos[1].Trim());
            Usuario Destinatario = new Usuario(campos[2].Trim());
            string conteudo = string.Join("|", campos.Skip(4));
            DateTime dataHora = DateTime.Parse(campos[3].Trim());

            MensagemTexto mensagem = new MensagemTexto(conteudo, Remetente, Destinatario, dataHora);

            mensagem.Remetente = Remetente.Apelido;
            mensagem.Destinatario = Destinatario.Apelido;
            mensagem.Corpo = conteudo;
            mensagem.Data = dataHora;

            return mensagem;
        }
    }
}