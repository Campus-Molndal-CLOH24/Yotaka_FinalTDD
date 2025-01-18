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


        //handle empty item name
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AddItem_ShouldThrowException_WhenItemNameEmpty()
        {
            // Arrange
            InventoryManager inventoryManager = new InventoryManager();
            string itemName = "";
            int quantity = 10;
            // Act
            inventoryManager.AddItem(itemName, quantity);
        }


        //handle negative quantity
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AddItem_ShouldThrowException_WhenQuantityNegative()
        {
            // Arrange
            InventoryManager inventoryManager = new InventoryManager();
            string itemName = "apple";
            int quantity = -10;
            // Act
            inventoryManager.AddItem(itemName, quantity);
        }


        //return correct result
        [TestMethod()]
        public void RemoveItem_ShouldReturnCorrectresult()
        {
            // Arrange
            InventoryManager inventoryManager = new InventoryManager();
            string itemName = "apple";
            int quantity = 2;
            inventoryManager.AddItem(itemName, 5);
            // Act
            inventoryManager.RemoveItem(itemName, quantity);
            // Assert
            Assert.AreEqual(3, inventoryManager.Items[itemName], "Failed remove item"); //check if quantity is correct result 
        }


        //try to remove item that is not in the list
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RemoveItem_ShouldThrowException_WhenItemNotFound()
        {
            // Arrange
            InventoryManager inventoryManager = new InventoryManager();
            string itemName = "coffee";
            int quantity = 2;
            // Act
            inventoryManager.RemoveItem(itemName, quantity);
        }


        //handle empty item name
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RemoveItem_ShouldThrowException_WhenItemNameEmpty()
        {
            // Arrange
            InventoryManager inventoryManager = new InventoryManager();
            string itemName = "";
            int quantity = 2;
            // Act
            inventoryManager.RemoveItem(itemName, quantity);
        }


        //handle with removing quantity that is greater than available stock
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RemoveItem_ShouldThrowException_WhenQuantityGreaterThanAvailableStock()
        {
            // Arrange
            InventoryManager inventoryManager = new InventoryManager();
            string itemName = "apple";
            int quantity = 2;
            inventoryManager.AddItem(itemName, 1); //in the stock has only 1 apple
            // Act
            inventoryManager.RemoveItem(itemName, quantity);
        }


        //return name of item that has quantity of 0
        [TestMethod()]
        public void GetOutOfStockItems_ShouldReturnEmptyList_WhenNoItemsOutOfStock()
        {
            // Arrange
            InventoryManager inventoryManager = new InventoryManager();
            inventoryManager.AddItem("orange", 10);
            inventoryManager.AddItem("lime", 5);
            // Act
            List<string> outOfStockItems = inventoryManager.GetOutOfStockItems();
            // Assert
            Assert.AreEqual(0, outOfStockItems.Count, "Failed get out of stock items");
        }


        //return name of item that has quantity of 0
        [TestMethod()]
        public void GetOutOfStockItems_ShouldReturnListOfItems_WhenItemsOutOfStock()
        {
            // Arrange
            InventoryManager inventoryManager = new InventoryManager();
            inventoryManager.AddItem("orange", 10);
            inventoryManager.AddItem("water", 0);
            inventoryManager.AddItem("salt", 0);
            // Act
            List<string> outOfStockItems = inventoryManager.GetOutOfStockItems();
            // Assert
            Assert.AreEqual(2, outOfStockItems.Count, "Failed get out of stock items");
            Assert.IsTrue(outOfStockItems.Contains("water"), "Failed get out of stock items"); //check if lime is out of stock
            Assert.IsTrue(outOfStockItems.Contains("salt"), "Failed get out of stock items");
        }
    }
}