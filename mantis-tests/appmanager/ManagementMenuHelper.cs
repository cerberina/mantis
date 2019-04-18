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
            driver.FindElement(By.XPath("//a[contains(@href='/mantisbt-2.20.0/manage_overview_page.php')]")).Click();
        }

        public void GoToProjectPage()
        {
            driver.FindElement(By.XPath("//a[contains(@href='/mantisbt-2.20.0/manage_proj_page.php')]")).Click();
        }

    }
}
