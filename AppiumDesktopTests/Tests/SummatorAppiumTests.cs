using AppiumDesktopTests.Window;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumDesktopTests.Tests
{
    public class SummatorAppiumTests
    {
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;
        private AppiumLocalService appiumLocalService;

        [OneTimeSetUp]
        public void OpenApp()
        {
            appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            appiumLocalService.Start();
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\QA Automation - Softuni 2022\06. Appium - Desktop\06.Appium-Desktop-Testing-Exercises-Resources\SummatorDesktopApp.exe");
            this.driver = new WindowsDriver<WindowsElement>(appiumLocalService, options);
        }

        [OneTimeTearDown]
        public void ShutDownApp()
        {
            this.driver.Quit();
            appiumLocalService.Dispose();
        }

        [TestCase("1", "2", "3")]
        [TestCase("-5", "-9", "-14")]
        [TestCase("2", "-2", "0")]
        [TestCase("9", "1v1", "error")]
        [TestCase("", "", "error")]
        [TestCase("", "8", "error")]
        [TestCase("4", "", "error")]
        [TestCase("  ", "3", "error")]
        [TestCase("", "samo levski", "error")]
        public void Test_Summator(string value1, string value2, string expected)
        {
            var window = new SummatorWindow(driver);
            string result = window.Calculate(value1, value2);
            Assert.AreEqual(expected, result);
        }
    }
}