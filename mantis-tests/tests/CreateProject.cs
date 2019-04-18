using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace mantis_tests
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
            ProjectData project = new ProjectData()
            {
                Name = "test_project"
            };
            app.projectManagement.Create(project);
        }
    }
}