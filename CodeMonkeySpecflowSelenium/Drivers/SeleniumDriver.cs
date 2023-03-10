using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMonkeySpecflowSelenium.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver Setup()
        {
            var edgeOptions = new EdgeOptions();
            driver = new RemoteWebDriver(new Uri("http://localhost:9515"), edgeOptions.ToCapabilities());

            _scenarioContext.Set(driver, "WebDriver");
            Thread.Sleep(3000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            return driver;
        }

        private dynamic GetBrowserOptions(string browserName)
        {
            if (browserName.ToLower() == "chrome")
                return new ChromeOptions();
            if (browserName.ToLower() == "firefox")
                return new FirefoxOptions();
            if (browserName.ToLower() == "MicrosoftEdge")
                return new EdgeOptions();
            if (browserName.ToLower() == "safari")
                return new SafariOptions();

            return new EdgeOptions();
        }
    }
}
