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

            MainWindowSetup();

        }

        private void MainWindowSetup()
        {
            this.radioAllCases.IsChecked = true;
            this.txtInstancesSetsNumber = null;
            txtStatus.Text = "Ready for benchmark generation.\n\n";
            txtStatus.Text += "Benchmarks will be saved in:\n";
            txtStatus.Text += BPMGeneratorMethods.GetStartingDirectory();

            txtStatus.Text += "\n\nClick Path to change directory. \n\n";
        }

        private void btnPath_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {

            string stringInstancesSetsNumber = null;

            int intInstancesSetsNumber = -1;
            try
            {
                stringInstancesSetsNumber = txtInstancesSetsNumber.Text;
                intInstancesSetsNumber = BPMGeneratorMethods.ParseStringToInteger(stringInstancesSetsNumber, 1);
                MessageBox.Show("stringInstancesSetsNumber: ", stringInstancesSetsNumber);
            }
            catch(ArgumentNullException nex)
            {
                MessageBox.Show(nex.Message);
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}