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
            ProjectData project = new ProjectData("test_project5");

                app.projectManagement.EnsureThatProjectExists();
                List<ProjectData> oldProjects = app.projectManagement.GetProjectList();
            
                app.projectManagement.Delete();

                List<ProjectData> newProjects = app.projectManagement.GetProjectList();
                oldProjects.RemoveAt(0);
                oldProjects.Sort();
                newProjects.Sort();

                Assert.AreEqual(oldProjects, newProjects);
            }

    }
}
