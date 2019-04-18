using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//form[@id='login-form']/fieldset/input[2]")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//form[@id='login-form']/fieldset/input[3]")).Click();

        }

        public void Logout()
        {
            driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/i[2]")).Click();
            driver.FindElement(By.XPath("//a[contains(@href, '/mantisbt-2.20.0/logout_page.php')]")).Click();
        }
    }
}
