using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Warehouse.Tests
{
    [TestClass()]
    public class InventoryManagerTests
    {
        [TestMethod()]
        public void AddItem_ShouldAddItem_returnCorrectQuatity()
        {
            // Arrange
            InventoryManager inventoryManager = new InventoryManager();
            string itemName = "apple";
            int quantity = 10;
            // Act
            inventoryManager.AddItem(itemName, quantity);
            // Assert
            Assert.AreEqual(quantity, inventoryManager.Items[itemName], "Failed add item");
        }

        [TestMethod()]
        public void RemoveItemTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetOutOfStockItemsTest()
        {
            Assert.Fail();
        }
    }
}