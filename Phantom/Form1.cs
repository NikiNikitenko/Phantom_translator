using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;

using OpenQA.Selenium.Interactions;

using System.Threading.Tasks;
//****//
using System.Diagnostics;
using System.IO;





namespace Phantom
{
    public partial class Form1 : Form
    {
        IWebDriver PJS;
        IWebElement Search;
        int count1 = 1;
        string way_to_srt=null;
        public Form1()
        {
            InitializeComponent();
            //PJS = new PhantomJSDriver();
            //PJS.Manage().Window.Maximize();
            
            //PJS.Navigate().GoToUrl("https://dapubg.com/");
         
            //PJS.Manage().Window.Size = size;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Action(() => {
                //твой код
            

            PJS = new PhantomJSDriver();
            PJS.Manage().Window.Maximize();
            PJS.Navigate().GoToUrl("https://translate.google.com/?hl=ru");
            var size = PJS.Manage().Window.Size;
           
            size.Height += 1000;
            size.Width += 1000;
            }).BeginInvoke(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PJS.Quit();
        }


        
        private void button2_Click(object sender, EventArgs e)
        {
            //           System.IO.File.WriteAllText("text\\sourse.txt",PJS.PageSource);
            //           (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\Jpg1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //           Application.DoEvents();
            //           //label1.Text = ("Чекай скрины");
            //           Search = PJS.FindElement(By.Id("source"));
            //           Search.Click();
            //           (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\Jpg2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            ////---------------

            //           Search.SendKeys("Fuck");
            //           (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\Jpg3.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //           Search = PJS.FindElement(By.Id("result_box"));
            // string myclipboard;
            //myclipboard = Search.Text;//Clipboard.GetText();
            //   System.IO.File.WriteAllText("text\\Clipboard.txt", myclipboard);


           
                try
                {
                    using (StreamReader sr = new StreamReader("text\\words2.txt"))
                    {
                        using (StreamWriter sl = new StreamWriter("text\\Words_translate.txt"))
                        {
                            string s1 = null;
                            string myclipboard = null;
                            try
                            {
                            while (s1 != "\0")
                            {
                                s1 = Convert.ToString(sr.ReadLine());
                                sl.Write(s1 + " ");
                                Search = PJS.FindElement(By.Id("source"));
                                Search.Click();
                                Search.Clear();

                                Search.SendKeys(s1);
                                Search.SendKeys("\n");
                                System.Threading.Thread.Sleep(1000);
                                (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\live2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                                Search = PJS.FindElement(By.Id("result_box"));
                                myclipboard = Search.Text;
                                sl.Write(myclipboard + "\n");
                                (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\live3.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                            }
                            }
                            catch { }
                        }
                    }
                }
                catch { }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Action(() => {
                //твой код

            Application.DoEvents();
            Search = PJS.FindElement(By.Id("twofactorcode_entry"));
            Search.SendKeys(textBox3.Text);
            System.Threading.Thread.Sleep(3000);
            (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\Jpg6.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Search.SendKeys(OpenQA.Selenium.Keys.Return);
            (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\Jpg7.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        
            }).BeginInvoke(null, null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Action(() =>
            {
                //твой код


                (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\Live.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }).BeginInvoke(null, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Action(() => {
                //твой код
          

            System.Threading.Thread.Sleep(3000);
            Search = PJS.FindElement(By.LinkText("Store"));
            Search.Click();



                //page.open(address, function(status) {
                //    if (status !== 'success') { console.log('Unable to load the address!'); phantom.exit(); }
                //    else
                //    {
                //        window.setTimeout(function() { page.render(output); phantom.exit(); }, 1000); // Change timeout as required to allow sufficient time
                //    } });


            }).BeginInvoke(null, null);
        }
        int i,count=0,numOfPage=1;
        private void button7_Click(object sender, EventArgs e)
        {
            new Action(() => {
                //твой код
           


            i = 0;
            for (; i < 1; count++)
            {
                System.Threading.Thread.Sleep(5000);
                IWebElement SteamContainer = PJS.FindElement(By.CssSelector(".skins-list"));
                System.Threading.Thread.Sleep(1000);
                List<IWebElement> Items2 = SteamContainer.FindElements(By.CssSelector(".skin")).ToList();
                System.Threading.Thread.Sleep(1000);

                string[]  txt =new string[Items2.Count];
                for (int j = 0; j < Items2.Count; j++)
                {
                    //Items2[j].Displayed=true;
                    //(PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\Right.1." + j+ ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    txt[j] = Items2[j].Text;
                }
                for (int j = 0; j < Items2.Count; j++)
                {
                    try
                    {
                        //
                        textBox1.Text = Items2[j].Text;
                        //

                        
                        //можно попобовать отдельно написать процедуру поиска подстроки
                        if (txt.Contains("checked shirt (red)"))//("Padded Jacket (khaki)")) //("SURVIVOR CRATE"))
                        {
                            Items2[j].Click();
                            (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\Test.2." + count1 + "." + count + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            count1++;
                        }
                    }
                    catch { }
                }
                //шмотки в корзине, теперь нужно их купить
                try
                {
                    Search = PJS.FindElement(By.CssSelector(".bonus-shop-refresh"));
                    Search.Click();
                }
                catch { }
                Application.DoEvents();


            }



            }).BeginInvoke(null, null);

        }
                //IWebElement SteamContainer = PJS.FindElement(By.CssSelector(".skins-list"));
                //List<IWebElement> Items = SteamContainer.FindElements(By.CssSelector(".image")).ToList();
            //for (int j = 0; j < Items.Count; j++)
            //{
            //    try
            //    {
            //        //Items[j].FindElement(By.LinkText("SURVIVOR CRATE")).Click();
            //        if (Items[j].GetAttribute("style") ==
            //            "background-image: url(https://steamcommunity-a.akamaihd.net/economy/image/8HAGSsiO9OXk0bu4o76O6xabNUY8RRLf00e56zWT3IZUH8Flab9goIFna_837oFuZVQtq2h33qr2q44kS69BkQoWDQ/70x50);")
            //        {
            //            Items[j].Click();
            //        (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\Test.1." + j + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //        }
            //    }
            //    catch { }
            //    try
            //    {
            //        Search = PJS.FindElement(By.Id("refresh-circle"));
            //        Search.Click();
            //    }
            //    catch { }
            //}
            //for (;i<1;)
            //{
            //    //try
            //    //{
            //    //    Search = PJS.FindElement(By.CssSelector(".skin .name-container"));
            //    //    Search.Click();
            //    //    (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("text\\item"+count+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //    //    count++;
            //    //}
            //    //catch { }
            //    try
            //    {
            //        Search = PJS.FindElement(By.Id("refresh-circle"));
            //        Search.Click();
            //    }
            //    catch { }
            //            Application.DoEvents();
            //}
        private void button10_Click(object sender, EventArgs e)
        {
            new Action(() => {
                //твой код 
                PJS.Navigate().Refresh();
            }).BeginInvoke(null, null);

           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new Action(() => {
                //твой код
           
            Search = PJS.FindElement(By.CssSelector(".btn-yellow.page-next"));
            Search.Click();
            }).BeginInvoke(null, null);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Action(() => {
                //твой код
           

            Search = PJS.FindElement(By.CssSelector(".btn-yellow.page-prev"));
            Search.Click();
             }).BeginInvoke(null, null);
        }

       

       

        private void button9_Click(object sender, EventArgs e)
        {
            new Action(() => {
                //твой код
             System.IO.File.WriteAllText("text\\test.txt", PJS.PageSource);
            }).BeginInvoke(null, null);

          

        }

        private void button13_Click(object sender, EventArgs e)
        {
           
            using (StreamReader sr = new StreamReader("text\\st.srt"))
            {
                using (StreamWriter sl = new StreamWriter("text\\words.txt")) {
                    char s1;
                    bool flag=false;
                    s1 = Convert.ToChar(sr.Read());
                    try
                    {
                        while (s1 != '\0')
                        {
                            s1 = Convert.ToChar(sr.Read());
                            if (char.IsLetter(s1))
                            {sl.Write(s1); flag = true; }
                            else { if (flag) { sl.Write('\n'); flag = false; } }
                        }
                    }
                    catch { }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            File.WriteAllLines("text\\output.txt", File.ReadAllLines("text\\words.txt").OrderBy(s => s));
            File.WriteAllLines("text\\words2.txt", File.ReadAllText("text\\output.txt").Split().Distinct());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PJS.Quit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            i = 1;
        }
    }
}
