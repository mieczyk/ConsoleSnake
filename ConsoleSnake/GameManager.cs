using System;
using System.Drawing;
using System.Linq;

namespace ConsoleSnake
{
    public class GameManager
    {
        public  Arena Arena { get; private set; }

        public Snake Snake { get; private set; }

        public GameManager(Arena arena, Snake snake)
        {
            if (arena == null)
                throw new ArgumentNullException("arena");

            if (snake == null)
                throw new ArgumentNullException("snake");

            Arena = arena;
            Snake = snake;

            Arena.GenerateBrickAtRandomPosition(Snake.Segments);
        }

        public bool MoveSnake()
        {
            Snake.Move();

            if (Snake.Segments.First() == Arena.ActiveBrick)
            {
                Snake.AddSegment(Arena.ActiveBrick);
                Arena.GenerateBrickAtRandomPosition(Snake.Segments);
                Console.Beep(1000, 100);
            }

            return !IsCollision();
        }

        private bool IsCollision()
        {
            Point snakeHead = Snake.Segments.First();
            bool result = false;

            if (snakeHead.X < Arena.X || snakeHead.Y < Arena.Y || snakeHead.X >= Arena.Width || snakeHead.Y >= Arena.Height)
                result = true;

            if (Snake.IsSelfCollision())
                result = true;

            return result;
        }
    }
}
