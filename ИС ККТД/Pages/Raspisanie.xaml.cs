using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ИС_ККТД.Models;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;


namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для Raspisanie.xaml
    /// </summary>
    public partial class Raspisanie
    {
        public Расписание currentRaspisanie = new Расписание();
        private string _filePath = null;
        private string _photoName = null;
        private bool _photoChanged = false;
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Fails\";
        public Raspisanie(Расписание selectedRaspisanie)
        {
            InitializeComponent();
            DatePickerStart.SelectedDate = DateTime.Now;
            if( selectedRaspisanie != null )
            {
                currentRaspisanie = selectedRaspisanie;
                _filePath = _currentDirectory + currentRaspisanie.Файл;
            }
            DataContext = currentRaspisanie;
            _photoName = currentRaspisanie.Файл;
        }

        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (currentRaspisanie.Дата_начала == null)
                s.AppendLine("Выберите дату начала");
            if (currentRaspisanie.Дата_завершения == null)
                s.AppendLine("Выберите дату завершения");
            if (string.IsNullOrEmpty(TxtFail.Text))
                s.AppendLine("Поле файл пустое");
            if (string.IsNullOrEmpty(TxtCategory.Text))
                s.AppendLine("Поле категории пустое");
            return s;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            if (currentRaspisanie.Id_расписания == 0)
            {
                // добавление нового товара, 
                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                if (_filePath != null)
                {
                    string photo = ChangePhotoName();
                    // путь куда нужно скопировать файл
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    currentRaspisanie.Файл = photo;
                }
                // добавляем товар в БД
                IS_KKTDEntities.GetContext().Расписание.Add(currentRaspisanie);
            }
            try
            { // если изменилось изображение
                if (_photoChanged)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    currentRaspisanie.Файл = photo;
                }
                IS_KKTDEntities.GetContext().SaveChanges(); // Сохраняем изменения в БД
                MessageBox.Show("Запись Изменена");
                NavigationService.GoBack(); // Возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Диалог открытия файла
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a fail";
                op.Filter = "Exsel Files (*.xlsx)|*.xlsx|exsel Files (*.xls)|*.xls";
                // диалог вернет true, если файл был открыт
                if (op.ShowDialog() == true)
                {
                    // проверка размера файла
                    // по условию файл дожен быть не более 2Мб.
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 7))
                    {
                        // размер файла меньше 2Мб. Поэтому выбрасывается новое исключение
                        throw new Exception("Размер файла должен быть меньше 7Мб");
                    }
                    TxtFail.Text = op.FileName;
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                    _photoChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _filePath = null;
            }
        }
        //подбор имени файла
        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;
        }

        private void DatePickerStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = DatePickerStart.SelectedDate;
        }

        private void DatePickerFinish_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = DatePickerFinish.SelectedDate;
        }
    }
}

