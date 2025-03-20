using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesDemo
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
        }
        static string ExecuteCommand(string command)
        {
            // 创建一个 ProcessStartInfo 对象
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", // 使用 cmd.exe 执行命令
                Arguments = $"/c {command}", // /c 参数表示执行命令后关闭窗口
                RedirectStandardOutput = true, // 重定向标准输出
                RedirectStandardError = true, // 重定向标准错误
                UseShellExecute = false, // 不使用操作系统 shell 启动进程
                CreateNoWindow = true, // 不创建新窗口
                WorkingDirectory=Environment.CurrentDirectory
            };

            // 创建 Process 对象
            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;

                // 启动进程
                process.Start();

                // 读取标准输出
                string output = process.StandardOutput.ReadToEnd();

                // 读取标准错误
                string error = process.StandardError.ReadToEnd();

                // 等待进程退出
                process.WaitForExit();

                // 如果有错误，抛出异常
                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception($"Command failed: {error}");
                }

                return output;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var str= ExecuteCommand($"sc create ServiceDemo binPath={Application.ExecutablePath}");
                Console.WriteLine(str);
                str = ExecuteCommand($"sc start ServiceDemo");
                Console.WriteLine(str);
            }
            else
            {
                var str = ExecuteCommand($"sc delete ServiceDemo");
                Console.WriteLine(str);
            }
        }
    }
}
