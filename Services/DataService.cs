using H1_Webshop.Classes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static H1_Webshop.Classes.ProductClass;
using static System.Reflection.Metadata.BlobBuilder;

namespace H1_Webshop.Services
{
    public class DataService
    {
        const string ConnectionString = "";

        public List<ProductData> Products { get; set; } = new List<ProductData>();
        public List<GenreData> Genres { get; set; } = new List<GenreData>();
        public BasketClass Basket { get; set; } = new BasketClass();

        public DataService()
        {
            LoadData();
        }

        public void LoadData()
        {
            if (String.IsNullOrWhiteSpace(ConnectionString) && ConnectedToDatabase(ConnectionString)) // We first test the string as it is faster than testing the connection
            {
                // Database logic
                return;
            }


            CreateDummyData();
        }

        private bool ConnectedToDatabase(string connectionString)
        {
            return false;
        }

        private void CreateDummyData()
        {
            DummyDataProductCategories();
            DummyDataProducts();
        }

        private void DummyDataProductCategories()
        {
            Genres.Add(new ProductClass.GenreData
            {
                Id = 0,
                Title = "All",
            });


            Genres.Add(new ProductClass.GenreData
            {
                Id = 1,
                Title = "Science Fiction",
            });

            Genres.Add(new ProductClass.GenreData
            {
                Id = 2,
                Title = "Mystery",
            });

            Genres.Add(new ProductClass.GenreData
            {
                Id = 3,
                Title = "Romance",
            });

            Genres.Add(new ProductClass.GenreData
            {
                Id = 4,
                Title = "Fantasy",
            });
        }

        private void DummyDataProducts()
        {
            double[] priceArray = new double[] { 5.99, 7.99, 10.99, 99.99, 15.99 };
            Random random = new Random();

            // Add science fiction
            Products.Add(new ProductData
            {
                SKU = 1,
                Title = "Dune",
                Description = "A classic science fiction novel about a desert planet and a noble family's struggle for power",
                Author = "Frank Herbert",
                ISBN = "9780441172719",
                GenreID = 1,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 2,
                Title = "Ender's Game",
                Description = "A military science fiction novel about a child prodigy's training to fight an alien race",
                Author = "Orson Scott Card",
                ISBN = "9780812550702",
                GenreID = 1,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 3,
                Title = "The Hitchhiker's Guide to the Galaxy",
                Description = "A humorous science fiction novel about an alien's adventures across the universe",
                Author = "Douglas Adams",
                ISBN = "9780345391803",
                GenreID = 1,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });




            // Add mystery
            Products.Add(new ProductData
            {
                SKU = 4,
                Title = "The Da Vinci Code",
                Description = "A mystery novel about a symbologist's search for the Holy Grail",
                Author = "Dan Brown",
                ISBN = "9780385504201",
                GenreID = 2,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 5,
                Title = "Murder on the Orient Express",
                Description = "A murder mystery novel about a detective's investigation on a luxury train",
                Author = "Agatha Christie",
                ISBN = "9780062073501",
                GenreID = 2,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 6,
                Title = "The Girl with the Dragon Tattoo",
                Description = "A mystery thriller novel about a journalist and a computer hacker's investigation into a wealthy family's secrets",
                Author = "Stieg Larsson",
                ISBN = "9780307949486",
                GenreID = 2,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });



            // Add romance
            Products.Add(new ProductData
            {
                SKU = 7,
                Title = "Pride and Prejudice",
                Description = "A classic romance novel about the relationship between Elizabeth Bennet and Mr. Darcy",
                Author = "Jane Austen",
                ISBN = "9780141439518",
                GenreID = 3,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 8,
                Title = "Outlander",
                Description = "A time-travel romance novel about a World War II nurse who finds herself in 18th century Scotland",
                Author = "Diana Gabaldon",
                ISBN = "9780385319959",
                GenreID = 3,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 9,
                Title = "The Notebook",
                Description = "A romance novel about a man who reads a love story to a woman with Alzheimer's disease",
                Author = "Nicholas Sparks",
                ISBN = "9780446698346",
                GenreID = 3,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });




            // Add fantasy
            Products.Add(new ProductData
            {
                SKU = 10,
                Title = "The Lord of the Rings",
                Description = "A classic high fantasy novel about hobbits, wizards, and a quest to destroy the One Ring",
                Author = "J.R.R. Tolkien",
                ISBN = "978-0544003415",
                GenreID = 4,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 11,
                Title = "A Song of Ice and Fire",
                Description = "A series of epic fantasy novels set in a medieval-inspired world full of political intrigue, dragons, and magic",
                Author = "George R.R. Martin",
                ISBN = "978-0553801477",
                GenreID = 4,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 12,
                Title = "The Name of the Wind",
                Description = "A novel about a young man who becomes a legendary wizard, set in a world of magic and music",
                Author = "Patrick Rothfuss",
                ISBN = "978-0756404741",
                GenreID = 4,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 13,
                Title = "The Lies of Locke Lamora",
                Description = "A novel about a group of thieves in a fantastical city, blending elements of fantasy and crime fiction",
                Author = "Scott Lynch",
                ISBN = "978-0553588941",
                GenreID = 4,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

            Products.Add(new ProductData
            {
                SKU = 14,
                Title = "The Wheel of Time",
                Description = "A series of epic fantasy novels about a group of adventurers on a quest to defeat the dark lord who threatens their world",
                Author = "Robert Jordan",
                ISBN = "978-0812511819",
                GenreID = 4,
                Price = priceArray[random.Next(0, priceArray.Length)],
            });

        }
    }
}