using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Classes
{
    public class MenuClass
    {
        public UiClass Ui { get; set; }

        public List<MenuItem> MenuItemList { get; set; } = new List<MenuItem>();
        public int HoveredTopMenu { get; set; } = 0;
        public bool IsSubMenuActive { get; set; } = false;
        public MenuClass() 
        {
            BuildMenu();
            Console.CursorVisible = false;
            ConsoleKeyInfo key = Console.ReadKey(true);



        }

        public void BuildMenu()
        {
            MenuItemList.Add(new MenuItem
            {
                Name = "ShopView",
                Text = "Shop",
                RelatedViewModel = UiClass.ViewModels.Shop,
            });

            MenuItemList.Add(new MenuItem
            {
                Name = "BasketView",
                Text = "Basket",
                RelatedViewModel = UiClass.ViewModels.Basket,
            });
        }

        public void NavigateMenu()
        {
            Ui.ShowMenu(MenuItemList,HoveredTopMenu);
        }


        public class MenuItem
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public UiClass.ViewModels RelatedViewModel { get; set; }
        }

    }
}
