using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
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
using Microsoft.Win32;
using Application = Microsoft.Office.Interop.Word.Application;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddVedomost.xaml
    /// </summary>
    public partial class AddVedomost
    {
        Ведомости currentVedomost;
        Дисциплины currentDisciplin;
        Студенты currentStudent;
        Группы currentGroup;

        int _itemcount = 0;
        private Dictionary<string, string> vedomo;

        public AddVedomost()
        {
            InitializeComponent();
            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(p => p.код_группы).ToList();
            CmbSpecialnost.ItemsSource = IS_KKTDEntities.GetContext().Специальности.OrderBy(p => p.Название).ToList();
            Cmbdisciplina.ItemsSource = IS_KKTDEntities.GetContext().Дисциплины.OrderBy(p => p.Id_дисциплины).ToList();
            CmbPrepod.ItemsSource = IS_KKTDEntities.GetContext().Сотрудники.OrderBy(p => p.Id_сотрудника).ToList();
            _itemcount = DataGridStudent.Items.Count;
        }

        public void Update()
        {
            var current = IS_KKTDEntities.GetContext().Студенты.OrderBy(p => p.id_студента).ToList();
            if (CmbGroup.SelectedIndex >= 0)
            {
                current = current.Where(p => p.Id_группы == (CmbGroup.SelectedItem as Группы).Id_группы).ToList();
            }
            DataGridStudent.ItemsSource = current;
            TextBlockCount.Text = $" Результат запроса: {current.Count} записей из {_itemcount}";
        }
        public void Prepod()
        {
            var current = IS_KKTDEntities.GetContext().Ведомости.OrderBy(p => p.Id_ведомости).ToList();
            if (Cmbdisciplina.SelectedIndex >= 0)
                current = current.Where(p => p.ДисцпилинаПреподователь.Учебный_план.Дисциплины.Id_дисциплины == (Cmbdisciplina.SelectedItem as Дисциплины).Id_дисциплины).ToList();
            CmbPrepod.ItemsSource = current.Where(p=>p.ДисцпилинаПреподователь.Учебный_план.Дисциплины.Название == Cmbdisciplina.SelectedValuePath).ToList();
        }
        private void BtnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            string inputFilePath = $@"{System.Windows.Forms.Application.StartupPath}\Vedomost\Шаблон дисциплины.docx";
            string outputFilePath = $@"{System.Windows.Forms.Application.StartupPath}\Vedomost\{Cmbdisciplina.Text} {CmbGroup}.docx";
            string Name;
            if (BtnZachet.IsChecked == true)
            {
                Name = BtnZachet.Content.ToString();
            }
            else
            {
                Name = BtnIKR.Content.ToString();
            }
            string FamStud;
            string ImyaSt;
            string OtcStud;
            for(int i = 0; i < DataGridStudent.Items.Count; i ++)
            {
                FamStud = currentStudent.Фамилия;
                ImyaSt = currentStudent.Имя;
                OtcStud = currentStudent.Отчество;
            }

            var ved = new System.Collections.Generic.Dictionary<string, string>
            {
                { "<NameVed>", Name},

                {"<Code>",CmbGroup.Text},

                {"<Specialnost>", CmbSpecialnost.Text},

                {"<CodeDisc>",$"{currentDisciplin.Код_дисциплины}"} ,{"<NameDisc>",$"{currentDisciplin.Название}"},

                {"<Familiya>",$"{currentVedomost.ДисцпилинаПреподователь.Сотрудники.Фамилия}" }, {"<Imya>",$"{currentVedomost.ДисцпилинаПреподователь.Сотрудники.Имя}" }, {"<Otchestvo>",$"{currentVedomost.ДисцпилинаПреподователь.Сотрудники.Отчество}" },

                 {"<FamiliyaStud1>", ""}, {"<ImyaStud1>","" }, {"<OStud1>","" },
                   {"<FamiliyaStud2>","" }, {"<ImyaStud2>","" }, {"<OStud2>","" },
                    {"<FamiliyaStud3>","" }, {"<ImyaStud3>","" }, {"<OStud3>","" },
                     {"<FamiliyaStud4>","" }, {"<ImyaStud4>","" }, {"<OStud4>","" },
                      {"<FamiliyaStud5>","" }, {"<ImyaStud5>","" }, {"<OStud5>","" },
                       {"<FamiliyaStud6>","" }, {"<ImyaStud6>","" }, {"<OStud6>","" },
                        {"<FamiliyaStud7>","" }, {"<ImyaStud7>","" }, {"<OStud7>","" },
                         {"<FamiliyaStud8>","" }, {"<ImyaStud8>","" }, {"<OStud8>","" },
                          {"<FamiliyaStud9>","" }, {"<ImyaStud9>","" }, {"<OStud9>","" },
                           {"<FamiliyaStud10>","" }, {"<ImyaStud10>","" }, {"<OStud10>","" },
                            {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                             {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                              {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                               {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" }, 
                                 {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                  {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                   {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                    {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                     {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                       {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                        {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                         {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                          {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                           {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },
                                             {"<FamiliyaStud1>","" }, {"<ImyaStud1>","" }, {"<OStud1>","" },

                {"<dd>","" },{"<mm>","" },{"<yyyy>","" },
            };

            if(Vedom(inputFilePath, outputFilePath, ved) == true)
            {
                MessageBox.Show("Документ успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static bool Vedom(string inputFilePath, string outputFilePath, System.Collections.Generic.Dictionary<string, string> ved)
        {
            Application wordApp = new Application();
            try
            {
                Document doc = wordApp.Documents.Open(inputFilePath, ReadOnly: true);

                Range range = doc.Content;
                Document newDoc = wordApp.Documents.Add(); //создаем новый документ в который будем вносить изменения
                range.Copy(); //копируем данные из исходного документа в буфер обмена
                newDoc.Range().Paste(); //переносим из буфера обмена в новый файл

                foreach(var vedomost in ved)
                {
                    newDoc.Content.Find.Execute(FindText: vedomost.Key, ReplaceWith: vedomost.Value, Replace: WdReplace.wdReplaceAll);
                }

                newDoc.SaveAs2(outputFilePath, WdSaveFormat.wdFormatDocument);
                newDoc.Close(SaveChanges: false);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при формировании документа: " + ex.Message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            finally
            {
                    Manager.PageNavigation.NavigationService.GoBack();
            }
        }
        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void CmbSpecialnost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        private void Cmbdisciplina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Prepod();
        }
        private void DataGridStudent_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 0).ToString();
        }

        private void DataGridStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentStudent = null;
            var selected = DataGridStudent.SelectedItems.Cast<Студенты>().ToList();
            if (selected.Count == 0) return;
            currentStudent = selected[0];
        }

        private void CmbPrepod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Prepod();
        }
    }
}
