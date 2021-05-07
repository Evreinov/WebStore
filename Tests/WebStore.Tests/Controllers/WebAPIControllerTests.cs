using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebStore.Controllers;
using WebStore.Interfaces.TestAPI;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class WebAPIControllerTests
    {
        [TestMethod]
        public void Index_Returns_View_with_Values()
        {
            var expected_value = new[] { "1", "2", "3" };

            var value_service_mock = new Mock<IValuesService>();
            value_service_mock
                .Setup(service => service.Get())
                .Returns(expected_value);

            var controller = new WebAPIController(value_service_mock.Object);

            var result = controller.Index();

            var view_result = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<string>>(view_result.Model);

            Assert.Equal(expected_value.Length, model.Count());

            value_service_mock.Verify(service => service.Get());
            value_service_mock.VerifyNoOtherCalls();
        }
    }
}
