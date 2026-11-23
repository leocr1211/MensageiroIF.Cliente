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
        public string linha = $"ENVIAR | ana | bruno | {DateTime.Now} | Bom dia";

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
            string conteudo = campos[4].Trim();
            DateTime dataHora = DateTime.Parse(campos[3].Trim());

            MensagemTexto mens = new MensagemTexto(conteudo, Remetente, Destinatario, dataHora);

            mens.Remetente = Remetente.Apelido;
            mens.Destinatario = Destinatario.Apelido;
            mens.Corpo = conteudo;
            mens.Data = dataHora;

            return mens;
        }
    }
}