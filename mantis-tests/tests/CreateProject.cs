using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace mantis_tests.tests
{
    [TestFixture]
    public class CreateProject: TestBase
    {
        [Test]
        public void LoginAndLogout()
        {
            AccountData account = new AccountData() {Name = "administrator", Password = "root"};
            app.Auth.Login(account);
            app.Auth.Logout();
        }
        [Test]
        public void CreateNewProject()
        {
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            app.Auth.Login(account);
            OpenManagePage();
            SelectManageProjectsTab();
            InitializeCreation();
            FillProjectForm();
            ClickSubmitButton();
            app.Auth.Logout();
        }
    }
}