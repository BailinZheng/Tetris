using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Block
    {
        public Block(int TBx)
        {
            Y = 0;
            X = TBx;
        }
        public int Y;
        public int X;

        public bool MoveDown(List<Block> bs)
        {
            if (!bs.Any(b => b.X == X && b.Y == Y + 1))
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(' ');
                Y++;
                Console.SetCursorPosition(X, Y);
                Console.Write('#');
                return true;
            }
            return false;
        }

        public void MoveLeft()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
            X--;
            Console.SetCursorPosition(X, Y);
            Console.Write('#');
        }

        public void MoveRight()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
            X++;
            Console.SetCursorPosition(X, Y);
            Console.Write('#');
        }
    }
}
