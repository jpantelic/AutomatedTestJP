using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using UIAutomatedTest.PageObject;


namespace UIAutomatedTest.TestCases
{
    class ContactUs
    {
        IWebDriver driver;       
        
        
        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://www.seleniumframework.com/Practiceform/";
        }

        [Test]
        public void SubmitContactUs()
        {
            
            var homePage = new HomePage(driver);
            homePage.ClearButton.Click();
            homePage.Name.SendKeys("Jelena");
            homePage.Company.SendKeys("Jelena doo");
            homePage.Telephone.SendKeys("+381651245787");
            homePage.Email.SendKeys("jecap86@gmail.com");
            homePage.Country.SendKeys("Serbia");
            homePage.Message.SendKeys("Ignore - Sending request by AutomationTest");
            homePage.SubmitButton.Click();
           
            Assert.IsTrue(homePage.FeedBack.Displayed, "Feedback doesn't exist");
                        

        }

        [Test]
        public void TakeScreenshoot()
        {
            Screenshot takePicture = ((ITakesScreenshot)driver).GetScreenshot();
            takePicture.SaveAsFile("C://Screenshot.jpeg", ScreenshotImageFormat.Jpeg);
        }

        [Test]
        public void handleNewAlert()
        {
            var homePage = new HomePage(driver);
            IAlert jsAlert = null;

            homePage.JavaAlertBox.Click();            
            jsAlert = driver.SwitchTo().Alert();
            String jsAlertText = jsAlert.Text;
            Assert.IsNotNull(jsAlert, "Java Script Alert doesn't exists");
            Console.WriteLine("Java Script Alert is: "+jsAlertText);
            jsAlert.Accept();            

        }

        [Test]
        public void handleNewWindow()
        {
            var homePage = new HomePage(driver);
            String parentHandle = null, lastHandle=null;
            parentHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle is: "+parentHandle);

            homePage.NewMessageWindow.Click();
            lastHandle = driver.WindowHandles.Last();
            Console.WriteLine("Last window's handle is: "+lastHandle);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            var newWindowPage = new NewWindowPage(driver);
            Console.WriteLine("Message on new window is: " + driver.Url);           
            Assert.IsTrue(driver.Url.Contains("about:blank"), "Url is wrong or window doesn't exist");
           // Assert.AreEqual("This message window is only for viewing purposes", newWindowPage.NewMessageWindow.Text, "Message is wrong or doesn't exist")




        }

        [Test]
        public void ExistSeleniumElement()
        {
            var homePage = new HomePage(driver);
            Assert.IsTrue(homePage.Selenium.Enabled, "Selenium element is enabled");
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }

    }
}
