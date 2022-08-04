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
using System.Collections;

namespace Task1
{
    public class Flipkart : Base
    {
        [Test, Order(1)]
        [TestCase("9738020725", "ashwathnarayan")]
        public void VerifyUserIsAbleToLogin(String phonenum, String passw)
        {
            HomePage hp = new HomePage(GetDriver());
            hp.ValidLogin(phonenum, passw);
            test.Log(Status.Info, "Phone Number & password entered successfully");
            test.Log(Status.Info, "Clicked on LogIn button");
           Thread.Sleep(3000);
            dynamic actual = driver.FindElement(By.XPath("//div[contains(text(),'ASHWATH')]"));
           Assert.AreEqual("ASHWATH", actual.Text);
            test.Log(Status.Info, "Expected Username : ASHWATH");
            test.Log(Status.Info, "Actual Username : ASHWATH");
            test.Log(Status.Info, "LogIn successful");
        }

        [Test, Order(2)]
        public void VerifyUserIsAbleToSearchAnItem()
        {
            HomePage hp = new HomePage(GetDriver());
            hp.ExplicitWait();
            hp.ValidSearch("SAMSUNG Galaxy M32");
            test.Log(Status.Info, "Product name entered in search box");
            test.Log(Status.Info, "Clicked on search button");
            string actualtext = hp.GetText().Text;
            string[] splittedActualText = actualtext.Split("5G");
            string trimmedActualText = splittedActualText[0].Trim();
            Assert.AreEqual("SAMSUNG Galaxy M32", trimmedActualText);
            test.Log(Status.Info, "Expected result : SAMSUNG Galaxy M32 products");
            test.Log(Status.Info, "Actual result : SAMSUNG Galaxy M32 products visible");
            test.Log(Status.Info, "Search successful");
        }

        [Test, Order(3)]
        public void VerifyUserIsAbleToClickOnItem()
        {
            ProductsPage pp = new ProductsPage(GetDriver());
            pp.ExplicitWait();
            pp.getClick().Click();
            test.Log(Status.Info, "Clicked on product");
            test.Log(Status.Info, "Expected result : To go to product description page");
            test.Log(Status.Info, "Outcome : Landed on product description page");
        }

        [Test, Order(4)]
        public void VerifyUserIsAbleToAddItemToCart()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            ProductDescrptionPage pdp = new ProductDescrptionPage(GetDriver());
            string beforeAddingToCart = "My Cart";
            test.Log(Status.Info, "Product description available");
            pdp.ClickToAddToCart();
            test.Log(Status.Info, "Clicked on Add to cart");
            string afterAddingToCart = pdp.GetMycart().Text;
            Assert.AreNotEqual(afterAddingToCart, beforeAddingToCart);
            test.Log(Status.Info, "Expected result : Selected product should be visible in cart");
            test.Log(Status.Info, "Outcome : Selected product is visible in cart");
            test.Log(Status.Info, "Product added to cart successfully");
        }

        [Test, Order(5)]
        public void VerifyUserIsAbleToRemoveItem ()
        {
            CartPage cartpage = new CartPage(GetDriver());
            cartpage.ExplicitWait();
            cartpage.Scrolls();
            string beforeRemoving = cartpage.GetMycart().Text;          
            cartpage.GetRemove().Click();
            test.Log(Status.Info, "Clicked on Remove button");
            Thread.Sleep(2000);
            cartpage.GetYesRemove().Click();
            string afterRemoving = "My Cart";           
            Assert.AreNotEqual(afterRemoving,beforeRemoving);
            test.Log(Status.Info, "Expected result : Selected product should not be visible in cart");
            test.Log(Status.Info, "Outcome : Selected product is not visible in cart");
            test.Log(Status.Info, "Product removed successfully");
        }

        [Test, Order(6)]
        public void VerifyMobileOptionsUnderElectronics()
        {
            CartPage cartpage = new CartPage(GetDriver());
            Actions a = new Actions(driver);
            a.MoveToElement(cartpage.GetLogo()).Click().Perform();           
            HomePage hp = new HomePage(GetDriver());
            hp.ClickOnMobiles();
            Thread.Sleep(2000);
            MobilesPage mp = new MobilesPage(GetDriver());
            mp.MobilesUnderElectronics();
            ArrayList actualresult = mp.GetActualMobiles();
            ArrayList expectedresult = mp.GetExpectedMobiles();
            Assert.AreEqual(expectedresult, actualresult);
            test.Log(Status.Info, "Expected result : Mobile options should be visible under Electronics dropdown");
            test.Log(Status.Info, "Outcome : Mobile options are visible under Electronics dropdown");
        }

        [Test, Order(7)]
        public void VerifyUserIsAbleToScrollDown ()
        {
            CartPage cartpage = new CartPage(GetDriver());
            Actions a = new Actions(driver);
            a.MoveToElement(cartpage.GetLogo()).Click().Perform();
            Thread.Sleep(3000);
            HomePage hp = new HomePage(GetDriver());
            hp.ScrollingDownFunc();
            test.Log(Status.Info, "scrolled down to bottom of the Homepage");
        }       

        [Test, Order(8)]
        public void VerifyUserIsAbleToLogout ()
        {
            HomePage hp = new HomePage(GetDriver());
            hp.Logout();
            test.Log(Status.Info, "Clicked on LogOut button");
            IWebElement actuallogOutText = driver.FindElement(By.XPath("//a[contains(text(),'Login')]"));
            Assert.AreEqual("Login", actuallogOutText.Text);
            test.Log(Status.Info, "Expected result : should see Login button on Homepage");
            test.Log(Status.Info, "Outcome : Login button on Homepage is visible");
            test.Log(Status.Info, "LogOut successful");
        }
    }
}