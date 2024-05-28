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

namespace ИС_ККТД.Windows
{
    /// <summary>
    /// Логика взаимодействия для DeptorsClick.xaml
    /// </summary>
    public partial class DeptorsClick : Window
    {
        public DeptorsClick()
        {
            InitializeComponent();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnprint_Click(object sender, RoutedEventArgs e)
        {
            //Zavotdel zavotdel = new Zavotdel();
            //zavotdel.Owner = this;
            //this.Hide();
            //zavotdel.Show();
            NavigationService.GetNavigationService(new Pages.DeptorsUser());
        }

        private void btnpddf_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
