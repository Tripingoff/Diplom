using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для AddBall.xaml
    /// </summary>
    public partial class AddBall : Page
    { 
        public Успеваемость currentTerm = new Успеваемость();
        public Студенты currentStudent = new Студенты();
        public AddBall(Успеваемость selectedTerm)
        {
            InitializeComponent();
            LoadAndInitData(selectedTerm);
        }
        void LoadAndInitData(Успеваемость selectedTerm)
        { // если передано null, то мы добавляем новый товар
            if (selectedTerm != null)
            {
                currentTerm = selectedTerm;
            }
            DataContext = currentTerm;
            //загрузка в выпалдающие списки
            // категории товаров
            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.ToList();
            CmbStudent.ItemsSource = IS_KKTDEntities.GetContext().Студенты.ToList();
            // производители товаров
            CmbDisciplins.ItemsSource = IS_KKTDEntities.GetContext().Дисциплины.ToList();
            // поставщики товаров
            DpDate.DisplayDate = DateTime.Today;
            // единицы измерения товаров
            //DpTime.DisplayDate = Time

            if(CmbGroup.SelectedIndex > 0)
            {
                CmbStudent.ItemsSource = IS_KKTDEntities.GetContext().Группы.Where(p => p.Id_группы == currentStudent.Id_группы).ToList();
            } 
        }
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (currentTerm.Оценка == null)
                s.AppendLine("Введите оценку");
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
            if (currentTerm.Id_успеваемости == 0)
            {
                // добавление нового товара, 
                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                    // добавляем товар в БД
                    IS_KKTDEntities.GetContext().Успеваемость.Add(currentTerm);
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

        //private void DpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //        DateTime? selectedDate = DpDate.SelectedDate;  
        //}
    }
}
