namespace BaloonsPopGame
{
    using System;
    using System.Text;

    public static class FieldToString
    {
        public static string Draw(byte[,] fieldClone)
        {
            if (fieldClone == null)
            {
                throw new ArgumentNullException("Field cannot be null!");
            }

            var builder = new StringBuilder();
            int fieldColumns = fieldClone.GetLength(1);

            builder.Append("    ");
            // Print Column numbers
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
                    if (fieldClone[row, col] == 0)
                    {
                        builder.Append("  ");
                        continue;
                    }

                    builder.Append(fieldClone[row, col] + " ");
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

        public static string DrawEmptyFrame(byte[,] fieldClone)
        {
            if (fieldClone == null)
            {
                throw new ArgumentNullException("Field cannot be null!");
            }

            var builder = new StringBuilder();
            int fieldColumns = fieldClone.GetLength(1);

            builder.Append("    ");
            // Print Column numbers
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
                    builder.Append("  ");                     
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
