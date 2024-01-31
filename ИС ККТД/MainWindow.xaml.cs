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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using ИС_ККТД.Models;
using ИС_ККТД.Windows;

namespace ИС_ККТД
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Window;
        public MainWindow()
        {
            InitializeComponent();
            Window = this;
        }


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Window.DragMove();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            { //загрузка всех пользователей из БД в список
                List<Авторизация> users = IS_KKTDEntities.GetContext().Авторизация.ToList();
                //попытка найти пользователя с указанным паролем и логином
                //если такого пользователя не будет обнаружено то переменная u будет равна null
                Авторизация user = users.FirstOrDefault(p => p.Пароль == TxtPassword.Text && p.Логин == TxtLogin.Text);
                if (user != null)
                {
                    switch (user.Id_роли)
                    {
                        case 1:
                            Manager.CurrentUser = user;
                            Admin admin = new Admin();
                            admin.Owner = this;
                            this.Hide();
                            admin.Show();
                            break;

                        case 2:
                            Manager.CurrentUser = user;
                            Sotrudnik sotrudnik = new Sotrudnik();
                            sotrudnik.Owner = this;
                            this.Hide();
                            sotrudnik.Show();
                            break;
                        case 3:
                            Manager.CurrentUser = user;
                            Student student = new Student();
                            student.Owner = this;
                            this.Hide();
                            student.Show();
                            break;
                        case 4:
                            Manager.CurrentUser = user;
                            Zavotdel zavotdel = new Zavotdel();
                            zavotdel.Owner = this;
                            this.Hide();
                            zavotdel.Show();
                            break;
                        case 5:
                            Manager.CurrentUser = user;
                            StudyChast study = new StudyChast();
                            study.Owner = this;
                            this.Hide();
                            study.Show();
                            break;
                    }
                }
                else
                    MessageBox.Show("Не верный логин или пароль");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите закрыть приложение ? ", "Выйти", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

        private void BtnEditPassord_Click(object sender, RoutedEventArgs e)
        {
            EditMain edit = new EditMain();
            edit.Owner = this;
            edit.ShowDialog();
        }

        private void TxtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TxtPassword.Focus();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnOpen.Focus();
            }
        }
    }
}
