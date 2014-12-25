using ConsoleSnake.Presentation;
using System;
using System.Drawing;
using System.Threading;

namespace ConsoleSnake
{
    class Program
    {
        static readonly int _width;
        static readonly int _height;

        static GameManager _gameManager;
        static RenderBuffer _renderBuffer;
        static BoxRenderer _boxRenderer;
        static GameRenderer _gameRenderer;
        
        static Program()
        {
            _width = Console.WindowWidth;
            _height = Console.WindowHeight - 2;

            Arena arena = new Arena(1, 1, _width - 2, _height - 2);
            Snake snake = new Snake(5, new Point(10, 10));
            _gameManager = new GameManager(arena, snake);

            _renderBuffer = new RenderBuffer(_width, _height);
            _boxRenderer = new BoxRenderer(_renderBuffer);
            _gameRenderer = new GameRenderer(_renderBuffer);
        }

        static void Main(string[] args)
        {
            _renderBuffer.ClearAll();

            _boxRenderer.Draw(0, 0, _width - 1, _height - 1);

            _renderBuffer.InvalidateAll();

            Console.CursorVisible = false;

            bool runGame = true;

            while(runGame)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            _gameManager.Snake.CurrentDirection = Direction.Up;
                            break;

                        case ConsoleKey.DownArrow:
                            _gameManager.Snake.CurrentDirection = Direction.Down;
                            break;

                        case ConsoleKey.RightArrow:
                            _gameManager.Snake.CurrentDirection = Direction.Right;
                            break;

                        case ConsoleKey.LeftArrow:
                            _gameManager.Snake.CurrentDirection = Direction.Left;
                            break;

                        case ConsoleKey.Q:
                            runGame = false;
                            break;
                    }
                }

                if (runGame)
                {
                    runGame = _gameManager.MoveSnake();

                    _renderBuffer.Clear(1, 1, _width - 1, _height - 1);

                    _gameRenderer.Draw(_gameManager);

                    _renderBuffer.Invalidate(1, 1, _width - 1, _height - 1);

                    Thread.Sleep(50);
                }
            }
        }
    }
}
