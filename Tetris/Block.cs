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

        const char blockSymbol = 'O';
        public int X;
        public int Y;

        public bool MoveDown(List<Block> blocks)
        {
            if (!blocks.Any(shape => shape.X == X && shape.Y == Y + 1))
            {
                if (X >= 1 && Y >= 0)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write(' ');
                }
                Y++;
                if (X >= 1 && Y >= 0)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write(blockSymbol);
                }
                return true;
            }
            return false;
        }

        public void Delete(int x = 0, int y = 0)
        {
            if (X + x >= 1 && Y + y >= 0)
            {
                Console.SetCursorPosition(X + x, Y + y);
                Console.Write(' ');
            }
        }

        public void Draw(int x = 0, int y = 0)
        {
            if (X + x >= 1 && Y + y >= 0)
            {
                Console.SetCursorPosition(X + x, Y + y);
                Console.Write(blockSymbol);
            }
        }

        public void MoveLeft()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
            X--;
            Console.SetCursorPosition(X, Y);
            Console.Write(blockSymbol);
        }

        public void MoveRight()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
            X++;
            Console.SetCursorPosition(X, Y);
            Console.Write(blockSymbol);
        }
    }
}
