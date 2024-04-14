using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace TestApotec.Tests
{
    public class LoginTest3browsers //Login Test on Chrome with correct credentials
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestLogin()
        {
            // Define the list of browsers
            string[] browsers = [ "chrome", "firefox", "edge" ];

            IWebDriver driver = new ChromeDriver();
            driver.Quit();

            // Iterate through each browser
            foreach (string browser in browsers)
            {
                try
                {
                    // Initialize the corresponding WebDriver based on the browser
                    switch (browser)
                    {
                        case "chrome":
                            driver = new ChromeDriver();
                            driver.Manage().Window.Maximize();
                            Console.WriteLine($"Browser: {browser}");
                            break;
                        case "firefox":
                            driver = new FirefoxDriver();
                            driver.Manage().Window.Maximize();
                            Console.WriteLine($"Browser: {browser}");
                            break;
                        case "edge":
                            driver = new EdgeDriver();
                            driver.Manage().Window.Maximize();
                            Console.WriteLine($"Browser: {browser}");
                            break;
                        default:
                            Console.WriteLine($"Unsupported browser: {browser}");
                            continue;
                    }

                    // Navigate to the apopro.dk website

                    driver.Navigate().GoToUrl("https://apopro.dk");

                    // Find and click on the cookies "Accepter alle"
                    IWebElement cookies = driver.FindElement(By.XPath("//button[@aria-label='Accepter alle']"));
                    cookies.Click();

                    // Wait for the page to load after login
                    System.Threading.Thread.Sleep(3000);

                    // Find and click on the login link
                    IWebElement loginLink = driver.FindElement(By.CssSelector("a[href='/Account/Login']"));
                    loginLink.Click();

                    // Find the username and password fields and enter credentials
                    IWebElement usernameField = driver.FindElement(By.Id("Email"));
                    usernameField.SendKeys("jekaterina@mail.dk");

                    IWebElement passwordField = driver.FindElement(By.Id("password"));
                    passwordField.SendKeys("Bluehouse24");

                    // Find and click on the login button
                    IWebElement loginButton = driver.FindElement(By.Id("login-submit"));
                    loginButton.Click();

                    // Wait for the page to load after login
                    System.Threading.Thread.Sleep(3000);

                    // Verify if the login was successful by checking for "Profil for jekaterina@mail.dk" element on the logged-in page
                     IWebElement loggedInMessage = driver.FindElement(By.CssSelector("h1[class='col-sm-12']"));
                     Console.WriteLine($"Login successful in {browser}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error testing login in {browser}: {ex.Message}");
                }
                finally
                {
                    // Close the browser
                    driver?.Quit();
                }

            }
        }
    }
}
