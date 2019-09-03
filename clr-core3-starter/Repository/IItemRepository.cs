using System;
using System.Collections.Generic;
using clrcore3starter.Models;

namespace clrcore3starter.Repository
{
    public interface IItemRepository
    {
        public Item GetItem(string itemId);
        public IEnumerable<Item> GetItems();
    }
}
