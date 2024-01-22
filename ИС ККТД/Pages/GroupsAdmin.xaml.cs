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
    /// Логика взаимодействия для GroupsAdmin.xaml
    /// </summary>
    public partial class GroupsAdmin : Page
    {
        public GroupsAdmin()
        {
            InitializeComponent();
            ListBoxGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(p=>p.код_группы).ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddGroups((sender as Button).DataContext as Группы));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddGroups(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
