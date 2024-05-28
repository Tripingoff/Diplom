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
    /// Логика взаимодействия для Vedomost.xaml
    /// </summary>
    public partial class Vedomost : Page
    {
        public Vedomost()
        {
            InitializeComponent();
            ListViewSotrudniki.ItemsSource = IS_KKTDEntities.GetContext().Ведомости.OrderBy(p => p.Id_ведомости).ToList();
        }

        public void Update()
        {
            var vedomost = IS_KKTDEntities.GetContext().Ведомости.OrderBy(p => p.Id_ведомости).ToList();
            if(CmbStatus.SelectedIndex >= 0)
            {
                if (CmbStatus.SelectedIndex == 0)
                    vedomost = vedomost.OrderByDescending(p => p.Статус).ToList();
                if (CmbStatus.SelectedIndex == 1)
                    vedomost = vedomost.OrderBy(p => p.Статус).ToList();
            }
            ListViewSotrudniki.ItemsSource = vedomost;
        }
        private void CmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void BtnVed_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.VedView((sender as Button).DataContext as Ведомости));
        }
    }
}
