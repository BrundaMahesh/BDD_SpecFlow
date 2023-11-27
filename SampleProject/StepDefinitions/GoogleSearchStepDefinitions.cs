using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SampleProject.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        public IWebDriver driver;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        [AfterScenario]
        public void Cleanup()
        {
            driver?.Quit();
        }

        [Given(@"Google home page should be loaded")]
        public void GivenGoogleHomePageShouldBeLoaded()
        {
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"Type ""(.*)"" in the search text input box")]
        public void WhenTypeInTheSearchTextInputBox(string searchtext)
        {
            IWebElement searchInputTextBox = driver.FindElement(By.Id("APjFqb"));
            searchInputTextBox.SendKeys(searchtext);
        }

        [When(@"Click on the Google Search button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement? gsButton = fluentWait.Until(d =>
            {
                IWebElement? searchButton = driver.FindElement(By.ClassName("gNO89b"));
                return searchButton.Displayed ? searchButton : null;
            });
            if (gsButton != null)
            {
                gsButton.Click();

            }
        }


        [Then(@"the results should be displayed on the next page with title ""(.*)""")]
        public void ThenTheResultsShouldBeDisplayedOnTheNextPageWithTitle(string title)
        {
            Assert.That(driver.Title,Is.EqualTo(title));
        }

        [When(@"Click on the I'm feeling lucky button")]
        public void WhenClickOnTheImFeelingLuckyButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement? imflButton = fluentWait.Until(d =>
            {
                IWebElement? searchButton = driver.FindElement(By.Name("btnI"));
                return searchButton.Displayed ? searchButton : null;
            });
            if (imflButton != null)
            {
                imflButton.Click();

            }
        }

        [Then(@"the results should be redirected to a new page title ""([^""]*)""")]
        public void ThenTheResultsShouldBeRedirectedToANewPageTitle(string title)
        {
            Assert.That(driver.Title.Contains(title));
        }



    }
}
