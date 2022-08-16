using System;
using Tetris;
//var block = new Block(4);
Console.CursorVisible = false;

const int height = 20;
const int width = 10;

Shape? shape = new Shape();
List<Block> blocks = new List<Block>();
Console.CursorVisible = false;

while (true)
{
    while (!Console.KeyAvailable)
    {
        Thread.Sleep(250);

        if (shape.Blocks.Any(block => block.Y == height) || !shape.MoveDown(blocks))
        {
            if (shape.Blocks.Any(block => block.Y == 0))
            {
                Console.SetCursorPosition(0, 21);
                Console.Write("Game over");
                return;
            }

            blocks.AddRange(shape.Blocks);

            #region Volle Reihen leeren und verschieben
            // -----------------------------------------------------
            for (int y = 0; y <= height; y++)
            {
                bool notFullRow = false;

                // Überprüfen, ob eine Reihe voll ist
                for (int x = 0; x <= width; x++)
                {
                    if (!blocks.Any(b => b.X == x && b.Y == y))
                    {
                        notFullRow = true;
                        break;
                    }
                }

                if (!notFullRow)
                {
                    // Volle Reihe leer machen
                    Console.SetCursorPosition(0, y);
                    Console.Write(new String(' ', width + 1));

                    // Blöcke der vollen Reihe aus der Liste entfernen
                    blocks.RemoveAll(b => b.Y == y);

                    // Alle Blöcke darüber nach unten bewegen.
                    for (int yMove = y - 1; yMove > 0; yMove--)
                    {
                        Console.SetCursorPosition(0, yMove);
                        Console.Write(new String(' ', width + 1));

                        foreach (Block block in blocks.Where(b => b.Y == yMove))
                        {
                            block.MoveDown(new List<Block>());
                        }
                    }
                }
            }
            // -----------------------------------------------------
            #endregion

            shape = new Shape();
        }
    }
    ConsoleKeyInfo key = Console.ReadKey(true);

    if (key.KeyChar == 'a')
    {
        shape.MoveLeft(blocks);
    }
    if (key.KeyChar == 'd')
    {
        shape.MoveRight(blocks);
    }
}


