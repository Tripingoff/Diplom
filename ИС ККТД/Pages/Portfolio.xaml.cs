using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Page = System.Windows.Controls.Page;
using System.IO.Packaging;
using DocumentFormat.OpenXml.EMMA;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для Portfolio.xaml
    /// </summary>
    public partial class Portfolio : Page
    {
        public Portfolio()
        {
            InitializeComponent();
            TextBlockActual.Text = $"Актуальное шаблон портфолио на {DateTime.Now}";
            TbFail.Text = "портфолио";
        }

        private void BtnDownloudFail_Click(object sender, RoutedEventArgs e)
        {

            string sourceFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Portfolio","портфолио.docx");
            if (System.IO.File.Exists(sourceFilePath))
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "портфолио"; // Default file name
                dlg.Filter = "Word file (*.docx) | *.docx"; // Filter files by extension

                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    string destinationFilePath = dlg.FileName;
                    System.IO.File.Copy(sourceFilePath, destinationFilePath, true);
                }
            }
            //Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            //dlg.FileName = "портфолио";// Default file name
            //                           // Default file extension
            //dlg.Filter = "Word file (*.docx) | *.docx"; // Filter files by extension

            //// Show save file dialog box
            //Nullable<bool> result = dlg.ShowDialog();

            //if (result == true)
            //{
            //    string downloadPath = dlg.FileName;
            //    string savePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "портфолио.docx");

            //    using (WebClient webClient = new WebClient())
            //    {
            //        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback4);
            //        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            //        webClient.DownloadFile(new Uri(downloadPath), savePath);
            //    }
            //}

        }
        private static void DownloadProgressCallback4(object sender, DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...",
                (string)e.UserState,
                e.BytesReceived,
                e.TotalBytesToReceive,
                e.ProgressPercentage);
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Download has been canceled.");
            }
            else
            {

                MessageBox.Show("Download completed!");
            }
        }
    }
}
