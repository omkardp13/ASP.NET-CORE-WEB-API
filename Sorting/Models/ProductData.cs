// Data/ProductData.cs
using DemoPractice.Models;
using System.Collections.Generic;
using System.Linq;

public static class ProductData
{
    private static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Product1", Price = 10.0m },
        new Product { Id = 2, Name = "Product2", Price = 20.0m },
        new Product { Id = 3, Name = "Product3", Price = 15.0m },
    };

    public static IEnumerable<Product> GetProducts(string sortBy)
    {
        switch (sortBy?.ToLower())
        {
            case "name":
                return Products.OrderBy(p => p.Name);
            case "price":
                return Products.OrderBy(p => p.Price);
            default:
                return Products.OrderBy(p => p.Id);
        }
    }
}
