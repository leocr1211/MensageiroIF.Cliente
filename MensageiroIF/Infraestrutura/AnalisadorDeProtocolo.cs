using MensageiroIF.Contratos;
using MensageiroIF.Dominio;
using MensageiroIF.Infraestrutura;
using MensageiroIF.Servicos;
using MensageiroIF.Excecoes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;

namespace MensageiroIF.Infraestrutura
{
    public class AnalisadorDeProtocolo
    {
        public MensagemTexto Analisar(string linha)
        {
            if (string.IsNullOrWhiteSpace(linha))
            {
                throw new ProtocoloInvalidoException("O protocolo não pode estar vazio.");
            }

            string[] campos = linha.Split('|');

            if (campos.Length < 5)
            {
                throw new ProtocoloInvalidoException("O protocolo possui campos insuficientes.");
            }

            string comando = campos[0].Trim();

            if (comando != "ENVIAR")
            {
                throw new ProtocoloInvalidoException("Comando inválido. Esperado: ENVIAR.");
            }

            string Remetente = campos[1].Trim();
            if (string.IsNullOrWhiteSpace(Remetente))
            {
                throw new ProtocoloInvalidoException("O remetente não pode estar vazio.");
            }
            string Destinatario = campos[2].Trim();
            
            string dataTexto = campos[3].Trim();
            DateTime dataHora;
            bool dataValida = DateTime.TryParse(dataTexto, out dataHora);
            if (!dataValida)
            {
                throw new ProtocoloInvalidoException("A data informada é inválida.");
            }
            
            string conteudo = string.Join("|", campos.Skip(4));
            if (string.IsNullOrWhiteSpace(conteudo))
            {
                throw new ProtocoloInvalidoException("O conteúdo da mensagem não pode estar vazio.");
            }
            Usuario remetente = new Usuario(Remetente);
            Usuario destinatario = new Usuario(Destinatario);
            MensagemTexto mensagem = new MensagemTexto(conteudo, remetente, destinatario, dataHora);

            mensagem.Remetente = remetente.Apelido;
            mensagem.Destinatario = destinatario.Apelido;
            mensagem.Corpo = conteudo;
            mensagem.Data = dataHora;

            return mensagem;
        }
    }
}