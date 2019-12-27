using System;
using System.Linq;
using System.Text.RegularExpressions;
using Books.BL.Interfaces.Validation;

namespace Books.BL.Validation
{
    public class IsbnValidator : IValidator
    {
        public bool IsValid(string value, out string errorMessage)
        {
            if (string.IsNullOrEmpty(value) || value.Length == 14 && CheckRegex(value) && CheckDigit(value))
            {
                errorMessage = string.Empty;
                return true;
            }

            errorMessage = "Incorrect ISBN number";
            return false;
        }

        private static bool CheckRegex(string value)
        {
            var regex = new Regex(@"^[0-9]{3}-[0-9]{10}$");
            return regex.IsMatch(value);
        }

        private static bool CheckDigit(string value)
        {
            var digits = value.Replace("-", string.Empty).Select(p => Convert.ToInt32(p.ToString())).ToArray();

            var sum = 0;
            for (var i = 0; i < 12; i++)
            {
                var rate = i % 2 == 0 ? 1 : 3;
                sum += digits[i] * rate;
            }

            var result = sum % 10;

            if (result != 0)
            {
                result = 10 - result;
            }

            return digits[12] == result;
        }
    }
}
