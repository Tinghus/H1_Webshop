using H1_Webshop.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Services
{
    public class OrderService
    {
        public DataService Data { get; set; }

        public void PlaceOrder(AddressClass address, BasketClass basket)
        {
            OrderData newOrder = new OrderData
            {
                Address = address,
                Basket = basket,
            };

            Data.Orders.Add(newOrder);
        }

        public class OrderData
        {
            public AddressClass Address { get; set; } = new AddressClass();
            public BasketClass Basket { get; set; } = new BasketClass();
        }


    }
}
