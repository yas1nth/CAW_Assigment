using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ChromeAutomatiom
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDynamicTable()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = "https://testpages.herokuapp.com/styled/tag/dynamic-table.html";
            driver.Manage().Window.Maximize();
            if (driver.FindElement(By.XPath("//h1[text()='Dynamic HTML TABLE Tag']")).Displayed)
            {
                driver.FindElement(By.XPath("//summary")).Click();
                driver.FindElement(By.XPath("//textarea[@id='jsondata']")).Clear();
                driver.FindElement(By.XPath("//textarea[@id='jsondata']")).SendKeys("");
                driver.FindElement(By.XPath("//button[text()='Refresh Table']")).Click();
                driver.Close();

            }
        }

       
    }
}
