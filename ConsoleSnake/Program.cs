using ConsoleSnake.Logic;
using ConsoleSnake.Presentation;
using System;
using System.Drawing;
using System.Threading;

namespace ConsoleSnake
{
    class Program
    {
        private const int WINDOW_WIDTH = 100;
        private const int WINDOW_HEIGHT = 30;

        private static DisplayManager _displayManager;
        private static GameManager _gameManager;

        static Program()
        {
            _displayManager = new DisplayManager(WINDOW_WIDTH, WINDOW_HEIGHT);

            int arenaX = (WINDOW_WIDTH - 88) / 2;
            int arenaY = 6;
            int arenaWidth = 89;
            int arenaHeight = 20;

            Arena arena = new Arena(arenaX, arenaY, arenaWidth, arenaHeight);
            Snake snake = new Snake(5, new Point(10, 10));
            Scoring scoring = new Scoring();

            _gameManager = new GameManager(arena, snake, scoring);
        }

        static void Main(string[] args)
        {
            _displayManager.PrepareGameWindow();
            _displayManager.DrawTitle();

            MenuPosition option = MenuLoop();

            switch(option)
            {
                case MenuPosition.NewGame:
                    GameLoop();
                    break;

                case MenuPosition.Exit:
                    return;
            }
        }

        static MenuPosition MenuLoop()
        {
            Menu menu = new Menu();

            bool displayMenu = true;
            while (displayMenu)
            {
                _displayManager.DrawMenu(menu);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch(keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        menu.Previous();
                        Console.Beep(1500, 150);
                        break;

                    case ConsoleKey.DownArrow:
                        menu.Next();
                        Console.Beep(1500, 150);
                        break;

                    case ConsoleKey.Enter:
                        displayMenu = false;
                        break;
                }
            }

            return menu.ActiveOption;
        }

        static void GameLoop()
        {
            Console.Clear();

            _displayManager.DrawScores(_gameManager.Scoring);
            _displayManager.DrawArenaAndSnake(_gameManager.Arena, _gameManager.Snake);

            bool runGame = true;
            while (runGame)
            {
                _displayManager.DrawScores(_gameManager.Scoring, true);
                _displayManager.DrawArenaAndSnake(_gameManager.Arena, _gameManager.Snake, true);

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
                    }
                }

                runGame = _gameManager.MoveSnake();

                Thread.Sleep(60);
            }
        }
    }
}
