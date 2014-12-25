using System.Collections.Generic;
using System.Drawing;

namespace ConsoleSnake.Presentation
{
    public class SnakeRenderer
    {
        private const char SEGMENT_CHAR = '\u2588';
        
        private RenderBuffer _renderBuffer;
        
        public SnakeRenderer(RenderBuffer renderBuffer)
        {
            _renderBuffer = renderBuffer;
        }

        public void Draw(Snake snake)
        {
            foreach(Point segment in snake.Segments)
            {
                _renderBuffer.Write(SEGMENT_CHAR, segment.X, segment.Y);
            }
        }
    }
}
