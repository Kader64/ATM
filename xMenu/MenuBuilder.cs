using System.Text;

namespace xMenu
{
    public class MenuBuilder
    {
        private List<Title> Titles;
        private List<Option> Options;
        private List<TextLine> Textlines;
        public string pointerColor { get; set; } = "\x1b[36m"; 
        private int chosenOption = 0;

        public MenuBuilder()
        {
            Titles = new List<Title>();
            Options = new List<Option>();
            Textlines = new List<TextLine>();
        }

        public MenuBuilder(List<Title> titles, List<Option> options, List<TextLine> textLines)
        {
            Titles = titles;
            Options = options;
            Textlines = textLines;
        }

        public void Add(Title title)
        {
            Titles.Add(title);
        }
        public void Add(Option option)
        {
            Options.Add(option);
        }
        public void Add(TextLine textline)
        {
            Textlines.Add(textline);
        }

        public void run()
        {
            bool running = true;
            while (running)
            {
                Console.SetCursorPosition(0, 0);
                StringBuilder bob = new StringBuilder();

                for(int i = 0; i < Titles.Count; i++)
                {
                    bob.Append(Titles[i].Build()+"\n");
                }

                for(int i=0; i < Textlines.Count; i++)
                {
                    bob.Append(Textlines[i].Build()+"\n");
                }

                for (int i = 0; i < Options.Count; i++)
                {
                    bob.Append(Options[i].Build());
                    if (i == chosenOption)
                    {
                        bob.Append(pointerColor+" ◄");
                    }
                    else
                    {
                        bob.Append("  ");
                    }
                    bob.Append("\n\n");
                }

                Console.Write(bob);
                Console.ForegroundColor = ConsoleColor.Black;

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (chosenOption < Options.Count - 1)
                        {
                            chosenOption++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (chosenOption > 0)
                        {
                            chosenOption--;
                        }
                        break;
                    case ConsoleKey.Enter: running = false; break;
                }
            }
            Options[chosenOption].Select();
        }
    }
}