using FluentFTP;

namespace TPL_TaskCancellation
{
    public partial class MainForm : Form
    {
        //test.rebex.net	demo/password
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationTokenSource cts1 = new CancellationTokenSource();
        CancellationTokenSource cts2 = new CancellationTokenSource();
        CancellationTokenSource cts3 = new CancellationTokenSource();
        private void btn_start_Click(object sender, EventArgs e)
        {
           var cts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token, cts3.Token);
            var token = cts.Token;
            var context = SynchronizationContext.Current;//channel/bridge
            Task.Factory.StartNew(() =>
            {
                var ftpClient = new FtpClient("test.rebex.net", "demo", "password");
                ftpClient.AutoConnect();
                context.Send(LogData, $"Connection to ftp server was successfully done");
                foreach (FtpListItem fileItem in ftpClient.GetListing("/pub/example"))
                {
                    if (fileItem.Type == FtpObjectType.File)
                    {
                        if (token.IsCancellationRequested)
                        {
                            context.Send(LogData, $"Cancellation requested");
                            throw new OperationCanceledException();//better 
                           
                        }

                        context.Send(LogData, $"Preparing to download {fileItem.Name}....");
                        ftpClient.DownloadFile($"C:/files/ftp/{fileItem.Name}", fileItem.FullName);
                        context.Send(LogData, $"Download completed for {fileItem.Name}....");
                    }
                }
            }, token);
        }

        private void LogData(object? state)
        {
            rcbx_text.AppendText($"{state.ToString()}\n");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cts2.Cancel();
        }
    }
}
