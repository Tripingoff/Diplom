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
    /// Логика взаимодействия для SotreudmiksAdmin.xaml
    /// </summary>
    public partial class SotrudniksAdmin : Page
    {
        public SotrudniksAdmin()
        {
            InitializeComponent();
            ListViewSotrudniki.ItemsSource = IS_KKTDEntities.GetContext().Сотрудники.OrderBy(p => p.Id_сотрудника).ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new Pages.AddSotrudniks((sender as Button).DataContext as Сотрудники));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddSotrudniks(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //получаем все выделенные товары
            var selectedGoods = ListViewSotrudniki.SelectedItems.Cast<Сотрудники>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()}записей ??? ","Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                    Сотрудники x = selectedGoods[0];
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                        if (x.Id_сотрудника > 0)
                        { 
                            throw new Exception("Есть записи в пользователях");
                        }
                    IS_KKTDEntities.GetContext().Сотрудники.Remove(x);
                    //сохраняем изменения
                    IS_KKTDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Сотрудники> goods = IS_KKTDEntities.GetContext().Сотрудники.OrderBy(p => p.Id_сотрудника).ToList();
                    ListViewSotrudniki.ItemsSource = null;
                    ListViewSotrudniki.ItemsSource = goods;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK,
                   MessageBoxImage.Error);

                }

            }
        }

        private void TxtGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        public void Update()
        {
            var currentSortudnik = IS_KKTDEntities.GetContext().Сотрудники.OrderBy(p => p.Id_сотрудника).ToList();
            currentSortudnik = currentSortudnik.Where(p=>p.Фамилия.ToLower().Contains(TxtGroup.Text.ToLower())).ToList();
            ListViewSotrudniki.ItemsSource = currentSortudnik;
        }
    }
}
