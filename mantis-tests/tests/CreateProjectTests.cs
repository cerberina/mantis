using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace mantis_tests
{
    [TestFixture]
    public class CreateProjectTests: AuthTestBase
    {
        [Test]
        public void LoginAndLogout()
        {
            AccountData account = new AccountData("administrator")
            {
                Password = "root"
            };
            app.Auth.Login(account);
            app.Auth.Logout();
        }
        [Test]
        public void CreateNewProject()
        {
            AccountData account = new AccountData("administrator") { Password = "root" };
            ProjectData project = new ProjectData("test_project5");
            //List<ProjectData> oldProjects = app.projectManagement.GetProjectList();
            List<ProjectData> oldProjects = app.API.GetProjectsList(account);

            app.projectManagement.Create(project);

            //List<ProjectData> newProjects = app.projectManagement.GetProjectList();
            List<ProjectData> newProjects = app.API.GetProjectsList(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}