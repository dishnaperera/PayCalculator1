using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculatorTemplate
{   /// <summary>
    /// This allows the selected employees payslip data to be saved to a CSV file. 
    /// </summary>
    public class SavePayslipCSV
    {
        public static void SavePayRecord(PaySlip PaySlip)
        {   
            using (var writer = new StreamWriter("Pay" + PaySlip.employeeID + PaySlip.name + DateTime.Now.ToFileTime() +".csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(PaySlip);
            }
        }

    }
    public sealed class PayslipCsvMapMap : ClassMap<PaySlip>
    {
        public PayslipCsvMapMap()
        {
            Map(m => m.payGrossCalculated).Index(0);
            Map(m => m.taxCalcuated).Index(1);
            Map(m => m.superCalculated).Index(2);
            Map(m => m.payNetCalculated).Index(3);
            
        }
    }
}
