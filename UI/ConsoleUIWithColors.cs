namespace BaloonsPopGame.UI
{
    using System;

    using BaloonsPopGame.GameField;

    public class ConsoleUIWithColors : ConsoleUI
    {
        private const int InitialTopCursorPosition = 2;
        private const int InitialLeftCursorPosition = 4;
        private bool isBackgroundChanged = false;

        public override void RenderGameFieldState(byte[,] fieldClone)
        {
            // the console is cleared only once - at first print of the field
            if (!this.isBackgroundChanged)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                this.isBackgroundChanged = true;
            }

            // sets the buffer size to maximum possible, because when printing many lines the cursor gets out of the console and throws an exception
            Console.BufferHeight = short.MaxValue - 1;
            Console.ForegroundColor = ConsoleColor.Black;

            var fieldAsString = FieldToString.DrawEmptyFrame(fieldClone);
            var topCursorPosition = Console.CursorTop;
            Console.WriteLine(fieldAsString);
            var defaultConsoleForegroundColor = Console.ForegroundColor;

            for (int row = 0; row < fieldClone.GetLength(0); row++)
            {
                Console.SetCursorPosition(InitialLeftCursorPosition, topCursorPosition + InitialTopCursorPosition + row);

                for (int col = 0; col < fieldClone.GetLength(1); col++)
                {
                    if (fieldClone[row, col] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    BaloonColor color = (BaloonColor)fieldClone[row, col];
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.ToString());
                    Console.Write("♥ ");
                }
            }

            Console.SetCursorPosition(0, topCursorPosition + InitialTopCursorPosition + 2 + fieldClone.GetLength(0));
            Console.ForegroundColor = defaultConsoleForegroundColor;
        }
    }
}
