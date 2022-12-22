using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayCalculatorTemplate;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests the CSV importer functions
        /// </summary>
        [TestMethod]
        public void TestCSVImport()
        {
            var fileName = @"C:\Users\place\OneDrive\Documents\GitHub\Tafe-Coding-Assessments\PayCalculatorTemplate_WITHTEST\PayCalculatorTemplate\PayCalculatorTemplate\employee.csv";

            List<CsvMap> importedRecords = EmployeeCsvImporter.ImportSomeRecords(fileName);

            Assert.IsNotNull(importedRecords);
        }
        /// <summary>
        /// Tests that the Pay Calclator calcuates grosspay correctly. 
        /// </summary>
        [TestMethod]
        public void TestPayCalc()
        {
            var fileName = @"C:\Users\place\OneDrive\Documents\GitHub\Tafe-Coding-Assessments\PayCalculatorTemplate_WITHTEST\PayCalculatorTemplate\PayCalculatorTemplate\employee.csv";

            List<CsvMap> importedRecords = EmployeeCsvImporter.ImportSomeRecords(fileName);

            double hrlyRate = 30;
            double hsWorked = 40;

            double expectedResult = PayCalculator.calculatePay(hrlyRate, hsWorked);

            double actualRate = importedRecords[3].hourlyRate;

            double actualResult = PayCalculator.calculatePay(actualRate, hsWorked);

            Assert.AreEqual(expectedResult, actualResult);
        }
        /// <summary>
        /// Tests that tax calculation is functioning correctly. 
        /// </summary>
        [TestMethod]
        public void TestTaxCalc()
        {
            var fileName = @"C:\Users\place\OneDrive\Documents\GitHub\Tafe-Coding-Assessments\C#\PayCalculator_V2\PayCalculatorEx\PayCalculatorTemplate\PayCalculatorTemplate\taxrate-withthreshold.csv";

            List<TaxCsvMap> importedTaxRecords = TaxRateCsvImporter.ImportSomeRecords(fileName);

            double grossPay = 1000;
            double taxA = 0.3477;
            double taxB = 186.2119;

            double expectedResult = PayCalculator.calcuateTax(grossPay, taxA, taxB);

            double actualTaxA = importedTaxRecords[5].a;
            double actualTaxB = importedTaxRecords[5].b;

            double actualResult = PayCalculator.calcuateTax(grossPay, actualTaxA, actualTaxB);

            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void TestSuperCalc()
        {
            var fileName = @"C:\Users\place\OneDrive\Documents\GitHub\Tafe-Coding-Assessments\PayCalculatorTemplate_WITHTEST\PayCalculatorTemplate\PayCalculatorTemplate\employee.csv";

            List<CsvMap> importedRecords = EmployeeCsvImporter.ImportSomeRecords(fileName);

            double grossPay = 1000;
            double hsWorked = 40;

            double expectedResult = PayCalculator.calculateSuperannuation(grossPay);

            double actualGrossPay = (importedRecords[0].hourlyRate)*hsWorked;

            double actualResult = PayCalculator.calculateSuperannuation(actualGrossPay);

            Assert.AreEqual(expectedResult, actualResult);  


            

            
        }
    }
}
