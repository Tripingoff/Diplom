﻿using System;
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
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        public Results()
        {
            InitializeComponent();
            DataGridResult.ItemsSource = IS_KKTDEntities.GetContext().Итог_дисциплин.Where(p => p.Студенты.id_user == Manager.CurrentUser.Id_user).ToList();
        }
    }
}
