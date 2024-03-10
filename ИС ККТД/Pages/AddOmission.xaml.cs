using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Логика взаимодействия для AddOmission.xaml
    /// </summary>
    public partial class AddOmission : Page
    {

        public Пропуски currentTerm = new Пропуски();
        public Студенты currentStudent = new Студенты();
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // флаг меняется, если фото товара поменялось
        private bool _photoChanged = false;
        // текущая папка приложения
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Images\";

        public AddOmission(Пропуски selectedTerm)
        {
            InitializeComponent();
            LoadAndInitData(selectedTerm);
        }
        void LoadAndInitData(Пропуски selectedTerm)
        { // если передано null, то мы добавляем новый товар
            if (selectedTerm != null)
            {
                currentTerm = selectedTerm;
            }
            DataContext = currentTerm;
            _photoName = currentTerm.Скан;

            //загрузка в выпалдающие списки
            // категории товаров
            CmbPropusc.ItemsSource = IS_KKTDEntities.GetContext().Тип_пропусков.ToList();
            CmbStudent.ItemsSource = IS_KKTDEntities.GetContext().Студенты.ToList();
            // производители товаров
            CmbDisciplins.ItemsSource = IS_KKTDEntities.GetContext().Дисциплины.ToList();
            // поставщики товаров
            DpDate.DisplayDate = DateTime.Today;
            // единицы измерения товаров
            //DpTime.DisplayDate = Time

            //if (CmbGroup.Items.Count > 0)
            //{
            //    //CmbStudent.ItemsSource = IS_KKTDEntities.GetContext().Группы.Where(p=>p.Id_группы == currentStudent.Id_группы).ToList();
            //}
        }
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (currentTerm.Время == null)
                s.AppendLine("Поле время не может быть пустым");
            return s;
        }
        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            // проверка полей прошла успешно
            // если товар новый, то его ID == 0
            if (currentTerm.Id_пропуска == 0)
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
                    currentTerm.Скан = photo;
                }

                // добавляем товар в БД
                IS_KKTDEntities.GetContext().Пропуски.Add(currentTerm);
            }
            try
            { // если изменилось изображение
                if (_photoChanged)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    currentTerm.Скан = photo;
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
        private void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Диалог открытия файла
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg) | *.jpg | GIF Files(*.gif) | *.gif";
            // диалог вернет true, если файл был открыт
                if (op.ShowDialog() == true)
                {
                    // проверка размера файла
                    // по условию файл дожен быть не более 2Мб.
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 2))
                    {
                    // размер файла меньше 2Мб. Поэтому выбрасывается новое исключение
                        throw new Exception("Размер файла должен быть меньше 2Мб");
                    }
                    Scan.Source = new BitmapImage(new Uri(op.FileName));
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

      //private void DpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    DateTime? selectedDate = DpDate.SelectedDate;
        //}
    }
}
