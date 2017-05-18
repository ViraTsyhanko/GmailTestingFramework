using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace GmailTestingFramework.Pages
{
    public class MainPage
    {
        private static IWebElement SignInBtm
        {
            get { return Browser.FindElementInPage(ElementIdentifier.CssCelector, ".gmail-nav__nav-link.gmail-nav__nav-link__sign-in"); }
        }

        private static IWebElement EmailOrPhoneField
        {
            get { return Browser.FindElementInPage(ElementIdentifier.Id, "identifierId"); }
        }

        private static IWebElement NextBtn
        {
            get { return Browser.FindElementInPage(ElementIdentifier.ClassName, "CwaK9"); }
        }

        private static IWebElement PasswordField
        {
            get { return Browser.FindElementInPage(ElementIdentifier.CssCelector, ".whsOnd.zHQkBf"); }
        }

        private static IWebElement LanguageBtn
        {
            get { return Browser.FindElementInPage(ElementIdentifier.CssCelector, ".MocG8c.B9IrJb.LMgvRb.KKjvXb"); }
        }

        private static IWebElement LanguageEnglishUSABtn
        {
            get { return Browser.FindElementInPage(ElementIdentifier.XPath, "//*[contains(text(),'‪English (United States)‬')]"); }
        }

        public static bool IsAtEnterEmailOrPhoneScreen()
        {
            return Browser.IsAt(ElementIdentifier.XPath, "//*[contains(text(),'Увійти')]");
        }

        public static bool IsAtEnterPasswordScreen()
        {
            return Browser.IsAt(ElementIdentifier.XPath, "//*[contains(text(),'Welcome')]");
        }

        public static void SiginOperation(string emailOrPhone, string password)
        {
            // SignInBtm.Click();
          //  ChangeLanguageForSignIn();
            Assert.IsTrue(IsAtEnterEmailOrPhoneScreen());
            EmailOrPhoneField.SendKeys(emailOrPhone);
            NextBtn.Click();
            Assert.IsTrue(IsAtEnterPasswordScreen());
            PasswordField.SendKeys(password);
            NextBtn.Click();
        }

        public static void ChangeLanguageForSignIn()
        {
            LanguageBtn.Click();
            LanguageEnglishUSABtn.Click();
        }
    }
}
