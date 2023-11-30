using System.Net;
using System.Net.Mail;

namespace Exkyn.Send.Email
{
    public class Send
    {
        private MailMessage _mailMessage;
        private SmtpClient _smtpClient;

        private void AddEmail(string email)
        {
            Validate.ValidateEmail(email);

            _mailMessage.To.Add(email);
        }

        private void AddSubject(string subject)
        {
            Validate.ValidateString(subject, "Informe um assunto");

            _mailMessage.Subject = subject;
        }

        private void AddMessage(string message)
        {
            Validate.ValidateString(message, "Informe uma mensagem");

            _mailMessage.Body = message;
        }

        private void SendEmail()
        {
            try
            {
                _smtpClient.Send(_mailMessage);
            }
            catch (Exception e)
            {
                var msgErro = e.Message;

                if (e.InnerException != null && !string.IsNullOrEmpty(e.InnerException.Message))
                    msgErro = e.InnerException.Message;

                throw new Exception(msgErro);
            }
        }

        public Send(SendingEmailConfiguration sendingEmailConfiguration)
        {
            if (sendingEmailConfiguration is null)
                throw new ArgumentNullException("Informe um objeto de configuração para o envio do e-mail.");

            Validate.ValidateString(sendingEmailConfiguration.Host, "Informe um host valido");

            _smtpClient = new SmtpClient(sendingEmailConfiguration.Host);

            _smtpClient.Port = sendingEmailConfiguration.Port;
            _smtpClient.EnableSsl = sendingEmailConfiguration.UseSsl;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential(sendingEmailConfiguration.Email, sendingEmailConfiguration.Password);

            _mailMessage = new MailMessage();

            _mailMessage.From = new MailAddress(sendingEmailConfiguration.Email, sendingEmailConfiguration.DisplayName);
            _mailMessage.IsBodyHtml = true;
        }

        public bool SendEmail(string email, string subject, string message)
        {
            AddEmail(email);

            AddSubject(subject);

            AddMessage(message);

            SendEmail();

            return true;
        }

        public bool SendEmail(List<string> emails, string subject, string message)
        {
            foreach(var email in emails)
            {
                AddEmail(email);
            }

            AddSubject(subject);

            AddMessage(message);

            SendEmail();

            return true;
        }
    }
}
