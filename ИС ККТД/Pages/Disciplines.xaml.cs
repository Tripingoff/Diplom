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
    /// Логика взаимодействия для Disciplines.xaml
    /// </summary>
    public partial class Disciplines : Page
    {
        public Disciplines()
        {
            InitializeComponent();
            ListBoxDisciplins.ItemsSource = IS_KKTDEntities.GetContext().ДисцпилинаПреподователь.OrderBy(p=>p.Id_дисциплины).ToList();
        }

        public void UpdateData()
        {
            var currentDisciplines = IS_KKTDEntities.GetContext().ДисцпилинаПреподователь.OrderBy(p=>p.Id_дисциплины).ToList();
            currentDisciplines = currentDisciplines.Where(p => p.Дисциплины.Название.ToLower().Contains(TxtKod.Text.ToLower())).ToList();
            ListBoxDisciplins.ItemsSource = currentDisciplines;
            //вывод значений из бд для выподающих списков, через сравнение их название
        }

        private void TxtKod_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnDannie_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.DannieDiscip((sender as Button).DataContext as ДисцпилинаПреподователь));
        }
    }
}
