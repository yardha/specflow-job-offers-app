using CodeMonkeySpecflowSelenium.Drivers;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace CodeMonkeySpecflowSelenium.StepDefinitions
{
    [Binding]
    public sealed class CreateJobOffersStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public CreateJobOffersStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
                
        [Given(@"I navigate to JobOffersApp to Create Job")]
        public void GivenINavigateToJobOffersAppToCreateJob(Table table)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

            //Open URL
            driver.Url = "https://localhost:7273/";
            Thread.Sleep(2000);
        }

        [When(@"I click Login to Create Job")]
        public void WhenIClickLoginToCreateJob()
        {
            //Hit Login button
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/header/div/div")).Click();
            Thread.Sleep(5000);
        }

        [When(@"JobOffersApp Web should opened to Create Job")]
        public void WhenJobOffersAppWebShouldOpenedtoCreateJob()
        {
            //Make sure the headlne beside the logo is displaying job offers app
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/div/header/p")).Text, Is.EqualTo("Job Offers App"));
        }

        [When(@"I hit Create Job Offer Tab")]
        public void WhenIHitCreateJobOfferTab()
        {
            //Hit Create Job Offer Tab
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/div[1]/div[1]/div")).Click();
            Thread.Sleep(2000);
        }

        [When(@"Job Registration Form opened")]
        public void WhenJobRegistrationFormOpened()
        {
            //Make sure the title is create a job offer
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/h1")).Text, Is.EqualTo("Create a Job Offer"));
        }

        [When(@"I fill the Job Title Field with (.*)")]
        public void WhenIFillTheJobTitleFieldwith(string title)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"title\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"title\"]")).SendKeys(title);
            
            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"title\"]")).GetAttribute("value"), Is.EqualTo(title)); 
            Thread.Sleep(1000);
        }

        [When(@"I fill the Company Name Field with (.*)")]
        public void WhenIFilltheCompanyNameFieldwith(string company)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"company\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"company\"]")).SendKeys(company);
            
            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"company\"]")).GetAttribute("value"), Is.EqualTo(company));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Description Field with (.*)")]
        public void WhenIFilltheDescriptionFieldwith(string description)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"description\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"description\"]")).SendKeys(description);
            
            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"description\"]")).GetAttribute("value"), Is.EqualTo(description));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Degree Field with (.*)")]
        public void WhenIFilltheDegreeFieldwith(string degree)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-3-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-3-input\"]")).SendKeys(degree);
            driver.FindElement(By.XPath("//*[@id=\"react-select-3-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[2]/div/div[1]/div")).Text, Is.EqualTo(degree));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Programming Languages Field with (.*)")]
        public void WhenIFilltheProgrammingLanguagesFieldwith(string progLang)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-5-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-5-input\"]")).SendKeys(progLang);
            driver.FindElement(By.XPath("//*[@id=\"react-select-5-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[2]/div/div[2]/div")).Text, Is.EqualTo(progLang));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Languages Field with (.*)")]
        public void WhenIFilltheLanguagesFieldwith(string language)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-7-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-7-input\"]")).SendKeys(language);
            driver.FindElement(By.XPath("//*[@id=\"react-select-7-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[2]/div/div[3]/div")).Text, Is.EqualTo(language));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Agile Methodologies Field with (.*)")]
        public void WhenIFilltheAgileMethodologiesFieldwith(string agileMethod)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-9-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-9-input\"]")).SendKeys(agileMethod);
            driver.FindElement(By.XPath("//*[@id=\"react-select-9-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[2]/div/div[4]/div")).Text, Is.EqualTo(agileMethod));
            Thread.Sleep(1000);
        }

        [When(@"I fill the City Field with (.*)")]
        public void WhenIFilltheCityFieldwith(string city)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-11-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-11-input\"]")).SendKeys(city);
            driver.FindElement(By.XPath("//*[@id=\"react-select-11-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[3]/div/div[1]/div")).Text, Is.EqualTo(city));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Country Field with (.*)")]
        public void WhenIFilltheCountryFieldwith(string country)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-13-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-13-input\"]")).SendKeys(country);
            driver.FindElement(By.XPath("//*[@id=\"react-select-13-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[3]/div/div[2]/div")).Text, Is.EqualTo(country));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Availability Field with (.*)")]
        public void WhenIFilltheAvailabilityFieldwith(string availability)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-15-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-15-input\"]")).SendKeys(availability);
            driver.FindElement(By.XPath("//*[@id=\"react-select-15-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[3]/div/div[3]/div/div/div[1]")).Text, Is.EqualTo(availability));
            Thread.Sleep(1000);
        }

        [When(@"I hit Create Job Offer Button")]
        public void WhenIHitCreateJobOfferButton()
        {
            //click submit button
            driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[3]/div/div[4]/div/div/div[1]/button")).Click();
            Thread.Sleep(3000);
        }

        [Then("I should redirected to Job Offer List page")]
        public void ThenIShouldRedirectedToJobOfferListPage()
        {
            //make sure opened page is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/h1")).Text, Is.EqualTo("List Of Job Offers"));
            Thread.Sleep(2000);
        }

        [Then(@"Title should be (.*)")]
        public void ThenTitleShouldBe(string title)
        {
            //check the title of the inputted jobs
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[1]")).Text, Is.EqualTo(title));
            Thread.Sleep(2000);
        }

        [Then(@"Company should be (.*)")]
        public void ThenCompanyShouldBe(string company)
        {
            //check the company of the inputted jobs
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[2]")).Text, Is.EqualTo(company));
            Thread.Sleep(2000);
        }

        [Then(@"Status should be (.*)")]
        public void ThenStatusShouldBe(string status)
        {
            //check the status of the inputted jobs
            //the status should be open
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[3]")).Text, Is.EqualTo(status));
            Thread.Sleep(2000);
        }

        [Then(@"Date should be Today")]
        public void ThenDateShouldBe()
        {
            //the date should be displayed as today's date
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[4]")).Text, Is.EqualTo(DateTime.Now.ToString("yyyy/MM/dd")));
            Thread.Sleep(2000);
        }
    }
}