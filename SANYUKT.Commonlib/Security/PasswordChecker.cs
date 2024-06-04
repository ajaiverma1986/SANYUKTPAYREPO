using System;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace SANYUKT.Commonlib.Security
{
    public enum PasswordStrength
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }

    public static class PasswordChecker
    {
        public static PasswordStrength GetPasswordStrength(string password, PasswordOptions opts)
        {
            int score = 0;

            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(password.Trim()))
                return PasswordStrength.Blank;

            if (!HasMinimumLength(password, opts.RequiredLength - 2))
                return PasswordStrength.VeryWeak;

            if (HasMinimumLength(password, opts.RequiredLength))
                score++;

            if (opts.RequireLowercase)
            {
                if (HasUpperCaseLetter(password))
                    score++;
            }

            if (opts.RequireLowercase)
            {
                if (HasLowerCaseLetter(password))
                    score++;
            }

            if (opts.RequireDigit)
            {
                if (HasDigit(password))
                    score++;
            }

            if (opts.RequireNonAlphanumeric)
            {
                if (HasSpecialChar(password))
                    score++;
            }
            return (PasswordStrength)score;
        }

        public static bool IsStrongPassword(string password)
        {
            return HasMinimumLength(password, 8)
                && HasUpperCaseLetter(password)
                && HasLowerCaseLetter(password)
                && (HasDigit(password) || HasSpecialChar(password));
        }

        public static bool IsValidPassword(string password, PasswordOptions opts)
        {
            return IsValidPassword(
                password,
                opts.RequiredLength,
                opts.RequiredUniqueChars,
                opts.RequireNonAlphanumeric,
                opts.RequireLowercase,
                opts.RequireUppercase,
                opts.RequireDigit);
        }

        public static bool IsValidPassword(
            string password,
            int requiredLength,
            int requiredUniqueChars,
            bool requireNonAlphanumeric,
            bool requireLowercase,
            bool requireUppercase,
            bool requireDigit)
        {
            if (!HasMinimumLength(password, requiredLength)) return false;
            if (!HasMinimumUniqueChars(password, requiredUniqueChars)) return false;
            if (requireNonAlphanumeric && !HasSpecialChar(password)) return false;
            if (requireLowercase && !HasLowerCaseLetter(password)) return false;
            if (requireUppercase && !HasUpperCaseLetter(password)) return false;
            if (requireDigit && !HasDigit(password)) return false;
            return true;
        }

        public static bool HasMinimumLength(string password, int minLength)
        {
            return password.Length >= minLength;
        }

        public static bool HasMinimumUniqueChars(string password, int minUniqueChars)
        {
            return password.Distinct().Count() >= minUniqueChars;
        }

        public static bool HasDigit(string password)
        {
            return password.Any(c => char.IsDigit(c));
        }

        public static bool HasSpecialChar(string password)
        {
            return password.IndexOfAny("!@#$%^&*?_~-£().,".ToCharArray()) != -1;
        }

        public static bool HasUpperCaseLetter(string password)
        {
            return password.Any(c => char.IsUpper(c));
        }

        public static bool HasLowerCaseLetter(string password)
        {
            return password.Any(c => char.IsLower(c));
        }
    }
    
}
