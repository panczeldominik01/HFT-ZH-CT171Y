using System;
using CT171Y_ZH;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AttributeHelperTest
{
    [TestClass]
    public class AttributeHelperTest
    {
        [TestMethod]
        public void GetPropertyDescription() 
        {
            var description = "Full name";
            var result = AttributeHelper.GetPropertyDescription<Celebrity>("Name");
            Assert.AreEqual(description, result);
        }
        [TestMethod]
        public void GetProperty_Default()
        {
            var defaultMessage = "No description found on property 'Age'.";
            var result = AttributeHelper.GetPropertyDescription<Celebrity>("Age");
            Assert.AreEqual(defaultMessage, result);
        }
    }
}
