using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.Null_check;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Null_check.Tests
{
    [TestClass()]
    public class ObjectValidatorTests
    {
        [TestMethod()]
        public void IsNull_ShouldReturnTrue_ForNullObject()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            object obj = null;
            object obj2 = null;
            object obj3 = 50;
            // Act
            bool result = objectValidator.IsNull(obj);
            bool result2 = objectValidator.IsNull(obj2);
            bool result3 = objectValidator.IsNull(obj3);
            // Assert
            Assert.IsTrue(result, "Fail validation");
            Assert.IsTrue(result2, "Fail validation");
            Assert.IsFalse(result3, "Fail validation");
        }


        //return false
        [TestMethod()]
        public void IsNull_ShouldReturnFalse_ForNullObject()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            object obj = null;
            object obj2 = "Great";
            object obj3 = 10;
            // Act
            bool result = objectValidator.IsNull(obj);
            bool result2 = objectValidator.IsNull(obj2);
            bool result3 = objectValidator.IsNull(obj3);
            // Assert
            Assert.IsTrue(result, "Fail validation");
            Assert.IsFalse(result2, "Fail validation");
            Assert.IsFalse(result3, "Fail validation");
        }


        //returnerar rätt lista för en klass med vissa null-properties.
        [TestMethod()]
        public void GetNullProperties_ShouldReturnCorrectPropertyNames()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            var person = new Person { Name = "Gigi", Age = null , Adress = null};
            
            // Act
            var result = objectValidator.GetNullProperties(person);
            // Assert
            CollectionAssert.AreEqual(new List<string> { "Age", "Adress" }, result); //return list of null properties
        }


        //handle with null throw exception
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNullProperties_ShouldThrowException_ForNullObject()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            object obj = null;
            // Act
            objectValidator.GetNullProperties(obj);
        }


        //return an empty list for no null properties
        [TestMethod()]
        public void GetNullProperties_ShouldReturnEmptyList_ForNoNullProperties()
        {
            // Arrange
            ObjectValidator objectValidator = new ObjectValidator();
            var person = new Person { Name = "Gigi", Age = 20, Adress = "Stockholm" };
            // Act
            var result = objectValidator.GetNullProperties(person);
            // Assert
            CollectionAssert.AreEqual(new List<string>(), result); //return empty list
        }
    }
}