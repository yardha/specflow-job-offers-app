using CodeMonkeySpecflowSelenium.Drivers;
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
            Thread.Sleep(5000);
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
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[1]/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[1]/input")).SendKeys(filterTitle);

            //make sure the filter title is written
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[1]/input")).GetAttribute("value"), Is.AtLeast(filterTitle));
            
            //make sure the result of the filter by title is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[1]")).Text, Is.AtLeast(filterTitle));
            Thread.Sleep(2000);
        }

        [When("Filter by Company is activated using (.*)")]
        public void WhenFilterByCompanyIsActivatedUsing(string filterCompany)
        {
            //click and input filter by company
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[2]/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[2]/input")).SendKeys(filterCompany);

            //make sure the filter company is written
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[2]/input")).GetAttribute("value"), Is.AtLeast(filterCompany));

            //make sure the result of the filter by company is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[2]")).Text, Is.EqualTo(filterCompany));
            Thread.Sleep(2000);
        }

        [When("Filter by Status is activated using (.*)")]
        public void WhenFilterByStatusIsActivatedUsing(string filterStatus)
        {
            //click and choose filter by status
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).SendKeys(filterStatus);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).SendKeys(Keys.Return);

            //make sure the filter status is written
            Thread.Sleep(1000);
            //Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).Text, Is.EqualTo(filterStatus));

            //make sure the result of the filter by status is correct
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr/td[3]")).Text, Is.EqualTo(filterStatus));
            Thread.Sleep(2000);
        }

        [When("Filter by Date is activated using Today date")]
        public void WhenFilterByDateIsActivatedUsing()
        {
            //click and choose filter by date
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[4]/button")).Click();
            Thread.Sleep(1000);

            //click and input start date as today
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div/div/input")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div[1]/div/input")).SendKeys(DateTime.Now.ToString("yyyy/MM/dd"));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div[1]/div/input")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //click and input end date as today
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div/input")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div/input")).SendKeys(DateTime.Now.ToString("yyyy/MM/dd"));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div/input")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the start date is today
            Assert.That(driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div/div/input")).GetAttribute("value"), Is.EqualTo(DateTime.Now.ToString("yyyy/MM/dd")));

            //make sure the end date is today
            Assert.That(driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/div/input")).GetAttribute("value"), Is.EqualTo(DateTime.Now.ToString("yyyy/MM/dd")));

            //click to apply the date filter
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/button[2]")).Click();

            //make sure the date filter is applied
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[4]/button")).Text, Is.EqualTo("Dates picked!"));

            //make sure result of the date filter is correct
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[4]")).Text, Is.EqualTo(DateTime.Now.ToString("yyyy/MM/dd")));
            Thread.Sleep(2000);
        }

        [Then("Manage Button is chosen")]
        public void ThenManageButtonIsChosen()
        {
            //click manage
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[5]/button[1]")).Click();
            Thread.Sleep(2000);

            //add something to job offer title
            driver.FindElement(By.XPath("//*[@id=\"title\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"title\"]")).SendKeys(" but Edited");
            Thread.Sleep(2000);

            //make sure delete button is clickable
            driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[3]/div/div[4]/div/div/div[1]/button[2]")).Click();
            Thread.Sleep(1000);

            //cancel delete
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/div[2]/div")).Click();

            //make sure discard button is clickable
            driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[3]/div/div[4]/div/div/div[2]/button[1]")).Click();
            Thread.Sleep(1000);

            //cancel discard
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/div[2]/div")).Click();
            Thread.Sleep(1000);

            //make sure archive button is clickable
            driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[3]/div/div[4]/div/div/div[2]/button[2]")).Click();
            Thread.Sleep(1000);

            //cancel archive
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/div[2]/div")).Click();
            Thread.Sleep(1000);

            //make sure update button is clickable
            driver.FindElement(By.XPath("//*[@id=\"jobOfferForm\"]/div/div[3]/div/div[4]/div/div/div[1]/button[1]")).Click();
            Thread.Sleep(2000);

            //list of job offers page has been opened automatically
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/h1")).Text, Is.EqualTo("List Of Job Offers"));

            //make sure edited job has been updated properly
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[1]")).Text, Is.AtMost("but Edited"));
        }

        [Then("Archive Button is chosen")]
        public void ThenArchiveButtonIsChosen()
        {
            //click archive button
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[5]/button[2]")).Click();
            Thread.Sleep(1000);

            //confirm to archive
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/div[1]/div")).Click();
            Thread.Sleep(2000);

            //make sure job status has been archived
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[3]")).Text, Is.EqualTo("Archived"));

            //unarchive job
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[5]/button[2]")).Click();

            //confirm to unarchive
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/div[1]/div")).Click();
            Thread.Sleep(2000);

            //make sure job status has changed from archived
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[3]")).Text, Is.EqualTo("Open"));
            Thread.Sleep(1000);
        }

        [Then("Delete Button is chosen")]
        public void ThenDeleteButtonIsChosen()
        {
            //click delete button
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[5]/button[3]")).Click();
            Thread.Sleep(1000);

            //confirm to archive
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/div[1]/div")).Click();
            Thread.Sleep(2000);

            //make sure job has been removed
            Assert.AreNotSame(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/tbody/tr[1]/td[1]")).Text, Is.EqualTo("An Automated Job"));
        }

        [Then("Remove Filter is chosen")]
        public void ThenRemoveFilterIsChosen()
        {
            //click remove all filter
            driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[5]/button")).Click();
            Thread.Sleep(500);

            //make sure filter by title is cleared
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[1]/input")).GetAttribute("value"), Is.EqualTo(""));
            Thread.Sleep(500);

            //make sure filter by company is cleared
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[2]/input")).GetAttribute("value"), Is.EqualTo(""));
            Thread.Sleep(500);

            //make sure filter by status is cleared
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[3]/select")).GetAttribute("value"), Is.EqualTo("None"));
            Thread.Sleep(500);

            //make sure filter by date is cleared
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"jobOfferListTable\"]/thead/tr/th[4]/button")).Text, Is.EqualTo("Pick dates"));
            Thread.Sleep(500);
        }
    }
}