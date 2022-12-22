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

namespace PayCalculatorTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Allows for mainwindow to write to payslip. 
        /// </summary>
        private PaySlip paySlip;
        /// <summary>
        /// MainWindow logic for Mainwindow.xaml
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //This is the filename of the CSV file the employee data is imported from. 
            var fileName = @"C:\Users\place\OneDrive\Documents\GitHub\PayCalculator\PayCalculatorTemplate\employee.csv";
            
            //CSV Helper           
            List<CsvMap> importedRecords = EmployeeCsvImporter.ImportSomeRecords(fileName);

            empDataGrid.DataContext = importedRecords;

          

        }

        /// <summary>
        /// Calculate pay of selected employee with entered hours ammount. Initiates PayCalculator functions
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Allows TextBox to show all variables of payment, tax and superannuation for selected employee required for Payslip
                        
            var data = empDataGrid.DataContext as List<CsvMap>;

            int cellId = empDataGrid.SelectedIndex;

            //Message Box accounting for user not selecting employee and clicking 'calcuate'

            if(cellId == -1)
            {
                MessageBox.Show("Please select employee profile.");
                return;
            }

            int employeeID = Convert.ToInt32(data[cellId].employeeID);
            string name = Convert.ToString(data[cellId].firstName + " " + data[cellId].lastName);
            double hrlyRate = Convert.ToDouble(data[cellId].hourlyRate);
            char taxThreshold = Convert.ToChar(data[cellId].taxthreshold);
            double hoursWorkedInput = Convert.ToDouble(inputHr.Text);
            double grossPay = hrlyRate * hoursWorkedInput;
            double grossPay2 = PayCalculator.calculatePay(hrlyRate, hoursWorkedInput);
            double super = PayCalculator.calculateSuperannuation(grossPay2);

            //Message box, when user input into Hours Worked box is out of bounds.

            if (hoursWorkedInput< 1 || hoursWorkedInput >168)
            {
                MessageBox.Show("Please enter value between 1 - 168");
                return;
            }
            //Variable to alter CSV file between two using if statements, determined if the employee selected is with tax threshold or without. 

            string taxFileName;

            if (taxThreshold == 'Y')
            {
                taxFileName = @"C:\Users\place\OneDrive\Documents\GitHub\PayCalculator\PayCalculatorTemplate\taxrate-withthreshold.csv";
            }
            else
            {
                taxFileName = @"C:\Users\place\OneDrive\Documents\GitHub\PayCalculator\PayCalculatorTemplate\taxrate-nothreshold.csv";
            }
            //Sends correct Tax file to Tax Tate CSV importer to convert into records. 

            List<TaxCsvMap> importedTaxRecords = TaxRateCsvImporter.ImportSomeRecords(taxFileName);

            //initlising calculatedTax variable

            double calculatedTax = 0;

            //determining which tax A and tax B amount to use based on gross pay amount. 

            foreach (TaxCsvMap importedTaxRecord in importedTaxRecords)
            {
                if (importedTaxRecord.fromPay <= grossPay2 && grossPay2  < importedTaxRecord.toPay)
                {
                   calculatedTax = PayCalculator.calcuateTax(grossPay2, importedTaxRecord.a, importedTaxRecord.b);
                }
            }

            double netPay = grossPay2 - calculatedTax;

            //Displays All selected employee relavant calculations in textBox

            PaymentSummaryDisplay.Text = ("ID: " + employeeID) + ("\nName: " + name) + ("\nHourly Rate: " + hrlyRate) + ("\nTax Threshold: " + taxThreshold) +
                ("\nGross Pay: " + grossPay2) + ("\nNet Pay: " + netPay) + ("\nTax: " + calculatedTax) + ("\nSuper: " + super);

            this.paySlip = new PaySlip();
            this.paySlip.employeeID = employeeID;
            this.paySlip.name = name;
            this.paySlip.payGrossCalculated = grossPay2;
            this.paySlip.payNetCalculated = netPay; 
            this.paySlip.superCalculated = super;
            this.paySlip.taxCalcuated = calculatedTax;

        }

        /// <summary>
        /// When button is clicked payslip is generated and saved. 
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SavePayslipCSV.SavePayRecord(this.paySlip);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            
        }

        private void empDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
