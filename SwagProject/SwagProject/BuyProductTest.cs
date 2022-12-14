using OpenQA.Selenium;
using SwagProject.Driver;
using SwagProject.Page;

namespace SwagProject
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;
        Card cardPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialization();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cardPage = new Card();
        }

        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_AddTwoProductsInCard_ShouldDisplayedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPack.Click();
            productPage.AddT_Shirt.Click();

            Assert.That("2", Is.EqualTo(productPage.Cart.Text));


        }

        [Test]
        public void TC02_SortProductByPrice_ShouldSortByHighPrice()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.SelectOption("Price (high to low)");

            Assert.That(productPage.SortByPrice.Displayed);
        }

        [Test]
        public void TC03_GoToAboutPage_ShouldRedirectToNewPage()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.MenuClick.Click();
            productPage.AboutClick.Click();

            Assert.That("https://saucelabs.com/", Is.EqualTo(WebDrivers.Instance.Url));
        }

        [Test]
        public void TC04_BuyProducts_ShouldBeFinishedShopping()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPack.Click();
            productPage.AddT_Shirt.Click();
            productPage.ShoppingCardClick.Click();

            cardPage.Checkout.Click();
            cardPage.FirstName.SendKeys("Bogdan");
            cardPage.LastName.SendKeys("Mitrovic");
            cardPage.ZipCode.SendKeys("11000");
            cardPage.ButtonContinue.Submit();

            cardPage.Finish.Click();
            Assert.That("THANK YOU FOR YOUR ORDER",Is.EqualTo(cardPage.OrderFinished.Text));
        }

    }
}