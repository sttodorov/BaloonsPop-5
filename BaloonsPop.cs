using System;
using System.Collections.Generic;

namespace BaloonsPopGame
{
    public class BaloonsPop
    {
        //private GameField gameField1;
        private Engine engine;


        public BaloonsPop()
        {
            //this.gameField1 = new GameField(5, 10);
            this.engine = new Engine();
            this.engine.Start();
        }
        /*
        public byte[,] GenetateField(byte rows, byte columns)
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

        public void PopBaloonsLeft(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn - 1;
            char direcrtion = 'l';
            PopEngine(gameField, searchingInRow, searchinInCol, searchedItem, direcrtion);

        }

        public void PopBaloonsRight(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn + 1;
            char direcrtion = 'r';
            PopEngine(gameField, searchingInRow, searchinInCol, searchedItem, direcrtion);

        }
        public void PopBaloonsUp(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
        {
            int searchingInRow = chosenRow - 1;
            int searchinInCol = chosenColumn;
            char direcrtion = 'u';
            PopEngine(gameField, searchingInRow, searchinInCol, searchedItem,direcrtion);

        }

        public void PopBaloonsDown(byte[,] gameField, int chosenRow, int chosenColumn, int searchedItem)
        {
            int searchingInRow = chosenRow + 1;
            int searchinInCol = chosenColumn;
            char direcrtion = 'd';
            PopEngine(gameField, searchingInRow, searchinInCol, searchedItem, direcrtion);

        }

        public void PopEngine(byte[,] gameField, int searchingInRow, int searchinInCol, int searchedItem, char direction)
        {
            try
            {
                if (gameField[searchingInRow, searchinInCol] == searchedItem)
                {
                    gameField[searchingInRow, searchinInCol] = 0;
                    switch (direction)
                    {
                        case 'l':
                            PopBaloonsLeft(gameField, searchingInRow, searchinInCol, searchedItem);
                            break;
                        case 'r':
                            PopBaloonsRight(gameField, searchingInRow, searchinInCol, searchedItem);
                            break;
                        case 'u':
                            PopBaloonsUp(gameField, searchingInRow, searchinInCol, searchedItem);
                            break;
                        case 'd':
                            PopBaloonsDown(gameField, searchingInRow, searchinInCol, searchedItem);
                            break;
                        default:
                            throw new ArgumentException("NOT Valid direction");
                    }
                }
                return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }
        public bool IsThereBaloon(byte[,] gameField, int choosenRow, int chosenCol)
        {
            if (gameField[choosenRow, chosenCol] == 0)
            {
                return false;
            }
            return true;
        }

        public void PopBaloon(byte[,] gameField, int choosenRow, int chosenCol)
        {
            byte searchedItem = gameField[choosenRow, chosenCol];
            if (gameField[choosenRow, chosenCol] == searchedItem)
            {
                gameField[choosenRow, chosenCol] = 0;
                PopBaloonsDown(gameField,choosenRow,chosenCol,searchedItem);
                PopBaloonsLeft(gameField, choosenRow, chosenCol, searchedItem);
                PopBaloonsRight(gameField, choosenRow, chosenCol, searchedItem);
                PopBaloonsUp(gameField, choosenRow, chosenCol, searchedItem);
            }
        }



        public bool IsGameOver(byte[,] gameField)
        {
            bool isWinner = true;
            int rowsCount = gameField.GetLength(0);
            int columnsCount = gameField.GetLength(1);
            for (int j = 0; j < columnsCount; j++)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    if (gameField[i, j] != 0)
                    {
                        isWinner = false;
                    }
                }
            }
            return isWinner;
        }

        public void RemovePopedBaloons(byte[,] gameField)
        {
            Stack<byte> remainingBaloons = new Stack<byte>();
            int rowsCount = gameField.GetLength(0);
            int columnsCount = gameField.GetLength(1);
            for (int j = 0; j < columnsCount; j++)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    if (gameField[i, j] != 0)
                    {
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

        }

        //TODO: Use HashSet/Dictionary - no need of class RankListReccord
        public List<RankListReccord> SortPlayersRanking(string[,] playersRankingToSort)
        {

            List<RankListReccord> ranking = new List<RankListReccord>();

            for (int i = 0; i < 5; ++i)
            {
                if (playersRankingToSort[i, 0] == null)
                {
                    break;
                }

                ranking.Add(new RankListReccord(int.Parse(playersRankingToSort[i, 0]), playersRankingToSort[i, 1]));

            }
            ranking.Sort();
            return ranking;



        }
        public void PrintRankList(string[,] playersRankingToSort)
        {
            List<RankListReccord> sortedChart = SortPlayersRanking(playersRankingToSort);
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < sortedChart.Count; ++i)
            {
                RankListReccord slot = sortedChart[i];
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
        }*/
    }

}