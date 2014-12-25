using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleSnake
{
    public class Arena
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Point ActiveBrick { get; private set; }

        public Arena(int x, int y, int width, int height)
        {
            if (x < 0 || y < 0)
                throw new ArgumentOutOfRangeException("x, y");

            if(width <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException("width, height");

            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Point GenerateBrickAtRandomPosition(IEnumerable<Point> excludedPositions)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            
            Point brick;
            bool repeat;

            do
            {
                repeat = false;
                brick = new Point(random.Next(X, Width), random.Next(Y, Height));

                foreach (Point excluded in excludedPositions)
                {
                    if(brick == excluded)
                    {
                        repeat = true;
                        break;
                    }
                }
            } 
            while(repeat);

            ActiveBrick = brick;

            return brick;
        }
    }
}
