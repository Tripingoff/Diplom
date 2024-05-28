using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
using ИС_ККТД.Models;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для RaspisanieAltual.xaml
    /// </summary>
    public partial class RaspisanieAltual : Page
    {
        Расписание currentRaspisanie = new Расписание();
        public RaspisanieAltual()
        {
            InitializeComponent();
            GridStarshie.DataContext = IS_KKTDEntities.GetContext().Расписание.OrderBy(p=>p.Id_расписания).Where(p => p.Дата_начала <= DateTime.Today && p.Дата_завершения >= DateTime.Today && p.Категория == "Старшие").ToList();
            GridMladshie.DataContext = IS_KKTDEntities.GetContext().Расписание.OrderBy(p=>p.Id_расписания).Where(p=>p.Дата_начала <= DateTime.Today && p.Дата_завершения >= DateTime.Today && p.Категория == "Младшие").ToList();
            TextBlockActual.Text = $"Актуальное расписание на {DateTime.Now}";
            currentRaspisanie.Файл = TbStar.Text;
             currentRaspisanie.Файл =TbMlad.Text;

        }

        private void BtnDownloudFail_Click(object sender, RoutedEventArgs e)
        {

            string sourceFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fails", currentRaspisanie.Файл);
            if (System.IO.File.Exists(sourceFilePath))
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = currentRaspisanie.Файл; // Задаем имя файла по умолчанию
                dlg.Filter = "Excel file (*.xlsx) | *.xlsx"; // Фильтр файлов по расширению

                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    string destinationFilePath = dlg.FileName;
                    System.IO.File.Copy(sourceFilePath, destinationFilePath, true);
                }
            }

        }
        private void BtnDownloud_Click(object sender, RoutedEventArgs e)
        {
            string sourceFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fails", currentRaspisanie.Файл.ToString());
            if (System.IO.File.Exists(sourceFilePath))
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = currentRaspisanie.Файл; // Задаем имя файла по умолчанию
                dlg.Filter = "Excel file (*.xlsx) | *.xlsx"; // Фильтр файлов по расширению

                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    string destinationFilePath = dlg.FileName;
                    System.IO.File.Copy(sourceFilePath, destinationFilePath, true);
                }
            }
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
            MessageBox.Show("Download completed!");
        }

        
    }
}
