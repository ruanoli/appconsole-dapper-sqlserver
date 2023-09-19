using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto03.Validations
{
    public class CpfValidation
    {
        public static bool IsValid(string cpf)
        {
            var regex = new Regex("^[0-9]{11}$");

            return regex.IsMatch(cpf);
        }
    }
}
