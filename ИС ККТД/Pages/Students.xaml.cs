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
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : Page
    {
       public Группы _currentGroup = new Группы();
       public Сотрудники _currentSotrudnik = new Сотрудники();
        public Студенты _currentStudent = new Студенты();
        public Students()
        {
            InitializeComponent();
            ListBoxStudents.ItemsSource = IS_KKTDEntities.GetContext().Студенты.OrderBy(p => p.Id_группы == _currentGroup.Id_группы).ToList();
        }

    }
}

        