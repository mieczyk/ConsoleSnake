namespace ConsoleSnake.Presentation
{
    public class BoxRenderer
    {
        private const char TOP_LEFT_CHAR = '\u2554';
        private const char DOWN_LEFT_CHAR = '\u255A';
        private const char TOP_RIGHT_CHAR = '\u2557';
        private const char DOWN_RIGHT_CHAR = '\u255D';
        private const char HORIZONTAL_CHAR = '\u2550';
        private const char VERTICAL_CHAR = '\u2551';
        
        private RenderBuffer _renderBuffer;
        
        public BoxRenderer(RenderBuffer renderBuffer)
        {
            _renderBuffer = renderBuffer;
        }

        public void Draw(int x, int y, int width, int height)
        {
            _renderBuffer.Write(TOP_LEFT_CHAR, x, y);

            for (int i = 1; i < width; i++)
                _renderBuffer.Write(HORIZONTAL_CHAR, x + i, y);

            _renderBuffer.Write(TOP_RIGHT_CHAR, x + width, y);

            for (int i = 1; i < height; i++)
            {
                _renderBuffer.Write(VERTICAL_CHAR, x, y + i);
                _renderBuffer.Write(VERTICAL_CHAR, x + width, y + i);
            }

            _renderBuffer.Write(DOWN_LEFT_CHAR, x, y + height);

            for (int i = 1; i < width; i++)
                _renderBuffer.Write(HORIZONTAL_CHAR, x + i, y + height);

            _renderBuffer.Write(DOWN_RIGHT_CHAR, x + width, y + height);
        }
    }
}
