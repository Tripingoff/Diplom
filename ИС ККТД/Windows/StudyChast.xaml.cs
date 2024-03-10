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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ИС_ККТД.Models;

namespace ИС_ККТД.Windows
{
    /// <summary>
    /// Логика взаимодействия для StudyChast.xaml
    /// </summary>
    public partial class StudyChast : Window
    {
        public static StudyChast Window;
        public StudyChast()
        {
            InitializeComponent();
            Авторизация currentStudent = Manager.CurrentUser; // Получение текущего пользователя
            Window = this;
            list.ItemsSource = IS_KKTDEntities.GetContext().Сотрудники.Where(p => p.Id_user == Manager.CurrentUser.Id_user).ToList();
            PagesNavigation.Navigate(new Pages.Main());
            btnMenu1.DataContext = IS_KKTDEntities.GetContext().Сотрудники.OrderBy(p => p.Id_сотрудника).ToList();

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
                StudyChast.Window.DragMove();
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

        private void Disciplines_Click(object sender, RoutedEventArgs e)
        {
             PagesNavigation.NavigationService.Navigate(new Pages.Disciplini());
        }

        private void Raspisanie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Prepodavateli_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.NavigationService.Navigate(new Pages.Prepodavatels());
        }
    }
}

