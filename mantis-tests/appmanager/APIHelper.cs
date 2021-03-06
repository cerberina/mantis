﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueDataLocal issueData)
        {
            Mantis.MantisConnectPortTypeClient client= new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            
            List<ProjectData> projects_list = new List<ProjectData>();

            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
         
            foreach (Mantis.ProjectData proj in projects)
            {
                ProjectData project = new ProjectData();
                project.Id = proj.id;
                project.Name = proj.name;
                projects_list.Add(project);
            }
            return projects_list;
        }

        public void CreateNewProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData newProject = new Mantis.ProjectData();
            newProject.name = project.Name;
            client.mc_project_add(account.Name, account.Password, newProject);
        }
    }
}
