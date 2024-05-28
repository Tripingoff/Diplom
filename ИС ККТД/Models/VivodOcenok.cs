using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace ИС_ККТД.Models
{
    internal class VivodOcenok
    {
        //public class Student
        //{
        //    public int StudentId { get; set; }
        //    public string Name { get; set; }
        //}

        //public class Subject
        //{
        //    public int SubjectId { get; set; }
        //    public string SubjectName { get; set; }
        //}

        //public class Yspevaemost
        //{
        //    public DateTime Date { get; set; }
        //    public Subject Subject { get; set; }
        //    public double Value { get; set; }
        //}

        //public static Dictionary<Студенты, Student> GetStudent { get; } = new Dictionary<Студенты, Student>();
        //public static Dictionary<Дисциплины, Subject> GetDisciplin { get; } = new Dictionary<Дисциплины, Subject>();
        //public static Dictionary<Успеваемость, Yspevaemost> GetYspevaemost { get; } = new Dictionary<Успеваемость, Yspevaemost>();

        //private ObservableCollection<Subject> _subjects = new ObservableCollection<Subject>();
        //public ObservableCollection<Subject> Subjects
        //{
        //    get { return _subjects; }
        //    set { _subjects = value; }
        //}
        public class Performances
        {
            public int StudentId { get; set; }
            public int DisciplineId { get; set; }
            public int Grade { get; set; }
        }

        public class Disciplinis
        {
            public int DisciplineId { get; set; }
            public string DisciplineName { get; set; }
        }

        public class Studentik
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
        }
        public static Dictionary<Студенты, Studentik> GetStudent { get; } = new Dictionary<Студенты, Studentik>();
        public static Dictionary<Дисциплины, Disciplinis> GetDisciplin { get; } = new Dictionary<Дисциплины, Disciplinis>();
        public static Dictionary<Успеваемость, Performances> GetYspevaemost { get; } = new Dictionary<Успеваемость, Performances>();
    }
}
