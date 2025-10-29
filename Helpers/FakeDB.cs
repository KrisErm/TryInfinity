using System.Collections.Generic;

namespace TryThree.Helpers
{
    public static class FakeDB
    {
        public static List<Product> _products = new List<Product>()
        {
            new Product { Id = 1, Name = "Телефон", Price = 25000, Quantity = 10, Color = "Черный" },
            new Product { Id = 2, Name = "Ноутбук", Price = 55000, Quantity = 5, Color = "Серебристый" },
            new Product { Id = 3, Name = "Мышка", Price = 1200, Quantity = 20, Color = "Серый" },
            new Product { Id = 4, Name = "Монитор", Price = 18000, Quantity = 8, Color = "Белый" }
        };
    }
}
