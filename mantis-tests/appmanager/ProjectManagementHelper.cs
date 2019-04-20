using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper: HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void Create(ProjectData project)
        {
            AccountData account = new AccountData("administrator")
            {
                Password = "root"
            };

            OpenManagePage();
            SelectManageProjectsTab();
            InitializeCreation();
            FillProjectForm(project);
            ClickSubmitButton();
        }

        public void Delete()
        {
            OpenManagePage();
            SelectManageProjectsTab();
            SelectProjectFromTheList();
            InitiateDeleteProject();
            ClickSubmitDeletionButton();
        }

        private ProjectManagementHelper ClickSubmitDeletionButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[4]")));
            driver.FindElement(By.XPath("//input[4]")).Click();
            return this;
        }

        private ProjectManagementHelper InitiateDeleteProject()
        {
            driver.FindElement(By.XPath("//form[@id='project-delete-form']/fieldset/input[3]")).Click();
            return this;
        }

        private ProjectManagementHelper SelectProjectFromTheList()
        {
            driver.FindElement(By.XPath("//td/a")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//form[@id='manage-proj-update-form']/div/div/h4")));
            return this;
        }

        public ProjectManagementHelper ClickSubmitButton()
        {
            driver.FindElement(By.XPath("//form[@id='manage-project-create-form']/div/div[3]/input")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[2]/div[2]/div/ul/li[3]/a")));
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

        public void EnsureThatProjectExists()
        {
            List<ProjectData> projects = GetProjectList();
            if (!IsProjectExists())
            {
                ProjectData proj = new ProjectData("new_project");
                Create(proj);
            }

        }

        public bool IsProjectExists()
        {
            return GetProjectList().Count != 0;
        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.managementMenu.GoToManagementPage();
            manager.managementMenu.GoToProjectPage();

            IWebElement table = driver.FindElement(By.ClassName("table-responsive"));
            IWebElement body = table.FindElement(By.TagName("tbody"));

            ICollection<IWebElement> elements = body.FindElements(By.TagName("tr"));
            foreach (IWebElement element in elements)
            {
                ICollection<IWebElement> cellElements = element.FindElements(By.TagName("td"));
                IWebElement[] projectCells = new IWebElement[cellElements.Count];
                cellElements.CopyTo(projectCells, 0);

                projects.Add(new ProjectData(projectCells[0].Text));
            }

            return projects;
        }
    }
}
