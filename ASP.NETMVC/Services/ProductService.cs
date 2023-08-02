using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class ProductService :List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]
            {
                new ProductModel(){Id= 1,Name = "IPHONEX", Price = 1000},
                new ProductModel(){Id= 2,Name = "IPHONE11", Price = 2000},
                new ProductModel(){Id= 3,Name = "IPHONE12", Price = 3000},
                new ProductModel(){Id= 4,Name = "IPHONE13", Price = 4000},
            });
        }
    }
}
