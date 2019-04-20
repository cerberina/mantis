using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue: TestBase
    {
        [Test]
        public void AddIssue()
        {
            AccountData account = new AccountData("administrator"){Password = "root"};
            ProjectData project = new ProjectData(){Id ="9"};
            IssueDataLocal issueData = new IssueDataLocal()
                { Summary = "some short text", Description = "some long text", Category="General" };
            app.API.CreateNewIssue(account, project, issueData);
        }

    }
}
