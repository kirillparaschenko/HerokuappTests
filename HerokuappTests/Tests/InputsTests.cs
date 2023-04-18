using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuappTests.Tests
{
    [TestFixture]
    internal class InputsTests
    {
        WebDriver ChromeDriver { get; set; }
        IWebElement input { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");

            input = ChromeDriver.FindElement(By.TagName("input"));
            input.Clear();
        }

        [Test]
        public void FillingInputWithNumbers()
        {
            input.SendKeys("123456789");
            Assert.That(input.GetAttribute("value"), Is.EqualTo("123456789"));
        }

        [Test]
        public void FillingInputWithNonNumbers()
        {
            input.SendKeys("asda!@#");
            Assert.That(input.GetAttribute("value"), Is.Empty);
        }

        [Test]
        public void FillingInputWithUpButton()
        {
            input.SendKeys(Keys.Up);
            Assert.That(input.GetAttribute("value"), Is.EqualTo("1"));
        }

        [Test]
        public void FillingInputWithDownButton()
        {
            input.SendKeys(Keys.Down);
            Assert.That(input.GetAttribute("value"), Is.EqualTo("-1"));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
