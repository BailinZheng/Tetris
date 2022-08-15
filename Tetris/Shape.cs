namespace Tetris
{
    public class Shape
    {
        public Shape()
        {
            Y = 1;
            Random random = new Random();
            X = random.Next(3,7);
        }
        public int X;
        public int Y;
        public int R;
        public enum bshape
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
            F = 6,
            G = 7,
        }

        static Random _R = new Random();
       
        public Shape(bshape form, int x, int y) 
        {
            var v = Enum.GetValues(typeof(bshape));
            form = (bshape)v.GetValue(_R.Next(v.Length));
            rContent = gContent(form);
            X = x;
            Y = y;
        }
        public List<(int x, int y)> rContent;
        
        public List<(int x, int y)> content;
        public List<(int x, int y)> gContent(bshape form)
        {
            switch (form)
            {
                case (bshape)1:
                    content[0] = (0, 0);
                    content[1] = (0, 1);
                    content[2] = (0, 2);
                    content[3] = (0, 3);
                    break;
                case (bshape)2:
                    content[0] = (1, 0);
                    content[1] = (1, 1);
                    content[2] = (1, 2);
                    content[3] = (0, 2);
                    break;
                case (bshape)3:
                    content[0] = (0, 0);
                    content[1] = (0, 1);
                    content[2] = (0, 2);
                    content[3] = (1, 2);
                    break;
                case (bshape)4:
                    content[0] = (0, 0);
                    content[1] = (1, 0);
                    content[2] = (0, 1);
                    content[3] = (1, 1);
                    break;
                case (bshape)5:
                    content[0] = (2, 0);
                    content[1] = (1, 0);
                    content[2] = (1, 1);
                    content[3] = (0, 1);
                    break;
                case (bshape)6:
                    content[0] = (0, 0);
                    content[1] = (1, 0);
                    content[2] = (2, 0);
                    content[3] = (1, 1);
                    break;
                case (bshape)7:
                    content[0] = (0, 0);
                    content[1] = (1, 0);
                    content[2] = (1, 1);
                    content[3] = (2, 1);
                    break;
            }
            return content;
        }
        public bool MoveDown(List<Shape> content)
        {
            if (!content.Any(b => b.X == X && b.Y == Y + 1))
            {
                for (int i = 0; i < content.Count; i++)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write(' ');
                    Y++;
                    Console.SetCursorPosition(X, Y);
                    Console.Write('#');
                    return true;
                }
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


