using Exkyn.Core.Helpers;
using System.Net;
using System.Net.Mail;

namespace Exkyn.Send.Email
{
    public class Send
    {
        private MailMessage _mailMessage;
        private SmtpClient _smtpClient;

        private string GetSmtpHost(string email) => "smtp" + email.Split('@')[1];

        private void ValidateEmail(string email)
        {
            ValidateString(email, "Informe o e-mail que irá disparar o envio do e-mail.");

            if (!ValidateHelpers.Email(email))
                throw new ArgumentException("Informe um e-mail valido.");
        }

        private void ValidateString(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(string.IsNullOrEmpty(message) ? "A variável não pode ser vazia ou nula" : message);
        }

        private void AddEmail(string email)
        {
            ValidateEmail(email);

            _mailMessage.To.Add(email);
        }

        private void AddSubject(string subject)
        {
            ValidateString(subject, "Informe um assunto");

            _mailMessage.Subject = subject;
        }

        private void AddMessage(string message)
        {
            ValidateString(message, "Informe uma mensagem");

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
                throw new ArgumentException(e.Message);
            }
        }

        public Send(SendingEmailConfiguration sendingEmailConfiguration)
        {
            if (sendingEmailConfiguration is null)
                throw new ArgumentNullException("Informe um objeto de configuração para o envio do e-mail.");

            ValidateEmail(sendingEmailConfiguration.Email);

            ValidateString(sendingEmailConfiguration.Password, "Informe a senha do e-mail que enviara a mensagem.");

            _smtpClient = new SmtpClient(GetSmtpHost(sendingEmailConfiguration.Email));

            _smtpClient.Port = sendingEmailConfiguration.Port;
            _smtpClient.EnableSsl = sendingEmailConfiguration.UseSsl;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential(sendingEmailConfiguration.Email, sendingEmailConfiguration.Password);

            _mailMessage = new MailMessage();

            _mailMessage.From = new MailAddress(sendingEmailConfiguration.Email);
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
