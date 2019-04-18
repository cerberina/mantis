using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementHelper: HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void Create(ProjectData project)
        {
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            manager.Auth.Login(account);

            OpenManagePage();
            SelectManageProjectsTab();
            InitializeCreation();
            FillProjectForm(project);
            ClickSubmitButton();
            manager.Auth.Logout();
        }

        public ProjectManagementHelper ClickSubmitButton()
        {
            driver.FindElement(By.XPath("//form[@id='manage-project-create-form']/div/div[3]/input")).Click();
            return this;
        }

        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            return this;
        }

        public ProjectManagementHelper InitializeCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }

        public ProjectManagementHelper SelectManageProjectsTab()
        {
            manager.managementMenu.GoToProjectPage();
            return this;
        }

        public ProjectManagementHelper OpenManagePage()
        {
            manager.managementMenu.GoToManagementPage();
            return this;
        }
    }
}
