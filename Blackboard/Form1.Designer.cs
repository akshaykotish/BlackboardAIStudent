namespace Blackboard
{
    partial class BlackBoard_AI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Script_Panel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Chrom_Browser = new System.Windows.Forms.Panel();
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.Header_Panel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.Script_Panel.SuspendLayout();
            this.Chrom_Browser.SuspendLayout();
            this.Header_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Script_Panel
            // 
            this.Script_Panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Script_Panel.Controls.Add(this.textBox1);
            this.Script_Panel.Controls.Add(this.button3);
            this.Script_Panel.Controls.Add(this.button1);
            this.Script_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Script_Panel.Location = new System.Drawing.Point(0, 40);
            this.Script_Panel.Name = "Script_Panel";
            this.Script_Panel.Size = new System.Drawing.Size(1000, 26);
            this.Script_Panel.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(172, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(806, 26);
            this.textBox1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Location = new System.Drawing.Point(978, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 26);
            this.button3.TabIndex = 1;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Execute Script";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // Chrom_Browser
            // 
            this.Chrom_Browser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Chrom_Browser.Controls.Add(this.chromiumWebBrowser1);
            this.Chrom_Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chrom_Browser.Location = new System.Drawing.Point(0, 66);
            this.Chrom_Browser.Name = "Chrom_Browser";
            this.Chrom_Browser.Size = new System.Drawing.Size(1000, 534);
            this.Chrom_Browser.TabIndex = 5;
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(1000, 534);
            this.chromiumWebBrowser1.TabIndex = 0;
            this.chromiumWebBrowser1.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chromiumWebBrowser1_LoadingStateChanged);
            // 
            // Header_Panel
            // 
            this.Header_Panel.BackgroundImage = global::Blackboard.Properties.Resources.header;
            this.Header_Panel.Controls.Add(this.button2);
            this.Header_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header_Panel.Location = new System.Drawing.Point(0, 0);
            this.Header_Panel.Name = "Header_Panel";
            this.Header_Panel.Size = new System.Drawing.Size(1000, 40);
            this.Header_Panel.TabIndex = 3;
            this.Header_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_Panel_MouseDown);
            this.Header_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Header_Panel_MouseMove);
            this.Header_Panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Header_Panel_MouseUp);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Blackboard.Properties.Resources.btn;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(934, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 30);
            this.button2.TabIndex = 0;
            this.button2.Text = "Over";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BlackBoard_AI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.Chrom_Browser);
            this.Controls.Add(this.Script_Panel);
            this.Controls.Add(this.Header_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BlackBoard_AI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlackBoard AI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BlackBoard_AI_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BlackBoard_AI_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BlackBoard_AI_MouseUp);
            this.Script_Panel.ResumeLayout(false);
            this.Script_Panel.PerformLayout();
            this.Chrom_Browser.ResumeLayout(false);
            this.Header_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Header_Panel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel Script_Panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel Chrom_Browser;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
    }
}

