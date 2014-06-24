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

            //throw new NotImplementedException("Replace Console #operations with StringBuilder operations");

            #region operations
            builder.Append("    ");
            //Print Column numbers
            for (byte column = 0; column < fieldClone.GetLength(1); column++)
            {
                ////Console.Write("{0} ", column);
                builder.Append(string.Format("{0} ", column));
            }

            ////Console.Write("\n   ");
            builder.Append("\n   ");

            //Print dashes between baloons and indexes
            ////for (byte column = 0; column < fieldClone.GetLength(1) * 2 + 1; column++)
            ////{
            ////    Console.Write("-");
            ////}
            builder.Append(new string('-', fieldClone.GetLength(1) * 2 + 1));

            ////Console.WriteLine();
            builder.AppendLine();

            for (byte i = 0; i < fieldClone.GetLength(0); i++)
            {
                //Print number of Row
                ////Console.Write(i + " | ");
                builder.Append(i + " | ");
                for (byte j = 0; j < fieldClone.GetLength(1); j++)
                {
                    if (fieldClone[i, j] == 0)
                    {
                        ////Console.Write("  ");
                        builder.Append("  ");
                        continue;
                    }

                    ////Console.Write(fieldClone[i, j] + " ");
                    builder.Append(fieldClone[i, j] + " ");
                }
                ////Console.Write("| ");
                ////Console.WriteLine();
                builder.Append("| ");
                builder.AppendLine();
            }

            ////Console.Write("   ");
            builder.Append("   ");
            ////for (byte column = 0; column < fieldClone.GetLength(1) * 2 + 1; column++)
            ////{
            ////    Console.Write("-");
            ////}
            builder.Append(new string('-', fieldClone.GetLength(1) * 2 + 1));


            ////Console.WriteLine();
            builder.AppendLine();

            #endregion

            var fieldString = builder.ToString();
            return fieldString;
        }
    }
}
