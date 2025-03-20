using System.Text.RegularExpressions;

namespace ServicesRegisterTool
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Load += MainWindow_Load;
        }

        private void MainWindow_Load(object? sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Config.Default.LastServiceExe))
            this.textBoxServicePath.Text = Config.Default.LastServiceExe;
            if(!string.IsNullOrEmpty(Config.Default.LastServiceName))
            this.textBoxSetServiceName.Text = Config.Default.LastServiceName;
        }

        private void buttonBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(Service Application)|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxServicePath.Text = ofd.FileName;
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            string _serviceName = textBoxSetServiceName.Text.Trim(); 
            string _servicePath = textBoxServicePath.Text.Trim();
            if (!string.IsNullOrEmpty(_serviceName) && !string.IsNullOrEmpty(_servicePath))
            {
                Config.Default.LastServiceName = _serviceName;
                Config.Default.LastServiceExe = _servicePath;
                InstallService(_serviceName,_servicePath);
            }
            else
            {
                MessageBox.Show("ServiceName can not be empty!");
            }
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            UnInstallService(textBoxSetServiceName.Text.Trim());
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            string _servcieName = textBoxSetServiceName.Text.Trim();
            Config.Default.LastServiceName= _servcieName;
            var Status = QueryServiceStatus(_servcieName);
            labelServiceStatus.Text = Status;
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartServices(textBoxSetServiceName.Text.Trim());
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopServices(textBoxSetServiceName.Text.Trim());
        }


        private void AppendLog(string msg)
        {
            this.richTextBox1.AppendText(msg);
            this.richTextBox1.ScrollToCaret();
        }

        private void InstallService(string ServiceName,string ServiceFilePath)
        {
            if (IsServiceExist(ServiceName))
            {
                MessageBox.Show($"{ServiceName} is Exist!");
            }
            else
            {
                string exeFile = ServiceFilePath;// 
                if (File.Exists(exeFile))
                {
                    var executeResult = CommandHelper.ExecuteCommand($"sc create {ServiceName} binPath={exeFile}",
                        out int exitCode, out bool errOccurred, out string errMsg);
                    AppendLog(executeResult);
                    if (exitCode == 0)
                    {
                        Thread.Sleep(500);
                        executeResult = CommandHelper.ExecuteCommand($"sc config {ServiceName} start= auto", out exitCode, out errOccurred, out errMsg);
                        AppendLog(executeResult);
                        if (exitCode == 0)
                        {
                            MessageBox.Show($"{ServiceName} install Successful!");
                            QueryServiceStatus(ServiceName);
                        }
                    }
                    else
                    {
                        MessageBox.Show(executeResult);
                    }
                }
                else
                {
                    MessageBox.Show($"{exeFile} is not Exist!");
                }
            }
        }
        private void UnInstallService(string ServiceName)
        {
            if (IsServiceExist(ServiceName))
            {
                var status = QueryServiceStatus(ServiceName);
                if (status.Equals("RUNNING", StringComparison.OrdinalIgnoreCase))
                {
                    StopServices(ServiceName);
                    Thread.Sleep(500);
                }
                var executeResult = CommandHelper.ExecuteCommand($"sc delete {ServiceName}", out int exitCode, out bool errOccurred, out string errMsg);
                AppendLog(executeResult);
                if (exitCode == 0)
                {
                    MessageBox.Show($"{ServiceName} Uninstall successful!");
                }
                else
                {
                    MessageBox.Show($"{ServiceName} Uninstall Fail! {executeResult}");
                }
            }
            else
            {
                MessageBox.Show($"{ServiceName} Not Exist!");
            }
        }
        private bool IsServiceExist(string ServiceName)
        {
            var executeResult = CommandHelper.ExecuteCommand($"sc query {ServiceName}", out int exitCode, out bool errOccurred, out string errMsg);
            AppendLog(executeResult);
            if (exitCode != 0)
            {
                return false;
            }
            return true;
        }

        private string QueryServiceStatus(string ServiceName)
        {
            string _serviceStatus = "";
            var executeResult = CommandHelper.ExecuteCommand($"sc query {ServiceName}", out int exitCode, out bool errOccurred, out string errMsg);
            AppendLog(executeResult);
            if (exitCode != 0)
            {
                _serviceStatus = "NOT EXIST";
            }
            else
            {
                Regex pattern = new Regex(@"STATE\s*:\s*\d+\s+(\w+)", RegexOptions.Multiline);
                var matchs = pattern.Match(executeResult);
                if (matchs.Success)
                {
                    _serviceStatus = matchs.Groups[1].Value;
                }
            }
            labelServiceStatus.Text = _serviceStatus;
            return _serviceStatus;
        }

        private void StartServices(string ServiceName)
        {
            if (IsServiceExist(ServiceName))
            {
                var executeResult = CommandHelper.ExecuteCommand($"sc start {ServiceName}", out int exitCode, out bool errOccurred, out string errMsg);
                AppendLog(executeResult);
                if (exitCode == 0)
                {
                    Thread.Sleep(500);
                    QueryServiceStatus(ServiceName);
                }
            }
            else
            {
                MessageBox.Show($"{ServiceName} not exist!");
            }
        }

        private void StopServices(string ServiceName)
        {
            if (IsServiceExist(ServiceName))
            {
                var executeResult = CommandHelper.ExecuteCommand($"sc stop {ServiceName}", out int exitCode, out bool errOccurred, out string errMsg);
                AppendLog(executeResult);
                if (exitCode == 0)
                {
                    Thread.Sleep(500);
                    QueryServiceStatus(ServiceName);
                }
            }
            else
            {
                MessageBox.Show($"{ServiceName} not exist!");
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Default.Save();
        }
    }
}
