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

namespace Task1
{
    public class Flipkart : Base
    {
        [Test, Order(1)]
        public void Login()
        {
            HomePage hp = new HomePage(getDriver());
            hp.validLogin("9738020725", "ashwathnarayan");
            Thread.Sleep(3000);
            dynamic actual = driver.FindElement(By.XPath("//div[contains(text(),'ASHWATH')]"));
            Assert.AreEqual("ASHWATH", actual.Text);
        }

        [Test, Order(2)]
        public void searchItem()
        {
            HomePage hp = new HomePage(getDriver());
            hp.explicitWait();
            hp.validSearch("SAMSUNG Galaxy M32");
            string actualtext = hp.getText().Text;
            string[] splittedActualText = actualtext.Split("5G");
            string trimmedActualText = splittedActualText[0].Trim();
            Assert.AreEqual("SAMSUNG Galaxy M32", trimmedActualText);
        }

        [Test, Order(3)]
        public void clickOnItem()
        {
            ProductsPage pp = new ProductsPage(getDriver());
            pp.explicitWait();
            pp.getClick().Click();
        }

        [Test, Order(4)]
        public void addToCart()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            ProductDescrptionPage pdp = new ProductDescrptionPage(getDriver());
            string beforeAddingToCart = "My Cart";
            pdp.clickToAddToCart();
            string afterAddingToCart = pdp.getMycart().Text;
            Assert.AreNotEqual(afterAddingToCart, beforeAddingToCart);
        }

        [Test, Order(5)]
        public void cartPage()
        {
            CartPage cartpage = new CartPage(getDriver());
            ProductDescrptionPage pdp = new ProductDescrptionPage(getDriver());
            cartpage.explicitWait();
            cartpage.scrolls();
            string beforeRemoving = pdp.getMycart().Text;
            cartpage.getRemove().Click();
            Thread.Sleep(2000);
            cartpage.getYesRemove().Click();
            string afterRemoving = pdp.getMycart().Text;
            Assert.AreNotEqual(afterRemoving, beforeRemoving);
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
        }

        [Test, Order(7)]
        public void logout()
        {
            HomePage hp = new HomePage(getDriver());
            hp.logout();
        }
    }
}