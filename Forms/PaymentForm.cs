using H1_Webshop.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Forms
{
    public class PaymentForm
    {

        public void ShowForm(int formPosTop)
        {
            Console.CursorTop = formPosTop;
            int cursorPosLeft = 12;
            AddressClass address = new AddressClass();


            Console.WriteLine(
                "Name: \n" +
                "Phonenumber: \n" +
                "Street: \n" +
                "Postcode: \n" +
                "City: \n"
                );

            // Get Name
            while (true)
            {

            }

        }

    }
}
