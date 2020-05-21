using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Interfaces
{
    public interface IValidationService
    {
        bool IsValid(string input);
    }
}
