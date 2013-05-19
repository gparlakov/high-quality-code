using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContent
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalogueContent, ICommand command, StringBuilder sb)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    {
                        catalogueContent.Add(new Content(ContentType.Book, command.Parameters));
                        sb.AppendLine("Book Added");
                        break;
                    }
                case CommandType.AddMovie:
                    {
                        catalogueContent.Add(new Content(ContentType.Movie, command.Parameters));

                        sb.AppendLine("Movie added");
                        break;
                    }
                case CommandType.AddSong:
                    {
                        catalogueContent.Add(new Content(ContentType.Music, command.Parameters));

                        sb.AppendLine("Song added");
                        break;
                    }
                case CommandType.AddApplication:
                    {
                        catalogueContent.Add(new Content(ContentType.Application, command.Parameters));

                        sb.AppendLine("Application added");
                        break;
                    }
                   
                case CommandType.Update:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            throw new FormatException("Invalid params!");
                        }
                        var numberItemsUpdated = catalogueContent.UpdateContent(command.Parameters[0], command.Parameters[1]);
                        sb.AppendLine(String.Format("{0} items updated", numberItemsUpdated));

                        break;
                    }
                case CommandType.Find:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            Console.WriteLine("Invalid params!");
                            throw new Exception("Invalid number of parameters!");
                        }

                        int numberOfElementsToList = int.Parse(command.Parameters[1]);

                        IEnumerable<IContent> foundContent =
                            catalogueContent.GetListContent(command.Parameters[0], numberOfElementsToList);

                        if (foundContent.Count() == 0)
                        {
                            sb.AppendLine("No items found");
                        }
                        else
                        {
                            foreach (IContent content in foundContent)
                            {
                                sb.AppendLine(content.TextRepresentation);
                            }
                        }

                        break;
                    }
                default:
                    {
                        throw new InvalidCastException("Unknown command!");
                    }
            }
        }
    }
}