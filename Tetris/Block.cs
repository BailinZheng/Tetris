using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Block
    {
        public Block(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        public bool MoveDown(List<Block> blocks)
        {
            if (!blocks.Any(shape => shape.X == X && shape.Y == Y + 1))
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
