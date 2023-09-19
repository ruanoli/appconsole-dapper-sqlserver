using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto03.Validations
{
    public class NomeValidation
    {
        public static bool IsValid(string nome)
        {
            var regex = new Regex("^[A-Za-zà-üÀ-Ü\\s]{1,100}$");

            return regex.IsMatch(nome);
        }
    }
}