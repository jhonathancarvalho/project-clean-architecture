using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTimeOffset BirthDate { get; private set; }
        public bool IsActive { get; private set; }

        private User() { }

        public User(string name, Email email, string passwordHash, DateTimeOffset birthDate)
        {
            SetName(name);
            SetEmail(email);
            SetPasswordHash(passwordHash);
            BirthDate = birthDate;
            IsActive = true;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome não pode ser vazio.");
            Name = name.Trim();
            MarkAsUpdated();
        }

        public void SetEmail(Email email)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            MarkAsUpdated();
        }

        public void SetBirthDate(DateTimeOffset birthDate)
        {
            if (birthDate > DateTimeOffset.UtcNow)
                throw new ArgumentException("A data não pode estar no futuro.", nameof(birthDate));

            BirthDate = birthDate;
            MarkAsUpdated();
        }

        public void SetPasswordHash(string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                throw new ArgumentException("Senha inválida.");
            PasswordHash = hash;
            MarkAsUpdated();
        }

        public void Deactivate()
        {
            IsActive = false;
            MarkAsUpdated();
        }

        public void Activate()
        {
            IsActive = true;
            MarkAsUpdated();
        }
    }
}