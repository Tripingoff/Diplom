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
    /// Логика взаимодействия для Omissions.xaml
    /// </summary>
    public partial class Omissions : Page
    {
        public Студенты currentStudent = new Студенты();
        public Пропуски selectedomission = new Пропуски();
        public Omissions()
        {
            InitializeComponent();
            ListBoxOmissions.ItemsSource = IS_KKTDEntities.GetContext().Пропуски.ToList();
            LoadDate();
        }

        public void LoadDate()
        { 
            List<Пропуски> listbox = IS_KKTDEntities.GetContext().Пропуски.ToList();
            currentStudent.id_студента = Manager.CurrentUser.Id_user;
            listbox = listbox.Where(p => p.Id_студента== currentStudent.id_студента).ToList();
            ListBoxOmissions.ItemsSource = listbox;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditOmission((sender as Button).DataContext as Пропуски));
        }

        private void DtPrOmission_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DateTime? selectedDate = DtPrOmission.SelectedDate;
        }
    }
}
