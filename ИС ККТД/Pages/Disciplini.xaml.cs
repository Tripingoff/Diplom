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
    /// Логика взаимодействия для Disciplini.xaml
    /// </summary>
    public partial class Disciplini : Page
    {
        public Disciplini()
        {
            InitializeComponent();
            ListBoxDisciplins.ItemsSource = IS_KKTDEntities.GetContext().Дисциплины.OrderBy(p => p.Id_дисциплины).ToList();
        }

        public void UpdateData()
        {
            var currentDisciplines = IS_KKTDEntities.GetContext().Дисциплины.OrderBy(p => p.Id_дисциплины).ToList();
            currentDisciplines = currentDisciplines.Where(p => p.Название.ToLower().Contains(TxtKod.Text.ToLower())).ToList();
            ListBoxDisciplins.ItemsSource = currentDisciplines;
            //вывод значений из бд для выподающих списков, через сравнение их название
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddDisciplines(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedGoods = ListBoxDisciplins.SelectedItems.Cast<Дисциплины>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()}записей ??? ", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                    Дисциплины x = selectedGoods[0];
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    IS_KKTDEntities.GetContext().Дисциплины.Remove(x);
                    //сохраняем изменения
                    IS_KKTDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Сотрудники> goods = IS_KKTDEntities.GetContext().Сотрудники.OrderBy(p => p.Id_сотрудника).ToList();
                    ListBoxDisciplins.ItemsSource = null;
                    ListBoxDisciplins.ItemsSource = goods;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK,
                   MessageBoxImage.Error);

                }

            }
        }
        private void search_Click(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddDisciplines((sender as Button).DataContext as Дисциплины));
        }
    }
}
