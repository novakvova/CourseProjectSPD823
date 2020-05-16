using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!catalogContext.CatalogBrands.Any())
                {
                    catalogContext.CatalogBrands.AddRange(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogTypes.Any())
                {
                    catalogContext.CatalogTypes.AddRange(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogItems.Any())
                {
                    catalogContext.CatalogItems.AddRange(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand("Adidas"),
                new CatalogBrand("Nike"),
                new CatalogBrand("Balenciaga"),
                new CatalogBrand("Puma"),
                new CatalogBrand("Інше")
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType("Літнє"),
                new CatalogType("Зимове"),
                new CatalogType("Весняне"),
                new CatalogType("Осіннє")
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem(2,2, "Куртка Nike зимова з капюшоном", "Куртка Nike зимова з капюшоном", 3500M,  "http://13.84.212.103:100/images/products/1.png"),
                new CatalogItem(1,2, "Кеди Nike", "Кеди Nike", 800, "http://13.84.212.103:100/images/products/2.png"),
                new CatalogItem(2,5, "Зимове взуття", "Зимове взуття", 1200,  "http://13.84.212.103:100/images/products/3.png"),
                new CatalogItem(2,2, "Кросівки Nike зимові", "Кросівки Nike зимові", 1500, "http://13.84.212.103:100/images/products/4.png"),
                new CatalogItem(3,5, "Футболка біла", "Футболка біла", 259, "http://13.84.212.103:100/images/products/5.png"),
                new CatalogItem(2,2, "Блакитний світшот Nike", "Блакитний світшот Nike", 1200, "http://13.84.212.103:100/images/products/6.png"),
                new CatalogItem(2,5, "Червона футболка", "Червона футболка",  250, "http://13.84.212.103:100/images/products/7.png"),
                new CatalogItem(2,5, "Фіолетовий світшот", "Фіолетовий світшот", 350.5M, "http://13.84.212.103:100/images/products/8.png"),
                new CatalogItem(1,5, "Босоніжки жіночі", "Босоніжки жіночі", 750, "http://13.84.212.103:100/images/products/9.png"),
                new CatalogItem(3,2, "Кеди Nike чоловічі", "Кеди Nike чоловічі", 2300, "http://13.84.212.103:100/images/products/10.png"),
                new CatalogItem(3,2, "Галоші Nike", "Галоші Nike", 200.5M, "http://13.84.212.103:100/images/products/11.png"),
                new CatalogItem(2,5, "Кирзові чоботи", "Кирзові чоботи", 300, "http://13.84.212.103:100/images/products/12.png")
            };
        }
    }
}
