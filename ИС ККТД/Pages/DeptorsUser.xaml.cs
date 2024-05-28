using Word = Microsoft.Office.Interop.Word;
using Microsoft.Win32;
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
using System.IO;
using System.Windows.Forms;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using MessageBox = System.Windows.MessageBox;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeptorsUser.xaml
    /// </summary>
    public partial class DeptorsUser : Page
    {
        public ДисцпилинаПреподователь currentPrepod = new ДисцпилинаПреподователь();
        Итог_дисциплин currentItog;
        Итог_дисциплин _selectedItog = null;
        public DeptorsUser()
        {
            InitializeComponent();
            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(p => p.код_группы).ToList(); 
            CmbStudentInGroup.DataContext = IS_KKTDEntities.GetContext().Студенты.ToList();
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void CmbStudentInGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }

        public void Update()
        {
            var currentItog = IS_KKTDEntities.GetContext().Студенты.OrderBy(p => p.id_студента).ToList();
            if (CmbGroup.SelectedIndex >= 0)
            {
                currentItog = currentItog.Where(p => p.Группы.Id_группы == (CmbGroup.SelectedItem as Группы).Id_группы).ToList();
            }
            CmbStudentInGroup.ItemsSource = currentItog;
        }
        public void Load()
        {
            var currentItog = IS_KKTDEntities.GetContext().Итог_дисциплин.OrderBy(p => p.Id_итог).ToList();
            if (CmbStudentInGroup.SelectedIndex >= 0)
            {
                currentItog = currentItog.Where(p => p.Id_студента == (CmbStudentInGroup.SelectedItem as Студенты).id_студента).ToList();
            }
            PdfDopusc.ItemsSource = currentItog.Where(p=>p.Оценка== null);
        }

        private void pdfsave_Click(object sender, RoutedEventArgs e)
        {
            PrintInPdf(currentItog);
        }

        void PrintInPdf(Итог_дисциплин Itog)
        {
            try
            {
                string path = null;
                // указываем файл для сохранения
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (.pdf)|*.pdf";
                // Filter files by extension
                // если диалог завершился успешно
                if (saveFileDialog.ShowDialog() == true)
                {
                    path = saveFileDialog.FileName;
                    Word.Application application = new Word.Application();
                    Word.Document document = application.Documents.Add();
                    Word.Paragraph paragraph = document.Paragraphs.Add();
                    Word.Range range = paragraph.Range;
                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"Направление";
                    range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"НА СДАЧУ (ПЕРЕСДАЧУ) ЭКЗАМЕНА, ЗАЧЕТА";
                    range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"По дисциплине: \n";
                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"Выдано студенту: {Dopuscki.GetListBox}";
                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"Группа: ";
                    range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Text = $"Преподаватель: ";
                    range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Text = $"Сдано на оценку:";
                    range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Text = $"Подпись преподавателя: ";
                    range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Text = $"Дата экзамена (зачета): ";
                    range.InsertParagraphAfter();
                    Word.Paragraph tableParagraph = document.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;
                    Word.Paragraph generalSumProduct = document.Paragraphs.Add();
                    Word.Range generalRange = generalSumProduct.Range;
                    document.SaveAs2($@"{path}", Word.WdExportFormat.wdExportFormatPDF);
                    MessageBox.Show("Файл сохранен");
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

        private void PdfDopusc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedItog = null;
            var selected = PdfDopusc.SelectedItems.Cast<Итог_дисциплин>().ToList();
            if (selected.Count == 0) return;
            _selectedItog = selected[0];
        }
    }

}
