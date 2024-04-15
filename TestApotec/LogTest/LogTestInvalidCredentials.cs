using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestApotec.Tests
{
    public class LogTestInvalidCredentials //Login Test on Firefox with wrong password
    {
       

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void TestLogin()
        {
            // Define the list of browsers
            string[] browsers = ["chrome", "firefox", "edge"];

            IWebDriver driver = new ChromeDriver();
            driver.Quit();

            // Iterate through each browser.
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
                    System.Threading.Thread.Sleep(5000);

                    // Find and click on the login link
                    IWebElement loginLink = driver.FindElement(By.CssSelector("a[href='/Account/Login']"));
                    loginLink.Click();

                    // Find the username and password fields and enter credentials
                    IWebElement usernameField = driver.FindElement(By.Id("Email"));
                    usernameField.SendKeys("jekaterina@mail.dk");

                    IWebElement passwordField = driver.FindElement(By.Id("password"));
                    passwordField.SendKeys("Bluehouse50");  //wrong pass

                    // Find and click on the login button
                    IWebElement loginButton = driver.FindElement(By.Id("login-submit"));
                    loginButton.Click();

                    // Wait for the page to load after login
                    System.Threading.Thread.Sleep(5000);

                    // Verify if the login was not successful by checking for "Forkert brugernavn eller adgangskode" message
                    IWebElement loggedInMessage = driver.FindElement(By.XPath("//p[contains(text(),'Forkert brugernavn eller adgangskode. Prøv igen el')]"));
                    Console.WriteLine($"Test pass.Login is not Successful with wrong password in {browser}");
                
                    //----------------------------------------------------------------------------------
                    //Test Login with wrong user name

                    // Find the username and password fields and enter credentials
                    usernameField = driver.FindElement(By.Id("Email"));
                    usernameField.Clear();
                    usernameField.SendKeys("katerina@mail.dk"); //wrong username

                    passwordField = driver.FindElement(By.Id("password"));
                    passwordField.Clear();
                    passwordField.SendKeys("Bluehouse24");  

                    // Find and click on the login button
                    loginButton = driver.FindElement(By.Id("login-submit"));
                    loginButton.Click();

                    // Wait for the page to load after login
                    System.Threading.Thread.Sleep(5000);

                    // Verify if the login was not successful by checking for "Forkert brugernavn eller adgangskode" message
                     loggedInMessage = driver.FindElement(By.XPath("//p[contains(text(),'Forkert brugernavn eller adgangskode. Prøv igen el')]"));
                    Console.WriteLine($"Test pass.Login is not Successful with wrong password in {browser}");
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



