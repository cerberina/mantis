using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class DeleteProjectTests : AuthTestBase
    {
        [Test]
        public void DeleteProject()
        {
            AccountData account = new AccountData("administrator") { Password = "root" };
            ProjectData project = new ProjectData("empty");

            app.projectManagement.EnsureThatProjectExists(account, project);
            //List<ProjectData> oldProjects = app.projectManagement.GetProjectList();
            List<ProjectData> oldProjects = app.API.GetProjectsList(account);
            app.projectManagement.Delete();

            //List<ProjectData> newProjects = app.projectManagement.GetProjectList();
            List<ProjectData> newProjects = app.API.GetProjectsList(account);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}
