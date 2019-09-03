using System;
using System.Collections.Generic;
using clrcore3starter.Models;

namespace clrcore3starter.Repository
{
    public class ItemsRepository: IItemRepository
    {
        public ItemsRepository()
        {
        }

        public Item GetItem(string itemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
