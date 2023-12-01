using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace LinkedInTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver? driver;

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
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            throw new PendingStepException();
        }

        [When(@"User will enter username")]
        public void WhenUserWillEnterUsername()
        {
            throw new PendingStepException();
        }

        [When(@"User will enter password")]
        public void WhenUserWillEnterPassword()
        {
            throw new PendingStepException();
        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            throw new PendingStepException();
        }

        [Then(@"User will be redirected to home page")]
        public void ThenUserWillBeRedirectedToHomePage()
        {
            throw new PendingStepException();
        }
    }
}
