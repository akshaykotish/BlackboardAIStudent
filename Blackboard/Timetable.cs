using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackboard
{
    public partial class Timetable : Form
    {
        public Timetable()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        int index_of_element = 0;
        int margin = 40;
        int row = 0;
        int size = 150;
        private void button1_Click(object sender, EventArgs e)
        {

            string n_line = Index.Text + "," + comboBox1.SelectedItem.ToString() + "," + HH.Text + "," + MM.Text + "\n";
            File.AppendAllText("TIMETABLE.csv", n_line);

            if(comboBox1.SelectedItem != null)
            {
                Painter(Index.Text, comboBox1.SelectedItem.ToString(), HH.Text, MM.Text);
            }
            else
            {
                MessageBox.Show("Please input correct values only.");
            }
        }

        void Painter(string index, string day, string Hh, string Mm)
        {
            try
            {
                Panel dynamic_text = new Panel();

                Label timmings = new Label();
                timmings.Text = Hh + ":" + Mm;
                timmings.Font = new Font("Century Gothic", 18, FontStyle.Bold);
                timmings.BackColor = Color.White;
                timmings.Location = new Point(25, 15);
                timmings.Size = new Size(100, 30);
                timmings.TextAlign = ContentAlignment.MiddleCenter;
                dynamic_text.Controls.Add(timmings);

                Label days = new Label();
                days.Text = day;
                days.Font = new Font("Century Gothic", 8, FontStyle.Bold);
                days.ForeColor = Color.Black;
                days.BackColor = Color.White;
                days.Location = new Point(25, 45);
                days.Size = new Size(100, 25);
                days.TextAlign = ContentAlignment.MiddleCenter;
                dynamic_text.Controls.Add(days);

                Label subject = new Label();
                subject.Text = "Index:- " + index;
                subject.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                subject.ForeColor = Color.Black;
                subject.BackColor = Color.White;
                subject.Location = new Point(25, 75);
                subject.Size = new Size(100, 30);
                subject.TextAlign = ContentAlignment.MiddleCenter;
                dynamic_text.Controls.Add(subject);

                dynamic_text.Location = new Point(margin + (size * index_of_element), margin + (size * row));
                dynamic_text.BackgroundImage = Blackboard.Properties.Resources.Rectangle_1;
                dynamic_text.BackgroundImageLayout = ImageLayout.Zoom;
                dynamic_text.Size = new Size(size, size);
                panel3.Controls.Add(dynamic_text);
                index_of_element++;
                if (index_of_element == 5)
                {
                    row++;
                    index_of_element = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Timetable_Load(object sender, EventArgs e)
        {

            if(File.Exists("TIMETABLE.csv"))
            {
                string[] courses = File.ReadAllLines("TIMETABLE.csv");
                for(int i=0; i<courses.Length; i++)
                {
                    Send_To_Paint(courses[i]);
                }
            }
        }

        void Send_To_Paint(string lines)
        {
            string t_index = "";
            string t_day = "";
            string t_Hh = "";
            string t_Mm = "";

            int w_c = 0;
            string word = "";
            for (int i=0; i<lines.Length; i++)
            {
                if(lines[i] == ',' || i == lines.Length - 1)
                {
                    w_c++;
                    if(w_c == 1)
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
                        t_Mm = word + lines[i];
                    }

                    word = "";
                }
                else
                {
                    word = word + lines[i];
                }
            }
            Painter(t_index, t_day, t_Hh, t_Mm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private bool mouseDown;
        private Point lastLocation;
        private void Header_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Header_Panel_MouseUp(object sender, MouseEventArgs e)
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
    }
}
