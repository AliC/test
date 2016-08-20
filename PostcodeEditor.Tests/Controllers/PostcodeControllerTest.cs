using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PostcodeEditor.Data;
using PostcodeEditor.SeparatedInterfaces;
using PostcodeEditor.Web.Controllers;

namespace PostcodeEditor.Tests.Controllers
{
    [TestFixture]
    public class PostcodeControllerTest
    {
        [Test]
        public void Index()
        {
            IPostcodeService service = Mock.Of<IPostcodeService>();
            IEnumerable<IPostcode> expectedPostcodes = new List<IPostcode>();
            Mock.Get(service).Setup(p => p.Get()).Returns(expectedPostcodes);
            PostcodeController controller = new PostcodeController(service);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

    }
}
