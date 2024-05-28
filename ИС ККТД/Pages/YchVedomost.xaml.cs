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

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для YchVedomost.xaml
    /// </summary>
    public partial class YchVedomost : Page
    {
        public YchVedomost()
        {
            InitializeComponent();
        }

        private void BtnDisciplin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddVedomost());
        }

        private void BtnSvodnaya_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddListSvodn());
        }

        private void BtnStependiya_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddVedomStep());
        }
    }
}
