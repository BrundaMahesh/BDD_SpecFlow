using BunnyCart.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartSteps
    {
        IWebDriver? driver = AllHooks.driver;
        [Then(@"The heading should have '([^']*)'")]
        public void ThenTheHeadingShouldHave(string searchtext)
        {
            IWebElement searchheading = driver.FindElement(By.XPath("//h1[@class='page-title']"));
            Assert.That(searchtext, Does.Contain(searchheading.Text));
        }
        [Then(@"Title should have '([^']*)'")]
        public void ThenTitleShouldHave(string searchtext)
        {
            Assert.That(searchtext, Does.Contain(driver.Title));
        }




    }
}
