using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Warehouse
{
    public class InventoryManager
    {
        public Dictionary<string, int> Items = new Dictionary<string, int>();
        public void AddItem(string itemName, int quantity)
        {
            if (string.IsNullOrWhiteSpace(itemName)) { throw new Exception("Item name can not be  empty or null"); }
            if (quantity < 0) { throw new Exception("Quantity can not be negative"); }
            // if the item already exists, add the quantity to the existing quantity
            // otherwise, add the item to the dictionary
            if (Items.ContainsKey(itemName))
            {
                Items[itemName] += quantity;
            }
            else
            {
                Items.Add(itemName, quantity);
            }

        }
        public void RemoveItem(string itemName, int quantity)
        {
            if (!Items.ContainsKey(itemName)) { throw new Exception("Item not found"); }
            if(string.IsNullOrWhiteSpace(itemName)) { throw new Exception("Item name can not be  empty or null"); }
            if (Items[itemName] < quantity) { throw new Exception("can not remove quantity is greater than available stock"); }
            
            Items[itemName] -= quantity;
        }
        public List<string> GetOutOfStockItems() 
        {
            return Items.Where(item => item.Value == 0).Select(item => item.Key).ToList(); // LINQ returns a list of items that have a quantity of 0
        }
    }
}
