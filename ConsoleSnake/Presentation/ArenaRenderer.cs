namespace ConsoleSnake.Presentation
{
    public class ArenaRenderer
    {
        private const char BRICK_CHAR = '\u2666';

        private RenderBuffer _renderBuffer;

        public ArenaRenderer(RenderBuffer renderBuffer)
        {
            _renderBuffer = renderBuffer;
        }

        public void Draw(Arena arena)
        {
            _renderBuffer.Write(BRICK_CHAR, arena.ActiveBrick.X, arena.ActiveBrick.Y);
        }
    }
}
