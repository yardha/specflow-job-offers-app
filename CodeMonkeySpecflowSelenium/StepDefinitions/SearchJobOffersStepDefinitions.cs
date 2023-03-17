using CodeMonkeySpecflowSelenium.Drivers;
using CodeMonkeySpecflowSelenium.Variables;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Xml.Linq;

namespace CodeMonkeySpecflowSelenium.StepDefinitions
{
    [Binding]
    public sealed class SearchJobOffersStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public SearchJobOffersStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
                
        [Given(@"I navigate to JobOffersApp to Search Job")]
        public void GivenINavigateToJobOffersAppToSearchJob(Table table)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

            //Open URL
            driver.Url = "https://localhost:7273/";
            Thread.Sleep(2000);
        }

        [When(@"I click Login to Search Job")]
        public void WhenIClickLoginToSearchJob()
        {
            //Hit Login button
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/header/div/div")).Click();
            Thread.Sleep(2000);
        }

        [When(@"JobOffersApp Web should opened to Search Job")]
        public void WhenJobOffersAppWebShouldOpenedtoSearchJob()
        {
            //Make sure the headlne beside the logo is displaying job offers app
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/div/header/p")).Text, Is.EqualTo("Job Offers App"));
        }

        [When("Job Offer List page opened to Search Job")]
        public void WhenJobRegistrationFormOpenedtoSearchJob()
        {
            //make sure by default the opened page is job offer list
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/h1")).Text, Is.EqualTo("List Of Job Offers"));
        }

        [When(@"I hit Search for Candidate")]
        public void WhenIHitSearchForCandidate()
        {
            //click search for candidate
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/div[2]/div/div")).Click();
            Thread.Sleep(5000);
        }

        [Then(@"Result should be displayed")]
        public void ThenResultShouldBeDisplayed()
        {
            //click search for candidate
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"contained-modal-title-vcenter\"]")).Text, Is.EqualTo("Search Completed!"));
            Thread.Sleep(1000);
        }

        [Then(@"Position should be (.*)")]
        public void ThenPositionShouldBe(string position)
        {
            //click search for candidate
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr/td[1]")).Text, Is.AtLeast(position));
            Thread.Sleep(1000);
        }

        [Then(@"Company Name should be (.*)")]
        public void ThenCompanyNameShouldBe(string company)
        {
            //click search for candidate
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr/td[2]")).Text, Is.AtLeast(company));
            Thread.Sleep(1000);
        }

        [Then(@"Selected Student should be (.*)")]
        public void ThenSelectedStudentShouldBe(string student)
        {
            //click search for candidate
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr/td[3]")).Text, Is.AtLeast(student));
            Thread.Sleep(1000);
        }

        [Then(@"Click Notify Button to send the email")]
        public void ThenClickNotifyButtonToSendTheEmail()
        {
            //click search for candidate
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/button")).Click(); 
            Thread.Sleep(1000);
        }

        [Then(@"The status of the Job Offer became (.*)")]
        public void ThenTheStatusOfTheJobOfferBecame(string status)
        {
            //refresh job offer page
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/div[1]/div[2]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/div[1]/div[2]")).Click();
            Thread.Sleep(3000);

            //make sure the job has been closed
            Assert.That(driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div[1]/table/tbody/tr[1]/td[3]")).Text, Is.EqualTo(status));
            Thread.Sleep(1000);
        }              
    }
}