using H1_Webshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Classes
{
    public class MenuClass
    {
        public UiClass Ui { get; set; }
        public DataService Data { get; set; }
        public ProductClass Product { get; set; }
        public BasketClass Basket { get; set; }

        public List<MenuItem> MenuItemList { get; set; } = new List<MenuItem>();
        public int HoveredTopMenu { get; set; } = 0;
        public bool SubMenuIsActive { get; set; } = false;
        public int HoveredSubMenu { get; set; } = 0;
        public int HoveredMenuFilter { get; set; } = 0;
        public ProductClass.GenreData GenreFilter { get; set; }

        public MenuClass()
        {
            BuildMenu();
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

            MenuItemList.Add(new MenuItem
            {
                Name = "AccountInfo",
                Text = "Account",
                RelatedViewModel = UiClass.ViewModels.AccountInfo,
            });
        }

        public void NavigateMenu()
        {
            Console.CursorVisible = false;
            Ui.ShowMenu(MenuItemList, HoveredTopMenu);
            Ui.ApplyViewModel(Ui.CurrentViewModel, 2);

            ConsoleKeyInfo key = Console.ReadKey(true);
            NavigationHandler(key);
        }

        private void NavigationHandler(ConsoleKeyInfo key)
        {

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    HorizontalNavigation(-1);
                    break;

                case ConsoleKey.RightArrow:
                    HorizontalNavigation(+1); //"+" is not needed. But we use it to make it clearer what is going on
                    break;

                case ConsoleKey.UpArrow:
                    VerticalNavigation(-1);
                    break;

                case ConsoleKey.DownArrow:
                    VerticalNavigation(+1);
                    break;

                case ConsoleKey.Enter:
                    ActivateItem();
                    break;

                case ConsoleKey.Add:
                    UpdateBasketContent(+1);
                    break;

                case ConsoleKey.Subtract:
                    UpdateBasketContent(-1);
                    break;

                case ConsoleKey.Backspace:
                    UpdateBasketContent(-1);
                    break;
            }
        }

        private int GetMenuIndex(string menuName)
        {

            for (int i = 0; i < MenuItemList.Count; i++)
            {
                if (MenuItemList[i].Name == menuName)
                {
                    return i;
                }
            }

            return 0;
        }

        private void ActivateItem()
        {
            if (SubMenuIsActive)
            {
                switch (Ui.CurrentViewModel)
                {
                    case UiClass.ViewModels.Basket:
                        if (HoveredSubMenu == Data.Basket.Products.Count)
                        {
                            Ui.CurrentViewModel = UiClass.ViewModels.Payments;
                        }

                        if (HoveredSubMenu == Data.Basket.Products.Count + 1)
                        {
                            HoveredTopMenu = GetMenuIndex("ShopView");
                            Ui.CurrentViewModel = UiClass.ViewModels.Shop;
                        }

                        if (HoveredSubMenu == Data.Basket.Products.Count + 2)
                        {
                            SubMenuIsActive = false;
                            Data.Basket.EmptyBasket();
                        }

                        HoveredSubMenu = 0;

                        break;

                    case UiClass.ViewModels.Shop:
                        UpdateBasketContent(+1);
                        break;
                }

                return;
            }

            switch (Ui.CurrentViewModel)
            {
                case UiClass.ViewModels.Shop:
                    SubMenuIsActive = true;
                    HoveredSubMenu = 0;
                    break;
            }
        }

        private void UpdateBasketContent(int modifier)
        {

            if (!SubMenuIsActive)
            {
                return;
            }

            switch (Ui.CurrentViewModel)
            {
                case UiClass.ViewModels.Shop:
                    break;

                case UiClass.ViewModels.Basket:
                    break;

                default:
                    return;
            }

            switch (Ui.CurrentViewModel)
            {
                case UiClass.ViewModels.Shop:
                    if (modifier > 0 && HoveredSubMenu > 0)
                    {
                        Data.Basket.AddToBasket(Product.GetFilteredProductList(Data.Products, GenreFilter)[HoveredSubMenu - 1]);
                    }
                    else if (modifier < 0 && HoveredSubMenu > 0)
                    {
                        Data.Basket.RemoveFromBasket(Product.GetFilteredProductList(Data.Products, GenreFilter)[HoveredSubMenu - 1]);
                    }
                    break;

                case UiClass.ViewModels.Basket:
                    if (modifier > 0)
                    {
                        Data.Basket.AddToBasket(Data.Basket.Products[HoveredSubMenu].Product);
                    }
                    else if (modifier < 0 && HoveredSubMenu <= Data.Basket.Products.Count)
                    {
                        Data.Basket.RemoveFromBasket(Data.Basket.Products[HoveredSubMenu].Product);
                    }
                    break;
            }

        }

        private void VerticalNavigation(int modifier)
        {
            if (SubMenuIsActive)
            {
                SubMenuVerticalNavigation(modifier);
                return;
            }

            switch (Ui.CurrentViewModel)
            {
                case UiClass.ViewModels.Shop:
                    if (Product.GetFilteredProductList(Data.Products, GenreFilter).Count == 0)
                    {
                        return;
                    }
                    break;

                case UiClass.ViewModels.Basket:
                    if (Data.Basket.Products.Count == 0)
                    {
                        return;
                    }
                    break;

                case UiClass.ViewModels.Order:
                    break;

                case UiClass.ViewModels.AccountInfo:
                    break;

                case UiClass.ViewModels.Payments:
                    break;

                default:
                    break;
            }

            SubMenuIsActive = true;
        }

        private void SubMenuVerticalNavigation(int modifier)
        {
            int minLimit = 0;
            int maxLimit = GetSubMenuNavigationUpperLimit();

            if (modifier < 0 && HoveredSubMenu <= minLimit)
            {
                SubMenuIsActive = false;
                return;
            }

            if (modifier > 0 && HoveredSubMenu >= maxLimit)
            {
                return;
            }

            HoveredSubMenu += modifier;
        }

        private int GetSubMenuNavigationUpperLimit()
        {
            switch (Ui.CurrentViewModel)
            {
                case UiClass.ViewModels.Welcome:
                    break;

                case UiClass.ViewModels.Shop:
                    return Product.GetFilteredProductList(Data.Products, GenreFilter).Count;

                case UiClass.ViewModels.Basket:
                    return Data.Basket.Products.Count + 2;

                case UiClass.ViewModels.Order:
                    break;

                case UiClass.ViewModels.AccountInfo:
                    break;
            }

            return 0;
        }

        private void HorizontalNavigation(int modifier)
        {
            int maxLimit = MenuItemList.Count - 1;
            int minLimit = 0;
            int currentItem = HoveredTopMenu;

            if (SubMenuIsActive)
            {
                SubMenuHorizontalNavigation(modifier);
                return;
            }

            if (modifier < 0 && currentItem <= minLimit)
            {
                return;
            }

            if (modifier > 0 && currentItem >= maxLimit)
            {
                return;
            }

            HoveredSubMenu = 0;
            SubMenuIsActive = false;
            HoveredTopMenu += modifier;
            Ui.CurrentViewModel = MenuItemList[HoveredTopMenu].RelatedViewModel;
        }



        private void SubMenuHorizontalNavigation(int modifier)
        {
            // Allows us to apply seperate logic depending on the context menu

            switch (Ui.CurrentViewModel)
            {
                case UiClass.ViewModels.Welcome:
                    break;

                case UiClass.ViewModels.Shop:
                    ChangeProductFilter(modifier);
                    break;

                case UiClass.ViewModels.Basket:
                    break;

                case UiClass.ViewModels.Order:
                    break;

                case UiClass.ViewModels.AccountInfo:
                    break;

                default:
                    break;
            }
        }

        private void ChangeProductFilter(int modifier)
        {
            int minLimit = 0;
            int maxLimit = Data.Genres.Count - 1;

            if (modifier < 0 && HoveredMenuFilter <= minLimit)
            {
                return;
            }

            if (modifier > 0 && HoveredMenuFilter >= maxLimit)
            {
                return;
            }

            HoveredMenuFilter += modifier;
            HoveredSubMenu = HoveredSubMenu > 0 ? 1 : 0; // We need to reset the selected submenu item when we change the filter
            GenreFilter = Data.Genres[HoveredMenuFilter];
        }

        public class MenuItem
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public UiClass.ViewModels RelatedViewModel { get; set; }
        }

    }
}
