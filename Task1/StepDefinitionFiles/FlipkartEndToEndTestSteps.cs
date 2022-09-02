using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using Task1.Pageobjects;
using Task1.Utilities;
using TechTalk.SpecFlow;

namespace Task1.FeatureFiles
{
    [Binding]
    public class FlipkartEndToEndTestSteps : Base
    {
        [Given(@"The Browser should be opened and navigated to Flipkart loginpage")]
        public void GivenTheBrowserShouldBeOpenedAndNavigatedToFlipkartLoginpage()
        {
            OpenBrowser();
        }
        
        [Given(@"Login credentials field should be visible")]
        public void GivenLoginCredentialsFieldShouldBeVisible()
        {
           
        }

        [When(@"user enters Phone number (.*) and (.*) password and clicked on Login")]
        public void WhenUserEntersPhoneNumberAndPasswordAndClickedOnLogin(string p0,string p1)
        {
            HomePage hp = new HomePage(GetDriver());
            hp.ValidLogin(p0, p1);
            Thread.Sleep(3000);                     
        }

        [Then(@"user should land on Flipkart homepage")]
        public void ThenUserShouldLandOnFlipkartHomepageAndAbleToSeeUsername()
        {
            dynamic actual = driver.FindElement(By.XPath("//div[contains(text(),'ASHWATH')]"));
            Assert.AreEqual("ASHWATH", actual.Text);
        }

        [Given(@"the user is on flipkart homepage")]
        public void GivenTheUserIsOnFlipkartHomepage()
        {
            
        }

        [When(@"user enter the product name (.*) in search bar and click enter")]
        public void WhenUserEnterTheProductNameInSearchBarAndClickEnter(string p0)
        {
            HomePage hp = new HomePage(GetDriver());
            hp.ExplicitWait();
            hp.ValidSearch(p0);
        }

        [Then(@"The product should be visible")]
        public void ThenTheProductShouldBeVisible()
        {
            HomePage hp = new HomePage(GetDriver());
            string actualtext = hp.GetText().Text;
            string[] splittedActualText = actualtext.Split("5G");
            string trimmedActualText = splittedActualText[0].Trim();
            Assert.AreEqual("SAMSUNG Galaxy M32", trimmedActualText);
        }

        [Given(@"the searched product is visible")]
        public void GivenTheSearchedProductIsVisible()
        {
            
        }

        [When(@"user clicks on the product")]
        public void WhenUserClicksOnTheProduct()
        {
            ProductsPage pp = new ProductsPage(GetDriver());
            pp.ExplicitWait();
            pp.getClick().Click();
        }

        [Then(@"user should see product description page")]
        public void ThenUserShouldSeeProductDescriptionPage()
        {
           
        }

        [Given(@"add to cart button should be visible")]
        public void GivenAddToCartButtonShouldBeVisible()
        {
           
        }

        [When(@"user clicks on add to cart button")]
        public void WhenUserClicksOnAddToCartButton()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            ProductDescrptionPage pdp = new ProductDescrptionPage(GetDriver());
            pdp.ClickToAddToCart();
        }

        [Then(@"product should be added into the cart")]
        public void ThenProductShouldBeAddedIntoTheCart()
        {
           
        }

        [Given(@"the product should be on cart page")]
        public void GivenTheProductShouldBeOnCartPage()
        {
           
        }

        [When(@"user clicks on remove button")]
        public void WhenUserClicksOnRemoveButton()
        {

            CartPage cartpage = new CartPage(GetDriver());
            cartpage.ExplicitWait();
            cartpage.Scrolls();                     
            cartpage.GetRemove().Click();           
            Thread.Sleep(2000);
            cartpage.GetYesRemove().Click();
        }

        [Then(@"products should not be visible on cart page")]
        public void ThenProductsShouldNotBeVisibleOnCartPage()
        {
           
        }

        [Given(@"the user is on flipkart homepage to logout")]
        public void GivenTheUserIsOnFlipkartHomepageToLogout()
        {
            CartPage cartpage = new CartPage(GetDriver());
            Actions a = new Actions(driver);
            a.MoveToElement(cartpage.GetLogo()).Click().Perform();
            Thread.Sleep(3000);

        }

        [When(@"the user clicks on logout button")]
        public void WhenTheUserClicksOnLogoutButton()
        {
            HomePage hp = new HomePage(GetDriver());
            hp.Logout();          
            IWebElement actuallogOutText = driver.FindElement(By.XPath("//a[contains(text(),'Login')]"));
        }

        [Then(@"the username in navigation bar should not be visible")]
        public void ThenTheUsernameInNavigationBarShouldNotBeVisible()
        {
            IWebElement actuallogOutText = driver.FindElement(By.XPath("//a[contains(text(),'Login')]"));
            Assert.AreEqual("Login", actuallogOutText.Text);
            driver.Quit();
        }




    }
}
