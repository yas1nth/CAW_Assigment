using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ChromeAutomatiom
{
    [TestClass]
    public class DynamicTable
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
                Dictionary<string, string> EmployeeA = new Dictionary<string, string>();
                EmployeeA.Add("name","Bob");
                EmployeeA.Add("age", "20");
                EmployeeA.Add("gender", "Male");
                driver.FindElement(By.XPath("//summary")).Click();
                driver.FindElement(By.XPath("//textarea[@id='jsondata']")).Clear();
                String input = "";
                foreach(KeyValuePair<string, string> e in EmployeeA)
                {
                    if(((e.Key).ToString()).Equals("gender"))
                    {
                        input = input + "\"" + e.Key + "\"" + ":" + "\"" + e.Value + "\"";
                    }
                    else
                    {
                        input = input + "\"" + e.Key + "\"" + ":" + "\"" + e.Value + "\"" + ",";
                    }  
                }
                String finalInput = "[{" + input + "}]";
                driver.FindElement(By.XPath("//textarea[@id='jsondata']")).SendKeys(finalInput);
                driver.FindElement(By.XPath("//button[text()='Refresh Table']")).Click();

                Dictionary<string, string> ActualEmployeeA = new Dictionary<string, string>();
                for (int i = 1; i <= driver.FindElements(By.XPath("//table[@id='dynamictable']//tr[2]//td")).Count;i++)
                {
                    String columnName = driver.FindElement(By.XPath("(//table[@id='dynamictable']//tr[1]//th)["+i+"]")).Text;
                    String columnValue = driver.FindElement(By.XPath("(//table[@id='dynamictable']//tr[2]//td)["+i+"]")).Text;
                    ActualEmployeeA.Add(columnName, columnValue);
                }

                bool flag = false;
                foreach(KeyValuePair<string, string> e in EmployeeA)
                {
                    if(!(ActualEmployeeA.ContainsKey(e.Key)))
                    {
                        flag = true;
                        Console.WriteLine("Data is not as Expected");
                        break;
                    }

                    if (!(ActualEmployeeA.ContainsValue(e.Value)))
                    {
                        flag = true;
                        Console.WriteLine("Data is not as Expected");
                        break;
                    }
                }
                if(!flag)
                {
                    Console.WriteLine("Data is as Expected");
                }
                driver.Close();
            }
        }
       
    }
}
