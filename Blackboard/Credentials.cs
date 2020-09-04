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
    public partial class Credentials : Form
    {
        public Credentials()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n_line = login_id.Text + "," + password.Text+ "," + blackboard_url.Text;
            File.WriteAllText("CREDENTIALS.SKRIT", n_line);

            Home home = new Home();
            home.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            
        }
    }
}
