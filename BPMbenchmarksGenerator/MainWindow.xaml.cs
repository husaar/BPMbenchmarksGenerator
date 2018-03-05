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

namespace BPMbenchmarksGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string stringInstancesSetsNumber = txtInstancesSetsNumber.Text;
            
            int intInstancesSetsNumber = -1;
            try
            {
                intInstancesSetsNumber = ParseStringToInteger(stringInstancesSetsNumber, 1);
                MessageBox.Show("stringInstancesSetsNumber: ", stringInstancesSetsNumber);
            }
            catch(FormatException fex)
            {
                MessageBox.Show(fex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private int ParseStringToInteger(string s, int lowestPossibleNumber)
        {
            int integer = -2;
            string exceptionMessage = null;
            try
            {
                integer = int.Parse(s);
            }
            catch(FormatException)
            {
                exceptionMessage = "Provided number has to be integer!";
                throw new FormatException(exceptionMessage);
            }

            if(integer < lowestPossibleNumber)
            {
                exceptionMessage = string.Format($"Integer value should be at least {lowestPossibleNumber.ToString()}.");
                throw new Exception(exceptionMessage);
            }

            return integer;
        }
    }
}