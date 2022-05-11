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
    public class ToDoTest1: IDisposable
    {
        // declaring class variables
        private const int WAIT_TIMEOUT = 30;
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly Actions action;


        //ctor click 2 times to Tab generate constructor
        public ToDoTest1()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT));
            action = new Actions(driver);



        }

       
        //test starts here with fact attribute
        [Fact]
        public void verifyToDopage()
        {
            driver.Navigate().GoToUrl("https://todomvc.com/");
            openTechAPP("React");




        }

        //method which is calling all the other action method 
        private void openTechAPP(String name)
        {
            
           IWebElement appLink = WaitAndFindElement(By.LinkText(name));
           appLink.Click();
            addnewItemToReact("Clean the console");
            addnewItemToReact("Clean the DB");
            addnewItemToReact("Clean the Code");

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

        //method validating result span couunt
        private void ValidateInnerTextIs(IWebElement resultspan, string expectedText)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(resultspan, expectedText));
        }





        //this method uses explicitly wait to wait then iwebelement interface to find element
        private IWebElement WaitAndFindElement(By Locator)
        {
           return wait.Until(ExpectedConditions.ElementExists(Locator));

        }

        //teardown method uses IDisposable interafce
        public void Dispose()
        {
           driver.Close();
        }
    }
}
