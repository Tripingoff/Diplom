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
    /// Логика взаимодействия для OmissionsSotrudnik.xaml
    /// </summary>
    public partial class OmissionsSotrudnik : Page
    {
        Сотрудники currentSotrudnik = new Сотрудники();
        Группы currentGroup = new Группы();
        Студенты currentStudent = new Студенты();
        public OmissionsSotrudnik()
        {
            InitializeComponent();
            ListBoxOmissionSotrudnik.ItemsSource = IS_KKTDEntities.GetContext().Пропуски.OrderBy(p=>p.Студенты.Id_группы).ToList();
        }
    }
}
