using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Validations
{
    public class IdValidation
    {
        public static bool IsValid(Guid id)
        {
            return (id != Guid.Empty);
        }
    }
}
