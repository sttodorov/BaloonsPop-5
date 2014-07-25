namespace BaloonsPopGame.GameField
{
    using System;
    using System.Text;

    public static class FieldToString
    {
        public static string Draw(byte[,] fieldClone)
        {
            return DrawField(fieldClone, false);
        }

        public static string DrawEmptyFrame(byte[,] fieldClone)
        {
            return DrawField(fieldClone, true);
        }

        private static string DrawField(byte[,] fieldClone, bool isEmptyField)
        {
            if (fieldClone == null)
            {
                throw new ArgumentNullException("Field cannot be null!");
            }

            var builder = new StringBuilder();
            int fieldColumns = fieldClone.GetLength(1);

            // Print Column numbers
            builder.Append("    ");
            for (byte column = 0; column < fieldColumns; column++)
            {
                builder.Append(string.Format("{0} ", column));
            }

            builder.AppendLine();
            builder.Append("   ");

            // Print dashes between baloons and indexes
            builder.Append(new string('-', fieldColumns * 2 + 1));
            builder.AppendLine();

            for (byte row = 0; row < fieldClone.GetLength(0); row++)
            {
                // Print number of Row
                builder.Append(row + " | ");
                for (byte col = 0; col < fieldColumns; col++)
                {
                    if (isEmptyField || fieldClone[row, col] == 0)
                    {
                        builder.Append("  ");
                    }
                    else
                    {
                        builder.Append(fieldClone[row, col] + " ");
                    }
                }

                builder.Append("|");
                builder.AppendLine();
            }

            builder.Append("   ");
            builder.Append(new string('-', fieldColumns * 2 + 1));
            builder.AppendLine();

            var fieldString = builder.ToString();
            return fieldString;
        }
    }
}
