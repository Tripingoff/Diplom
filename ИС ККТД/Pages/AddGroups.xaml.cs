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

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddGroups.xaml
    /// </summary>
    public partial class AddGroups : Page
    { 
        private Группы _currentGroup = new Группы();
        // путь к файлу
        // название текущей главной фотографии
        public AddGroups(Группы selectedGroup)
        {
            InitializeComponent();
            LoadAndInitData(selectedGroup);
        }
        void LoadAndInitData(Группы selectedGroup)
        { // если передано null, то мы добавляем новый товар
            if (selectedGroup != null)
            {
                _currentGroup = selectedGroup;
            }
            // контекст данных текущий товар
            DataContext = _currentGroup;
            // единицы измерения товаров
            CmbSpecialnost.ItemsSource = IS_KKTDEntities.GetContext().Специальности.ToList();
            CmbCurator.ItemsSource = IS_KKTDEntities.GetContext().Преподователи.ToList();
        }
        /// <summary>
        /// Проверка полей ввод на корректыне данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (string.IsNullOrEmpty(_currentGroup.код_группы))
                s.AppendLine("Поле название пустое");
            if (_currentGroup.курс == 0)
                s.AppendLine("Выберите производителя");
            if (_currentGroup.Количество_студентов == 0)
                s.AppendLine("Выберите производителя");
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
            // проверка полей прошла успешно
            // если товар новый, то его ID == 0
            if (_currentGroup.Id_группы == 0)
            {
                // добавляем товар в БД
                IS_KKTDEntities.GetContext().Группы.Add(_currentGroup);
            }
            try
            { // если изменилось изображение
                IS_KKTDEntities.GetContext().SaveChanges(); // Сохраняем изменения в БД
                MessageBox.Show("Запись Изменена");
                NavigationService.GoBack(); // Возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        } 
    }
}
