using H1_Webshop.Classes;


namespace H1_Webshop
{
    internal class Program
    {
        static MenuClass Menu = new MenuClass();
        static UiClass Ui = new UiClass();

        static void Main(string[] args)
        {
            BuildReferences();
            
            while (true)
            {
                Menu.NavigateMenu();
            }

        }

        static void BuildReferences ()
        {
            Menu.Ui = Ui;
        }
    }
}