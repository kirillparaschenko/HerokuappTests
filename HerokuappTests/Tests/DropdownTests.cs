using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HerokuappTests.Tests
{
    [TestFixture]
    public class DropdownTests
    {

        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
        }

        [Test]
        public void VerifyingDropdown()
        {
            SelectElement dropDown = new SelectElement(ChromeDriver.FindElement(By.Id("dropdown")));

            dropDown.SelectByText("Option 1");
            Assert.That(dropDown.SelectedOption.GetAttribute("selected"), Is.EqualTo("true"));
            Assert.That(dropDown.SelectedOption.Text, Is.EqualTo("Option 1"));

            dropDown.SelectByText("Option 2");
            Assert.That(dropDown.SelectedOption.GetAttribute("selected"), Is.EqualTo("true"));
            Assert.That(dropDown.SelectedOption.Text, Is.EqualTo("Option 2"));
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
