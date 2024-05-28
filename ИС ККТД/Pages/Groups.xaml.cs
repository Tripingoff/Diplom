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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ИС_ККТД.Models;
using ИС_ККТД.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Page = System.Windows.Controls.Page;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : Page
    {
        DataTable dt = new DataTable();
        public Успеваемость currentTerm = new Успеваемость();
        public Дисциплины currentDisciplin = new Дисциплины();
        public Студенты currentStudent = new Студенты();
        public Группы currentGroup = new Группы();
        public ДисцпилинаПреподователь Prepod = new ДисцпилинаПреподователь();
        public Groups()
        {
            InitializeComponent();

            //DataGridOcenki.DataContext = dt.DefaultView;
            CmbDisciplin.ItemsSource = IS_KKTDEntities.GetContext().Дисциплины.OrderBy(p => p.Id_дисциплины).ToList();
            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(p => p.код_группы).ToList();

            DataTable();
        }

        public void DataTable()
        {
            dt.Columns.Add("Студент", typeof(string));

            DateTime currentDate = new DateTime();
            DateTime startDate = new DateTime(2023, 10, 1);
            DateTime endDate = new DateTime(2023, 10, 31);
            currentDate = startDate;

            // Добавление колонок для каждой даты и среднего балла
            while (currentDate <= endDate)
            {
                dt.Columns.Add(currentDate.ToString("dd"), typeof(string));
                currentDate = currentDate.AddDays(1);
            }
            dt.Columns.Add("Средний балл", typeof(double));

            var uniqueDisciplines = new HashSet<string>();
            // Получение данных из БД
            using (var context = new IS_KKTDEntities())
            {
                var disciplines = context.Успеваемость.ToList();
                foreach (var student in disciplines)
                {
                    var disciplineName = student.Студенты.Фамилия + " " + student.Студенты.Имя;

                    if (!uniqueDisciplines.Contains(disciplineName))
                    {
                        var row = dt.NewRow();
                    row["Студент"] = student.Студенты.Фамилия + " " + student.Студенты.Имя;
                    currentDate = startDate;  // Сбросить дату на начальную дату
                    while (currentDate <= endDate)
                    {
                        var mark = GetMarkForStudentAndDate(student.Студенты.Фамилия, currentDate);
                        row[currentDate.ToString("dd")] = mark;
                        currentDate = currentDate.AddDays(1);
                    }
                    //row["Средний балл"] = student.CalculateAverageGradeForStudent;
                    dt.Rows.Add(row);
                    uniqueDisciplines.Add(disciplineName);
                    }
                }

            }
            // Привязка DataTable к DataGrid
            DataGridOcenki.ItemsSource = dt.DefaultView;
        }

        public string GetMarkForStudentAndDate(string student, DateTime date)
        {
            var mark = IS_KKTDEntities.GetContext().Успеваемость.FirstOrDefault(p => p.Дата == date && p.Студенты.Группы.Id_группы == CmbGroup.SelectedIndex&&p.Учебный_план.Дисциплины.Id_дисциплины == CmbDisciplin.SelectedIndex&& p.Студенты.Фамилия == student);
            if (mark != null)
            {
                return mark.Оценка.Value.ToString();
            }
            return null;
        }

        public void UpdateData()
        {
            var listPlayers = IS_KKTDEntities.GetContext().Успеваемость.ToList();

            if (CmbGroup.SelectedIndex >= 0)
                listPlayers = listPlayers.Where(x => x.Студенты.Id_группы == (CmbGroup.SelectedItem as Группы).Id_группы).ToList();
            if (CmbDisciplin.SelectedIndex >= 0)
                listPlayers = listPlayers.Where(x => x.Учебный_план.Дисциплины.Название == (CmbDisciplin.SelectedItem as Дисциплины).Название).ToList();
            DataGridOcenki.DataContext = listPlayers;
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void CmbDisciplin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnAddOmission_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddOmission(null));
        }

        private void BtnAddBall_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddBall(null));
        }

        //private void BtnEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService.Navigate(new Pages.AddBall((sender as Button).DataContext as Успеваемость));
        //}
    }
}
