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
    public class TestCase : Base
    {

        [Test, Order(1)]
        public void Login()
        {

            LoginPage loginpage = new LoginPage(getDriver());
            loginpage.validLogin("9738020725", "ashwathnarayan");
            Thread.Sleep(3000);
            dynamic actual = driver.FindElement(By.XPath("//div[contains(text(),'ASHWATH')]"));
            Assert.AreEqual("ASHWATH",actual.Text );
                   
        }

        [Test,Order(2)]
        public void searchItem()
        {
            SearchPage searchpage = new SearchPage(getDriver());
            searchpage.explicitWait();
            searchpage.validSearch("SAMSUNG Galaxy M32");
            string actualtext = searchpage.getText().Text;
            string [] splittedActualText = actualtext.Split("5G");
            string trimmedActualText = splittedActualText[0].Trim();
            Assert.AreEqual("SAMSUNG Galaxy M32", trimmedActualText);
           
            

        }
        [Test,Order(3)]
        public void clickOnItem()
        {
            ClickOnItem clickonitem = new ClickOnItem(getDriver());
            clickonitem.explicitWait();
            clickonitem.getClick().Click();
        }
        [Test,Order(4)]
        public void addToCart()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            AddToCart addtocart = new AddToCart(getDriver());
            string beforeAddingToCart = "My Cart";
             addtocart.clickToAddToCart();
            string afterAddingToCart = addtocart.getMycart().Text;
            Assert.AreNotEqual(afterAddingToCart, beforeAddingToCart);
        }
        [Test,Order(5)]
        public void cartPage()
        {
            
            CartPage cartpage = new CartPage(getDriver());
            AddToCart addtocart = new AddToCart(getDriver());
            cartpage.explicitWait();
            cartpage.scrolls();
            string beforeRemoving = addtocart.getMycart().Text;
            cartpage.getRemove().Click();
            Thread.Sleep(2000);
            cartpage.getYesRemove().Click();
            string afterRemoving = addtocart.getMycart().Text;
            Assert.AreNotEqual(afterRemoving, beforeRemoving);





        }
        [Test,Order(6)]
        public void scrollDown()
        {
            ScrollDown scrolldown = new ScrollDown(getDriver());
            Actions a = new Actions(driver);
            a.MoveToElement(scrolldown.getLogo()).Click().Perform();
            Thread.Sleep(3000);
            scrolldown.scrollingDownFunc();
            
        }
        [Test,Order(7)]
        public void logout()
        {
            Logout lo = new Logout(getDriver());
            lo.logout();
        }

        
    }
}