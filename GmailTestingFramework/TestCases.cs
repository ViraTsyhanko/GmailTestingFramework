using System;
using GmailTestingFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GmailTestingFramework
{
    [TestClass]
    public class TestCases
    {

        [TestInitialize]
        public void Initialization()
        {
            Browser.CreateDriver(Browsers.Ie);
            Browser.GoTo("https://mail.google.com");
        }
        [TestMethod]
        public void SignInWithValidCredentials()
        {
            MainPage.SiginOperation("viratsyhanko@gmail.com", "2611180895");
        }
    }
}
