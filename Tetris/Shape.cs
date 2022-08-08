namespace Tetris
{
    public class Shape
    {
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

        public bshape Form { get; set; }

        public List<(int x, int y)> Content;
        
        public int X;
        
        public int Y;

        public Shape(bshape form)
        {
            Form = form;
        }
        
        public Shape(bshape form, int x, int y) 
        {
            Form = form;
            Content = GetContent(form);
            X = x;
            Y = y;
        }
        
        public static List<(int x, int y)> GetContent(bshape form)
        {
            List<(int x, int y)> content = new ();
            switch (form)
            {
                case bshape.A:
                    content[0] = (0, 0);
                    content[1] = (0, 1);
                    content[2] = (0, 2);
                    content[3] = (0, 3);
                    break;
                case bshape.B:
                    content[0] = (1, 0);
                    content[1] = (1, 1);
                    content[2] = (1, 2);
                    content[3] = (0, 2);
                    break;
                case bshape.C:
                    content[0] = (0, 0);
                    content[1] = (0, 1);
                    content[2] = (0, 2);
                    content[3] = (1, 2);
                    break;
                case bshape.D:
                    content[0] = (0, 0);
                    content[1] = (1, 0);
                    content[2] = (0, 1);
                    content[3] = (1, 1);
                    break;
                case bshape.E:
                    content[0] = (2, 0);
                    content[1] = (1, 0);
                    content[2] = (1, 1);
                    content[3] = (0, 1);
                    break;
                case bshape.F:
                    content[0] = (0, 0);
                    content[1] = (1, 0);
                    content[2] = (2, 0);
                    content[3] = (1, 1);
                    break;
                case bshape.G:
                    content[0] = (0, 0);
                    content[1] = (1, 0);
                    content[2] = (1, 1);
                    content[3] = (2, 1);
                    break;
            }
            return content;
        }


        //now connected to my own laptop
    }

}

