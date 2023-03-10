using H1_Webshop.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H1_Webshop.Classes;
using H1_Webshop.Services;

namespace H1_Webshop.Forms
{
    public class PaymentForm
    {
        SelectForm selectForm = new SelectForm();
        public OrderService Order { get; set; }

        public UiClass Ui { get; set; }

        public void ShowForm(int formPosTop)
        {
            AddressClass address = new AddressClass();
            int cursorPosLeft = 16;
            bool leavePaymentForm = false;

            while (!leavePaymentForm)
            {
                Console.CursorTop = formPosTop;
                Console.CursorVisible = true;

                Console.WriteLine(
                    "Name: \n" +
                    "Phonenumber: \n" +
                    "Street: \n" +
                    "Postcode: \n" +
                    "City: \n"
                    );

                // Get Name
                string name = "";
                while (true)
                {
                    clearLine(formPosTop);
                    Console.CursorLeft = cursorPosLeft;
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter) && input.Length < 20)
                    {
                        name = input;
                        break;
                    }
                }
                address.CustomerName = name;

                // Get PhoneNumber
                string phoneNumber = "";
                while (true)
                {
                    clearLine(formPosTop + 1);
                    Console.CursorLeft = cursorPosLeft;
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit) && input.Length < 12)
                    {
                        phoneNumber = input;
                        break;
                    }
                }
                address.Phonenumber = phoneNumber;

                // Get Street
                string street = "";
                while (true)
                {
                    clearLine(formPosTop + 2);
                    Console.CursorLeft = cursorPosLeft;
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && input.Length < 24)
                    {
                        street = input;
                        break;
                    }
                }
                address.Street = street;

                // Get Postcode
                string postcode = "";
                while (true)
                {
                    clearLine(formPosTop + 3);
                    Console.CursorLeft = cursorPosLeft;
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit) && input.Length < 8)
                    {
                        postcode = input;
                        break;
                    }
                }
                address.Postcode = Convert.ToInt32(postcode);

                // Get City
                string city = "";
                while (true)
                {
                    clearLine(formPosTop + 4);
                    Console.CursorLeft = cursorPosLeft;
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input) && input.Length < 12)
                    {
                        city = input;
                        break;
                    }
                }
                address.City = city;

                Console.CursorVisible = false;

                string[] selectOptions = new string[] { "Buy items", "Back to basket", "Change address" };
                string selectFormResponse = selectForm.ShowSelectForm("Confirm Order", "", selectOptions, formPosTop + 6);


                switch (selectFormResponse)
                {
                    case "Buy items":
                        leavePaymentForm = true;
                        Ui.CurrentViewModel = UiClass.ViewModels.OrderConfirmation;
                        break;

                    case "Back to basket":
                        leavePaymentForm = true;
                        Ui.CurrentViewModel = UiClass.ViewModels.Basket;
                        // Todo add logic to take us directly back to basket view
                        break;

                    case "Change address":
                        leavePaymentForm = false;
                        break;
                }

            };

        }

        private void clearLine(int posTop)
        {
            Console.CursorTop = posTop;
            Console.CursorLeft = 14;
            Console.Write("                              ");
        }

    }
}
