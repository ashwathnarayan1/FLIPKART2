using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Task1.Pageobjects;
using Task1.Utilities;
using WebDriverManager.DriverConfigs.Impl;
using AventStack.ExtentReports;

namespace Task1
{
    public class Flipkart : Base
    {
        [Test, Order(1)]
        public void Login()
        {
            HomePage hp = new HomePage(getDriver());
            hp.validLogin("9738020725", "ashwathnarayan");
            test.Log(Status.Info, "Phone Number & password entered successfully");
            test.Log(Status.Info, "Clicked on LogIn button");
           Thread.Sleep(3000);
            dynamic actual = driver.FindElement(By.XPath("//div[contains(text(),'ASHWATH')]"));
           Assert.AreEqual("ASHWATH", actual.Text);
            test.Log(Status.Info, "LogIn successful");
        }

        [Test, Order(2)]
        public void searchItem()
        {
            HomePage hp = new HomePage(getDriver());
            hp.explicitWait();
            hp.validSearch("SAMSUNG Galaxy M32");
            test.Log(Status.Info, "Product name entered in search box");
            test.Log(Status.Info, "Clicked on search button");
            string actualtext = hp.getText().Text;
            string[] splittedActualText = actualtext.Split("5G");
            string trimmedActualText = splittedActualText[0].Trim();
            Assert.AreEqual("SAMSUNG Galaxy M32", trimmedActualText);
            test.Log(Status.Info, "Search successful");
        }

        [Test, Order(3)]
        public void clickOnItem()
        {
            ProductsPage pp = new ProductsPage(getDriver());
            pp.explicitWait();
            pp.getClick().Click();
            test.Log(Status.Info, "Clicked on product");
        }

        [Test, Order(4)]
        public void addToCart()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            ProductDescrptionPage pdp = new ProductDescrptionPage(getDriver());
            string beforeAddingToCart = "My Cart";
            test.Log(Status.Info, "Product description available");
            pdp.clickToAddToCart();
            test.Log(Status.Info, "Clicked on Add to cart");
            string afterAddingToCart = pdp.getMycart().Text;
            Assert.AreNotEqual(afterAddingToCart, beforeAddingToCart);
            test.Log(Status.Info, "Product added to cart successfully");
        }

        [Test, Order(5)]
        public void cartPage()
        {
            CartPage cartpage = new CartPage(getDriver());
            cartpage.explicitWait();
            cartpage.scrolls();
            string beforeRemoving = cartpage.getMycart().Text;          
            cartpage.getRemove().Click();
            test.Log(Status.Info, "Clicked on Remove button");
            Thread.Sleep(2000);
            cartpage.getYesRemove().Click();
            string afterRemoving = "My Cart";           
            Assert.AreNotEqual(afterRemoving,beforeRemoving);
            test.Log(Status.Info, "Product removed successfully");

        }

        [Test, Order(6)]
        public void scrollDown()
        {
            CartPage cartpage = new CartPage(getDriver());
            Actions a = new Actions(driver);
            a.MoveToElement(cartpage.getLogo()).Click().Perform();
            Thread.Sleep(3000);
            HomePage hp = new HomePage(getDriver());
            hp.scrollingDownFunc();
            test.Log(Status.Info, "scrolled down to bottom of the Homepage");
        }

        [Test, Order(7)]
        public void logout()
        {
            HomePage hp = new HomePage(getDriver());
            hp.logout();
            test.Log(Status.Info, "Clicked on LogOut button");
            IWebElement actuallogOutText = driver.FindElement(By.XPath("//a[contains(text(),'Login')]"));
            Assert.AreEqual("Login", actuallogOutText.Text);
            test.Log(Status.Info, "LogOut successful");
        }
    }
}