namespace Ads
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    class Program
    {
        static void Main()
        {
            var context = new AdsEntities();
            var ads = context.Ads;
            //Problem 1
                  
            //AllAdsWithoutIncluding(ads);
            //AllAdsWithIncluding(ads);

            //Problem 2

            //AdsInvokeToList(ads);
            //AdsWithoutInvokeToList(ads);

            //Problem 3.

            //take all information in table Ads
            //foreach (var ad in ads)
            //{
            //    Console.WriteLine(ad.Title);
            //    Console.WriteLine();
            //}

            //take only Title in table Ads
            foreach (var ad in ads.Select(e => e.Title))
            {
                Console.WriteLine(ad);
                Console.WriteLine();
            }
        }

        private static void AdsWithoutInvokeToList(DbSet<Ad> ads)
        {
            foreach (var ad in ads//without ToList()
                .Where(e => e.AdStatus.Status == "Published")
                .OrderBy(e => e.Date)
                .Select(e => new
                {                   
                    Title = e.Title,
                    Category = e.Category,
                    Town = e.Town
                })
               .ToList())
            {
                Console.WriteLine("Title: {0}\n\rCategory: {1}\n\rTown: {2}",
                   ad.Title,
                   ad.Category == null ? "No category" : ad.Category.Name,
                   ad.Town == null ? "No town" : ad.Town.Name);
                Console.WriteLine();
            }
        }
        private static void AdsInvokeToList(DbSet<Ad> ads)
        {
            foreach (var ad in ads.ToList()//Invoke ToList()
                .Where(e => e.AdStatus.Status == "Published")
                .OrderBy(e => e.Date)
                .Select(e => new
                {
                    Title = e.Title,
                    Category = e.Category,
                    Town = e.Town
                })
               .ToList())
            {
                Console.WriteLine("Title: {0}\n\rCategory: {1}\n\rTown: {2}",
                   ad.Title,
                   ad.Category == null ? "No category" : ad.Category.Name,
                   ad.Town == null ? "No town" : ad.Town.Name);
                Console.WriteLine();
            }
        }

        private static void AllAdsWithIncluding(DbSet<Ad> ads)
        {
            foreach (var ad in ads.
                Include(e => e.AspNetUser).
                Include(e => e.Category).
                Include(e => e.AdStatus).
                Include(e => e.Town)
                )
            {
                Console.WriteLine("Title: {0}\n\rStatus: {1}\n\rCategory: {2}\n\rTown: {3}\n\rUser: {4}",
                   ad.Title,
                   ad.AdStatus.Status,
                   ad.Category == null ? "No category" : ad.Category.Name,
                   ad.Town == null ? "No town" : ad.Town.Name,
                   ad.AspNetUser.Name);
                Console.WriteLine();
            }
        }

        private static void AllAdsWithoutIncluding(System.Data.Entity.DbSet<Ad> ads)
        {
            foreach (var ad in ads)
            {
                Console.WriteLine("Title: {0}\n\rStatus: {1}\n\rCategory: {2}\n\rTown: {3}\n\rUser: {4}",
                   ad.Title,
                   ad.AdStatus.Status,
                   ad.Category == null ? "No category" : ad.Category.Name,
                   ad.Town == null ? "No town" : ad.Town.Name,
                   ad.AspNetUser.Name);
                Console.WriteLine();
            }
        }
    }
}
