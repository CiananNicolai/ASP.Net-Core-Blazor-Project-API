using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCA3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUserGetsResponse()
        {
            // Instantiate Counter class
            var counter = new Counter();

            // Simulate user input by setting query variable
            counter.query = "test";

            // Call Search method to send query to API
            counter.Search();

            // Assert that response variable has been updated
            Assert.IsFalse(string.IsNullOrEmpty(counter.response));
        }
    }
}
