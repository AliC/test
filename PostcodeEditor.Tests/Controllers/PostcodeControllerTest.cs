using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using PostcodeEditor;
using PostcodeEditor.Web.Controllers;

namespace PostcodeEditor.Tests.Controllers
{
    [TestFixture]
    public class PostcodeControllerTest
    {
        [Test]
        public void Index()
        {

            PostcodeController controller = new PostcodeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void IndListex()
        {

            PostcodeController controller = new PostcodeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

    }
}
