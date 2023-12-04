using BunnyCart.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchSteps:CoreCodes
    {
        public static IWebDriver? driver;
        

        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }

        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            driver?.Navigate().GoToUrl("https://www.bunnycart.com/");
        }

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
        }

        [When(@"User clicks on search button")]
        public void WhenUserClicksOnSearchButton()
        {
            IWebElement? searchButton = driver.FindElement(By.XPath("//button[@title='Search']"));
            searchButton?.Click();
        }

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Success");
            }
            catch(AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed",ex.Message);
            }

        }
    }
}
