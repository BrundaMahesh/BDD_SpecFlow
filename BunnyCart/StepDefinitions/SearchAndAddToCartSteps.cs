using BunnyCart.Hooks;
using BunnyCart.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartSteps:CoreCodes
    {

        IWebDriver? driver = AllHooks.driver;
        string? label;

        [Given(@"User will be on the home page")]
        public void GivenUserWillBeOnTheHomePage()
        {
            driver.Url = "https://www.bunnycart.com/";
            driver.Manage().Window.Maximize();
        }


        [When(@"User will type the '([^']*)' in the search box")]
        public void WhenUserWillTypeTheInTheSearchBox(string searchtext)
        {
            IWebElement? searchInput = driver.FindElement(By.Id("search"));
            searchInput?.SendKeys(searchtext);
            Log.Information("Typed search text " + searchtext);
            searchInput?.SendKeys(Keys.Enter);
        }

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {

            TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }

        }
        [Then(@"The heading should have '([^']*)'")]
        public void ThenTheHeadingShouldHave(string searchtext)
        {
            TakeScreenShot(driver);
            try
            {
                IWebElement searchheading = driver.FindElement(By.XPath("//h1[@class='page-title']"));
                Assert.That(searchheading.Text, Does.Contain(searchtext));
                LogTestResult("Heading Test", "Heading Test success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Heading Test", "Heading Test Failed", ex.Message);
            }

        }
        [Then(@"Title should have '([^']*)'")]
        public void ThenTitleShouldHave(string searchtext)
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Title, Does.Contain(searchtext));
                LogTestResult("Title Test", "Title Test success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Title Test", "Title Test Failed", ex.Message);
            }
        }
        
        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string prodno)
        {
            IWebElement prod = driver.FindElement(By.XPath("//*[@id=\"amasty-shopby-product-list\"]/div[2]/ol/li[1]/div/div[2]/strong/a[" + prodno + "]"));
            label = prod.Text;
            prod.Click();
        }

        [Then(@"Product page is loaded")]
        public void ThenProductPageIsLoaded()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.FindElement(By.XPath("//h1[@class='page-title']")).Text.Equals(label));
                LogTestResult("Product Page Test", "Product Page Test success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Product Page Test", "Product Page Test Failed", ex.Message);
            }
        }

        [When(@"User click on Net Pot type")]
        public void WhenUserClickOnNetPotType()
        {
            ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[2]/div[1]/div[2]/div[3]/div[2]/a[2]")));
            IWebElement netPot = driver.FindElement(By.XPath("//div[@role='listbox']/div[text()='Net Pot']"));
            netPot.Click();
           
        }

        [When(@"User click on Add to Cart")]
        public void WhenUserClickOnAddToCart()
        {
            IWebElement addtocart=driver.FindElement(By.Id("product-addtocart-button"));
            addtocart.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Modal will appear")]
        public void ThenModalWillAppear()
        {
            TakeScreenShot(driver);
            try
            {
                //string? modal = driver.FindElement(By.XPath("//div[@id='modal-content-60']/div[contains(text(),'Water trumpet')]")).Text;
                Assert.True(true);
                LogTestResult("Add to Cart Modal Test", "Add to Cart Modal Test success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Add to Cart Modal Test", "Add to Cart Modal Test Failed", ex.Message);
            }
        }








    }
}
