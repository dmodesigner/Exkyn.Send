namespace Exkyn.Send.Email
{
    public class SendingEmailConfiguration
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ushort Port { get; set; } = 587;
        public bool UseSsl { get; set; }
    }
}
