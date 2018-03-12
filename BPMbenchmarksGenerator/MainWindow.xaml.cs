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
            allGeneratedBenchmarks = new List<BenchmarkInstance>();
            generationArgs = new GenerationArgs();

            InitializeComponent();
            MainWindowSetup();

        }

        private void MainWindowSetup()
        {
            radioAllCases.IsChecked = true;

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
            int lowestAcceptableNumberOfSets = 1;
            int InstancesSetsNumber = GetSetsNumber(lowestAcceptableNumberOfSets);

            if (radioAllCases.IsChecked == true)
            {
                if (InstancesSetsNumber >= lowestAcceptableNumberOfSets)
                    GenerateAllCases(InstancesSetsNumber);
            }
            else if(radioCustomSemi.IsChecked == true)
            {
                if (InstancesSetsNumber >= lowestAcceptableNumberOfSets)
                    GenerateWithDefaultRange(InstancesSetsNumber);
            }
            else if(radioCustomFull.IsChecked == true)
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

            string statusCleanUp = string.Format($"Save directory:\n {_saveDirectory}\n\n Benchmarks parameters: \n\n");
            txtStatus.Text = statusCleanUp;



            SetGenerationArgumentsAllCases("10", "[1,10]", "[1,10]","10");
            txtStatus.Text = BPMGeneratorMethods.UpdateStatusWithGenerationArgs(generationArgs, txtStatus);

            SetGenerationArgumentsAllCases("10", "[1,10]", "[2,4]", "10");
            txtStatus.Text = BPMGeneratorMethods.UpdateStatusWithGenerationArgs(generationArgs, txtStatus);

            SetGenerationArgumentsAllCases("10", "[1,10]", "[4,8]", "10");
            txtStatus.Text = BPMGeneratorMethods.UpdateStatusWithGenerationArgs(generationArgs, txtStatus);

        }


        public void SetGenerationArgumentsAllCases(string noJobs, string jobProcTimeRange, string jobSizeRange, string machCapacity)
        {
            BPMGeneratorMethods.SetNumberOfJobsArgs(noJobs, generationArgs);
            BPMGeneratorMethods.SetJobProcTimeArgs(jobProcTimeRange, generationArgs);
            BPMGeneratorMethods.SetJobSizeArgs(jobSizeRange, generationArgs);
            BPMGeneratorMethods.SetMachineCapacityArgs(machCapacity, generationArgs);
        }


        private void GenerateWithDefaultRange(int SetsNumber)
        {
            MessageBox.Show("radioCustomSemi.IsChecked");


            SetGenerationArgumentsFromDefaultRange();


            txtStatus.Text = BPMGeneratorMethods.UpdateStatusWithGenArgsAndSaveDirectory(generationArgs, _saveDirectory);

            allGeneratedBenchmarks.Clear();
            for (int i = 0; i < SetsNumber; i++)
            {
                GenerateAndAddBencharkInstanceToList(generationArgs);
            }

            printAllGeneratedBenchmarksToMessageBox();
        }

        private void SetGenerationArgumentsFromDefaultRange()
        {
            string stringNumberOfJobs = (this.combNumOfJobs.SelectedItem as ComboBoxItem)?.Content.ToString();
            string stringJobProcTimeRange = (this.combJobProcTime.SelectedItem as ComboBoxItem)?.Content.ToString();
            string stringJobSizeRange = (this.combJobSize.SelectedItem as ComboBoxItem)?.Content.ToString();
            string stringMachineCapacity = "10";

            BPMGeneratorMethods.SetNumberOfJobsArgs(stringNumberOfJobs, generationArgs);
            BPMGeneratorMethods.SetJobProcTimeArgs(stringJobProcTimeRange, generationArgs);
            BPMGeneratorMethods.SetJobSizeArgs(stringJobSizeRange, generationArgs);
            BPMGeneratorMethods.SetMachineCapacityArgs(stringMachineCapacity, generationArgs);

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

            txtStatus.Text = BPMGeneratorMethods.UpdateStatusWithGenArgsAndSaveDirectory(generationArgs, _saveDirectory);

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