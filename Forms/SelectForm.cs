using H1_Webshop.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Forms
{
    public class SelectForm
    {
        public string ShowSelectForm(string title, string textBody, string[] options, int cursorPosTop)
        {
            UiClass Ui = new UiClass();
            int optionSelected = 0;

            while (true)
            {
                Console.CursorTop = cursorPosTop;

                Console.WriteLine(title);
                Console.WriteLine(textBody);

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == optionSelected)
                    {
                        Ui.ApplyEffect(options[i], UiClass.Effects.ActiveMenuItem, true);
                    }
                    else
                    {
                        Console.WriteLine(options[i]);
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (optionSelected > 0)
                        {
                            optionSelected--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (optionSelected < options.Length - 1)
                        {
                            optionSelected++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        return options[optionSelected];
                }
            }

        }
    }
}
