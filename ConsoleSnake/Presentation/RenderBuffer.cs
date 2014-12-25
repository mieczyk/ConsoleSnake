using System;

namespace ConsoleSnake.Presentation
{
    public class RenderBuffer
    {
        private const char BACKGROUND_CHAR = ' ';
        
        private int _width;
        private int _height;
        private char[][] _buffer;

        public RenderBuffer(int width, int height)
        {
            _width = width;
            _height = height;

            _buffer = new char[_height][];
            for (int j = 0; j < _height; ++j)
                _buffer[j] = new char[_width];
        }

        public void Write(char character, int x, int y)
        {
            if (x < 0 || x >= _width)
                throw new ArgumentOutOfRangeException("x");

            if(y < 0 || y >= _height)
                throw new ArgumentOutOfRangeException("y");

            _buffer[y][x] = character;
        }

        public void ClearAll()
        {
            Clear(0, 0, _width, _height);
        }

        public void Clear(int x, int y, int width, int height)
        {
            for (int j = y; j < height; ++j)
                for (int i = x; i < width; ++i)
                    _buffer[j][i] = BACKGROUND_CHAR;
        }

        public void InvalidateAll()
        {
            Invalidate(0, 0, _width, _height);
        }

        public void Invalidate(int x, int y, int width, int height)
        {
            for(int j = y; j < height; j++)
            {
                Console.SetCursorPosition(x, j);

                char[] line = new char[width];
                Array.Copy(_buffer[j], x, line, 0, width);
                Console.WriteLine(line);
            }
        }
    }
}
