using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace Tetris
{
    public class Block
    {
        public int BX;
        public int BY;
        public Block()
        {
            BX = 0;
            BY = 0;
        }

        public bool MoveDown(List<Shape> bs)
        {
            if (!bs.Any(b => b.X == BX && b.Y == BY + 1))
            {
                Console.SetCursorPosition(BX, BY);
                Console.Write(' ');
                BY++;
                Console.SetCursorPosition(BX, BY);
                Console.Write('#');
                return true;
            }
            return false;
        }

        public void MoveLeft()
        {
            Console.SetCursorPosition(BX, BY);
            Console.Write(' ');
            BX--;
            Console.SetCursorPosition(BX, BY);
            Console.Write('#');
        }

        public void MoveRight()
        {
            Console.SetCursorPosition(BX, BY);
            Console.Write(' ');
            BX++;
            Console.SetCursorPosition(BX, BY);
            Console.Write('#');
        }
    }
}
*/