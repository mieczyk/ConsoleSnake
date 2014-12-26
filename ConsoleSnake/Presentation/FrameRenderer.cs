using System;
using System.Text;

namespace ConsoleSnake.Presentation
{
    public class FrameRenderer
    {
        private const char TOP_LEFT_CHAR = '\u2554';
        private const char DOWN_LEFT_CHAR = '\u255A';
        private const char TOP_RIGHT_CHAR = '\u2557';
        private const char DOWN_RIGHT_CHAR = '\u255D';
        private const char HORIZONTAL_CHAR = '\u2550';
        private const char VERTICAL_CHAR = '\u2551';

        public void Draw(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(TOP_LEFT_CHAR);

            for (int i = 1; i < width; i++)
                Console.Write(HORIZONTAL_CHAR);
            Console.Write(TOP_RIGHT_CHAR);

            Console.Write(Environment.NewLine);

            StringBuilder line = new StringBuilder(VERTICAL_CHAR.ToString());
            line.Append(new String(' ', width - 1));
            line.Append(VERTICAL_CHAR.ToString());

            for (int i = 1; i < height; i++)
            {
                Console.SetCursorPosition(x, Console.CursorTop);
                Console.WriteLine(line.ToString());
            }

            Console.SetCursorPosition(x, Console.CursorTop);
            Console.Write(DOWN_LEFT_CHAR);

            for (int i = 1; i < width; i++)
                Console.Write(HORIZONTAL_CHAR);
            Console.Write(DOWN_RIGHT_CHAR);
        }
    }
}
