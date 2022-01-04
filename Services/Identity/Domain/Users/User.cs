using System;

namespace Domain.Users
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public User(string name, string email)
        {
            Id = new Guid();
            ChangeName(name);
            ChangeEmail(email);
            var randomPassword = Users.Password.GenerateRandom();
            ChangePassword(randomPassword, randomPassword);
            Activate();
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new UserException("O nome não pode ser vazio");
            Name = name;
        }
        public void ChangeEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new UserException("O email não pode ser vazio");
            Email = email;
        }
        public void ChangePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                throw new UserException("A senha não pode ser vazia.");

            if (password != confirmPassword)
                throw new UserException("A confirmação de senha precisa ser identica.");

            var validate = password.Validate();
            if (!validate.valid)
                throw new UserException(validate.message);
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
        public void Activate() => Active = true;
        public void Disable() => Active = false;

    }
}