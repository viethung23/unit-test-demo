namespace UnitTestDemo.Api.Data;

public class DataSeeder
{
    public static void SeedCountries(TestDbContext context)
    {
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "produc 1", Description = "Hamlet", Price = 70000 },
                new Product { Id = 2, Name = "produc 2", Description = "King Lear", Price = 40000 },
                new Product { Id = 3, Name = "produc 3", Description = "Othello", Price = 58000 },
            };
            context.AddRange(products);
            context.SaveChanges();
        }
    }
}
