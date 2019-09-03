using System.Collections.Generic;
using System.Threading.Tasks;
using clr_core3_starter.Models;

namespace clr_core3_starter.Repository
{
    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(string itemId);
        Task<List<Item>> GetItemsAsync();
    }
}
