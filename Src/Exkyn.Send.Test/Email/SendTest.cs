using Exkyn.Send.Email;

namespace Exkyn.Send.Test.Email
{
    [TestClass]
    public class SendTest
    {
        private readonly SendingEmailConfiguration _config;
        private const string _subject = "Mensagem de Teste";
        private const string _message = "Mensagem de teste, disparado pelo sistema de teste.";

        public SendTest()
        {
            _config = new SendingEmailConfiguration("seu_email@email.com.br", "senha_do_email");
        }

        [TestMethod]
        public void EnviaParaUmEmail()
        {
            var sendEmail = new Send.Email.Send(_config);
            sendEmail.SendEmail("email@email.com.br", _subject, _message);
        }

        [TestMethod]
        public void EnviaParaUmaListaDeEmail()
        {
            var sendEmail = new Send.Email.Send(_config);
            
            sendEmail.SendEmail(new List<string>
            {
                "email1@email.com.br",
                "email2@email.com.br"
            }, _subject, _message);
        }
    }
}
