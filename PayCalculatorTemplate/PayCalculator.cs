using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculatorTemplate
{    /// <summary>
     /// Class to set up pay calculator
     /// </summary>
    public class PayCalculator
    {

        public static double calculatePay(double hrlyRate, double hrsWork)
        {
            //will calculate pay based on hours worked entered by user x hourly rate
            return hrlyRate * hrsWork;
        }

        public static double calcuateTax(double grossPay2,double taxRateA, double taxRateB)
        {
            //calulates tax based on hourlyrate x taxrate.
            double x = Math.Floor(grossPay2) + 0.99;
            return Math.Round(taxRateA * x - taxRateB, 2);
        }

       public static double calculateSuperannuation(double grosspay2)
        {
            //calculate super based on super rate x pay. 

            return grosspay2 * 0.105;

            
        }
    }
}
