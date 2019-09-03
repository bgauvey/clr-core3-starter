using clr_core3_starter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clr_core3_starter.Repository
{
    public class MesDbSeeder
    {
        readonly ILogger _Logger;

        public MesDbSeeder(ILoggerFactory loggerFactory)
        {
            _Logger = loggerFactory.CreateLogger("MesDbSeederLogger");
        }

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            //Based on EF team's example at https://github.com/aspnet/MusicStore/blob/dev/samples/MusicStore/Models/SampleData.cs
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var mesDb = serviceScope.ServiceProvider.GetService<MesDbContext>();
                if (await mesDb.Database.EnsureCreatedAsync())
                {
                    if (!await mesDb.Items.AnyAsync())
                    {
                        await InsertItemsSampleData(mesDb);
                    }
                }
            }
        }

        public async Task InsertItemsSampleData(MesDbContext db)
        {
            var items = GetItems();
            db.Items.AddRange(items);
            try
            {
                int numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation(@"Saved {numAffected} states");
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(MesDbSeeder)}: " + exp.Message);
                throw;
            }
        }

        private List<Item> GetItems()
        {
            var items = new List<Item>
            {
                new Item { ItemDesc = "PANEL TOP WICK", ItemId = "73012345" },
            };

            return items;
        }

    }
}
