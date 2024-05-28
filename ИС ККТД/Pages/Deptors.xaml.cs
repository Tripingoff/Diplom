using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Win32;
using Word = Microsoft.Office.Interop.Word;
using ИС_ККТД.Windows;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using MessageBox = System.Windows.MessageBox;
using Microsoft.Office.Interop.Word;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для Deptors.xaml
    /// </summary>
    public partial class Deptors
    {
        public Дисциплины currentDisciplin = new Дисциплины();
        Итог_дисциплин currentItog;
        Итог_дисциплин _selectedItog = null;
        public Deptors()
        {
            InitializeComponent();
            ListBoxUserDate.ItemsSource = IS_KKTDEntities.GetContext().Итог_дисциплин.OrderBy(p=>p.Id_студента).Where(p=>p.Оценка == null).ToList();

            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(season => season.код_группы).ToList();
            CmbDisciplin.ItemsSource = IS_KKTDEntities.GetContext().Дисциплины.OrderBy(team => team.Id_дисциплины).ToList();
            //присвоение выподающим спискам нулевых значение
            CmbGroup.SelectedIndex = 0;
        }
        

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void CmbDisciplines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            //Дисциплины selectedTeam = CmbDisciplines.SelectedItem as Дисциплины;
            //Группы selectedSeason = CmbGroup.SelectedItem as Группы;
            List<Итог_дисциплин> listPlayers = IS_KKTDEntities.GetContext().Итог_дисциплин.ToList();
            //вывод значений из бд для выподающих списков, через сравнение их название\
            if (CmbGroup.SelectedIndex >= 0)
                listPlayers = listPlayers.Where(p => p.Студенты.Группы.Id_группы == (CmbGroup.SelectedItem as Группы).Id_группы).ToList();
            if (CmbDisciplin.SelectedIndex >= 0)
                listPlayers = listPlayers.Where(p => p.Учебный_план.Дисциплины.Id_дисциплины == (CmbDisciplin.SelectedItem as Дисциплины).Id_дисциплины).ToList();
            listPlayers = listPlayers.OrderBy(p => p.Id_студента).ToList();
            
            //сортировка значений по возростанию на выводе
            ListBoxUserDate.ItemsSource = listPlayers.Where(p=>p.Оценка == null).ToList();
        }
        private void btnprint_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.DeptorsUser());
        }

        private void Btnpdf_Click(object sender, RoutedEventArgs e)
        {
            PrintInPdf(currentItog);
        }
        void PrintInPdf(Итог_дисциплин _currentItog)
        {
            try
            {
                string path = null;
                // указываем файл для сохранения
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (.pdf)|*.pdf"; // Filter files by extension
                                                            // если диалог завершился успешно
                if (saveFileDialog.ShowDialog() == true)
                {
                    path = saveFileDialog.FileName;
                    Word.Application application = new Word.Application();
                    Word.Document document = application.Documents.Add();
                    Word.Paragraph paragraph = document.Paragraphs.Add();
                    Word.Range range = paragraph.Range;

                    range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Text = $"ГАПОУ Казанский колледж технологии и дизайна";
                    range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"Студенты не сдавшие зачеты(экзамены) по дисциплинам";
                    range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"Группа: {CmbGroup.Text}";
                    range.InsertParagraphAfter();

                    Word.Paragraph tableParagraph = document.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;

                    Word.Table table = document.Tables.Add(tableRange, ListBoxUserDate.Items.Count + 1, 3);
                    range.Font.Size = 14;
                    table.Columns[1].Width = 160;
                    table.Columns[2].Width = 160;
                    table.Columns[3].Width = 160;
                    table.Range.Bold = 0;
                    table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    Word.Range cellRange;
                    cellRange = table.Cell(1, 1).Range;
                    cellRange.Text = "ФИО студента";
                    cellRange = table.Cell(1, 2).Range;
                    cellRange.Text = "Дисциплины";
                    cellRange = table.Cell(1, 3).Range;
                    cellRange.Text = "Преподаватель";
                    table.Rows[1].Range.Bold = 1;
                    table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    int i = 1;
                    foreach (var item in ListBoxUserDate.Items)
                    {
                        table.Rows[i+1].Height = 6;
                        cellRange = table.Cell(i + 1, 1).Range;
                        cellRange.Text = item.ToString();
                        cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = table.Cell(i + 1, 2).Range;
                        cellRange.Text = item.ToString();
                        cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = table.Cell(i + 1, 3).Range;
                        cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        i++;
                    }
                    range.InsertParagraphAfter();
                    Word.Paragraph generalSumProduct = document.Paragraphs.Add();
                    Word.Range generalRange = generalSumProduct.Range;
                    document.SaveAs2($@"{path}", Word.WdExportFormat.wdExportFormatPDF);
                    MessageBox.Show("Талон сохранен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (currentItog == null)
                return;
            // добавляем товар в корзину
            Dopuscki.AddProductInBasket(currentItog);
        }

        private void ListBoxUserDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedItog = null;
            var selected = ListBoxUserDate.SelectedItems.Cast<Итог_дисциплин>().ToList();
            if (selected.Count == 0) return;
            _selectedItog = selected[0];
        }
    }
}
