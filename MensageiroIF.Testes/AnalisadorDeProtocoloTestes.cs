using MensageiroIF.Cliente.Dominio;
using MensageiroIF.Cliente.Infraestrutura;

namespace MensageiroIF.Testes
{
    [TestClass]
    public sealed class AnalisadorDeProtocoloTestes
    {
        [TestMethod]
        public void Analisar_LinhaValida_DevolveRemetenteCorreto()
        {
            AnalisadorDeProtocolo analisador = new AnalisadorDeProtocolo();
            string linha = "ENVIAR|ana|bruno|2026-10-20T14:32|bom dia";
            Mensagem mensagem = analisador.Analisar(linha);
            Assert.AreEqual("ana", mensagem.Remetente);
        }
    }
}
