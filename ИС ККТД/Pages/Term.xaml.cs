using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
using static ИС_ККТД.Models.VivodOcenok;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для Term.xaml
    /// </summary>
    public partial class Term : Page
    {
        DataTable dt = new DataTable();
        public Успеваемость currentTerm = new Успеваемость();
        public Дисциплины currentDisciplin = new Дисциплины();
        public Студенты currentStudent = new Студенты();
        public Term()
        {
            InitializeComponent();

            //DataGridOcenki.ItemsSource = dt.DefaultView;
            DataTable();
        }

        public void DataTable()
        {
            dt.Columns.Add("Дисциплина", typeof(string));

            DateTime currentDate = new DateTime();
            DateTime startDate = new DateTime(2023, 10, 1);
            DateTime endDate = new DateTime(2023, 10, 31);
            currentDate = startDate;
            while (currentDate <= endDate)
            {
                dt.Columns.Add(currentDate.ToString("dd"), typeof(string));
                currentDate = currentDate.AddDays(1);
            }
            dt.Columns.Add("Средний балл", typeof(double));
            var uniqueDisciplines = new HashSet<string>();

            using (var context = new IS_KKTDEntities())
            {
                var disciplines = context.Успеваемость.Where(p => p.Студенты.id_user == Manager.CurrentUser.Id_user).ToList();
                foreach (var student in disciplines)
                {
                    var disciplineName = student.Учебный_план.Дисциплины.Название;

                    if (!uniqueDisciplines.Contains(disciplineName))
                    {
                        var row = dt.NewRow();
                    row["Дисциплина"] = student.Учебный_план.Дисциплины.Название;
                    currentDate = startDate;  // Сбросить дату на начальную дату
                    while (currentDate <= endDate)
                    {
                        var mark = GetMarkForStudentAndDate(student.Учебный_план.Дисциплины.Id_дисциплины, currentDate);
                        row[currentDate.ToString("dd")] = mark;
                        currentDate = currentDate.AddDays(1);
                    }
                    row["Средний балл"] = student.CalculateAverageGradeForStudent;
                    dt.Rows.Add(row);
                        uniqueDisciplines.Add(disciplineName);
                    }
                } 
                
            }
            DataGridOcenki.ItemsSource = dt.DefaultView;
        }

        public string GetMarkForStudentAndDate(int student, DateTime date)
        {

            var mark = IS_KKTDEntities.GetContext().Успеваемость.FirstOrDefault(p => p.Дата == date && p.Учебный_план.Дисциплины.Id_дисциплины == student);
            if (mark != null)
            {
                
                return mark.Оценка.Value.ToString();
            }
            return "";
            // Здесь можно написать код для получения оценки студента по определенной дате
            // Вернуть реальную оценку
        }

        void SortByMonth()
        {
            var currentMount = IS_KKTDEntities.GetContext().Успеваемость.OrderBy(p => p.Дата).ToList();
            if (DpDateYsp.SelectedDate != null)
            {
                int selectedMonth = DpDateYsp.SelectedDate.Value.Month;
                currentMount = currentMount.Select(p =>
                {
                    p.Дата = new DateTime(p.Дата.Year, selectedMonth, p.Дата.Month);
                    return p;
                }).ToList();
                
            }
            DataGridOcenki.ItemsSource = currentMount;
        }

        private void DpDateYsp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           int selectedDate = DpDateYsp.SelectedDate.Value.Month;
           SortByMonth();
        }

    }

}
