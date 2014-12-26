namespace ConsoleSnake.Logic
{
    public class Scoring
    {
        public int Value { get; private set; }

        public Scoring()
        {
            Value = 0;
        }

        public void AddScore(int score)
        {
            Value += score;
        }
    }
}
