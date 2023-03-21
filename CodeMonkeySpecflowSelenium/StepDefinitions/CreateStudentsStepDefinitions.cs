using CodeMonkeySpecflowSelenium.Drivers;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Diagnostics.Metrics;

namespace CodeMonkeySpecflowSelenium.StepDefinitions
{
    [Binding]
    public sealed class CreateStudentsStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public CreateStudentsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
                
        [Given(@"I navigate to StudentsApp to Create Students")]
        public void GivenINavigateToStudentsAppToCreateStudents(Table table)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

            //Open URL
            driver.Url = "https://jolly-moss-057191303.2.azurestaticapps.net/";
            Thread.Sleep(2000);
        }

        [When(@"I click Login to Create Students")]
        public void WhenIClickLoginToCreateStudents()
        {
            //Hit Login button
            driver.FindElement(By.XPath("//*[@id=\"root\"]/nav/div[3]/button")).Click();
            Thread.Sleep(3000);
        }

        [When(@"StudentsApp Web should opened to Create Students")]
        public void WhenStudentsAppWebShouldOpenedtoCreateStudents()
        {
            //Make sure the headlne beside the logo is displaying job offers app
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/nav/span")).Text, Is.EqualTo("Caffeine Overflow"));
            Thread.Sleep(2000);
        }

        [When(@"I hit Create Students Tab")]
        public void WhenIHitCreateStudentsTab()
        {
            //Hit Create Job Offer Tab
            driver.FindElement(By.XPath("//*[@id=\"application-tabs-tab-createStudent\"]")).Click();
            Thread.Sleep(2000);
        }

        [When(@"Students Registration Form opened")]
        public void WhenStudentsFormOpened()
        {
            //Make sure the title is create a job offer
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[1]/div[1]/span")).Text, Is.EqualTo("First Name"));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students First Name Field with (.*)")]
        public void WhenIFillTheStudentsFirstNameFieldWith(string firstName)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"firstName\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"firstName\"]")).SendKeys(firstName);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"firstName\"]")).GetAttribute("value"), Is.EqualTo(firstName)); 
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Last Name Field with (.*)")]
        public void WhenIFilltheStudentsLastNameFieldWith(string lastName)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"lastName\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"lastName\"]")).SendKeys(lastName);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"lastName\"]")).GetAttribute("value"), Is.EqualTo(lastName));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Email Field with (.*)")]
        public void WhenIFilltheStudentsEmailFieldWith(string email)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"email\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"email\"]")).SendKeys(email);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"email\"]")).GetAttribute("value"), Is.EqualTo(email));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Country Field with (.*)")]
        public void WhenIFilltheStudentsCountryFieldWith(string country)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-3-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-3-input\"]")).SendKeys(country);
            driver.FindElement(By.XPath("//*[@id=\"react-select-3-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[2]/div[2]/div/div/div[1]/div[1]")).Text, Is.EqualTo(country));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Telephone Field with (.*)")]
        public void WhenIFilltheStudentsTelephoneFieldwith(string telephone)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[3]/div[1]/div/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[3]/div[1]/div/input")).SendKeys(telephone);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[3]/div[1]/div/input")).GetAttribute("value"), Is.EqualTo(telephone));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Address Field with (.*)")]
        public void WhenIFilltheStudentsAddressFieldwith(string address)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"address\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"address\"]")).SendKeys(address);
            driver.FindElement(By.XPath("//*[@id=\"address\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"address\"]")).GetAttribute("value"), Is.EqualTo(address));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students University Field with (.*)")]
        public void WhenIFilltheStudentsUniversityFieldwith(string university)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-4-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-4-input\"]")).SendKeys(university);
            driver.FindElement(By.XPath("//*[@id=\"react-select-4-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[4]/div[1]/div/div/div[1]/div[1]")).Text, Is.EqualTo(university));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students IT Area Field with (.*)")]
        public void WhenIFilltheStudentsITAreaFieldwith(string area)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-5-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-5-input\"]")).SendKeys(area);
            driver.FindElement(By.XPath("//*[@id=\"react-select-5-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[4]/div[2]/div/div/div[1]/div[1]")).Text, Is.EqualTo(area));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Date of Birth Field with (.*)")]
        public void WhenIFilltheStudentsDateOfBirthFieldwith(string birthdate)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"dateOfBirth\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"dateOfBirth\"]")).SendKeys(birthdate);
            driver.FindElement(By.XPath("//*[@id=\"dateOfBirth\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            //Assert.That(driver.FindElement(By.XPath("//*[@id=\"dateOfBirth\"]")).GetAttribute("value"), Is.EqualTo(birthdate));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students City Field with (.*)")]
        public void WhenIFilltheStudentsCityFieldwith(string city)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-6-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-6-input\"]")).SendKeys(city);
            driver.FindElement(By.XPath("//*[@id=\"react-select-6-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[5]/div[2]/div/div/div[1]/div[1]")).Text, Is.EqualTo(city));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Languages Field with (.*)")]
        public void WhenIFilltheStudentsLanguagesFieldwith(string language)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 5000)");
            Thread.Sleep(1000);

            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-7-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-7-input\"]")).SendKeys(language);
            driver.FindElement(By.XPath("//*[@id=\"react-select-7-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[6]/div/div/div/div")).Text, Is.EqualTo(language));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Programming Languages Field with (.*)")]
        public void WhenIFilltheStudentsProgrammingLanguagesFieldwith(string progLang)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-8-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-8-input\"]")).SendKeys(progLang);
            driver.FindElement(By.XPath("//*[@id=\"react-select-8-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[7]/div/div/div/div")).Text, Is.EqualTo(progLang));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Agile Methodologies Field with (.*)")]
        public void WhenIFilltheStudentsAgileMethodologiesFieldwith(string agile)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-9-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-9-input\"]")).SendKeys(agile);
            driver.FindElement(By.XPath("//*[@id=\"react-select-9-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[8]/div[1]/div/div")).Text, Is.EqualTo(agile));
            Thread.Sleep(1000);
        }

        [When(@"I fill the Students Availability Field with (.*)")]
        public void WhenIFilltheStudentsAvailabilityFieldwith(string availability)
        {
            //click and input the field
            driver.FindElement(By.XPath("//*[@id=\"react-select-10-input\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"react-select-10-input\"]")).SendKeys(availability);
            driver.FindElement(By.XPath("//*[@id=\"react-select-10-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //make sure the input is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[8]/div[2]/div/div")).Text, Is.EqualTo(availability));
            Thread.Sleep(1000);
        }

        [When(@"I hit Create Students Button")]
        public void WhenIHitCreateStudentsButton()
        {
            //click submit button
            driver.FindElement(By.XPath("//*[@id=\"studentForm\"]/div/div[9]/div/div/div[1]/button")).Click();
            Thread.Sleep(10000);
        }

        [Then("I should redirected to Students List page")]
        public void ThenIShouldRedirectedToStudentsListPage()
        {
            //make sure opened page is correct
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"application-tabs-tab-refresh\"]")).Text, Is.EqualTo("Refresh List"));
            Thread.Sleep(2000);
        }
    }
}