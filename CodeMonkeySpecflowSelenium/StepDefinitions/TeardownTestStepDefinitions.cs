using CodeMonkeySpecflowSelenium.Drivers;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.ComponentModel;

namespace CodeMonkeySpecflowSelenium.StepDefinitions
{
    [Binding]
    public sealed class TeardownTestStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public TeardownTestStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to StudentsApp to Remove Student")]
        public void GivenINavigateToStudentsAppToRemoveStudent(Table table)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

            //Open URL
            driver.Url = "https://jolly-moss-057191303.2.azurestaticapps.net/";
            Thread.Sleep(2000);
        }

        [When(@"I click Login to Remove Student")]
        public void WhenIClickLoginToRemoveStudent()
        {
            //Hit Login button
            driver.FindElement(By.XPath("//*[@id=\"root\"]/nav/div[3]/button")).Click();
            Thread.Sleep(3000);
        }

        [When(@"StudentsApp Web should opened to Remove Student")]
        public void WhenStudentsAppWebShouldOpenedtoRemoveStudent()
        {
            //Make sure the headlne beside the logo is displaying students app
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"root\"]/nav/span")).Text, Is.EqualTo("Caffeine Overflow"));
            Thread.Sleep(2000);
        }

        [When(@"Search for a student named (.*)")]
        public void WhenSearchForAStudentNamed(string student)
        {
            //search for a student
            driver.FindElement(By.XPath("//*[@id=\"react-select-2-input\"]")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//*[@id=\"react-select-2-input\"]")).SendKeys(student);
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//*[@id=\"react-select-2-input\"]")).SendKeys(Keys.Return);
            Thread.Sleep(2000);

            //make sure the student is correct
            Assert.That(driver.FindElement(By.XPath("/html/body/div/div/div[3]/div/div[3]/form/div/div[1]/div[1]/input")).GetAttribute("value"), Is.EqualTo(student));
            Thread.Sleep(1000);
        }

        [When(@"Delete the student")]
        public void WhenDeleteTheStudent()
        {
            //hit delete button
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 7000)");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/div/div/div[3]/div/div[3]/form/div/div[9]/div/div/div[2]/button")).Click();
            Thread.Sleep(500);

            //confirm to delete
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/button[1]")).Click();
            Thread.Sleep(5000);
        }

        [Then(@"Student list is not storing a student named (.*)")]
        public void ThenStudentShouldRemovedFromTheList(string student)
        {
            //refresh job offer page
            driver.FindElement(By.XPath("//*[@id=\"react-select-2-input\"]")).Click();

            //search for deleted student
            driver.FindElement(By.XPath("//*[@id=\"react-select-2-input\"]")).SendKeys(student);
            driver.FindElement(By.XPath("//*[@id=\"react-select-2-input\"]")).SendKeys(Keys.Return);

            //make sure the job has been closed
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"application-tabs-tab-refresh\"]")).Text, Is.EqualTo("Refresh List"));
            Thread.Sleep(1000);
        }
    }
}