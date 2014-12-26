using System;
using System.Drawing;
using System.Linq;

namespace ConsoleSnake.Logic
{
    public class GameManager
    {
        public Arena Arena { get; private set; }

        public Snake Snake { get; private set; }

        public Scoring Scoring { get; private set; }

        public GameManager(Arena arena, Snake snake, Scoring scoring)
        {
            if (arena == null)
                throw new ArgumentNullException("arena");

            if (snake == null)
                throw new ArgumentNullException("snake");

            if (scoring == null)
                throw new ArgumentException("scoring");

            Arena = arena;
            Snake = snake;
            Scoring = scoring;

            Arena.GenerateBrickAtRandomPosition(Snake.Segments);
        }

        public bool MoveSnake()
        {
            Snake.Move();

            if (Snake.Segments.First() == Arena.ActiveBrick)
            {
                Snake.AddSegment();
                Arena.GenerateBrickAtRandomPosition(Snake.Segments);
                Scoring.AddScore(10);

                Console.Beep(2500, 150);
            }

            return !IsCollision();
        }

        private bool IsCollision()
        {
            Point snakeHead = Snake.Segments.First();
            bool result = false;

            if (snakeHead.X < Arena.X 
                || snakeHead.Y < Arena.Y 
                || snakeHead.X >= Arena.X + Arena.Width 
                || snakeHead.Y >= Arena.Y + Arena.Height)
                result = true;

            if (Snake.IsSelfCollision())
                result = true;

            return result;
        }
    }
}
