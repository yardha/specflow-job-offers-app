using CodeMonkeySpecflowSelenium.Drivers;
using CodeMonkeySpecflowSelenium.Variables;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CodeMonkeySpecflowSelenium.StepDefinitions
{
    [Binding]
    public sealed class DisplayJobOffersStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public DisplayJobOffersStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
                
        [Given("I navigate to JobOffersApp to Display Job")]
        public void GivenINavigateToJobOffersApptoDisplayJob(Table table)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

            //open url
            driver.Url = "https://localhost:7273/";
            Thread.Sleep(2000);
        }

        [When("I click Login to Display Job")]
        public void WhenIClickLogintoDisplayJob()
        {
            //hit login button
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div/header/div/div")).Click();
            Thread.Sleep(2000);
        }

        [When("JobOffersApp Web should opened to Display Job")]
        public void WhenJobOffersAppWebShouldOpenedtoDisplayJob()
        {
            //Make sure the headlne beside the logo is displaying job offers app
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/div/header/p")).Text, Is.EqualTo("Job Offers App"));
        }

        [When("Job Offer List page opened to Display Job")]
        public void WhenJobRegistrationFormOpenedtoDisplayJob()
        {
            //make sure by default the opened page is job offer list
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/h1")).Text, Is.EqualTo("List Of Job Offers"));
        }

        [When("Filter by Title is activated using (.*)")]
        public void WhenFilterByTitleIsActivatedUsing(string filterTitle)
        {
            //click and input filter by title
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[1]/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[1]/input")).SendKeys(filterTitle);
            
            //make sure the filter title is written
            Assert.That(driver.FindElement(By.XPath("//*[@id=\\\"jobOfferListTable\\\"]/thead/tr/th[1]/input\"")).GetAttribute("value"), Is.EqualTo(filterTitle));
            
            //make sure the result of the filter by title is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[1]")).GetAttribute("value"), Is.EqualTo(filterTitle));
            Thread.Sleep(2000);
        }

        [When("Filter by Company is activated using (.*)")]
        public void WhenFilterByCompanyIsActivatedUsing(string filterCompany)
        {
            //click and input filter by company
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[2]/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[2]/input")).SendKeys(filterCompany);

            //make sure the filter company is written
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[2]/input")).GetAttribute("value"), Is.EqualTo(filterCompany));

            //make sure the result of the filter by company is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[2]")).GetAttribute("value"), Is.EqualTo(filterCompany));
            Thread.Sleep(2000);
        }

        [When("Filter by Status is activated using (.*)")]
        public void WhenFilterByStatusIsActivatedUsing(string filterStatus)
        {
            //click and choose filter by status
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).Click();
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).SendKeys(filterStatus);
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).SendKeys(Keys.Return);

            //make sure the filter status is written
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).GetAttribute("value"), Is.EqualTo(filterStatus));

            //make sure the result of the filter by status is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr/td[3]")).GetAttribute("value"), Is.EqualTo(filterStatus));
            Thread.Sleep(2000);
        }

        [When("Filter by Date is activated using Today date")]
        public void WhenFilterByDateIsActivatedUsing()
        {
            //click and choose filter by date
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[4]/button")).Click();

            //click and input start date as today
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div/div/input")).Click();
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div[1]/div/input")).SendKeys(DateTime.Now.ToString("yyyy/MM/dd"));
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div[1]/div/input")).SendKeys(Keys.Return);

            //click and input end date as today
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div/input")).Click();
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div/input")).SendKeys(DateTime.Now.ToString("yyyy/MM/dd"));
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div/input")).SendKeys(Keys.Return);
            
            //make sure the start date is today
            Assert.That(driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div/div/input")).GetAttribute("value"), Is.EqualTo(DateTime.Now.ToString("yyyy/MM/dd")));

            //make sure the end date is today
            Assert.That(driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div/input")).GetAttribute("value"), Is.EqualTo(DateTime.Now.ToString("yyyy/MM/dd")));

            //click to apply the date filter
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/button[2]")).Click();

            //make sure the date filter is applied
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[4]/button")).GetAttribute("value"), Is.EqualTo("Dates picked!"));

            //make sure result of the date filter is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[4]")).GetAttribute("value"), Is.EqualTo(DateTime.Now.ToString("yyyy/MM/dd")));
            Thread.Sleep(2000);
        }

        [When("Remove Filter is chosen")]
        public void WhenRemoveFilterIsChosen()
        {
            //click remove all filter
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[5]/button")).Click();

            //make sure filter by title is cleared
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[1]/input")).GetAttribute("value"), Is.EqualTo(""));

            //make sure filter by company is cleared
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[2]/input")).GetAttribute("value"), Is.EqualTo(""));

            //make sure filter by status is cleared
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).GetAttribute("value"), Is.EqualTo("None"));

            //make sure filter by date is cleared
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[4]/button")).GetAttribute("value"), Is.EqualTo("Pick dates"));
            Thread.Sleep(2000);
        }

    }
}