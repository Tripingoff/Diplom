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
    /// Логика взаимодействия для AddDisciplines.xaml
    /// </summary>
    public partial class AddDisciplines : Page
    {
        ДисцпилинаПреподователь currentDisciplin = new ДисцпилинаПреподователь();
        public AddDisciplines(ДисцпилинаПреподователь selectedDiscipline)
        {
            InitializeComponent();
            if(selectedDiscipline == null)
            {
                currentDisciplin = selectedDiscipline;
            }
            DataContext = currentDisciplin;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
