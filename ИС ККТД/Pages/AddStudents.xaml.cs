﻿using Microsoft.Win32;
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
    /// Логика взаимодействия для Addstudents.xaml
    /// </summary>
    public partial class AddStudents : Page
    {   

        private Студенты _currentStudent = new Студенты();
        // путь к файлу
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // флаг меняется, если фото товара поменялось
        private bool _photoChanged = false;
        // текущая папка приложения
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Images\";
        public AddStudents(Студенты selectedStudents)
        {
            InitializeComponent();
            LoadAndInitData(selectedStudents);
        }
        void LoadAndInitData(Студенты selectedStudents)
        { // если передано null, то мы добавляем новый товар
            if (selectedStudents != null)
            {
                _currentStudent = selectedStudents;
                _filePath = _currentDirectory + _currentStudent.Фото;
            }
            // контекст данных текущий товар
            DataContext = _currentStudent;
            _photoName = _currentStudent.Фото;
            //загрузка в выпалдающие списки
            // категории товаров
            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.ToList();
            TxtUser.ItemsSource = IS_KKTDEntities.GetContext().Авторизация.ToList();
            // производители товаров
        }
        /// <summary>
        /// Проверка полей ввод на корректыне данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (TxtKod.Text == null)
                s.AppendLine("Введите код");
            if (_currentStudent.Фамилия == null)
                s.AppendLine("Введите Фамилию");
            if (_currentStudent.Имя == null)
                s.AppendLine("Введите Имя");
            if (CmbGroup.Text == null)
                s.AppendLine("Выберите группу");
            if (TxtUser.Text == null)
                s.AppendLine("Выберите пользователя");
            if (_currentStudent.Пол == null)
                s.AppendLine("Введите пол одной буквой");
            if (_currentStudent.Дата_рождения == null)
                s.AppendLine("Введите дату рождения");
            if (_currentStudent.ИНН == null)
                s.AppendLine("Введите ИНН");
            if (_currentStudent.СНИЛС == null)
                s.AppendLine("Введите СНИЛС");
            if (_currentStudent.Паспорт == null)
               s.AppendLine("Введите номер и серию паспорта");
            if (_currentStudent.Полис == null)
               s.AppendLine("Введите номер полиса ОМС");
            if (_currentStudent.Дата == null)
                s.AppendLine("Введите дату флюрографии");
            if (_currentStudent.Дата1 == null)
                s.AppendLine("Введите дату манту");
            if (_currentStudent.Флюрография == null)
                s.AppendLine("Введите результат флюрографии");
            if (_currentStudent.Манту == null)
                s.AppendLine("Введите результат манту");
            if (ImagePhoto.Source == null)
                s.AppendLine("Добавьте фото");
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
            if (_currentStudent.id_студента == 0)
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
                    _currentStudent.Фото = photo;
                }
                // добавляем товар в БД
                IS_KKTDEntities.GetContext().Студенты.Add(_currentStudent);
            }
            try
            { // если изменилось изображение
                if (_photoChanged)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentStudent.Фото = photo;
                }
                IS_KKTDEntities.GetContext().SaveChanges(); // Сохраняем изменения в БД
                MessageBox.Show("Запись Изменена");
                Manager.PageNavigation.NavigationService.GoBack(); // Возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        } // загрузка фото
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
                    ImagePhoto.Source = new BitmapImage(new Uri(op.FileName));
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

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddUser(null));
        }
    }
}
