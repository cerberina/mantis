using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper: HelperBase
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            IWebElement table = driver.FindElement(By.ClassName("table-responsive"));
            IWebElement body = table.FindElement(By.TagName("tbody"));

            ICollection<IWebElement> elements = body.FindElements(By.TagName("tr"));
            foreach (IWebElement element in elements)
            {
                ICollection<IWebElement> cellElements = element.FindElements(By.TagName("td"));
                IWebElement[] accountCells = new IWebElement[cellElements.Count];
                cellElements.CopyTo(accountCells, 0);
                string href = accountCells[0].GetAttribute("href");
                string name = accountCells[0].Text;
                Match n = Regex.Match(href,@"\d+$");
                string id = n.Value;

                accounts.Add(new AccountData(name)
                {
                    Id = id
                });
            }

            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.XPath("//form[2]/fieldset/span/input")).Click();
            driver.FindElement(By.XPath("//input[4]")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "/login_page.php";

            Type(By.Name("username"), "administrator");
            driver.FindElement(By.XPath("//input[2]")).Click();
            Type(By.Name("password"), "root");
            driver.FindElement(By.XPath("//form[@id='login-form']/fieldset/input[3]")).Click();
            return driver;
        }
    }
}
