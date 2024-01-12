using System.Xml;

namespace EAP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private XmlDocument document = null!;
        private void btn_download_Click(object sender, EventArgs e)
        {
            this.bgWorker.RunWorkerAsync();
            this.btn_download.Enabled = false;
            while (this.bgWorker.IsBusy)
            {
                progressBarItem.Increment(1);

                //the form remains responsive during the asynchronous operation.
                Application.DoEvents();
            }
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            document = new XmlDocument();

            Thread.Sleep(3000);

            document.Load(@"http://restapi.adequateshop.com/api/Traveler?page=1");
        }

        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBarItem.Value = 100;

            if (e.Error == null)
            {
                MessageBox.Show(document.InnerXml, "Download Complete");
            }
            else
            {
                MessageBox.Show(
                    "Failed to download file",
                    "Download failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Enable the download button and reset the progress bar.
            this.btn_download.Enabled = true;
            progressBarItem.Value = 0;
        }
    }
}
