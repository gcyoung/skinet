using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if ( ! context.ProductBrands.Any())
                {
                    var data = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(data);

                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();

                }

                if ( ! context.ProductTypes.Any() )
                {
                    var data = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(data);

                    foreach(var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();

                }

                if ( ! context.Products.Any() )
                {
                    var data = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var models = JsonSerializer.Deserialize<List<Product>>(data);

                    foreach(var item in models)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();

                }

            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}