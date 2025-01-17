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
            throw new NotImplementedException();
        }
        public List<string> GetOutOfStockItems() 
        {
            return Items.Where(x => x.Value == 0).Select(x => x.Key).ToList();
        }
    }
}
