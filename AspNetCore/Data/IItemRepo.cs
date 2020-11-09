using System.Collections.Generic;
using AspNetCore.Models;

namespace AspNetCore.Data
{
    public interface IItemRepo
    {
        bool SaveChanges();
        IEnumerable<Item> GetAllItems();
        Item GetItemById(int id);
        Item CreateItem(string desc);
        void DeleteItem(Item item);
        void Updateitem(Item item);
    }
}