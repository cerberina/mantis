using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests: TestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            string path = TestContext.CurrentContext.WorkDirectory;
            using (Stream localFile = File.Open(path+@"\config_inc.php", FileMode.Open))
            {
                 app.Ftp.Upload("/config_inc.php", localFile);
            }

        }


        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser3",
                Password = "password",
                Email = "testuser3@localhost.localdomain"
            };


            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }

        [OneTimeTearDown]

        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
