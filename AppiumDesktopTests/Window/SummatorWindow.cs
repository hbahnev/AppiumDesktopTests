using OpenQA.Selenium.Appium.Windows;


namespace AppiumDesktopTests.Window
{
    public class SummatorWindow
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public SummatorWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }
        public WindowsElement num1 => driver.FindElementByAccessibilityId("textBoxFirstNum");
        public WindowsElement num2 => driver.FindElementByAccessibilityId("textBoxSecondNum");
        public WindowsElement result => driver.FindElementByAccessibilityId("textBoxSum");
        public WindowsElement calcButton => driver.FindElementByAccessibilityId("buttonCalc");

        public string Calculate(string field1, string field2)
        {
            num1.Clear();
            num1.Click();
            num1.SendKeys(field1);

            num2.Clear();
            num2.Click();
            num2.SendKeys(field2);

            calcButton.Click();
            return result.Text;
        }
    }
}

