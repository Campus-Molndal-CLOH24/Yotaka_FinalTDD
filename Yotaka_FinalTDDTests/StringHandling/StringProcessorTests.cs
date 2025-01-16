using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.StringHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.StringHandling.Tests
{
    [TestClass()]
    public class StringProcessorTests
    {
        [TestMethod()]
        public void ToLowerCase_Returncorrectresult()
        {
            // Arrange
            StringProcessor stringProcessor = new StringProcessor();
            // Act
            string result = stringProcessor.ToLowerCase("HELLO");
            // Assert
            Assert.AreEqual("hello", result);
        }
        //test case when input is  empty string
        [TestMethod()]
        public void ToLowerCase_EmptyString_returncorrectresult()
        {
            // Arrange
            StringProcessor stringProcessor = new StringProcessor();
            // Act
            string result = stringProcessor.ToLowerCase("");
            // Assert
            Assert.AreEqual("", result, $"Failed to return {result}");
        }
        //test case when input is  null
        [TestMethod()]
        public void ToLowerCase_Null_returncorrectresult()
        {
            // Arrange
            StringProcessor stringProcessor = new StringProcessor();
            // Act
            string result = stringProcessor.ToLowerCase(null);
            // Assert
            Assert.AreEqual(null, result, $"Failed to return {result}");
        }
        
        [TestMethod()]
        public void Sanitize_delectallspecialtecken_returncorrectresult()
        {
            // Arrange
            StringProcessor stringProcessor = new StringProcessor();
            // Act
            string result = stringProcessor.Sanitize("Hello!@#$");
            // Assert
            Assert.AreEqual("Hello", result);
        }
        //return result if it maches the expected result between two strings
        [TestMethod()]
        public void AreEqual_compare_returncorrectresult()
        {
            // Arrange
            StringProcessor stringProcessor = new StringProcessor();
            // Act
            bool result = stringProcessor.AreEqual("Hello,World", "HELLO WORLD");
            // Assert
            Assert.IsTrue(result);
        }
       
    }
}