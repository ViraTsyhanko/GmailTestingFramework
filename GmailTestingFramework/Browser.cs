using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace GmailTestingFramework
{
    public enum ElementIdentifier
    {
        ClassName,
        CssCelector,
        Id,
        LinkText,
        Name,
        PartialLinkText,
        TagName,
        XPath,
    }

    public enum Browsers
    {
        Chrome,
        Firefox,
        Ie
    }

    class Browser
    {
        public static IWebDriver Driver { get; set; }

        public static void CreateDriver(Browsers br)
        {
            switch (br)
            {
                case Browsers.Chrome:
                {
                    Driver = new ChromeDriver();
                    break;
                }

                case Browsers.Firefox:
                {
                    Driver = new FirefoxDriver();
                    break;
                }

                case Browsers.Ie:
                {
                    Driver = new InternetExplorerDriver();
                    break;
                }

                default:
                    Console.WriteLine("There is no such browser");
                    break;
            }
        }

        public static void GoTo(string url)
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElementInPage(ElementIdentifier elementIdentifier, string value)
        {
            switch (elementIdentifier)
            {
                case ElementIdentifier.Id:
                {
                    return FindElementWithWaitUnditElementIsVisible(By.Id(value));
                }

                case ElementIdentifier.XPath:
                {
                    return FindElementWithWaitUnditElementIsVisible(By.XPath(value));
                }

                case ElementIdentifier.Name:
                {
                    return FindElementWithWaitUnditElementIsVisible(By.Name(value));
                }

                case ElementIdentifier.ClassName:
                {
                    return FindElementWithWaitUnditElementIsVisible(By.ClassName(value));
                }

                case ElementIdentifier.CssCelector:
                {
                    return FindElementWithWaitUnditElementIsVisible(By.CssSelector(value));
                }

                case ElementIdentifier.LinkText:
                {
                    return FindElementWithWaitUnditElementIsVisible(By.LinkText(value));

                }

                case ElementIdentifier.PartialLinkText:
                {
                    return FindElementWithWaitUnditElementIsVisible(By.PartialLinkText(value));
                }

                case ElementIdentifier.TagName:
                {
                    return FindElementWithWaitUnditElementIsVisible(By.TagName(value));
                }

                default:
                    return null;
            }
        }

        private static IWebElement FindElementWithWaitUnditElementIsVisible(By by)
        {
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(by));
                return myDynamicElement;
            }
        }

        public static bool IsAt(ElementIdentifier el, string value)
        {
            return FindElementInPage(el, value).Displayed;
        }
    }
}
