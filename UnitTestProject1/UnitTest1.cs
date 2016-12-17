using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelife.Controllers;
using System.Web.Mvc;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            NotesController controller = new NotesController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            NotesController controller = new NotesController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
