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
            PostcodeController controller = new PostcodeController(service);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void List()
        {
            IList<Core.PostcodeDetails> expectedPostcodes = new List<Core.PostcodeDetails>
            {
                new Core.PostcodeDetails
                {
                    Postcode = "QV1 1IJ"
                }
            };

            IPostcodeService service = Mock.Of<IPostcodeService>();
            Mock.Get(service).Setup(s => s.Get()).Returns(expectedPostcodes);

            PostcodeController controller = new PostcodeController(service);

            ViewResult result = controller.List() as ViewResult;

            Assert.IsNotNull(result);

            IList<Core.PostcodeDetails> postcodes = result.Model as IList<Core.PostcodeDetails>;

            Assert.IsNotNull(postcodes);
            Assert.That(postcodes.Count, Is.EqualTo(expectedPostcodes.Count));
        }

    }
}
