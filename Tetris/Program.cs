using System;
using Tetris;
//var block = new Block(4);
Console.CursorVisible = false;

const int height = 20;
const int width = 10;
string nameplayer;
while (true)
{
    Console.CursorVisible = true;


    Console.WriteLine("Wer bist du?");
    nameplayer = Console.ReadLine();
    Console.Clear();
    // UserName eingeben (Console einlesen)

    Console.CursorVisible = false;
    var horizontaleKante = new String('-', width + 2);
    for (int j = 0; j < height; j++)
    {
        Console.SetCursorPosition(0, j + 1);
        Console.Write("|");

        Console.SetCursorPosition(width + 1, j + 1);
        Console.Write("|");
    }
    Console.SetCursorPosition(0, height + 1);
    Console.WriteLine(horizontaleKante);

    Console.SetCursorPosition(13, 4);
    Console.Write("nächste block ist");

    int gameSpeed = 250;
    int score = 0;
    Shape shape = new Shape();
    Shape nextShape = new Shape();
    List<Block> blocks = new List<Block>();

    Console.SetCursorPosition(13, 12);
    Console.Write("Deine score ist " + score);
    Console.SetCursorPosition(13, 13);
    Console.Write("Deine level ist " + score / 10);

    bool shapeAtBottom = true;

    while (true)
    {
        bool gameOver = false;

        while (!Console.KeyAvailable)
        {
            if (shapeAtBottom)
            {
                nextShape.Blocks.ForEach(block => block.Delete(10, 7));
                shape = nextShape;

                shape.Blocks.ForEach(block => block.Draw());

                nextShape = new();
                nextShape.Blocks.ForEach(block => block.Draw(10, 7));

                // block.MoveDown(new List<Block>());
                shapeAtBottom = false;
            }

            Thread.Sleep(gameSpeed);

            Console.SetCursorPosition(13, 12);
            Console.Write("Deine score ist " + score);
            Console.SetCursorPosition(13, 13);
            Console.Write("Deine level ist " + score / 10);

            if (shape.Blocks.Any(block => block.Y == height) || !shape.MoveDown(blocks))
            {
                if (shape.Blocks.Any(block => block.Y == 0))
                {
                    gameOver = true;
                    break;
                }

                blocks.AddRange(shape.Blocks);

                #region Volle Reihen leeren und verschieben
                // -----------------------------------------------------
                for (int y = 0; y <= height; y++)
                {
                    bool notFullRow = false;

                    // Überprüfen, ob eine Reihe voll ist
                    for (int x = 1; x <= width; x++)
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
                        Console.SetCursorPosition(1, y);
                        Console.Write(new String(' ', width));

                        score++;
                        gameSpeed = 250 - ((score / 5) * 15);

                        Console.SetCursorPosition(13, 12);
                        Console.Write("Deine score ist " + score);
                        Console.SetCursorPosition(13, 13);
                        Console.Write("Deine level ist " + score / 5);

                        // Blöcke der vollen Reihe aus der Liste entfernen
                        blocks.RemoveAll(b => b.Y == y);

                        // Alle Blöcke darüber nach unten bewegen.
                        for (int yMove = y - 1; yMove > 0; yMove--)
                        {
                            Console.SetCursorPosition(1, yMove);
                            Console.Write(new String(' ', width));

                            foreach (Block block in blocks.Where(b => b.Y == yMove))
                            {
                                block.MoveDown(new List<Block>());
                            }
                        }
                    }
                }
                // -----------------------------------------------------
                #endregion

                shapeAtBottom = true;
            }
        }

        if (gameOver)
        {
            gameOver = false;
            break;
        }

        ConsoleKeyInfo key = Console.ReadKey(true);

        if (key.KeyChar == 'a')
        {
            shape.MoveLeft(blocks);
        }
        else if (key.KeyChar == 'd')
        {
            shape.MoveRight(blocks);
        }
        else if (key.KeyChar == 'w')
        {
            shape.Turn(blocks);
        }
        else if (key.KeyChar == 's')
        {

            while (!shape.Blocks.Any(block => block.Y == height))
            {
                if (!shape.MoveDown(blocks))
                {
                    break;
                }
                Thread.Sleep(25);
            }
        }
        else if (key.Key == ConsoleKey.Escape)
        {
            break;
        }
    }
    /* Abfrage, ob spiel neu Starten (Consolen-Eingabe (y/n))
     * Wenn ja: 
     *      - Highscore setzen (Highscore-Variable)
     *      - Nutzernamen des Highscore-Users setzen (HighscoreUserName-Variable)
     * Wenn nein:
     *      return;
     */

    Console.Clear();
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Game over");
    Console.WriteLine("Highscore");
    Console.WriteLine(nameplayer + ":   " + score);
    Console.WriteLine();
    Console.WriteLine("Do you want to restart?");
    Console.CursorVisible = true;
    string input = Console.ReadLine() ?? "";
    Console.CursorVisible = false;

    if (input != "y")
    {
        return;
    }
}

