using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public static class FieldToString
    {
        public static string Draw(byte[,] fieldClone)
        {
            var builder = new StringBuilder();

            throw new NotImplementedException("Replace Console #operations with StringBuilder operations");

            #region operations
            Console.Write("    ");
            //Print Column numbers
            for (byte column = 0; column < fieldClone.GetLongLength(1); column++)
            {
                Console.Write("{0} ", column);
            }

            Console.Write("\n   ");
            //Print dashes between baloons and indexes
            for (byte column = 0; column < fieldClone.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < fieldClone.GetLongLength(0); i++)
            {
                //Print number of Row
                Console.Write(i + " | ");
                for (byte j = 0; j < fieldClone.GetLongLength(1); j++)
                {
                    if (fieldClone[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(fieldClone[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");
            for (byte column = 0; column < fieldClone.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
            #endregion

            var fieldString = builder.ToString();
            return fieldString;
        }
    }
}
