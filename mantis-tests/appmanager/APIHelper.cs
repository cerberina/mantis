using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mantis_tests.Mantis;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueDataLocal issueData)
        {
            Mantis.MantisConnectPortTypeClient client= new MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }
    }
}
