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
            ListBoxStudents.ItemsSource = IS_KKTDEntities.GetContext().ДисцпилинаПреподователь.OrderBy(p => p.Сотрудники.Должность == 6).ToList();
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
