using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Xunit;

namespace OpenCartDemo
{
    public class AttributesInXunit : IDisposable
    {

        private IWebDriver driver;

        public AttributesInXunit()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [Fact]
        //[Fact(Skip = "There is a bug Jira ID = BRNK3456"]
        //[SkippableFact(typeof(DriverNotFoundException))]   add nugetpackage skippablefact
        //[Trait("Category", "CI")]
        //[Trait("Priority", "1")]
        //[RetryFact(MaxRetries = 2)]
        public void TitleTest()
        {
            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            Assert.Equal("Sample page - lambdatest.com", driver.Title);
            IWebElement header = driver.FindElement(By.XPath("//h2[text()='LambdaTest Sample App']"));
            Assert.NotNull(header);
            Console.WriteLine(header.Text);

            IWebElement sampleText = driver.FindElement(By.XPath("//input[@Id='sampletodotext']"));
            sampleText.SendKeys("hey");

            IWebElement addButton = driver.FindElement(By.XPath("//input[@Id='addbutton']"));
            addButton.Click();

        }      

        public void Dispose()
        {
            //driver.Close();
        }
    }
}
