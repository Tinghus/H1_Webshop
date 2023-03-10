using H1_Webshop.Classes;
using H1_Webshop.Forms;
using H1_Webshop.Services;

namespace H1_Webshop
{
    internal class Program
    {
        static MenuClass Menu = new MenuClass();
        static UiClass Ui = new UiClass();
        static DataService Data = new DataService();
        static ProductClass Product = new ProductClass();
        static BasketClass Basket = new BasketClass();

        static PaymentForm Paymentform = new PaymentForm();

        static void Main(string[] args)
        {
            BuildReferences();
            Ui.CurrentViewModel = UiClass.ViewModels.Shop;
            Menu.GenreFilter = Data.Genres[0];

            while (true)
            {
                Menu.NavigateMenu();
            }

        }

        static void BuildReferences()
        {
            Menu.Ui = Ui;
            Menu.Data = Data;
            Menu.Product = Product;
            Menu.Basket = Basket;

            Ui.Menu = Menu;
            Ui.Product = Product;
            Ui.Data = Data;
            Ui.Payment = Paymentform;
            Ui.Basket = Basket;

            Product.Data = Data;

            Paymentform.Ui = Ui;

            // Basket.Data = Data;
        }
    }
}