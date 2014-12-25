namespace ConsoleSnake.Presentation
{
    public class GameRenderer
    {
        private RenderBuffer _renderBuffer;
        private ArenaRenderer _arenaRenderer;
        private SnakeRenderer _snakeRenderer;

        public GameRenderer(RenderBuffer renderBuffer)
        {
            _renderBuffer = renderBuffer;

            _arenaRenderer = new ArenaRenderer(_renderBuffer);
            _snakeRenderer = new SnakeRenderer(_renderBuffer);
        }

        public void Draw(GameManager gameManager)
        {
            _arenaRenderer.Draw(gameManager.Arena);
            _snakeRenderer.Draw(gameManager.Snake);
        }
    }
}
