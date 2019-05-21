using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check24CodeTask
{
    class Program
    {
        static int n ;
        static int m ;
        static int[,] board;
        static Dictionary<int, int> tileNumberOfColors;

        static void Main(string[] args)
        {

            Random random = new Random();
            tileNumberOfColors = new Dictionary<int, int>();
            Console.WriteLine("Board Size : ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine("Please enter a positive number.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Number of Colors : ");
            m = Convert.ToInt32(Console.ReadLine());
            if (m == 0)
            {
                Console.WriteLine("Please enter a positive number.");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < m; i++)
            {
                tileNumberOfColors.Add(i, 0);
            }

            BoardGenerator boardGenerator = new BoardGenerator(n,m,ref tileNumberOfColors);
            board = boardGenerator.Generate();

            GameSolver gameSolver = new GameSolver(board,tileNumberOfColors);
       
            Console.WriteLine("Number of steps : " + gameSolver.Solve());
            Console.WriteLine("Game Solved!");
            Console.Read();

        }


    }
}
