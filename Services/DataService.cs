using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Webshop.Services
{
    public class DataService
    {
        public List<ProductService.ProductCatogoryObject> ProductCategories { get; set; } = new List<ProductService.ProductCatogoryObject>();

        public DataService() 
        { 
            
        }

        public void LoadData()
        {
            if(false)
            {
                return;
            }


        }

        private void CreateDummyData()
        {
            DummyDataProductCategories();
        }

        private void DummyDataProductCategories()
        {
            ProductCategories.Add(new ProductService.ProductCatogoryObject
            {
                Id = 0,
                Name = "Test_1",
                Text = "Test 1",
            });

            ProductCategories.Add(new ProductService.ProductCatogoryObject
            {
                Id = 1,
                Name = "Test_2",
                Text = "Test 2",
            });

            ProductCategories.Add(new ProductService.ProductCatogoryObject
            {
                Id = 2,
                Name = "Test_3",
                Text = "Test 1",
            });
        }

    }
}
