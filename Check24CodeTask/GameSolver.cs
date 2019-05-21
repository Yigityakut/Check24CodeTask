using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check24CodeTask
{
    public class GameSolver: IGameSolver
    {

        int originColor;
        List<int> adjacentColors = new List<int>();
        List<Coordinate> tilesToBePainted = new List<Coordinate>();
        private int[,] board;
        private Dictionary<int, int> tileNumberOfColors;
        public GameSolver(int[,] board, Dictionary<int, int> tileNumberOfColors)
        {
            this.board = board;
            this.tileNumberOfColors = tileNumberOfColors;
        }
        /// <summary>
        /// Solves the board game.
        /// </summary>
        /// <returns>Count of tries.</returns>
        public int Solve()
        {
            int countOfTries = 0;
            while (true)
            {

                originColor = board[0, 0];
                GetAdjacentColors(0, 0);
                if (adjacentColors.Count == 0)
                {
                    break;
                }
                int countMax = tileNumberOfColors.Where(x => adjacentColors.Contains(x.Key)).ToDictionary(t => t.Key, t => t.Value).Max(x => x.Value);
                int maxNumberOfTilesAdjacentColor = tileNumberOfColors.FirstOrDefault(x => x.Value == countMax).Key; // Color to be clicked
                SetNewColor(maxNumberOfTilesAdjacentColor, 0, 0);
                UpdateTileNumberOfColors(originColor, maxNumberOfTilesAdjacentColor);
                tilesToBePainted.Clear();
                adjacentColors.Clear();
                countOfTries++;
            }return countOfTries;
        }



        private void UpdateTileNumberOfColors(int oldColor, int newColor)
        {
            tileNumberOfColors[oldColor] -= tilesToBePainted.Count;
            tileNumberOfColors[newColor] += tilesToBePainted.Count;
        }

        private void SetNewColor(int color, int x, int y)
        {
            foreach (var tile in tilesToBePainted)
            {
                board[tile.x, tile.y] = color;
            }
        }


        private void GetAdjacentColors(int x, int y)
        {
            tilesToBePainted.Add(new Coordinate() { x = x, y = y });
            if (y + 1 != board.GetLength(0))
            {
                if (board[x, y + 1] != originColor)
                {
                    if (!adjacentColors.Contains(board[x, y + 1]))
                    {
                        adjacentColors.Add(board[x, y + 1]);
                    }
                }
                else
                {
                    GetAdjacentColors(x, y + 1);
                }
            }
            if (x + 1 != board.GetLength(0))
            {
                if (board[x + 1, y] != originColor)
                {
                    if (!adjacentColors.Contains(board[x + 1, y]))
                    {
                        adjacentColors.Add(board[x + 1, y]);
                    }
                }
                else
                {
                    GetAdjacentColors(x + 1, y);
                }
            }
        }




    }
}
