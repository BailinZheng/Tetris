using System;
using Tetris;

var block = new Block(4);
Console.CursorVisible = false;

int height = 20;
int width = 10;

List<Block> blocks = new List<Block>();
while (true)
{
    while (!Console.KeyAvailable)
    {
        Thread.Sleep(75);

        if (block.Y == height || !block.MoveDown(blocks))
        {
            if (block.Y == 0)
            {
                Console.SetCursorPosition(0, 21);
                Console.Write("Game over");
                return;
            }

            blocks.Add(block);

            // Volle Reihen
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

                        foreach (Block b in blocks.Where(b => b.Y == yMove))
                        {
                            b.MoveDown(new List<Block>());
                        }
                    }
                }
            }
            // -----------------------------------------------------

            block = new Block(4);
        }
    }
    ConsoleKeyInfo key = Console.ReadKey(true);

    if (key.KeyChar == 'a')
    {
        if (block.X > 0 && !blocks.Any(b => b.X == block.X - 1 && b.Y == block.Y))
        {
            block.MoveLeft();
        }
    }

    if (key.KeyChar == 'd')
    {
        if (block.X < width && !blocks.Any(b => b.X == block.X - 1 && b.Y == block.Y))
        {
            block.MoveRight();
        }

    }
};


