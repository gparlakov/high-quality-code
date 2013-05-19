using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContent
{
    public class FreeContentDemo
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalogue = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            var parsedInput = ParseInput();
            foreach (ICommand item in parsedInput)
            {
                commandExecutor.ExecuteCommand(catalogue, item, output);
            }

            Console.Write(output); 
        }

        private static IList<ICommand> ParseInput()
        {
            IList<ICommand> input = new List<ICommand>();
            bool end = false;

            do
            {
                string line = Console.ReadLine();
                end = (line.Trim() == "End");
                if (!end)
                {
                    input.Add(new Command(line));
                }
            }
            while (!end);

            return input;
        }
    }
}