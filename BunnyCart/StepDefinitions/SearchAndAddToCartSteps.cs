using BunnyCart.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartSteps
    {
        IWebDriver? driver = AllHooks.driver;
        string? label;

        [Given(@"Search page is loaded")]
        public void GivenSearchPageIsLoaded()
        {
            driver.Url = "https://www.bunnycart.com/catalogsearch/result/?q=water";
        }

        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string prodno)
        {
            IWebElement prod=driver.FindElement(By.XPath("//*[@id=\"amasty-shopby-product-list\"]/div[2]/ol/li[1]/div/div[2]/strong/a[" +prodno + "]"));
            label = prod.Text;
            prod.Click();
        }

        [Then(@"Product page is loaded")]
        public void ThenProductPageIsLoaded()
        {
            Assert.That(driver.FindElement(By.XPath("//h1[@class='page-title']")).Text.Equals(label));
        }





    }
}
