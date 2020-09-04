using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackboard
{
    public partial class Home : Form
    {
        BlackBoard_AI blackboard_AI = new BlackBoard_AI();
        List<String> logs = new List<string>();
        int index_id = 0;
        string login_id = "", pass = "", bb_url = "";
        bool run_class = false;
        public Home()
        {
            InitializeComponent();
        }

        Credentials credentials = new Credentials();
        private void Home_Load(object sender, EventArgs e)
        {
            Class_Check();
            if (File.Exists("CREDENTIALS.SKRIT"))
            {
                string cred = File.ReadAllText("CREDENTIALS.SKRIT");
                string wrd = "";
                int cnt = 0;
                for (int i=0; i<cred.Length; i++)
                {
                    if(cred[i] == ',' || i == cred.Length - 1)
                    {
                        if(cnt == 0)
                        {
                            login_id = wrd;
                        }
                        else if(cnt == 1)
                        {
                            pass = wrd;
                        }
                        else if(cnt == 2)
                        {
                            bb_url = wrd + cred[i];
                        }
                        cnt++;
                        wrd = "";
                    }
                    else
                    {
                        wrd = wrd + cred[i];
                    }
                }
                label6.Text = login_id;
                label1.Text = bb_url;
            }
            else
            {
                credentials.Show();
                
            }

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1 * 40 * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RUN_PROCESSES();
        }
        void RUN_PROCESSES()
        {
            //    Thread thread = new Thread(Class_Check);
            //    thread.Start();
            Class_Check();
            if (run_class == true && !blackboard_AI.isloaded)
            {
                Load_Class();
                run_class = false;
            }
        }

        void Load_Class()
        {
            if (!blackboard_AI.isloaded)
            {
                blackboard_AI.Show();
                blackboard_AI.Push_Load(index_id, bb_url, login_id, pass);
                
            }
                
        }

        void Class_Check()
        {
            if (File.Exists("TIMETABLE.csv"))
                {
                    string[] courses = File.ReadAllLines("TIMETABLE.csv");
                    for (int j = 0; j < courses.Length; j++)
                    {
                        string dt_Hh = DateTime.Now.ToString("HH");
                        string dt_Mm = DateTime.Now.ToString("mm");
                        string dayy = DateTime.Today.DayOfWeek.ToString();
                        string lines = courses[j];
                        string t_index = "";
                        string t_day = "";
                        string t_Hh = "";
                        string t_Mm = "";

                        int w_c = 0;
                        string word = "";
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i] == ',' || i == lines.Length - 1)
                            {
                                w_c++;
                                if (w_c == 1)
                                {
                                    t_index = word;
                                }
                                else if (w_c == 2)
                                {
                                    t_day = word;
                                }
                                else if (w_c == 3)
                                {
                                    t_Hh = word;
                                }
                                else if (w_c == 4)
                                {
                                    t_Mm = word + lines[i] ;
                                }

                                word = "";
                            }
                            else
                            {
                                word = word + lines[i];
                            }
                        }
                        if(dt_Hh == t_Hh && dt_Mm == t_Mm && !check_log(t_Hh + t_Mm) && t_day == dayy)
                        {
                            index_id = Convert.ToInt32(t_index);
                            logs.Add(t_Hh + t_Mm);
                            run_class = true;
                        }
                        else if(dt_Hh == t_Hh && Convert.ToInt32(dt_Mm) < Convert.ToInt32(t_Mm) && !check_log(t_Hh + t_Mm) && (t_day) == dayy)
                        {
                            l_Hh.BeginInvoke((MethodInvoker)delegate () { l_Hh.Text = t_Hh; });
                        l_Mm.BeginInvoke((MethodInvoker)delegate () { l_Mm.Text = t_Mm; });
                        l_index.BeginInvoke((MethodInvoker)delegate () { l_index.Text = t_index; });
                    }
                    }
                }
                else
                {
                }
        }

        int Get_My_Day(string d)
        {
            int v = 0;
            if(d == "Monday")
            {
                v = 0;
            }
            else if (d == "Tuesday")
            {
                v = 1;
            }
            else if (d == "Wednesday")
            {
                v = 2;
            }
            else if (d == "Thrusday")
            {
                v = 3;
            }
            else if (d == "Friday")
            {
                v = 4;
            }
            else if (d == "Saturday")
            {
                v = 5;
            }
            else if (d == "Sunday")
            {
                v = 6;
            }
            return v;
        }


        bool check_log(string l)
        {
            for(int i=0; i<logs.Count; i++)
            {
                if(l == logs[i])
                {
                    return true;
                }
            }
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Timetable timetable = new Timetable();
            timetable.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Timetable timetable = new Timetable();
            timetable.Show();
            
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            button3.Location = new Point(label6.Location.X + label6.Width + 5, label6.Location.Y + 5);
            button3.Visible = true;
        } 

        private bool mouseDown;
        private Point lastLocation;
        private void label6_MouseLeave(object sender, EventArgs e)
        {
            Thread.Sleep(10000);
            button3.Visible = false;
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
            MessageBox.Show("Hello");
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Location = new Point(label6.Location.X + label6.Width + 5, label6.Location.Y + 5);
            button3.Visible = true;
        }

        private void l_Mm_Click(object sender, EventArgs e)
        {

        }

        private void l_Hh_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            button3.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            credentials.Show();
            
        }
    }
}
