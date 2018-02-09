using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;


namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {

        class ModelCompleteFakeRepostory : IRepository
        {


            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
                //nothing
            }
        }






        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelISComplete(Product[] products)
        {
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepostory()
            {
                Products = products
            };
        
        
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        class ModelCompleteFakeRepositoryPricesUnder50: IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                new Product { Name = "P1", Price=5M },
                new Product { Name = "P2", Price=48.95M },
                new Product { Name = "P3", Price=19.50M },
                new Product { Name = "P3", Price=34.95M }
            };
            public void AddProduct(Product p)
            {
                //nothing
            }
        }

        [Fact]
        public void IndexActionModelIsCompletePricesUnder50()
        {
            var controller = new HomeController(); controller.Repository = new ModelCompleteFakeRepositoryPricesUnder50();
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((P1, P2) => P1.Name == P2.Name && P1.Price == P2.Price)); 
        }

    }
}
