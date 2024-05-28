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
        Сотрудники currentSotrudnik = new Сотрудники();
        public Disciplines()
        {
            InitializeComponent();
            //ListBoxDisciplins.ItemsSource = IS_KKTDEntities.GetContext().Дисциплины.OrderBy(p => p.Id_дисциплины).ToList();
            ListBoxDisciplins.ItemsSource = IS_KKTDEntities.GetContext().ДисцпилинаПреподователь.GroupBy(p => p.Учебный_план.Дисциплины.Id_дисциплины).ToList();

            //Class1 class1 = new Class1 { LastName = currentSotrudnik.Фамилия, FirstName = currentSotrudnik.Имя, MiddleName = currentSotrudnik.Отчество};

            //string fullname = $"{class1.LastName}{class1.FirstName}{class1.MiddleName}";
            //string[] names = fullname.Split();
            //string lastName = names[0];
            //string initials = names[1][0] + "." + names[2][0] + ".";
            //string result = lastName + " " + initials;

            //ListBoxDisciplins.ItemsSource = result;
        }

        public void UpdateData()
        {
            var currentDisciplines = IS_KKTDEntities.GetContext().ДисцпилинаПреподователь.OrderBy(p=>p.Учебный_план.Дисциплины.Id_дисциплины).ToList();
            currentDisciplines = currentDisciplines.Where(p => p.Учебный_план.Дисциплины.Название.ToLower().Contains(TxtKod.Text.ToLower())).ToList();
            ListBoxDisciplins.ItemsSource = currentDisciplines;
            //вывод значений из бд для выподающих списков, через сравнение их название
        }

        private void BtnDannie_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.DannieDiscip((sender as Button).DataContext as ДисцпилинаПреподователь));
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }
    }
}
