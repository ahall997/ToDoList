using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Models;

namespace AspNetCore.Data
{
    public class ItemRepo : IItemRepo
    {

        private static List<Item> items = new List<Item> {
            new Item{ Id=0, Description = "These are dummy tasks"},
            new Item{ Id=1, Description = "Incase of sql server errors" }
        };

        private readonly ItemContext _context;

        public ItemRepo(ItemContext context)
        {
            _context = context;
        }

        public Item CreateItem(string desc)
        {   
            Item newItem = new Item();
            newItem.Description = desc;
            newItem.Completed = false;

            try{
                _context.Items.Add(newItem);
                _context.SaveChanges(); 
                
            }
            catch(Exception ex) {
                newItem.Id = items.Max(c => c.Id) +1;
                items.Add(newItem);
                return newItem;
            }
            return newItem;

        }

        public void DeleteItem(Item item)
        {
            try{
                _context.Items.Remove(item);
            }
            catch(Exception ex) {
                items.Remove(item);
                return;
            }
            _context.SaveChanges();
        }

        public IEnumerable<Item> GetAllItems()
        {
            try{
                return _context.Items.ToList();
            }
            catch(Exception ex) {
                return items;
            }
        }

        public Item GetItemById(int id)
        {
            try{
                return _context.Items.FirstOrDefault(c => c.Id == id);
            }
            catch(Exception ex) {
                return items.FirstOrDefault(c => c.Id == id);
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() != 0);
        }

        public void Updateitem(Item item)
        {
            var incomingItem = item;
            incomingItem.Completed = !item.Completed;

            try{
                _context.Entry(incomingItem).CurrentValues.SetValues(incomingItem);
            }
            catch(Exception ex){
                items[item.Id] = incomingItem;
            }
        }
    }
}