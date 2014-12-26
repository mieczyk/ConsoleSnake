using ConsoleSnake.Logic;
using System;
using System.Drawing;
using System.Linq;

namespace ConsoleSnake.Presentation
{
    public class DisplayManager
    {
        private int _windowWidth;
        private int _windowHeight;

        private FrameRenderer _frameRenderer;

        public DisplayManager(int windowWidth, int windowHeight)
        {
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;

            _frameRenderer = new FrameRenderer();
        }

        public void PrepareGameWindow()
        {
            Console.SetWindowSize(_windowWidth, _windowHeight);
            Console.SetBufferSize(_windowWidth, _windowHeight);
            Console.Title = "Snake";
            Console.CursorVisible = false;
            Console.Clear();
        }

        public void DrawTitle()
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine(@"     _______..__   __.      ___       __  ___  _______ ");
            Console.WriteLine(@"    /       ||  \ |  |     /   \     |  |/  / |   ____|");
            Console.WriteLine(@"   |   (----`|   \|  |    /  ^  \    |  '  /  |  |__   ");
            Console.WriteLine(@"    \   \    |  . `  |   /  /_\  \   |    <   |   __|  ");
            Console.WriteLine(@".----)   |   |  |\   |  /  _____  \  |  .  \  |  |____ ");
            Console.WriteLine(@"|_______/    |__| \__| /__/     \__\ |__|\__\ |_______|");

            int x = (_windowWidth - 55) / 2;
            int y = 2;
            int width = 55;
            int height = 6;

            Console.MoveBufferArea(0, 0, width, height, x, y);
        }

        public void DrawMenu(Menu menu)
        {
            int x = (_windowWidth - 30) / 2;
            int y = 10;
            int width = 20;
            int height = menu.Options.Count + 3;

            _frameRenderer.Draw(x, y, width, height);

            int j = 2;
            foreach(var option in menu.Options)
            {
                Console.SetCursorPosition(x + 2, y + j);

                if (option.Key == menu.ActiveOption)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                
                Console.Write(option.Value);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;

                j++;
            }
        }

        public void DrawScores(Scoring scoring, bool refresh = false)
        {
            int x = (_windowWidth - 90) / 2;
            int y = 2;
            int width = 90;
            int height = 2;
            
            if(!refresh)
            {
                _frameRenderer.Draw(x, y, width, height);
            }

            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write("SCORE: {0}", scoring.Value);
        }

        public void DrawArenaAndSnake(Arena arena, Snake snake, bool refresh = false)
        {
            const char BRICK_CHAR = '\u2666';
            const char SEGMENT_CHAR = '\u2588';
            const char BACKGROUND_CHAR = ' ';

            if (!refresh)
                _frameRenderer.Draw(arena.X - 1, arena.Y - 1, arena.Width + 1, arena.Height + 1);

            // Double buffering eliminates flickering.
            char[][] buffer = new char[arena.Height][];
            for (int j = 0; j < arena.Height; ++j)
                buffer[j] = new char[arena.Width];

            for (int j = 0; j < arena.Height; j++)
            {
                for(int i = 0; i < arena.Width; i++)
                {
                    if (arena.ActiveBrick.X == arena.X + i && arena.ActiveBrick.Y == arena.Y + j)
                        buffer[j][i] = BRICK_CHAR;
                    else if (snake.Segments.Contains(new Point(arena.X + i, arena.Y + j)))
                        buffer[j][i] = SEGMENT_CHAR;
                    else
                    buffer[j][i] = BACKGROUND_CHAR;
                }
            }

            for (int j = 0; j < arena.Height; j++)
            {
                Console.SetCursorPosition(arena.X, arena.Y + j);
                Console.WriteLine(buffer[j]);
            }
        }
    }
}
 