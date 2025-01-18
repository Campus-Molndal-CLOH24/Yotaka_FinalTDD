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
        public void IsNull_checkvalue_Retuencorrectlogisk()
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

        [TestMethod()]
        public void GetNullPropertiesTest()
        {
            Assert.Fail();
        }
    }
}