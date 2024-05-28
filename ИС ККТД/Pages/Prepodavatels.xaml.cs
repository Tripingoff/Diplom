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
    /// Логика взаимодействия для Prepodavatels.xaml
    /// </summary>
    public partial class Prepodavatels : Page
    {
        public Prepodavatels()
        {
            InitializeComponent();
            ListViewSotrudniki.ItemsSource = IS_KKTDEntities.GetContext().ДисцпилинаПреподователь.Where(p=>p.Сотрудники.Id_сотрудника != null).GroupBy(p=>p.Id_сотрудника).ToList();
        }
        public void Update()
        {
            var currentSortudnik = IS_KKTDEntities.GetContext().ДисцпилинаПреподователь.OrderBy(p => p.Сотрудники.Id_сотрудника).ToList();
            currentSortudnik = currentSortudnik.Where(p => p.Сотрудники.Фамилия.ToLower().Contains(TxtKod.Text.ToLower())).ToList();
            ListViewSotrudniki.ItemsSource = currentSortudnik.Where(p=>p.Сотрудники.Id_сотрудника != null).ToList();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
