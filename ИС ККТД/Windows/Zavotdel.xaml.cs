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
using System.Windows.Shapes;
using ИС_ККТД.Models;

namespace ИС_ККТД.Windows
{
    /// <summary>
    /// Логика взаимодействия для Zavotdel.xaml
    /// </summary>
    public partial class Zavotdel : Window
    {
        public static Zavotdel Window;
        public Zavotdel()
        {
            InitializeComponent();
            Авторизация currentStudent = Manager.CurrentUser; // Получение текущего пользователя
            Window = this;
            list.ItemsSource = IS_KKTDEntities.GetContext().Сотрудники.Where(p => p.Id_user == Manager.CurrentUser.Id_user).ToList();
            PagesNavigation.Navigate(new Pages.Main());
            Spmenu.DataContext = IS_KKTDEntities.GetContext().Сотрудники.Where(p => p.Id_user == Manager.CurrentUser.Id_user).ToList();

        }
        private void WindowClosed(object sender, EventArgs e)
        {
            // показать владельца формы
            Owner.Show();
            // или если надо, то можно закрыть приложение командой
        }
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите выйти?",
            "Выйти", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Zavotdel.Window.DragMove();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximaze_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;

            }
            else
                WindowState = WindowState.Normal;
        }

        private void BtnMinimaze_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Term_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.NavigationService.Navigate(new Pages.Raspisanie());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow admin = new MainWindow();
            admin.Owner = this;
            this.Hide();
            admin.Show();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (PagesNavigation.CanGoBack)
                PagesNavigation.GoBack();
        }
        private void PagesNavigation_ContentRendered(object sender, EventArgs e)
        {

            if (PagesNavigation.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            return;
        }

        private void btnMenu1_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void TextBlock_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (btnMenu1.)
            {
                Spmenu.Visibility = Visibility.Collapsed;
            }
            else
            {
                Spmenu.Visibility = Visibility.Visible;
            }
            return;
        }
    }
}

