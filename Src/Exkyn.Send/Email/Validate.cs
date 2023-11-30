using Exkyn.Core.Helpers;

namespace Exkyn.Send.Email
{
    public static class Validate
    {
        public static void ValidateEmail(string email)
        {
            ValidateString(email, "Informe o e-mail que irá disparar o envio do e-mail.");

            if (!ValidateHelpers.Email(email))
                throw new ArgumentException("Informe um e-mail valido.");
        }

        public static void ValidateString(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(string.IsNullOrEmpty(message) ? "A variável não pode ser vazia ou nula" : message);
        }
    }
}
