using System;
using System.Collections.Generic;
using System.Data;
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
using ИС_ККТД.Windows;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : Page
    {
        public Студенты currentStudent = new Студенты();
        Дисциплины currentDisciplin = new Дисциплины();
        public Groups()
        {
            InitializeComponent();
            DataGridGroup.ItemsSource = IS_KKTDEntities.GetContext().Успеваемость.OrderBy(p=>p.Дата).ToList();
            //CmbDisciplin.ItemsSource = IS_KKTDEntities.GetContext().Дисциплины.OrderBy(season => season.Название).ToList();
            //CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(team => team.код_группы).ToList();
            //присвоение выподающим спискам нулевых значение
            CmbDisciplin.SelectedIndex = 0;
            CmbGroup.SelectedIndex = 0;
            UpdateData();

        }

        public void LoadDate()
        {
            List<ДисцпилинаПреподователь> listbox = IS_KKTDEntities.GetContext().ДисцпилинаПреподователь.ToList();
            listbox = listbox.Where(p => p.Сотрудники.Id_user == Manager.CurrentUser.Id_user).ToList();
            listbox = listbox.Where(p => p.Дисциплины.Id_дисциплины == currentDisciplin.Id_дисциплины).ToList();
            DataGridGroup.ItemsSource = listbox;
            CmbDisciplin.ItemsSource = listbox;
        }


        public void UpdateData()
        {
            List<Успеваемость> listPlayers = IS_KKTDEntities.GetContext().Успеваемость.ToList();
            //вывод значений из бд для выподающих списков, через сравнение их название
            if (CmbGroup.SelectedIndex > 0)
                listPlayers = listPlayers.OrderBy(x => x.Студенты.Группы).ToList();
            if(CmbDisciplin.SelectedIndex > 0)
                listPlayers = listPlayers.OrderBy(x => x.Дисциплины).ToList();
            DataGridGroup.ItemsSource = listPlayers;
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void CmbDisciplin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddBall((sender as Button).DataContext as Успеваемость));
        }

        private void BtnAddBall_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddBall(null));
        }

        private void BtnAddOmission_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddOmission(null));
        }
    }
}
