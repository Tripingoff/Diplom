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
    /// Логика взаимодействия для Prepodovateli.xaml
    /// </summary>
    public partial class Prepodovateli : Page
    {
        public Prepodovateli()
        {
            InitializeComponent();
            ListBoxDisciplins.ItemsSource = IS_KKTDEntities.GetContext().Сотрудники.OrderBy(p => p.Должность == 6).ToList();
        }

        public void UpdateData()
        {
            var currentDisciplines = IS_KKTDEntities.GetContext().Сотрудники.OrderBy(p => p.Id_сотрудника).ToList();
            currentDisciplines = currentDisciplines.Where(p => p.Фамилия.ToLower().Contains(TxtKod.Text.ToLower())).ToList();
            ListBoxDisciplins.ItemsSource = currentDisciplines;
            //вывод значений из бд для выподающих списков, через сравнение их название
        }

        private void TxtKod_TextChanged(object sender, TextChangedEventArgs e)
        { 
            UpdateData();
        }
    }
    
}
