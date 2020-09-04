using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Blackboard
{
    public partial class BlackBoard_AI : Form
    {
        public bool isloaded = false;
        public BlackBoard_AI()
        {
            InitializeComponent();

            try
            {
                CefSettings settings = new CefSettings();
                //settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEFCOOKIES";
                settings.CefCommandLineArgs.Add("enable-media-stream", "1");
                Cef.Initialize(settings);
            }
            catch { }
        }

        DateTime start;
        int sc_sr = 0;
        ChromiumWebBrowser browser;
        string url = "https://cuchd.blackboard.com/";
        int index_id = 0;
        string log_id, pass;
        public void Push_Load(int indx_id, string t_url, string login_id, string passw)
        {
            index_id = indx_id;
            url = t_url;
            log_id = login_id;
            pass = passw;
            start = DateTime.Now;
            chromiumWebBrowser1.Load(url);
            isloaded = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //start = DateTime.Now;
            //chromiumWebBrowser1.Load(url);
            isloaded = true;

        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            //MessageBox.Show("State Changed");
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            Launch_Scripts();
        }

        async void Load_Script(string script)
        {
           if (chromiumWebBrowser1.CanExecuteJavascriptInMainFrame && !string.IsNullOrWhiteSpace(script))
            {
                JavascriptResponse response = await chromiumWebBrowser1.EvaluateScriptAsync(script);

                if (response.Result != null)
                {
                    MessageBox.Show(response.Result.ToString(), "JavaScript Result");
                }
            }
         }
        

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            url = browser.Address;
            sc_sr++;
        }

        

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            if (chromiumWebBrowser1.CanExecuteJavascriptInMainFrame && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                JavascriptResponse response = await chromiumWebBrowser1.EvaluateScriptAsync(textBox1.Text);

                if (response.Result != null)
                {
                    MessageBox.Show(response.Result.ToString(), "JavaScript Result");
                }
            }
        }

        private bool mouseDown;
        private Point lastLocation;
        private void BlackBoard_AI_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void BlackBoard_AI_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void BlackBoard_AI_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Header_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Header_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Header_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Script_Panel.Visible = false;
        }

        private void chromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                //MessageBox.Show(sc_sr.ToString());
                Launch_Scripts();
                sc_sr++;
            }
        }
        
        void Launch_Scripts()
        {
            switch (sc_sr)
            {
                case 0:
                    Thread thread0 = new Thread(Step1);
                    thread0.Start();
                    break;
                case 2:
                    Thread thread = new Thread(Step2);
                    thread.Start();
                    break;
                case 3:
                    //Thread thread1 = new Thread(Step3);
                    //thread1.Start();
                    break;

                case 4:
                    Thread thread2 = new Thread(Step4);
                    thread2.Start();

                    break;

                case 5:
                    Thread thread3 = new Thread(Step5);
                    thread3.Start();

                    break;
            }
        }

        void Step1()
        {
            DateTime end = DateTime.Now;
            TimeSpan c = end - start;
            int min = c.Minutes;
            while (min < 0)
            {
                Console.Write(".");
                end = DateTime.Now;
                c = end - start;
                min = c.Minutes;
            }
            var script = @"
                    document.getElementById('containerdiv').style.display = 'none';
                    document.getElementsByName('user_id')[0].value = '"+ log_id +@"';
                    document.getElementsByName('password')[0].value = '"+ pass + @"';
                    document.getElementById('entry-login').click();";
            Load_Script(script);
        }

        void Step2()
        {
            start = DateTime.Now;
            DateTime end = DateTime.Now;
            TimeSpan c = end - start;
            int min = c.Minutes;
            while (min < 2)
            {
                Console.Write(".");
                end = DateTime.Now;
                c = end - start;
                min = c.Minutes;
            }
            var script = @"
                    document.getElementsByClassName('course-title')["+ index_id +"].click();";

            Load_Script(script);
            Load_Script(script);

        }

        void Step3()
        {
            DateTime end = DateTime.Now;
            TimeSpan c = end - start;
            int min = c.Minutes;
            while (min < 2)
            {
                Console.Write(".");
                end = DateTime.Now;
                c = end - start;
                min = c.Minutes;
            }
            var script = @"
                    document.getElementsByClassName('blue-link')[2].click();";
            
            Load_Script(script);

        }


        void Step4()
        {
            DateTime end = DateTime.Now;
            TimeSpan c = end - start;
            int min = c.Minutes;
            while (min < 3)
            {
                Console.Write(".");
                end = DateTime.Now;
                c = end - start;
                min = c.Minutes;
            }
            var script = @"
                var list = document.getElementsByTagName('a');
                for (var i =0; i<list.length; i++){
                    if(list[i].getAttribute('role') == 'menuitem' && list[i].getAttribute('ng-click') == 'courseOutline.joinSession(collabSession.id)')
                    {
                        console.log(list[i].getAttribute('role'));
                        list[i].click();
                    }
                }
            ";
            Load_Script(script);
        }


        void Step5()
        {
            DateTime end = DateTime.Now;
            TimeSpan c = end - start;
            int min = c.Minutes;
            while (min < 4)
            {
                Console.Write(".");
                end = DateTime.Now;
                c = end - start;
                min = c.Minutes;
            }
            var script = @"
                var c= document.getElementsByClassName('close');
                for (var i=0; i<c.length; i++)
                    {
                         c[i].click();   
                    }            
                    ";
            Load_Script(script);
        }

        void Close_Form()
        {
            var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "MyForm").FirstOrDefault();
            if(frm != null)
            {
                MessageBox.Show("Form is open.");
                frm.Close();
                frm = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string prcs = "";
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                prcs = prcs + p.ProcessName + ", ";
            }
            MessageBox.Show(prcs);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Timetable timetable = new Timetable();
            timetable.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
