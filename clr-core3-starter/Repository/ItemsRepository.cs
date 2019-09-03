using clr_core3_starter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clr_core3_starter.Repository
{
    public class ItemsRepository: IItemsRepository
    {
        private readonly MesDbContext _Context;
        private readonly ILogger _Logger;

        public ItemsRepository(MesDbContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("ItemsRepository");
        }

        public async Task<Item> GetItemAsync(string itemId)
        {
            return await _Context.Items.Where(s => s.ItemId == itemId).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await _Context.Items.OrderBy(s => s.ItemId).ToListAsync();
        }
    }
}
