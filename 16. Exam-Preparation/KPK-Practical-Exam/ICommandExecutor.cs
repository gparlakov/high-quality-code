using System;
using System.Linq;
using System.Text;

namespace FreeContent
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output);
    }
}