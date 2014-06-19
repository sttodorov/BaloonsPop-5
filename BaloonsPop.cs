using System;
using System.Collections.Generic;

namespace BaloonsPopGame
{
    public class BaloonsPop
    {
        public byte[,] GenerateField(byte rows, byte columns)
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

        public void CheckForBaloonsLeft(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
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

        public void CheckForBaloonsRight(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
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
        public void CheckForBaloonsUp(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
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

        public void CheckForBaloonsDown(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
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
        public bool PopBaloon(byte[,] gameField, int choosenRow, int chosenCol)
        {
            if (gameField[choosenRow, chosenCol] == 0)
            {
                return true;
            }
            byte searchedTarget = gameField[choosenRow, chosenCol];
            gameField[choosenRow, chosenCol] = 0;

            CheckForBaloonsLeft(gameField, choosenRow, chosenCol, searchedTarget);
            CheckForBaloonsRight(gameField, choosenRow, chosenCol, searchedTarget);
            CheckForBaloonsUp(gameField, choosenRow, chosenCol, searchedTarget);
            CheckForBaloonsDown(gameField, choosenRow, chosenCol, searchedTarget);
            return false;
        }

        public bool IsGameOver(byte[,] gameField)
        {
            bool isWinner = true;
            Stack<byte> remainingBaloons = new Stack<byte>();
            int rowsCount = gameField.GetLength(0);
            int columnsCount = gameField.GetLength(1);
            for (int j = 0; j < columnsCount; j++)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    if (gameField[i, j] != 0)
                    {
                        isWinner = false;
                       remainingBaloons.Push(gameField[i, j]);
                    }
                }
                for (int k = rowsCount - 1; k >= 0; k--)
                {
                    try
                    {
                        gameField[k, j] = remainingBaloons.Pop();
                    }
                    catch (Exception)
                    {
                        gameField[k, j] = 0;
                    }
                }
            }
            return isWinner;
        }

        //TODO: Use HashSet/Dictionary - no need of class RankList
        public List<RankList> SortPlayersRanking(string[,] playersRankingToSort)
        {

            List<RankList> ranking = new List<RankList>();

            for (int i = 0; i < 5; ++i)
            {
                if (playersRankingToSort[i, 0] == null)
                {
                    break;
                }

                ranking.Add(new RankList(int.Parse(playersRankingToSort[i, 0]), playersRankingToSort[i, 1]));

            }
            ranking.Sort();
            return ranking;
            


        }
        public void PrintRankList(string[,] playersRankingToSort)
        {
            List<RankList> sortedChart = SortPlayersRanking(playersRankingToSort);
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < sortedChart.Count; ++i)
            {
                RankList slot = sortedChart[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");
        }

        public void DrawGameField(byte[,] gameField)
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
    }
}