using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Xunit;


namespace OpenCartDemo
{
    public class ToDoTest2: IDisposable
    {
        private const int WAIT_TIMEOUT = 30;
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly Actions action;


        //ctor click 2 times to Tab generate constructor
        public ToDoTest2()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT));
            action = new Actions(driver);



        }


        //to do this test data driven another attribute is [Theory]
        // if there thery attribute means we have to pass param
        [Theory]
        [InlineData("Backbone.js")]
        [InlineData("AngularJS")]
        [InlineData("React")]
        [InlineData("Vue.js")]
        [InlineData("CanJS")]
        [InlineData("KnockoutJS")]
        [InlineData("Marionette.js")]
        [InlineData("Polymer")]
        [InlineData("Angular 2.0")]
        [InlineData("Dart")]
        [InlineData("Elm")]
        [InlineData("Closure")]
        [InlineData("Vanilla JS")]
        [InlineData("jQuery")]
        [InlineData("cujoJS")]
        [InlineData("Spine")]
        [InlineData("Dojo")]
        [InlineData("Mithril")]
        [InlineData("Kotlin + React")]
        [InlineData("Firebase + AngularJS")]
        [InlineData("Vanilla ES6")]
        [InlineData("Ember.js")]

        public void verifyToDopage(string techno)
        {
            driver.Navigate().GoToUrl("https://todomvc.com/");
            openTechAPP(techno);




        }

        private void openTechAPP(String name)
        {
            
           IWebElement appLink = WaitAndFindElement(By.LinkText(name));
           appLink.Click();
            addnewItemToReact("Clean the console");
            addnewItemToReact("Clean the Code");
            addnewItemToReact("Clean the DB");

            checkItemCheckBox("Clean the console").Click();
            AssertLeftItems(2);
        }

      

        private void addnewItemToReact(string todoItem)
        {
            var todoInput = WaitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
            todoInput.SendKeys(todoItem);
            action.Click(todoInput).SendKeys(Keys.Enter).Build().Perform();
        }

        private IWebElement checkItemCheckBox(string CheckBox)
        {
            var checkboxtoInput = WaitAndFindElement(By.XPath($"//label[text()='{CheckBox}']/preceding-sibling::input"));
            return checkboxtoInput;
        }

        private void AssertLeftItems(int expectedCount)
        {
            var resultspan = WaitAndFindElement(By.XPath("//footer/span"));
            if(expectedCount <= 0)
            {
                ValidateInnerTextIs(resultspan, $"{expectedCount} item left");
            }
            else
            {
                ValidateInnerTextIs(resultspan, $"{expectedCount} items left");
            }

        }

        private void ValidateInnerTextIs(IWebElement resultspan, string expectedText)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(resultspan, expectedText));
        }






        private IWebElement WaitAndFindElement(By Locator)
        {
           return wait.Until(ExpectedConditions.ElementExists(Locator));

        }

        public void Dispose()
        {
           driver.Close();
        }
    }
}
