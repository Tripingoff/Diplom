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
using ИС_ККТД.Windows;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для Deptors.xaml
    /// </summary>
    public partial class Deptors : Page
    {
        public Студенты currentGroup = new Студенты();
        public Deptors()
        {
            InitializeComponent();
            DataGridDeptors.ItemsSource = IS_KKTDEntities.GetContext().Итог_дисциплин.Where(p => p.Оценка == null).OrderBy(p=>p.Id_студента).ToList();

            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(season => season.код_группы).ToList();
            CmbDisciplines.ItemsSource = IS_KKTDEntities.GetContext().Дисциплины.OrderBy(team => team.Название).ToList();
            //присвоение выподающим спискам нулевых значение
            CmbGroup.SelectedIndex = 0;
            CmbDisciplines.SelectedIndex = 0;
            UpdateData();
        }

        private void btnpddf_Click(object sender, RoutedEventArgs e)
        {
            Windows.DeptorsClick deptors = new Windows.DeptorsClick();
            deptors.Show();
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void CmbDisciplines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            //присвоение элементов из бд выподающим спискам
            Дисциплины selectedTeam = CmbDisciplines.SelectedItem as Дисциплины;
            Группы selectedSeason = CmbGroup.SelectedItem as Группы;
            List<Итог_дисциплин> listPlayers = IS_KKTDEntities.GetContext().Итог_дисциплин.ToList();
            //вывод значений из бд для выподающих списков, через сравнение их название
            listPlayers = listPlayers.Where(x => x.Студенты.Группы == selectedSeason).ToList();
            listPlayers = listPlayers.Where(x => x.Дисциплины == selectedTeam).ToList();
            listPlayers = listPlayers.OrderBy(p => p.Id_студента).ToList();
            //сортировка значений по возростанию на выводе
            DataGridDeptors.ItemsSource = listPlayers;
        }

    }
}
