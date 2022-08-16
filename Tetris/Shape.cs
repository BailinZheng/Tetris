using System.Linq;

namespace Tetris
{
    public class Shape
    {
        private enum bshape
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
            F = 6,
            G = 7,
        }

        public Shape()
        {
            var shapeList = Enum.GetValues<bshape>();
            bshape shape = shapeList[new Random().Next(shapeList.Length)];
            Blocks = new();

            switch (shape)
            {
                case (bshape)1:
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 2, 0 + 0));
                    Blocks.Add(new Block(5 + 3, 0 + 0));
                    break;
                case (bshape)2:
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    Blocks.Add(new Block(5 + 1, 0 + 1));
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 2, 0 + 1));
                    break;
                case (bshape)3:
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    Blocks.Add(new Block(5 + 0, 0 + 2));
                    Blocks.Add(new Block(5 + 1, 0 + 2));
                    break;
                case (bshape)4:
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    Blocks.Add(new Block(5 + 1, 0 + 1));
                    break;
                case (bshape)5:
                    Blocks.Add(new Block(5 + 2, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 1));
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    break;
                case (bshape)6:
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 2, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 1));
                    break;
                case (bshape)7:
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 1));
                    Blocks.Add(new Block(5 + 2, 0 + 1));
                    break;
            }
        }

        public List<Block> Blocks;

        public bool MoveDown(List<Block> otherBlocks)
        {
            if (!Collides(otherBlocks))
            {
                int maxY = Blocks.Max(block => block.Y);
                int minY = Blocks.Min(block => block.Y);

                for (int i = maxY; i >= minY; i--)
                {
                    foreach (Block blockToMove in Blocks.Where(block => block.Y == i))
                    {
                        if (!blockToMove.MoveDown(otherBlocks))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public void MoveLeft(List<Block> blocks)
        {
            if (!Blocks.Any(block => block.X == 0)
                && !blocks.Any(deadBlock => Blocks.Any(block => 
                    block.X - 1 == deadBlock.X && deadBlock.Y == block.Y)))
            {
                int maxX = Blocks.Max(block => block.X);
                int minX = Blocks.Min(block => block.X);

                for (int i = minX; i <= maxX; i++)
                {
                    foreach (Block blockToMove in Blocks.Where(block => block.X == i))
                    {
                        blockToMove.MoveLeft();
                    }
                }
            }
        }

        public void MoveRight(List<Block> blocks)
        {
            if (!Blocks.Any(block => block.X == 10) 
                && !blocks.Any(deadBlock => Blocks.Any(block => 
                    block.X + 1 == deadBlock.X && deadBlock.Y == block.Y)))
            {
                int maxX = Blocks.Max(block => block.X);
                int minX = Blocks.Min(block => block.X);

                for (int i = maxX; i >= minX; i--)
                {
                    foreach (Block blockToMove in Blocks.Where(block => block.X == i))
                    {
                        blockToMove.MoveRight();
                    }
                }
            }
        }

        public bool Collides(List<Block> blocks)
        {
            if (blocks.Any(block => Blocks.Any(shapeBlock => shapeBlock.X == block.X && shapeBlock.Y+1 == block.Y)))
            {
                return true;
            }

            return false;
        }
    }
}


