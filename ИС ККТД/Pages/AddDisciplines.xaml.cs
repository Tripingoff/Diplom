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
        Дисциплины currentDisciplin = new Дисциплины();
        public AddDisciplines(Дисциплины selectedDiscipline)
        {
            InitializeComponent();
            if(selectedDiscipline == null)
            {
                currentDisciplin = selectedDiscipline;
            }
            DataContext = currentDisciplin;
        }
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (string.IsNullOrEmpty(currentDisciplin.Код_дисциплины))
                s.AppendLine("Поле название пустое");
            if (string.IsNullOrEmpty(currentDisciplin.Название))
                s.AppendLine("Выберите производителя");
            if (currentDisciplin.Id_дисциплины == 0)
                s.AppendLine("Выберите производителя");
            return s;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // проверка полей прошла успешно
            // если товар новый, то его ID == 0
            if (currentDisciplin.Id_дисциплины == 0)
            {
                // добавляем товар в БД
                IS_KKTDEntities.GetContext().Дисциплины.Add(currentDisciplin);
            }
            try
            { // если изменилось изображение
                IS_KKTDEntities.GetContext().SaveChanges(); // Сохраняем изменения в БД
                MessageBox.Show("Запись Изменена");
                NavigationService.GoBack(); // Возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
