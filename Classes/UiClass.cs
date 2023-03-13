using H1_Webshop.Forms;
using H1_Webshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Classes
{
    public class UiClass
    {
        public MenuClass Menu { get; set; }
        public ProductClass Product { get; set; }
        public DataService Data { get; set; }
        public PaymentForm Payment { get; set; }
        public BasketClass Basket { get; set; }
        public ViewModels CurrentViewModel { get; set; }


        public void ShowMenu(List<MenuClass.MenuItem> menuItems, int activeItem)
        {
            if (menuItems.Count <= 0)
            {
                return;
            }

            Console.Clear();
            int cursorPosLeft = 0;

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.CursorLeft = cursorPosLeft;

                if (i == activeItem && !Menu.SubMenuIsActive)
                {
                    ApplyEffect(menuItems[i].Text, Effects.ActiveMenuItem);
                }
                else if (i == activeItem && Menu.SubMenuIsActive)
                {
                    ApplyEffect(menuItems[i].Text, Effects.ActiveSubMenuItem);
                }
                else
                {
                    Console.Write(menuItems[i].Text);
                }

                cursorPosLeft += 12;
            }


            Console.WriteLine();
            ShowHorizontalDivider();

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

                case Effects.ActiveSubMenuItem:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
            }

            Console.Write(output);

            if (newLine)
            {
                Console.WriteLine();
            }

            Console.ForegroundColor = foregroundStart;
            Console.BackgroundColor = backgroundStart;
        }

        public void ApplyViewModel(ViewModels viewModel, int cursorStartPosTop)
        {
            // We take viewModel as paramater instead of just taking it from CurrentViewModel so that it is easier for us to apply custom logic if needed

            Console.CursorTop = cursorStartPosTop;
            Console.CursorLeft = 0;

            switch (viewModel)
            {
                case ViewModels.Shop:
                    ApplyShopView();
                    break;

                case ViewModels.Basket:
                    ApplyBasketView();
                    break;

                case ViewModels.Payments:
                    ApplyPaymentView();
                    break;
            }
        }

        public void ApplyPaymentView()
        {
            Console.WriteLine("Payment \n");
            Payment.ShowForm(4);
        }

        private void ApplyShopView()
        {
            List<ProductClass.ProductData> products = Product.GetFilteredProductList(Data.Products, Menu.GenreFilter);

            ApplyShopViewHeader();

            for (int i = 0; i < products.Count; i++)
            {
                string output =
                    Product.GetGenreFromID(products[i].GenreID).Title.PadRight(18) +
                    LimitStringLength(products[i].Title, 38).PadRight(40) +
                    LimitStringLength(products[i].Author, 18).PadRight(20) +
                    (products[i].Price.ToString("0.00").PadRight(5) + " USD").PadRight(12) +
                    Data.Basket.GetProductCountFromBasket(products[i]).ToString().PadRight(11) +
                    products[i].ISBN.PadRight(16);

                if (Menu.HoveredSubMenu - 1 == i)
                {
                    ApplyEffect(output, Effects.ActiveMenuItem, true);
                }
                else
                {
                    Console.WriteLine(output);
                }
            }
        }

        private string LimitStringLength(string input, int maxLength)
        {
            return (input?.Length > maxLength) ? input.Substring(0, maxLength) : input;
        }

        private void ApplyShopViewHeader()
        {
            Console.WriteLine("Enter to access submenu, Arrow keys to change filter, + to add products to cart \n");

            Console.Write("Filter: ");

            int maxWidth = 18;

            int spaces = maxWidth - Menu.GenreFilter.Title.Length;
            int leftPadding = spaces / 2;
            int rightPadding = spaces - leftPadding;

            if (Menu.HoveredSubMenu == 0 && Menu.SubMenuIsActive)
            {
                ApplyEffect("<" + new string(' ', leftPadding) + Menu.GenreFilter.Title + new string(' ', rightPadding) + ">", Effects.ActiveMenuItem, false);
            }
            else
            {
                Console.Write("<" + new string(' ', leftPadding) + Menu.GenreFilter.Title + new string(' ', rightPadding) + ">");
            }

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(
                "Genre".PadRight(18) +
                "Title".PadRight(40) +
                "Author".PadRight(20) +
                "Price".PadRight(12) +
                "In Basket".PadRight(11) +
                "ISBN".PadRight(16)
                );
        }

        private void ApplyBasketView()
        {
            if (Data.Basket.Products.Count == 0)
            {
                Console.WriteLine("Basket is empty");
                Menu.SubMenuIsActive = false;
                return;
            }


            Console.WriteLine(
                "Title".PadRight(40) +
                "Quantity".PadRight(12) +
                "Unit Price".PadRight(12) +
                "Total Price"
                );


            for (int i = 0; i < Data.Basket.Products.Count; i++)
            {
                BasketClass.BasketData product = Data.Basket.Products[i];

                string output =
                    LimitStringLength(product.Product.Title, 38).PadRight(40) +
                    product.ProductCount.ToString().PadRight(12) +
                    product.Product.Price.ToString("0.00").PadRight(12) +
                    (product.Product.Price * product.ProductCount).ToString("0.00");

                if (Menu.HoveredSubMenu == i && Menu.SubMenuIsActive)
                {
                    ApplyEffect(output, Effects.ActiveMenuItem, true);
                }
                else
                {
                    Console.WriteLine(output);
                }
            }


            Console.WriteLine();
            Console.WriteLine("Totals: " + Data.Basket.GetBasketValue().ToString("0.00") + Environment.NewLine);

            if (Menu.HoveredSubMenu == Data.Basket.Products.Count)
            {
                ApplyEffect("Go to payments", Effects.ActiveMenuItem, true);
            }
            else
            {
                Console.WriteLine("Go to payments");
            }

            if (Menu.HoveredSubMenu == Data.Basket.Products.Count + 1)
            {
                ApplyEffect("Back to shopping", Effects.ActiveMenuItem, true);
            }
            else
            {
                Console.WriteLine("Back to shopping");
            }

            if (Menu.HoveredSubMenu == Data.Basket.Products.Count + 2)
            {
                ApplyEffect("Empty Basket", Effects.ActiveMenuItem);
            }
            else
            {
                Console.WriteLine("Empty Basket");
            }

        }

        public enum Effects
        {
            ActiveMenuItem,
            ActiveSubMenuItem,
        }


        public enum ViewModels
        {
            Welcome,
            Shop,
            Basket,
            Order,
            AccountInfo,
            Payments,
            OrderConfirmation,
        }

    }
}
