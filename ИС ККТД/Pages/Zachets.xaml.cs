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
    /// Логика взаимодействия для Zachets.xaml
    /// </summary>
    public partial class Zachets : Page
    {
        public Zachets()
        {
            InitializeComponent();
        }

        private void VedGroup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.VedStudent());
        }

        private void VedPrepod_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Ved_prepod());
        }
    }
}
