using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Classes
{
    public class UiClass
    {

        public void ShowMenu(List<MenuClass.MenuItem> menuItems, int activeItem)
        {
            if(menuItems.Count <= 0)
            {
                return;
            }

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == activeItem)
                {
                    ApplyEffect(menuItems[i].Text, Effects.ActiveMenuItem);
                }
                else
                {
                    Console.WriteLine(menuItems[i].Text);
                }
            }

        }

        public void ShowHorizontalDivider()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
        }

        public void ApplyEffect(string output, Effects effect, bool newLine = false)
        {
            ConsoleColor foregroundStart = Console.ForegroundColor;
            ConsoleColor backgroundStart = Console.BackgroundColor;

            switch (effect)
            {
                case Effects.ActiveMenuItem:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
            }

            Console.Write(output);

            if(newLine)
            {
                Console.WriteLine();
            }

            Console.ForegroundColor = foregroundStart;
            Console.BackgroundColor = backgroundStart;
        }

        public void ApplyViewModel(ViewModels viewModel) 
        { 
        }

        public enum Effects
        {
            ActiveMenuItem,
        }

           
        public enum ViewModels
        {
            Welcome,
            Shop,
            Basket,
            Order,
        }

    }
}
