using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomatedTest.PageObject
{
    class NewWindowPage
    {
        IWebDriver driver;

        [FindsBy(How =How.XPath, Using = "//body[.='This message window is only for viewing purposes']")]
        public IWebElement NewMessageWindow { get; set; }

        public NewWindowPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
