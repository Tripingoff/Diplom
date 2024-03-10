using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Windows.Shapes;
using ИС_ККТД.Models;

namespace ИС_ККТД.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditMain.xaml
    /// </summary>
    public partial class EditMain : Window
    {
        Авторизация _currentUser = new Авторизация();
        public EditMain()
        {
            InitializeComponent();
            // если передано null, то мы добавляем новый товар 
            // контекст данных текущий товар 
            DataContext = _currentUser;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое 
            if (_currentUser.Логин != TxtLogin.Text && string.IsNullOrEmpty(_currentUser.Логин))
                s.AppendLine("Введите логин");
            if (_currentUser.Пароль == null)
                s.AppendLine("Введите пароль");
            if (PsPassword.Password != PsPassword1.Password)
            {
                s.AppendLine("Пароли не совподают!");
            }
            // если поле стоимость не пустое, 
            // проверяем данные на корректность 
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
            if (_currentUser.Id_user == 0)
            {
                // добавляем товар в БД 
                IS_KKTDEntities.GetContext().Авторизация.AddOrUpdate(_currentUser);
            }
            try
            { // если изменилось изображение 
                IS_KKTDEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись Изменена");
                this.Close();// Возвращаемся на предыдущую форму 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }
        public void UpdateData()
        {
            var currentDisciplines = IS_KKTDEntities.GetContext().Авторизация.OrderBy(p => p.Id_user).ToList();
            currentDisciplines = currentDisciplines.Where(p => p.Логин.ToLower().Contains(TxtLogin.Text.ToLower())).ToList();
            SpLogin.DataContext = currentDisciplines;
        }

        private void BtnVisible1_Click(object sender, RoutedEventArgs e)
        {
            var check = sender as CheckBox;
            if (check.IsChecked.Value)
            {

                TxtPassword1.Text = PsPassword1.Password; // скопируем в TextBox из PasswordBox
                TxtPassword1.Visibility = Visibility.Visible; // TextBox - отобразить
                PsPassword1.Visibility = Visibility.Hidden; // PasswordBox - скрыть
            }
            else
            {
                PsPassword1.Password = TxtPassword1.Text; // скопируем в PasswordBox из TextBox 
                TxtPassword1.Visibility = Visibility.Hidden; // TextBox - скрыть
                PsPassword1.Visibility = Visibility.Visible; // PasswordBox - отобразить
            }
        }

        private void BtnVisible_Click(object sender, RoutedEventArgs e)
        {
            var buttoon = sender as CheckBox;
            if (buttoon.IsChecked.Value)
            {

                TxtPassword.Text = PsPassword.Password; // скопируем в TextBox из PasswordBox
                TxtPassword.Visibility = Visibility.Visible; // TextBox - отобразить
                PsPassword.Visibility = Visibility.Hidden; // PasswordBox - скрыть
            }
            else
            {
                PsPassword.Password = TxtPassword.Text; // скопируем в PasswordBox из TextBox 
                TxtPassword.Visibility = Visibility.Hidden; // TextBox - скрыть
                PsPassword.Visibility = Visibility.Visible; // PasswordBox - отобразить
            }
        }

    }
}
