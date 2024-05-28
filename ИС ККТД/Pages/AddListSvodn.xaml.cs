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
using System.Windows.Forms;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using MessageBox = System.Windows.Forms.MessageBox;
//using Leadtools;
//using Leadtools.Caching;
//using Leadtools.Controls;
//using Leadtools.Document;
//using Leadtools.Document.Viewer;

namespace ИС_ККТД.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddListSvodn.xaml
    /// </summary>
    public partial class AddListSvodn
    {
        private DocumentViewer docViewer;
        Ведомости currentVedomost;
        Студенты currentStudent;
        int _itemcount = 0;
        public AddListSvodn()
        {
            InitializeComponent();
            DataGridStudent.ItemsSource = PDF.GetDataGrid;
            // создаем новый заказ

            CmbGroup.ItemsSource = IS_KKTDEntities.GetContext().Группы.OrderBy(p => p.код_группы).ToList(); 
            CmbSpecialnost.ItemsSource = IS_KKTDEntities.GetContext().Специальности.OrderBy(p => p.Название).ToList();
            _itemcount = DataGridStudent.Items.Count;

        }
            public void Update()
            {
                var current = IS_KKTDEntities.GetContext().Итог_дисциплин.OrderBy(p => p.Студенты.id_студента).ToList();
                if (CmbGroup.SelectedIndex >= 0)
                {
                    current = current.Where(p => p.Студенты.Id_группы == (CmbGroup.SelectedItem as Группы).Id_группы).ToList();
                }
                if (CmbSpecialnost.SelectedIndex >= 0)
                {

                }
                if (CmbKurs.SelectedIndex > 0)
                {
                    switch (CmbKurs.SelectedIndex)
                    {
                        case 1:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 2:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 3:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 4:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                    }
                }
                if (CmbSemestr.SelectedIndex > 0)
                {
                    switch (CmbSemestr.SelectedIndex)
                    {
                        case 1:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 2:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 3:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 4:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 5:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 6:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 7:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                        case 8:
                            current = current.Where(p => p.Учебный_план.Курс == CmbKurs.SelectedIndex).ToList();
                            break;
                    }

                }
                DataGridStudent.ItemsSource = current.GroupBy(p => p.Id_студента).ToList();
                TextBlockCount.Text = $" Результат запроса: {current.Count} записей из {_itemcount}";
            }

        private void BtnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = null;
                // указываем файл для сохранения
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Документ Word (.doc)|*.doc";
                // Filter files by extension
                // если диалог завершился успешно
                if (saveFileDialog.ShowDialog() == true)
                {
                    path = saveFileDialog.FileName;
                    Word.Application application = new Word.Application();
                    Word.Document document = application.Documents.Add();
                    Word.Paragraph paragraph = document.Paragraphs.Add();
                    Word.Range range = paragraph.Range;
                    range.PageSetup.PaperSize = WdPaperSize.wdPaperA4;
                    range.PageSetup.HeaderDistance = 2;
                    range.PageSetup.LeftMargin = 40;
                    range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Font.Size = 14;
                    range.Font.NameBi = "Times New Roman";
                    range.Text = $"Государственное автономное профессиональное образование учреждение\n " +
                        $"\"Казанский колледж технологии и дизайна\" \n";
                    range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Font.Size = 16; 
                    range.Text = $"Сводный лист\n";
                    range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Font.Size = 14;
                    range.Text = $"Успеваемости студентов группы {CmbGroup.Text} очного отделения\n" +
                        $"за учебного года\n";
                    range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    range = paragraph.Range;
                    range.InsertParagraphAfter();

                    Word.Paragraph tableParagraph = document.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;
                    range = paragraph.Range;
                    Word.Table table = document.Tables.Add(tableRange, 25, 17);
                    range.Font.Size = 12;
                    table.Columns[1].Width = 24;
                    table.Columns[2].Width = 170;
                    table.Columns[3].Width = 20;
                    table.Columns[4].Width = 20;
                    table.Columns[5].Width = 20;
                    table.Columns[6].Width = 20;
                    table.Columns[7].Width = 20;
                    table.Columns[8].Width = 20;
                    table.Columns[9].Width = 20;
                    table.Columns[10].Width =20;
                    table.Columns[11].Width = 20;
                    table.Columns[12].Width = 20;
                    table.Columns[13].Width = 20;
                    table.Columns[14].Width = 20;
                    table.Columns[15].Width = 20;
                    table.Columns[16].Width = 20;
                    table.Columns[17].Width = 20;
                    table.Range.Bold = 0;
                    table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    Word.Range cellRange;
                    cellRange = table.Cell(1, 1).Range;
                    cellRange.Text = "№п/п";
                    cellRange = table.Cell(1, 2).Range;
                    cellRange.Text = "Ф.И.О. студента";
                    cellRange = table.Cell(1, 3).Range;
                    cellRange.Text = $"";   
                    cellRange = table.Cell(1, 4).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 5).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 6).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 7).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 8).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 9).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 10).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 11).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 12).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 13).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 14).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 15).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 16).Range;
                    cellRange.Text = $"";
                    cellRange = table.Cell(1, 17).Range;
                    cellRange.Text = "Примечания";
                    table.Rows[1].Range.Bold = 1;
                    table.Rows[1].Cells[3].Merge(table.Rows[1].Cells[16]);
                    table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        int i = 0;
                        foreach (var item in DataGridStudent.Items)
                        {
                            table.Rows[i+1].Height = 6;
                            cellRange = table.Cell(i + 2, 1).Range;
                            cellRange.Text = i.ToString();
                            cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            cellRange = table.Cell(i + 2, 2).Range;
                            cellRange.Text = item.ToString();
                            cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            cellRange = table.Cell(i + 2, 3).Range;

                            cellRange = table.Cell(i + 2, 4).Range;

                            cellRange = table.Cell(i + 2, 5).Range;

                            cellRange = table.Cell(i + 2, 6).Range;
                            cellRange = table.Cell(i + 2, 7).Range;
                            cellRange = table.Cell(i + 2, 8).Range;
                            cellRange = table.Cell(i + 2, 9).Range;
                            cellRange = table.Cell(i + 2, 10).Range;
                            cellRange = table.Cell(i + 2, 11).Range;
                            cellRange = table.Cell(i + 2, 12).Range;
                            cellRange = table.Cell(i + 2, 13).Range;
                            cellRange = table.Cell(i + 2, 14).Range;
                            cellRange = table.Cell(i + 2, 15).Range;
                            cellRange = table.Cell(i + 2, 16).Range;
                            cellRange = table.Cell(i + 2, 17).Range;
                        i++;
                        }
                    range = paragraph.Range;
                    range.InsertParagraphAfter();
                    range = paragraph.Range;
                    range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    range.Text = $"Абсолютная успеваемость (%) ____\n" +
                    $"Качественный показатель (%) ____\n" +
                    $"Зав. отделением ____________\n" +
                    $"Куратор группы _____________\n";
                  
                    Word.Paragraph generalSumProduct = document.Paragraphs.Add();
                    Word.Range generalRange = generalSumProduct.Range;
                    document.SaveAs2($@"{path}", Word.WdSaveFormat.wdFormatDocument);
                    MessageBox.Show("Файл сохранен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void DataGridStudent_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void DataGridStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentStudent = null;
            var selected = DataGridStudent.SelectedItems.Cast<Студенты>().ToList();
            if (selected.Count == 0) return;
            currentStudent = selected[0];
        }

        private void CmbKurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void CmbSemestr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
