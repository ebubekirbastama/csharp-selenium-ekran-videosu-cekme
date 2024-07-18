using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace Csharp_Selenium_Ekrankayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string url = "https://ebubekirbastama.com.tr/EBSScreenVideoSave.html";
        string url1 = "https://www.trendyol.com/";
        string searchxpath = "//*[@placeholder='Aradığınız ürün, kategori veya markayı yazınız']";
        ChromeDriver drv; Thread th;
        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(kayitbasla); th.Start();
        }
        private void kayitbasla()
        {
            EkranKayitBaslat();

            #region Trendyol Test
            drv.SwitchTo().Window(drv.WindowHandles[1]);
            drv.FindElement(By.XPath(searchxpath)).SendKeys(textBox1.Text + OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(3000);
            drv.ExecuteScript("document.querySelector(\"#search-app > div > div.srch-rslt-cntnt > div.srch-prdcts-cntnr.srch-prdcts-cntnr-V2.search-products-container-for-blacklistUrl > div:nth-child(2) > div > div > div > button.quick-filters-item.collectableCoupon\").click();");
            Thread.Sleep(3000);
            drv.ExecuteScript("document.querySelector(\"#search-app > div > div.srch-rslt-cntnt > div.srch-prdcts-cntnr.srch-prdcts-cntnr-V2.search-products-container-for-blacklistUrl > div:nth-child(2) > div > div > div > button.quick-filters-item.rushDeliveryTimes\").click();");
            Thread.Sleep(3000);
            drv.ExecuteScript("document.querySelector(\"#search-app > div > div.srch-rslt-cntnt > div.srch-prdcts-cntnr.srch-prdcts-cntnr-V2.search-products-container-for-blacklistUrl > div:nth-child(2) > div > div > div > button.quick-filters-item.freeCargo\").click();");
            drv.ExecuteScript("document.querySelector(\"#sticky-aggregations > div > div:nth-child(2) > div.fltrs > div > div > div:nth-child(1) > div > a\").click();"); Thread.Sleep(3000);
            drv.ExecuteScript("document.querySelector(\"#sticky-aggregations > div > div:nth-child(2) > div.fltrs > div > div > div:nth-child(3) > div > a\").click();"); Thread.Sleep(3000);
            drv.ExecuteScript("document.querySelector(\"#sticky-aggregations > div > div:nth-child(2) > div.fltrs > div > div > div:nth-child(1) > div > a\").click();"); Thread.Sleep(3000);
            drv.ExecuteScript("document.querySelector(\"#sticky-aggregations > div > div:nth-child(2) > div.fltrs > div > div > div:nth-child(3) > div > a\").click();"); Thread.Sleep(3000);
            drv.SwitchTo().Window(drv.WindowHandles[0]);
            drv.FindElement(By.XPath("//*[@id='stopBtn']")).Click();
            MessageBox.Show("Test Bitti");
            #endregion
        }

        private void EkranKayitBaslat()
        {
            ChromeOptions op = new ChromeOptions();
            op.AddArguments("use-fake-ui-for-media");
            drv = new ChromeDriver(op);
            drv.Navigate().GoToUrl(url);
            drv.ExecuteScript($"window.open('{url1}');");
            drv.SwitchTo().Window(drv.WindowHandles[0]);
            drv.FindElement(By.XPath("//*[@id='startBtn']")).Click();
            Thread.Sleep(3000);

                SendKey("{TAB}");
                Thread.Sleep(100); // Tuşlar arasında gecikme
                SendKey("{TAB}");
                Thread.Sleep(100); // Tuşlar arasında gecikme
                SendKey("{DOWN}");
                Thread.Sleep(100); // Tuşlar arasında gecikme
                SendKey("{TAB}");
                Thread.Sleep(100); // Tuşlar arasında gecikme
                SendKey(" ");

            
        }

        static void SendKey(string key)
        {
            SendKeys.SendWait(key);
        }

    }
}
