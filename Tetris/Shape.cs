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
            Cube,
            E = 5,
            F = 6,
            G = 7,
        }
        int X;
        int Y;
        bshape BShape;

        public Shape()
        {
            var shapeList = Enum.GetValues<bshape>();
            bshape shape = shapeList[new Random().Next(shapeList.Length)];
            Blocks = new();

            X = 5;
            Y = 0;
            BShape = shape;

            switch (shape)
            {
                case (bshape)1:
                    Blocks.Add(new Block(5 - 1, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 2, 0 + 0));
                    break;
                case (bshape)2:
                    Blocks.Add(new Block(5 - 1, 0 + 1));
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 1));
                    break;
                case (bshape)3:
                    Blocks.Add(new Block(5 + 0, 0 - 1));
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    Blocks.Add(new Block(5 + 1, 0 + 1));
                    break;
                case bshape.Cube:
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    Blocks.Add(new Block(5 + 1, 0 + 1));
                    break;
                case (bshape)5:
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    Blocks.Add(new Block(5 - 1, 0 + 1));
                    break;
                case (bshape)6:
                    Blocks.Add(new Block(5 - 1, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 1, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    break;
                case (bshape)7:
                    Blocks.Add(new Block(5 - 1, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 0));
                    Blocks.Add(new Block(5 + 0, 0 + 1));
                    Blocks.Add(new Block(5 + 1, 0 + 1));
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

                Y++;

                return true;
            }
            return false;
        }

        public void MoveLeft(List<Block> otherBlocks)
        {
            if (!Blocks.Any(block => block.X == 1)
                && !otherBlocks.Any(deadBlock => Blocks.Any(block =>
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

                X--;
            }
        }

        public void MoveRight(List<Block> otherBlocks)
        {
            if (!Blocks.Any(block => block.X == 10)
                && !otherBlocks.Any(deadBlock => Blocks.Any(block =>
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

                X++;
            }
        }

        public bool Collides(List<Block> otherBlocks)
        {
            if (otherBlocks.Any(block => Blocks.Any(shapeBlock => shapeBlock.X == block.X && shapeBlock.Y + 1 == block.Y)))
            {
                return true;
            }

            return false;
        }

        public static bool Collides(List<Block> myBlocks, List<Block> otherBlocks)
        {
            if (otherBlocks.Any(block => myBlocks.Any(shapeBlock => shapeBlock.X == block.X && shapeBlock.Y + 1 == block.Y)))
            {
                return true;
            }

            return false;
        }

        public bool Turn(List<Block> otherBlocks)
        {
            if (BShape == bshape.Cube) return true;

            List<Block> newBlocks = new List<Block>();

            foreach (Block block in Blocks)
            {
                int relativeX = block.X - X;
                int relativeY = block.Y - Y;

                newBlocks.Add(new Block(X + relativeY, Y - relativeX));
            }

            if (!Collides(newBlocks, otherBlocks) && !newBlocks.Any(block => block.X < 1 || block.X > 10 || block.Y < 0 || block.Y > 20))
            {
                for (int i = 0; i < Blocks.Count; i++)
                {
                    Blocks[i].Delete();
                    Blocks[i] = newBlocks[i];
                }

                foreach(Block block in Blocks)
                {
                    block.Draw();
                }

                return true;
            }

            return false;
        }
    }
}


