using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Sockets;
using System.Text;

namespace ServicesDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            Application.EnableVisualStyles();
            CreateHostBuilder(args).Build().RunAsync();
            Application.Run(new MainWindow());
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<MyBackgroundService>();
                });
    }

    public class MyBackgroundService : BackgroundService
    {
        private void SendMsg(string data)
        {
            UdpClient udp = new UdpClient();
            string msg = $"{DateTime.Now}:{data}========";
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            udp.Send(buffer, buffer.Length, "127.0.0.1", 9000);
            udp.Close();
        }
        private void Log(string msg)
        {
            //string path = @"D:\System\Desktop\log.txt";
            string path =Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\log.txt";
            File.AppendAllText(path, $"{DateTime.Now}:{msg}\n");
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            string path = Environment.CurrentDirectory + "\\log.txt";
            //SendMsg("Services Start===========");
            //SendMsg(path);
            Log("Services Start===========");
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Log("Services Stoped===========");
            return base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                SendMsg("ExecuteAsync");   
                string path = Environment.CurrentDirectory + "\\log.txt";
                // 后台任务逻辑
                Log($"Service is running at {DateTime.Now}\n");
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}