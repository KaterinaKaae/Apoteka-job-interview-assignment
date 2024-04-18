
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace TestApotec.Tests
{
    public class BasketTest1Chrome //Basket Test on Chrome 
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver with options
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLogin()
        {
            // Create instance of Login Helper
            LoginHelper loginHelper = new LoginHelper(driver);

            // Call Login method before performing test actions
            loginHelper.Login( "jekaterina@mail.dk", "Bluehouse24");


            // Find and click on the haandkoebsmedicin link
            IWebElement haandkoebsmedicinLink = driver.FindElement(By.CssSelector("div[role='navigation'] li:nth-child(3) a:nth-child(1) span:nth-child(1)"));
            haandkoebsmedicinLink.Click();

            // Find and click on the link "Se al håndkøbsmedicin"
            IWebElement counterLink = driver.FindElement(By.PartialLinkText("Se al håndkøbsmedicin"));
            counterLink.Click();

            // Find and click on the link "Børnemedicin"
            IWebElement boernemedicinLink = driver.FindElement(By.PartialLinkText("Børnemedicin"));
            boernemedicinLink.Click();
            Console.WriteLine("Børnemedicin link Successful!");


            // Wait for the page to load 
           // System.Threading.Thread.Sleep(1000);

            // Find and click on the link "Panodil Junior 125mg"
            IWebElement panodil125mgLink = driver.FindElement(By.CssSelector("a.product-link[data-product-id=\"550731\"]"));
            panodil125mgLink.Click();                                         
            Console.WriteLine("Panodil Junior 125mg link Successful!");

            // Wait for the page to load 
            //System.Threading.Thread.Sleep(1000);

            // Find and click on the link "Læg i kurv"
            IWebElement leagikurvLink = driver.FindElement(By.CssSelector("a[class='btn btn-primary btn-lg'] span[class='enable-add']"));
            leagikurvLink.Click();
            Console.WriteLine("Læg i kurv Link Successful!");

            // Wait for the page to load 
            System.Threading.Thread.Sleep(3000);

            // Find and click on the link "Gå til kurv"
            IWebElement gotilkurvLink = driver.FindElement(By.CssSelector("#addToCart > div > div > div.modal-body > div > div.col-xs-12.col-sm-5 > div > div:nth-child(3) > p:nth-child(1) > a"));
            gotilkurvLink.Click();
            Console.WriteLine("Gå til kurv Link Successful!");


            // Check for the product in the basket
            try
            {
                IWebElement CartEmptyMessage = driver.FindElement(By.CssSelector("a[href = '/panodil-junior-125-mg-10-stk-suppositorier-550731']"));
                Console.WriteLine("Selected product is in the basket!"); 

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Selected product is not in the basket!");
            }

            // Wait for the page to load 
            System.Threading.Thread.Sleep(3000);

            // Find and click on the link "Empty basket"
            IWebElement emptybasketLink = driver.FindElement(By.CssSelector("a[title='Fjern fra kurv']"));
            emptybasketLink.Click(); 
            Console.WriteLine("Empty basket Link Successful!");

            // Wait for the page to load 
            System.Threading.Thread.Sleep(3000);

            // Verify that the basket is empty
            IWebElement emptyBasketMessage = driver.FindElement(By.XPath("//h3[normalize-space()='Din kurv er tom']"));
            if (emptyBasketMessage.Enabled)
            {
                Console.WriteLine("Din kurv er tom, test pass."); 
            }
            else
            {
                Console.WriteLine("Din kurv er ikke tom, test failed.");
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
