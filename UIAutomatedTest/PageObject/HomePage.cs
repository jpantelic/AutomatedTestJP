using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomatedTest.PageObject
{
    class HomePage
    {
        private IWebDriver driver;


        // lokatori za sekciju Contact us
        [FindsBy(How =How.Name, Using = "name")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[class='form-mail'] input")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "telephone")]
        public IWebElement Telephone { get; set; }

        [FindsBy(How = How.Name, Using = "country")]
        public IWebElement Country { get; set; }

        [FindsBy(How = How.Name, Using = "company")]
        public IWebElement Company { get; set; }

        [FindsBy(How = How.Name, Using = "message")]
        public IWebElement Message { get; set; }

        [FindsBy(How =How.XPath, Using = "//a[.='Submit']")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How =How.XPath, Using = "//a[.='clear']")]
        public IWebElement ClearButton { get; set; }



        // par lokatora za meni

        [FindsBy(How = How.XPath, Using = "//a[.='HOME']")]
        public IWebElement Home { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[.='SELENIUM']")]
        public IWebElement Selenium { get; set; }



        // lokatori za Practise Form Controls

        [FindsBy(How =How.XPath, Using = "//button[.='New Browser Tab']")]
        public IWebElement NewBrowserTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[.='New Message Window']")]
        public IWebElement NewMessageWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[.='Alert Box']")]
        public IWebElement JavaAlertBox { get; set; }

        // obavestenja na stranici

        [FindsBy(How =How.XPath, Using = "//div/div[.='Feedback has been sent to the administrator']")]
        public IWebElement FeedBack { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
