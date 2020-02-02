using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace OnlineQuizTest
{
    [TestFixture]
    public class Test
    {
        IWebDriver driver = new  ChromeDriver(); // tarayıcımızı driver nesnesine atadık
        [Test]
        public void siteninAcilmesi()
        {
            // TODO: Add your test code here
            driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login"); // tarayıcımızın gitmesi gerektiği sitenin urlsini verdik 
            Assert.Pass("sitenin açılması passing test");
        }
        [Test]
        //kullanıcı giriş testi
        public void login()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login");// tarayıcımızın gitmesi gerektiği site
            //şifre mts_test@gmail.com wNL54zWkf % wRz2F
            //burada xpath kullandık xpath tarayıcı da xml verilerine ulaşmak için kullanılır burada ana sayfa menüsünde giriş yap butonuna tıklanıyor
            driver.FindElement(By.Name("Input.Email")).SendKeys("ogrenci@gmail.com"); // burada kullanıcı adı veya eposta ile giriş için bilgiler gönderiliyor textboxa
            driver.FindElement(By.Name("Input.Password")).SendKeys("Berkan8946."); // burada kullanıcı şifresi gönderilyor textboxa
            driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/section/form/div[3]/button")).Click(); // burada ise giriş yapma butonuna tıklanıyor
            Assert.Pass("passing test");
        }
        [Test]
        //kullanıcı giriş testi
        public void login(string ID,string sifre)
        {
            driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login");// tarayıcımızın gitmesi gerektiği site
            //şifre mts_test@gmail.com wNL54zWkf % wRz2F
            //burada xpath kullandık xpath tarayıcı da xml verilerine ulaşmak için kullanılır burada ana sayfa menüsünde giriş yap butonuna tıklanıyor
            driver.FindElement(By.Name("Input.Email")).SendKeys(ID); // burada kullanıcı adı veya eposta ile giriş için bilgiler gönderiliyor textboxa
            driver.FindElement(By.Name("Input.Password")).SendKeys(sifre); // burada kullanıcı şifresi gönderilyor textboxa
            driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/section/form/div[3]/button")).Click(); // burada ise giriş yapma butonuna tıklanıyor
          
        }
        [Test]
        //kullanıcı giriş testi
        public void SoruEkle()
        {
            
            driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login");// tarayıcımızın gitmesi gerektiği site
            login("ogretmen@gmail.com", "Berkan8946.");
            //burada xpath kullandık xpath tarayıcı da xml verilerine ulaşmak için kullanılır burada ana sayfa menüsünde giriş yap butonuna tıklanıyor

            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[1]/ul/li[3]/a/span")).Click(); // burada ise giriş yapma butonuna tıklanıyor
            //şifre mts_test@gmail.com wNL54zWkf % wRz2F
            //burada xpath kullandık xpath tarayıcı da xml verilerine ulaşmak için kullanılır burada ana sayfa menüsünde giriş yap butonuna tıklanıyor
            //DropDown xpathi ver Konu
            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div[1]/div/div/select/option[8]")).Click();

            //DropDown xpathi ver Doğru şık




            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div[3]/div/div/input")).SendKeys("soru buraya yazılırr");
            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div[4]/div/div/input")).SendKeys("Cevap1");
            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div[5]/div/div/input")).SendKeys("Cevap2");

            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div[6]/div/div/input")).SendKeys("Cevap3");
            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div[7]/div/div/input")).SendKeys("Cevap4");
            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div[7]/div/div/select/option[2]")).Click();
            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/button")).Click(); // 

            Assert.Pass("passing test");
        }
        [Test]
        //kullanıcı giriş testi
        public void SınavOl()
        {
            login("ogrenci@gmail.com","Berkan8946.");
            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[1]/ul/li[4]/a/span")).Click(); // SOldaki TEST OL 

            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div/button")).Click(); // SINAVA BAŞLA 
            System.Threading.Thread.Sleep(2000);

            //burada xpath kullandık xpath tarayıcı da xml verilerine ulaşmak için kullanılır burada ana sayfa menüsünde giriş yap butonuna tıklanıyor
            for (int i = 0; i < 3; i++)
            {
                driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div/div[2]/div[1]/button")).Click();
                System.Threading.Thread.Sleep(2000);

                driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div/div[2]/div/button")).Click();
                System.Threading.Thread.Sleep(2000);

            }

            //DropDown xpathi ver Doğru şık

            //soruyu bitir
            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[2]/div/div[2]/div/div[2]/button")).Click();



          

            Assert.Pass("passing test");
        }
        [Test]
        //kullanıcı giriş testi
        public void LogOut()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login");// tarayıcımızın gitmesi gerektiği site
            //şifre mts_test@gmail.com wNL54zWkf % wRz2F
            //burada xpath kullandık xpath tarayıcı da xml verilerine ulaşmak için kullanılır burada ana sayfa menüsünde giriş yap butonuna tıklanıyor
            login("ogrenci@gmail.com", "Berkan8946.");
            driver.FindElement(By.XPath("/html/body/div/div[1]/nav/div[2]/ul[1]/li[2]/form/button")).Click(); // burada ise çıkış yapma butonuna tıklanıyor
            Assert.Pass("passing test");
        }
    }
}
