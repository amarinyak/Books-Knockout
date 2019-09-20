using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Books.Web.Logic.Validation
{
    public class IsbnValidator
    {
        public static bool IsValid(string value, out string errorMessage)
        {
            if (string.IsNullOrEmpty(value) || value.Length == 17 && ChecRegex(value) && CheckDigit(value))
            {
                errorMessage = string.Empty;
                return true;
            }

            errorMessage = "Неправильный номер ISBN";
            return false;
        }

        private static bool ChecRegex(string value)
        {
            var regex = new Regex(@"^[0-9]{3}-[0-9]{1}-[0-9]{2,7}-[0-9]{1,6}-[0-9]{1}$");
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

            if(result != 0) result = 10 - result;

            return digits[12] == result;
        }
    }
}
