using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace TestApotec.Tests
{
    public class LogTestPassChange //Login Test on Chrome with Passworg Change
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLogin()
        {


            // Navigate to the apopro.dk Password Change page

            driver.Navigate().GoToUrl("https://apopro.dk/Account/ResetPassword?encryptedEmail=ZXiKz9H9ZeCfVqpuMKvo%252b%252fGzSOc20MgX2hJnOcUQ%252biP1sx182LTf0tJ56rXEPNrg&token=BuQWv6wIcdAc8dK5k%2Br9T%2FndD9ZWer7lS1NzyT92sYFARP9%2B9cH7AmSlEp9C9Zuh55gfjouseNEv7exT%2FU%2BxU5UBVIRnCcjfcNcqJAqA7sNYQtP%2BE%2BttfcEpuKwdNYemGaoa3pz%2F%2BLa%2F9e5DVNxtjeWaY7Ki0ZQbotga5P3J2XojyRKjCAMbOIXWT5UID1hbx%2FKkVg%3D%3D%20Med%20venlig%20hilsen");

            // Find "Skift adganskode" message
            IWebElement changpassmessage = driver.FindElement(By.XPath("//h4[normalize-space()='Skift adgangskode']"));
            Console.WriteLine("Skift adganskode message presented");
 


            // Find the username and password fields and enter credentials
             IWebElement resetpass = driver.FindElement(By.Id("reset-pass"));
            resetpass.SendKeys("Bluehouse24");

            IWebElement repeatpass = driver.FindElement(By.Id("repeat-pass"));
            repeatpass.SendKeys("Bluehouse24");

            // Find and click on the "to reset password" button
            IWebElement resetpassButton = driver.FindElement(By.Id("to-reset-password"));
            resetpassButton.Click();

            // Wait for the page to load after login
            System.Threading.Thread.Sleep(3000);

            // Verify if the login was successful by checking for "Profil for jekaterina@mail.dk" element on the logged-in page
            try
            {
                IWebElement loggedInMessage = driver.FindElement(By.CssSelector("h1[class='col-sm-12']"));
                Console.WriteLine("Login Successful!");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Login Failed!");
            }

            // Close the browser
            driver.Quit();
        }
            [TearDown]
            public void TearDown()
            {
                // Dispose of the driver object
                driver.Dispose();
            }
        
    }
}
