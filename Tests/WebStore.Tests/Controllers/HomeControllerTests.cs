using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStore.Controllers;

using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_Returns_View()
        {
            var controller = new HomeController();

            var result = controller.Index();
            // Стандартный класс тестирования Microsoft
            //Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsType<ViewResult>(result);

        }

        [TestMethod]
        public void Shop_Returns_View()
        {
            Assert.IsType<ViewResult>(new HomeController().Shop());
        }

        [TestMethod]
        public void ProductDetails_Returns_View()
        {
            Assert.IsType<ViewResult>(new HomeController().ProductDetails());
        }

        [TestMethod]
        public void CheckOut_Returns_View()
        {
            Assert.IsType<ViewResult>(new HomeController().CheckOut());
        }

        [TestMethod]
        public void Cart_Returns_View()
        {
            Assert.IsType<ViewResult>(new HomeController().Cart());
        }

        [TestMethod]
        public void Login_Returns_View()
        {
            Assert.IsType<ViewResult>(new HomeController().Login());
        }

        [TestMethod]
        public void Blog_Returns_View()
        {
            Assert.IsType<ViewResult>(new HomeController().Blog());
        }

        [TestMethod]
        public void BlogSingle_Returns_View()
        {
            Assert.IsType<ViewResult>(new HomeController().BlogSingle());
        }

        [TestMethod]
        public void Error404_Returns_View()
        {
            var controller = new HomeController();

            var result = controller.Error404();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ErrorStatus_404_RedirectTo_Error404()
        {
            var controller = new HomeController();

            const string error_status_code = "404";
            const string expected_action_name = nameof(HomeController.Error404);

            var result = controller.ErrorStatus(error_status_code);

            var redirect_to_action = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal(expected_action_name, redirect_to_action.ActionName);
            Assert.Null(redirect_to_action.ControllerName);
        }

        [TestMethod]
        public void ContactUs_Returns_View()
        {
            Assert.IsType<ViewResult>(new HomeController().ContactUs());
        }
    }
}
