namespace Exkyn.Send.Email
{
    public class SendingEmailConfiguration
    {
        private string GetSmtpHost(string email) => "mail." + email.Split('@')[1].Trim();

        public SendingEmailConfiguration(string email, string password)
        {
            Validate.ValidateEmail(email);
            Validate.ValidateString(password, "Informe o password");

            Email = email;
            Password = password;
            Host = GetSmtpHost(email);
        }

        public SendingEmailConfiguration(string displayName, string email, string password)
        {
            Validate.ValidateEmail(email);
            Validate.ValidateString(password, "Informe o password");
            Validate.ValidateString(displayName, "Informe o display name");

            DisplayName = displayName;
            Email = email;
            Password = password;
            Host = GetSmtpHost(email);
        }

        /// <summary>
        /// Nome do e-mail do remetente
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// E-mail do remetente
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do e-mail do remetente
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Host do e-mail do remetente
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Porta a ser usada para envio do e-mail, caso não seja informada será usada a porta padrão 587
        /// </summary>
        public ushort Port { get; set; } = 587;

        /// <summary>
        /// Habilita ou desabilita o envio do e-mail por uma conexão SSL. Padrão é falso, só deve ser habilitada se o host do servidor possuir SSL para envio de e-mail
        /// </summary>
        public bool UseSsl { get; set; }
    }
}
