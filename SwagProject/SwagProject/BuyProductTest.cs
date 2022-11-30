using SwagProject.Driver;
using SwagProject.Page;

namespace SwagProject
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialization();
            loginPage = new LoginPage();  
            productPage = new ProductPage();
        }

        [Test]
        public void TC01_AddTwoProductsInCard_ShouldDisplayedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPack.Click();
            productPage.AddT_Shirt.Click();

            Assert.That("2", Is.EqualTo(productPage.Cart.Text));


        }
        [TearDown]
        public void ClosePage()
        {
            WebDrivers.CleanUp();
        }

    }
}