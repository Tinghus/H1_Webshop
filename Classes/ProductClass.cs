using H1_Webshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Classes
{
    public class ProductClass
    {
        public DataService Data { get; set; }

        public List<ProductClass.ProductData> GetFilteredProductList(List<ProductData> productList, GenreData filterByGenre)
        {
            if (filterByGenre.Title.ToLower() == "all")
            {
                return productList;
            }

            List<ProductClass.ProductData> filteredProducts = new List<ProductClass.ProductData>();

            return productList.Where(product => product.GenreID == filterByGenre.Id).ToList();
        }

        public GenreData GetGenreFromID(int genreID)
        {
            return Data.Genres.FirstOrDefault(genre => genre.Id == genreID);
        }


        public class ProductData
        {
            public int SKU { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public int GenreID { get; set; }
            public double Price { get; set; }
            private int _stockCount { get; set; }
            public bool InStock => _stockCount > 0;

        }

        public class GenreData
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}

