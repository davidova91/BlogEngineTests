using System;
using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    [TestClass]
    public class NonDriverTests
    {
        [TestMethod]
        public void Add_Virtual_Path()
        {
            var name = Guid.NewGuid().ToString();

            const string baseAddress = "http://localhost:63129/";
            const string virtualPath = "~/test";
            const string res1 = "http://localhost:63129/test";

            var res2 = BlogsPage.CombineVirtualPath(baseAddress, virtualPath);

            Assert.AreEqual(res1, res2);
        }
    }
}
