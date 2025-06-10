using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.ValueObjects
{
    public sealed class Email
    {
        public string Address { get; }

        private static readonly Regex _regex = new(
            @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Email não pode ser vazio.");

            if (!_regex.IsMatch(address))
                throw new ArgumentException("Email inválido.");

            Address = address.Trim().ToLowerInvariant();
        }

        public override string ToString() => Address;

        public override bool Equals(object? obj) =>
            obj is Email other && Address == other.Address;

        public override int GetHashCode() => Address.GetHashCode();
    }
}

