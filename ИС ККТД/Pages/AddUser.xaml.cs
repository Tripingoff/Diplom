using System;
using System.Collections.Generic;
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
using System.IO;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        private Авторизация _currentUser = new Авторизация();
        // путь к файлу
        public AddUser(Авторизация selectedUser)
        {
            InitializeComponent();
            LoadAndInitData(selectedUser);
        }
        void LoadAndInitData(Авторизация selectedUser)
        { // если передано null, то мы добавляем новый товар
            if (selectedUser != null)
            {
                _currentUser = selectedUser;
            }
            // контекст данных текущий товар
            DataContext = _currentUser;
            // единицы измерения товаров
            CmbRole.ItemsSource = IS_KKTDEntities.GetContext().Роли.ToList();
        }
        /// <summary>
        /// Проверка полей ввод на корректыне данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (string.IsNullOrWhiteSpace(_currentUser.Логин))
                s.AppendLine("Введите логин");
            if (_currentUser.Пароль == null)
                s.AppendLine("Введите пароль");
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
                IS_KKTDEntities.GetContext().Авторизация.Add(_currentUser);
            }
            try
            { // если изменилось изображение
                IS_KKTDEntities.GetContext().SaveChanges(); // Сохраняем изменения в БД
                MessageBox.Show("Запись Изменена");
                Manager.PageNavigation.NavigationService.GoBack(); // Возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        } 
    }
}
