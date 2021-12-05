﻿using GUI_Group_Project.Database;
using GUI_Group_Project.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI_Group_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();

            //using (DBrepo repository = new DBrepo())
            //{
            //    Winninglotto winninglotto = new Winninglotto()
            //    {
            //        LotteryID = 1,
            //        No1 = 7,
            //        No2 = 1,
            //        No3 = 6,
            //        Letter = "H"


            //    };
            //    repository.Winninglottos.Add(winninglotto);
            //    repository.SaveChanges();
            //}
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calenderwindow sw = new calenderwindow();
            sw.Show();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Boughtlotto boughtlotto = new Boughtlotto()
            {
                No1 = int.Parse(_1.Text),
                No2 = int.Parse(_2.Text),
                No3 = int.Parse(_3.Text),
                Letter = _4.Text,
                LotteryID = int.Parse(DateTime.Now.ToString("MMdd")),
                UserID = 25,
                //Date = DateTime.Now.Date,
                BoughtlottoID = 123

            };
            DBContext Database = new DBContext();
            try
            {
                Database.Boughtlottos.Add(boughtlotto);
                Database.SaveChanges();

                MessageBox.Show("Succesfully Bought");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedIndex = 2;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedIndex = 1;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _1.Text = "";
            _2.Text = "";
            _3.Text = "";
            _4.Text = "";
        }
    }
}