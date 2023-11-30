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

        public string? DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public ushort Port { get; set; } = 587;
        public bool UseSsl { get; set; }
    }
}
