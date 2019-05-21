using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check24CodeTask
{
    public class BoardGenerator : IBoardGenerator
    {
        public BoardGenerator(int boardSize, int numberOfColors, ref Dictionary<int, int> tileNumberOfColors)
        {
            this.boardSize = boardSize;
            this.numberOfColors = numberOfColors;
            this.tileNumberOfColors = tileNumberOfColors;
        }
        private readonly int boardSize;
        private readonly int numberOfColors;
        private Dictionary<int, int> tileNumberOfColors { get; set; }
        /// <summary>
        /// Generates a board using given board size. 
        /// </summary>
        /// <returns> A game board with n x n .</returns>
        public int[,] Generate()
        {
            Random random = new Random();
            int[,] board = new int[boardSize, boardSize];

            for (int i = 0; i < boardSize; i++)
            {

                for (int j = 0; j < boardSize; j++)
                {
                    int color = random.Next(0, numberOfColors);
                    tileNumberOfColors[color]++;
                    board[i, j] = color;
                }
            }
            return board;
        }

    }
}
