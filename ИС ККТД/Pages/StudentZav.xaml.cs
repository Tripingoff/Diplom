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
    /// Логика взаимодействия для StudentZav.xaml
    /// </summary>
    public partial class StudentZav : Page
    {
        public StudentZav()
        {
            InitializeComponent();
            ListBoxStudents.ItemsSource = IS_KKTDEntities.GetContext().Студенты.OrderBy(p => p.id_студента).ToList();
            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(p => p.Id_группы).ToList();
            CmbGroup.SelectedIndex = 0;

        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            var currentStudent = IS_KKTDEntities.GetContext().Студенты.OrderBy(p => p.id_студента).ToList();
            currentStudent = currentStudent.OrderBy(p => p.Группы.код_группы).ToList();
            ListBoxStudents.ItemsSource = currentStudent;
        }
    }
}
