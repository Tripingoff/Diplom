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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public static Admin Window;
        Авторизация _currentAdmin = new Авторизация();
        public Admin()
        {
            InitializeComponent();
            _currentAdmin = Manager.CurrentUser;
            Window = this;
            PagesNavigation.NavigationService.Navigate(new Pages.Main());
            list.ItemsSource = IS_KKTDEntities.GetContext().Сотрудники.Where(p=>p.Id_user == Manager.CurrentUser.Id_user).ToList();

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
                Admin.Window.DragMove();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximaze_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void BtnMinimaze_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Students_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.NavigationService.Navigate(new Pages.StudentsAdmin());
        }

        private void Groups_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.NavigationService.Navigate(new Pages.GroupsAdmin());
        }

        private void Sotrudniks_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.NavigationService.Navigate(new Pages.SotrudniksAdmin());
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
            if(PagesNavigation.CanGoBack)
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
            PagesNavigation.NavigationService.Navigate( new Pages.Disciplini());
        }

    }
}
