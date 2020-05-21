using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Interfaces
{
    public interface ICommandService
    {
        List<IDroneCommand> GetCommands(string input);
    }
}
