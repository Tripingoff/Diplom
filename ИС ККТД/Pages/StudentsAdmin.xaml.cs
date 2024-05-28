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
    /// Логика взаимодействия для StudentsAdmin.xaml
    /// </summary>
    public partial class StudentsAdmin : Page
    {
        public StudentsAdmin()
        {
            InitializeComponent();
            ListBoxStudents.ItemsSource = IS_KKTDEntities.GetContext().Студенты.OrderBy(p => p.id_студента).ToList();
            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(p => p.код_группы).ToList();
            CmbGroup.SelectedIndex = 0;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddStudents((sender as Button).DataContext as Студенты));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddStudents(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //получаем все выделенные товары
            var selectedGoods = ListBoxStudents.SelectedItems.Cast<Студенты>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()}записей ??? ", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                    Студенты x = selectedGoods[0];
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    //if (x.id_студента > 0)
                    //{
                    //    throw new Exception("Есть записи в пользователях");
                    //}
                    IS_KKTDEntities.GetContext().Студенты.Remove(x);
                    //сохраняем изменения
                    IS_KKTDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Студенты> goods = IS_KKTDEntities.GetContext().Студенты.OrderBy(p => p.id_студента).ToList();
                    ListBoxStudents.ItemsSource = null;
                    ListBoxStudents.ItemsSource = goods;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK,
                   MessageBoxImage.Error);

                }
            }
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            var currentDisciplines = IS_KKTDEntities.GetContext().Студенты.OrderBy(p => p.id_студента).ToList();
            if(CmbGroup.SelectedIndex > 0)
                currentDisciplines = currentDisciplines.Where(p => p.Id_группы == (CmbGroup.SelectedItem as Группы).Id_группы).ToList();
            ListBoxStudents.ItemsSource = currentDisciplines;
        }
    }
}
