using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Classes
{
    public class BasketClass
    {
        public List<BasketData> Products { get; set; } = new List<BasketData>();

        public void AddToBasket(ProductClass.ProductData product)
        {
            BasketData? basketDataToAdd = Products.FirstOrDefault(b => b.Product == product);

            if (basketDataToAdd != null)
            {
                basketDataToAdd.ProductCount++;
            }
            else
            {
                Products.Add(new BasketData
                {
                    Product = product,
                    ProductCount = 1,
                });
            }
        }

        public void RemoveFromBasket(ProductClass.ProductData product)
        {
            BasketData? basketDataToRemove = Products.FirstOrDefault(b => b.Product == product);

            if (basketDataToRemove != null)
            {
                if (basketDataToRemove.ProductCount > 1)
                {
                    basketDataToRemove.ProductCount--;
                }
                else
                {
                    Products.Remove(basketDataToRemove);
                }
            }
        }

        public void EmptyBasket()
        {
            Products.Clear();
        }

        public double GetBasketValue()
        {
            return Products.Sum(b => b.Product.Price * b.ProductCount);
        }

        public int GetProductCountFromBasket(ProductClass.ProductData product)
        {
            BasketData? basketData = Products.FirstOrDefault(b => b.Product == product);
            return basketData?.ProductCount ?? 0;
        }

        public class BasketData
        {
            public ProductClass.ProductData Product { get; set; }
            public int ProductCount { get; set; }
        }

    }
}
