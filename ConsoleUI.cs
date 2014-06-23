using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public class ConsoleUI : IFrontEnd
    {
        public string UserCommandAsScript()
        {
            throw new NotImplementedException();
        }

        public void RenderGameFieldState()
        {
            throw new NotImplementedException();
        }

        public void PublishPrompt()
        {
            throw new NotImplementedException();
        }

        public void RenderUserCoordCommand(string userCommand)
        {
            if (String.IsNullOrWhiteSpace(userCommand))
            {
                throw new ArgumentNullException("Invalid command. Command cannot be empty.");
            }

            int commandRow = 0;
            int commandCol = 0;
            char separator = ' ';

            bool isCommandRowCorrect;
            bool isCommandColCorrect;
            bool isSeparatorCorrect;

            commandRow = int.Parse(userCommand[0].ToString());
            separator = userCommand[1];
            commandCol = int.Parse(userCommand[2].ToString());

            isCommandRowCorrect = commandRow >= 0 && commandRow <= GameConstants.FieldRows;
            isCommandColCorrect = commandCol >= 0 && commandCol <= GameConstants.FieldCols;
            isSeparatorCorrect = separator == ' ' || separator == '.' || separator == ',';

            if ((userCommand.Length == 3) && isCommandRowCorrect && isCommandColCorrect && isSeparatorCorrect)
            {
                if (commandRow >= GameConstants.FieldRows || commandCol >= GameConstants.FieldCols)
                {
                    throw new ArgumentException("This is not valid Input!");
                }

                this.PopEngine(commandRow, commandCol); //change this to send (commandRow, commandCol) via UserCommandAsScript()
            }
            else
            {
                throw new ArgumentException("This is not valid Input!");
            }
        }

        public void Draw()
        {
            Console.Write("    ");
            //Print Column numbers
            for (byte column = 0; column < this.GameFieldProp.GetLongLength(1); column++)
            {
                Console.Write("{0} ", column);
            }

            Console.Write("\n   ");
            //Print dashes between baloons and indexes
            for (byte column = 0; column < this.GameFieldProp.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < this.GameFieldProp.GetLongLength(0); i++)
            {
                //Print number of Row
                Console.Write(i + " | ");
                for (byte j = 0; j < this.GameFieldProp.GetLongLength(1); j++)
                {
                    if (this.GameFieldProp[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(this.GameFieldProp[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");
            for (byte column = 0; column < this.GameFieldProp.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}
