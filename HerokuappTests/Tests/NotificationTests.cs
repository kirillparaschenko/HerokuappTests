using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuappTests.Tests
{
    [TestFixture]
    internal class NotificationTests
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/notification_message_rendered");

            ChromeDriver.FindElement(By.LinkText("Click here")).Click();
        }

        [Test]
        public void VerifyingNotificationUnsuccesful()
        {
            Assert.That(ChromeDriver.FindElement(By.Id("flash")).Text, Is.EqualTo("Action unsuccesful, please try again\r\n×"));
        }

        [Test]
        public void VerifyingNotificationSuccesful()
        {
            Assert.That(ChromeDriver.FindElement(By.Id("flash")).Text, Is.EqualTo("Action successful\r\n×"));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
