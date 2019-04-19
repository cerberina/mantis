using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper: HelperBase
    {
        public string baseURL;

        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url != baseURL)
            {
                driver.Navigate().GoToUrl(baseURL);
            }
        }

        public void GoToManagementPage()
        {
            GoToHomePage();
            driver.FindElement(By.CssSelector("i.menu-icon.fa.fa-gears")).Click();
        }

        public void GoToProjectPage()
        {
            driver.FindElement(By.XPath("//div[2]/div[2]/div/ul/li[3]/a")).Click();
        }

    }
}
