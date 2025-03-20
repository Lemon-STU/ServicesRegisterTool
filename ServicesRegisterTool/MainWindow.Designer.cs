namespace ServicesRegisterTool
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            buttonBrowser = new Button();
            textBoxServicePath = new TextBox();
            label3 = new Label();
            buttonUninstall = new Button();
            buttonInstall = new Button();
            buttonStop = new Button();
            buttonStart = new Button();
            labelServiceStatus = new Label();
            buttonRefresh = new Button();
            textBoxSetServiceName = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.ForeColor = SystemColors.ControlLightLight;
            richTextBox1.Location = new Point(0, 128);
            richTextBox1.Margin = new Padding(10);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(517, 322);
            richTextBox1.TabIndex = 0;
            richTextBox1.TabStop = false;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonBrowser);
            panel1.Controls.Add(textBoxServicePath);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(buttonUninstall);
            panel1.Controls.Add(buttonInstall);
            panel1.Controls.Add(buttonStop);
            panel1.Controls.Add(buttonStart);
            panel1.Controls.Add(labelServiceStatus);
            panel1.Controls.Add(buttonRefresh);
            panel1.Controls.Add(textBoxSetServiceName);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(517, 128);
            panel1.TabIndex = 1;
            // 
            // buttonBrowser
            // 
            buttonBrowser.Location = new Point(413, 49);
            buttonBrowser.Name = "buttonBrowser";
            buttonBrowser.Size = new Size(75, 23);
            buttonBrowser.TabIndex = 10;
            buttonBrowser.Text = "Browser";
            buttonBrowser.UseVisualStyleBackColor = true;
            buttonBrowser.Click += buttonBrowser_Click;
            // 
            // textBoxServicePath
            // 
            textBoxServicePath.Location = new Point(112, 49);
            textBoxServicePath.Name = "textBoxServicePath";
            textBoxServicePath.Size = new Size(181, 23);
            textBoxServicePath.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 52);
            label3.Name = "label3";
            label3.Size = new Size(83, 17);
            label3.TabIndex = 8;
            label3.Text = "ServicesPath:";
            // 
            // buttonUninstall
            // 
            buttonUninstall.Location = new Point(413, 89);
            buttonUninstall.Name = "buttonUninstall";
            buttonUninstall.Size = new Size(75, 23);
            buttonUninstall.TabIndex = 7;
            buttonUninstall.Text = "UnInstall";
            buttonUninstall.UseVisualStyleBackColor = true;
            buttonUninstall.Click += buttonUninstall_Click;
            // 
            // buttonInstall
            // 
            buttonInstall.Location = new Point(413, 11);
            buttonInstall.Name = "buttonInstall";
            buttonInstall.Size = new Size(75, 23);
            buttonInstall.TabIndex = 6;
            buttonInstall.Text = "Install";
            buttonInstall.UseVisualStyleBackColor = true;
            buttonInstall.Click += buttonInstall_Click;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(218, 89);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 5;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(112, 89);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 4;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelServiceStatus
            // 
            labelServiceStatus.AutoSize = true;
            labelServiceStatus.Location = new Point(304, 14);
            labelServiceStatus.Name = "labelServiceStatus";
            labelServiceStatus.Size = new Size(95, 17);
            labelServiceStatus.TabIndex = 3;
            labelServiceStatus.Text = "NOTRUNNING";
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(13, 89);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 2;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // textBoxSetServiceName
            // 
            textBoxSetServiceName.Location = new Point(112, 11);
            textBoxSetServiceName.Name = "textBoxSetServiceName";
            textBoxSetServiceName.Size = new Size(181, 23);
            textBoxSetServiceName.TabIndex = 1;
            textBoxSetServiceName.Text = "ServicesDemo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 14);
            label1.Name = "label1";
            label1.Size = new Size(93, 17);
            label1.TabIndex = 0;
            label1.Text = "ServicesName:";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 450);
            Controls.Add(richTextBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServicesRegisterTool";
            FormClosing += MainWindow_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Panel panel1;
        private Label labelServiceStatus;
        private Button buttonRefresh;
        private TextBox textBoxSetServiceName;
        private Label label1;
        private TextBox textBoxServicePath;
        private Label label3;
        private Button buttonUninstall;
        private Button buttonInstall;
        private Button buttonStop;
        private Button buttonStart;
        private Button buttonBrowser;
    }
}
