using System;
using Tetris;
var shape = new Shape();
//var block = new Block(4);
Console.CursorVisible = false;

const int height = 20;
const int width = 10;
List<Shape> shapes = new List<Shape>();
while (true)
{
    while (!Console.KeyAvailable)
    {
        Thread.Sleep(75);

        if (shape.Y == height || !shape.MoveDown(shapes))
        {
            if (shape.Y == 0)
            {
                Console.SetCursorPosition(0, 21);
                Console.Write("Game over");
                return;
            }

            shapes.Add(shape);

            // Volle Reihen
            // -----------------------------------------------------
            for (int y = 0; y <= height; y++)
            {
                bool notFullRow = false;

                // Überprüfen, ob eine Reihe voll ist
                for (int x = 0; x <= width; x++)
                {
                    if (!shapes.Any(b => b.X == x && b.Y == y))
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
                    shapes.RemoveAll(b => b.Y == y);

                    // Alle Blöcke darüber nach unten bewegen.
                    for (int yMove = y - 1; yMove > 0; yMove--)
                    {
                        Console.SetCursorPosition(0, yMove);
                        Console.Write(new String(' ', width + 1));

                        foreach (Shape b in shapes.Where(b => b.Y == yMove))
                        {
                            b.MoveDown(new List<Shape>());
                        }
                    }
                }
            }
            // -----------------------------------------------------

            shape = new Shape();
        }
    }
    ConsoleKeyInfo key = Console.ReadKey(true);

    if (key.KeyChar == 'a')
    {
        if (shape.X > 0 && !shapes.Any(b => b.X == shape.X - 1 && b.Y == shape.Y))
        {
            shape.MoveLeft();
        }

        if (key.KeyChar == 'd')
        {
            if (shape.X < width && !shapes.Any(b => b.X == shape.X - 1 && b.Y == shape.Y))
            {
                shape.MoveRight();
            }

        }
    };
}


