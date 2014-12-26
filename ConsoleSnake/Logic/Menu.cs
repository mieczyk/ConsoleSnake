using System.Collections.Generic;
using System.Linq;

namespace ConsoleSnake.Logic
{
    public class Menu
    {
        private SortedDictionary<MenuPosition, string> _options;

        public SortedDictionary<MenuPosition, string> Options
        {
            get { return _options; }
        }

        public MenuPosition ActiveOption { get; private set; }

        public Menu()
        {
            _options = new SortedDictionary<MenuPosition, string>();

            _options.Add(MenuPosition.SinglePlayer, "Single Player");
            _options.Add(MenuPosition.Exit, "Exit");

            ActiveOption = MenuPosition.SinglePlayer;
        }

        public bool Next()
        {
            int lastIndex = (int)_options.Last().Key;

            if ((int)ActiveOption == lastIndex)
                return false;

            ActiveOption++;

            return true;
        }

        public bool Previous()
        {
            if ((int)ActiveOption == 1)
                return false;

            ActiveOption--;

            return true;
        }
    }
}
