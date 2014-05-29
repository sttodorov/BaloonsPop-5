using System;
using System.Collections.Generic;

namespace BaloonsPopGame
{
    public class BaloonsPop
    {
        static byte[,] GenetateField(byte rows, byte columns)
        {
            byte[,] generatedField = new byte[rows, columns];
            Random randomGeneretor = new Random();
            byte currentRandomByteNumber;
            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    currentRandomByteNumber = (byte)randomGeneretor.Next(1, 5);
                    generatedField[row, column] = currentRandomByteNumber;
                }
            }
            return generatedField;
        }

        static void CheckForBaloonsLeft(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn - 1;
            try
            {
                if (gameField[searchingInRow, searchinInCol] == searchedItem)
                {
                    gameField[searchingInRow, searchinInCol] = 0;
                    CheckForBaloonsLeft(gameField, searchingInRow, searchinInCol, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }

        }

        static void CheckForBaloonsRight(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn + 1;
            try
            {
                if (gameField[searchingInRow, searchinInCol] == searchedItem)
                {
                    gameField[searchingInRow, searchinInCol] = 0;
                    CheckForBaloonsRight(gameField, searchingInRow, searchinInCol, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }

        }
        static void CheckForBaloonsUp(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
        {
            int searchingInRow = chosenRow - 1;
            int searchinInCol = chosenColumn;
            try
            {
                if (gameField[searchingInRow, searchinInCol] == searchedItem)
                {
                    gameField[searchingInRow, searchinInCol] = 0;
                    CheckForBaloonsUp(gameField, searchingInRow, searchinInCol, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }

        }

        static void CheckForBaloonsDown(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
        {
            int searchingInRow = chosenRow + 1;
            int searchinInCol = chosenColumn;
            try
            {
                if (gameField[searchingInRow, searchinInCol] == searchedItem)
                {
                    gameField[searchingInRow, searchinInCol] = 0;
                    CheckForBaloonsDown(gameField, searchingInRow, searchinInCol, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }

        }
        static bool PopBaloon(byte[,] matrixToModify, int rowAtm, int columnAtm)
        {
            if (matrixToModify[rowAtm, columnAtm] == 0)
            {
                return true;
            }
            byte searchedTarget = matrixToModify[rowAtm, columnAtm];
            matrixToModify[rowAtm, columnAtm] = 0;

            CheckForBaloonsLeft(matrixToModify, rowAtm, columnAtm, searchedTarget);
            CheckForBaloonsRight(matrixToModify, rowAtm, columnAtm, searchedTarget);
            CheckForBaloonsUp(matrixToModify, rowAtm, columnAtm, searchedTarget);
            CheckForBaloonsDown(matrixToModify, rowAtm, columnAtm, searchedTarget);
            return false;
        }

        static bool isGameOver(byte[,] matrix)
        {
            bool isWinner = true;
            Stack<byte> stek = new Stack<byte>();
            int columnLenght = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isWinner = false;
                        stek.Push(matrix[i, j]);
                    }
                }
                for (int k = columnLenght - 1; (k >= 0); k--)
                {
                    try
                    {
                        matrix[k, j] = stek.Pop();
                    }
                    catch (Exception)
                    {
                        matrix[k, j] = 0;
                    }
                }
            }
            return isWinner;
        }

        //TODO: Use HashSet/Dictionary - no need of class RankList
        static List<RankList> SortChart(string[,] tableToSort)
        {

            List<RankList> klasirane = new List<RankList>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                klasirane.Add(new RankList(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));

            }
            klasirane.Sort();
            return klasirane;
            


        }
        static void PrintChart(string[,] tableToSort)
        {
            List<RankList> sortedChart = SortChart(tableToSort);
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < sortedChart.Count; ++i)
            {
                RankList slot = sortedChart[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");
        }

        static void DrawGameField(byte[,] gameField)
        {
            Console.Write("    ");
            //Print Column numbers
            for (byte column = 0; column < gameField.GetLongLength(1); column++)
            {
                Console.Write("{0} ", column);
            }

            Console.Write("\n   ");
            //Print dashes between baloons and indexes
            for (byte column = 0; column < gameField.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < gameField.GetLongLength(0); i++)
            {
                //Print number of Row
                Console.Write(i + " | ");
                for (byte j = 0; j < gameField.GetLongLength(1); j++)
                {
                    if (gameField[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(gameField[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");
            for (byte column = 0; column < gameField.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] gameField = GenetateField(5, 10);
            Console.WriteLine("NEW GAME!\n");            
            DrawGameField(gameField);

            string userCommand = String.Empty;
            int movesCount = 0;
            int commandRow = 0;
            int commandCol = 0;
            char separator = ' ';
            bool isCommandRowCorrect;
            bool isCommandColCorrect;
            bool isSeparatorCorrect;

            while (userCommand != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                userCommand = Console.ReadLine();
                userCommand = userCommand.ToUpper().Trim();

                switch (userCommand)
                {
                    case "RESTART":
                        Console.WriteLine("\nNEW GAME!\n");
                        gameField = GenetateField(5, 10);
                        DrawGameField(gameField);
                        movesCount = 0;
                        break;

                    case "TOP":
                        PrintChart(topFive);
                        break;
                    
                    case "EXIT":
                        break;

                    default:
                        commandRow = userCommand[0];
                        separator = userCommand[1];
                        commandCol = userCommand[2];
                        isCommandRowCorrect = commandRow >= '0' && commandRow <= '9';
                        isCommandColCorrect = commandCol >= '0' && commandCol <= '9';
                        isSeparatorCorrect = separator == ' ' || separator == '.' || separator == ',';

                        if ((userCommand.Length == 3) && isCommandRowCorrect && isCommandColCorrect && isSeparatorCorrect)
                        {
                            commandRow = int.Parse(userCommand[0].ToString());
                            separator = userCommand[1];
                            commandCol = int.Parse(userCommand[2].ToString());
                            if (commandRow > 4)
                            {
                                Console.WriteLine("Wrong input ! Try Again ! ");
                                continue;
                            }

                            if (PopBaloon(gameField, commandRow, commandCol))
                            {
                                Console.WriteLine("cannot pop missing ballon!");
                                continue;
                            }
                            movesCount++;
                            if (isGameOver(gameField))
                            {
                                Console.WriteLine("Gratz ! You completed it in {0} moves.", movesCount);
                                if (topFive.isSkilled(movesCount))
                                {
                                    PrintChart(topFive);
                                }
                                else
                                {
                                    Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                                }
                                gameField = GenetateField(5, 10);
                                movesCount = 0;
                            }

                            Console.WriteLine("\nNEW GAME!\n");                            
                            DrawGameField(gameField);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            break;
                        }


                }
            }
            Console.WriteLine("Good Bye! ");

        }
    }
}