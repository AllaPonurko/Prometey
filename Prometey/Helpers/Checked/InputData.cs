using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prometey.Helpers.Checked
{
    public static class InputData
    {
        private static string _patternEmail = @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$";

        /// <summary>
        /// Проверка корректности ввода email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>true - если введен верно</returns>
        public static bool CheckEmail(string email)
        {
            if (Regex.IsMatch(email, _patternEmail, RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
