using System.Text;
using System.Text.RegularExpressions;
using SimplePasswordGenerator;

namespace Domain.Users
{
    public static class Password
    {
        public static (bool valid, string message) Validate(this string password)
        {
            StringBuilder message = new();
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            bool valid = true;
            if (!hasNumber.IsMatch(password))
            {
                valid = false;
                message.Append("É preciso conter ao menos um número.");
            }
            if (!hasUpperChar.IsMatch(password))
            {
                valid = false;
                message.Append("É preciso conter letras maiúsculas.");
            }
            if (!hasMiniMaxChars.IsMatch(password))
            {
                valid = false;
                message.Append("É preciso conter de 8 a 15 caracteres.");
            }
            if (!hasLowerChar.IsMatch(password))
            {
                valid = false;
                message.Append("É preciso conter letras minúsculas.");
            }
            if (!hasSymbols.IsMatch(password))
            {
                valid = false;
                message.Append("É preciso conter caracteres especiais.");
            }

            return (valid, message.ToString());
        }

        internal static string GenerateRandom()
        {
            var generator = new Generator(letters: "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                                      numerics: "1234567890",
                                      specials: "!@#$%&[]()=?+*-_");

            return generator.Generate(passwordLength: 32,
                                                casing: Casing.Mixed,
                                                useSpecials: true,
                                                useNumerics: true,
                                                filter: "@#?");
        }

    }
}