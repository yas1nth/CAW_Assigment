using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChromeAutomatiom
{
    [TestClass]
    class ImageDisable
    {
        [TestMethod]
        public static void TestMethod2()
        {
            ChromeOptions options = new ChromeOptions();
            DisableChromeOptions(options);
            IWebDriver driver = new ChromeDriver();
            driver.Url = ("https://www.amazon.com/");
            driver.Manage().Window.Maximize();
            driver.Close();

        }

        public static ChromeOptions DisableChromeOptions(ChromeOptions options)
        {
            Dictionary<String, Object> imagesMap = new Dictionary<String, Object>();
            imagesMap.Add("images", 2);

            Dictionary<String, Object> prefsMap = new Dictionary<String, Object>();
            prefsMap.Add("profile.default_content_settin_values", imagesMap);

            options.AddUserProfilePreference("prefs", prefsMap);

            return options;
        }

    }
}
