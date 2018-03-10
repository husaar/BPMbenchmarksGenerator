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
        private GenerationArgs generationArgs;

        List<BenchmarkInstance> allGeneratedBenchmarks;


        public MainWindow()
        {
            InitializeComponent();

            MainWindowSetup();

        }

        private void MainWindowSetup()
        {

            generationArgs = new GenerationArgs();

            radioAllCases.IsChecked = true;

            _saveDirectory = BPMGeneratorMethods.GetStartingDirectory();

            txtStatus.Text += BPMGeneratorMethods.CurrentSaveDirectoryStatus(_saveDirectory);

            allGeneratedBenchmarks = new List<BenchmarkInstance>();
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
            int lowestAcceptableNumberOfSets = 1;
            int InstancesSetsNumber = GetSetsNumber(lowestAcceptableNumberOfSets);

            generationArgs.Reset();

            if ((bool)radioAllCases.IsChecked)
            {
                if (InstancesSetsNumber >= lowestAcceptableNumberOfSets)
                    GenerateAllCases(InstancesSetsNumber);
            }
            else if((bool)radioCustomSemi.IsChecked)
            {
                if (InstancesSetsNumber >= lowestAcceptableNumberOfSets)
                    GenerateWithDefaultRange(InstancesSetsNumber);
            }
            else if((bool)radioCustomFull.IsChecked)
            {
                if (InstancesSetsNumber >= lowestAcceptableNumberOfSets)
                    GenerateWithCustomRange(InstancesSetsNumber);
            }
            else
            {
                MessageBox.Show("Please select proper option in Cusotmoze tab.");
            }

        }

        private int GetSetsNumber(int lowestNumberOfSets)
        {
            string stringInstancesSetsNumber = null;

            int intInstancesSetsNumber = -1;

            try
            {
                stringInstancesSetsNumber = txtInstancesSetsNumber.Text;
                intInstancesSetsNumber = BPMGeneratorMethods.ParseStringToInteger(stringInstancesSetsNumber, txbInstancesSetsNumber, lowestNumberOfSets);
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return intInstancesSetsNumber;
        }

        private void GenerateAllCases(int SetsNumber)
        {

                MessageBox.Show("stringInstancesSetsNumber: ", SetsNumber.ToString());

        }

        private void GenerateWithDefaultRange(int SetsNumber)
        {
            MessageBox.Show("radioCustomSemi.IsChecked");

            int intNumberOfJobs = -2;
            int intMachineCapacity = 10;

            int intJobProcessingTimeFrom = -4;
            int intJobProcessingTimeTo = -5;

            int intJobSizeFrom = -6;
            int intJobJobSizeTo = -7;

            int lowestPossibleNum = 1;



        }

        private int GetNumberOfJobsFromDefaultRange()
        {

            return 0;
        }

        private void GenerateWithCustomRange(int SetsNumber)
        {
            MessageBox.Show("stringInstancesSetsNumber: ", SetsNumber.ToString());
            
            string stringNumberOfJobs = txtNumOfJobs.Text;
            string stringMachineCapacity = txtMachineCapacity.Text;

            string stringJobProcessingTimeFrom = txtJobProcTimeFrom.Text;
            string stringJobProcessingTimeTo = txtJobProcTimeTo.Text;

            string stringJobSizeFrom = txtJobSizeFrom.Text;
            string stringJobSizeTo = txtJobSizeTo.Text;

            int lowestPossibleNum = 1;

            try
            {
                generationArgs.NumberOfJobs = BPMGeneratorMethods.ParseStringToInteger(stringNumberOfJobs, txbNumOfJobs, lowestPossibleNum);
                generationArgs.MachineCapacity = BPMGeneratorMethods.ParseStringToInteger(stringMachineCapacity, txbMachineCapacity, lowestPossibleNum);

                generationArgs.JobProcessingTimeFrom = BPMGeneratorMethods.ParseStringToInteger(stringJobProcessingTimeFrom, txbJobProcTime, lowestPossibleNum);
                generationArgs.JobProcessingTimeTo = BPMGeneratorMethods.ParseStringToInteger(stringJobProcessingTimeTo, txbJobProcTime, lowestPossibleNum);

                generationArgs.JobSizeFrom = BPMGeneratorMethods.ParseStringToInteger(stringJobSizeFrom, txbJobSize, lowestPossibleNum);
                generationArgs.JobSizeTo = BPMGeneratorMethods.ParseStringToInteger(stringJobSizeTo, txbJobSize, lowestPossibleNum);
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           string controlMessage = string.Format($"NumberOfJobs: {generationArgs.NumberOfJobs} MachineCapacity: {generationArgs.MachineCapacity} JobProcessingTimeFrom: {generationArgs.JobProcessingTimeFrom} JobProcessingTimeTo: {generationArgs.JobProcessingTimeTo} JobSizeFrom: {generationArgs.JobSizeFrom} JobSizeTo: {generationArgs.JobSizeTo}");

            MessageBox.Show(controlMessage);

            allGeneratedBenchmarks.Clear();
            for (int i = 0; i < SetsNumber; i++)
            {
                GenerateAndAddBencharkInstanceToList(generationArgs);
            }

            printAllGeneratedBenchmarksToMessageBox();
        }

        private void GenerateAndAddBencharkInstanceToList(GenerationArgs gArgs)
        {
            BenchmarkInstance benchmark = null;
            try
            {
                benchmark = BPMGeneratorMethods.GenerateOneBencharkInstance(gArgs);
            }
            catch (ArgumentOutOfRangeException rex)
            {
                MessageBox.Show(rex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (benchmark != null)
            {
                allGeneratedBenchmarks.Add(benchmark);
            }
        }

        private void printAllGeneratedBenchmarksToMessageBox()
        {
            foreach (BenchmarkInstance b in allGeneratedBenchmarks)
            {
                MessageBox.Show(b.ToString());
            }
        }

}
}