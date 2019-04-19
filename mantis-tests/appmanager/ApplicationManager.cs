using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected LoginHelper loginHelper;
        protected ManagementMenuHelper managementMenuHelper;
        protected ProjectManagementHelper projectManagementHelper;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager ()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080/mantisbt-2.20.0/login_page.php";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            loginHelper = new LoginHelper(this);
            managementMenuHelper = new ManagementMenuHelper(this, baseURL);
            projectManagementHelper = new ProjectManagementHelper(this);
        }
         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost:8080/mantisbt-2.20.0/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public ManagementMenuHelper managementMenu
        {
            get
            {
                return managementMenuHelper;
            }
        }

        public ProjectManagementHelper projectManagement
        {
            get
            {
                return projectManagementHelper;
            }
        }
    }
}
