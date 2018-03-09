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
        private string _saveDirectory = "";

        public MainWindow()
        {
            InitializeComponent();

            MainWindowSetup();

        }

        private void MainWindowSetup()
        {
            this.radioAllCases.IsChecked = true;
            this.txtInstancesSetsNumber = null;

            _saveDirectory = BPMGeneratorMethods.GetStartingDirectory();

            txtStatus.Text += BPMGeneratorMethods.CurrentSaveDirectoryStatus(_saveDirectory);
        }

        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog newDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();

            System.Windows.Forms.DialogResult dialogResult = newDirectoryDialog.ShowDialog();

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                _saveDirectory = newDirectoryDialog.SelectedPath;
                txtStatus.Text = BPMGeneratorMethods.CurrentSaveDirectoryStatus(_saveDirectory);
            }
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