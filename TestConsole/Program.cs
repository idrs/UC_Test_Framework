using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var driver = new ChromeDriver())
            {
                // implizit global wait
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));


                driver.Navigate().GoToUrl("http://www.hotel.de");

                var searchbox = driver.FindElementById("SearchCriteria_Destination");
                searchbox.SendKeys("Berlin");

                //var searchbutton = driver.FindElementById("SearchSubmitButton_ButtonValue");

                // Explicit wait
                var searchbutton = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until<IWebElement>(d =>
                    d.FindElement(By.Id("SearchSubmitButton_ButtonValue"))
                );

                Thread.Sleep(TimeSpan.FromSeconds(10));

                searchbutton.Click();
            }

            
        }
    }
}


// Example:
// http://scraping.pro/example-of-scraping-with-selenium-webdriver-in-csharp/

namespace WebDriverTest
{
    class Program
    {
        static void blablnalnla()
        {
            // Initialize the Chrome Driver
            using (var driver = new ChromeDriver())
            {
                // Go to the home page
                driver.Navigate().GoToUrl("http://testing-ground.scraping.pro/login");

                // Get the page elements
                var userNameField = driver.FindElementById("usr");
                var userPasswordField = driver.FindElementById("pwd");
                var loginButton = driver.FindElementByXPath("//input[@value='Login']");

                // Type user name and password
                userNameField.SendKeys("admin");
                userPasswordField.SendKeys("12345");

                // and click the login button
                loginButton.Click();

                // Extract the text and save it into result.txt
                var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
                File.WriteAllText("result.txt", result);

                // Take a screenshot and save it into screen.png
                driver.GetScreenshot().SaveAsFile(@"screen.png", ImageFormat.Png);
            }
        }
    }
}

