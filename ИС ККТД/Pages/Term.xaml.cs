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
    /// Логика взаимодействия для Term.xaml
    /// </summary>
    public partial class Term : Page
    {
        public Успеваемость currentTerm = new Успеваемость();
        public Дисциплины currentDisciplin = new Дисциплины();
        public Студенты currentStudent = new Студенты();
        public Term()
        {
            InitializeComponent();
            dataGrid.ItemsSource = IS_KKTDEntities.GetContext().Успеваемость.ToList();

            LoadDate();
            
        }

        public void LoadDate()
        {
            List<Успеваемость> listbox = IS_KKTDEntities.GetContext().Успеваемость.ToList();
            dataGrid.ItemsSource = listbox.Where(p=>p.Студенты.id_user == Manager.CurrentUser.Id_user).ToList();
        }

    }

}
