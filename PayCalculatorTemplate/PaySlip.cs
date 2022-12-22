using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculatorTemplate
{   
    /// <summary>
    /// PaySlip amounts are recived and stored. 
    /// </summary>
    public class PaySlip
    {   
        public int employeeID { get; set; }
        public string name { get; set; }
        public string typeEmployee { get; set; }
        public int hourlyRate { get; set; }
        public string taxthreshold { get; set; }
        public double payGrossCalculated { get; set; }
        public double taxCalcuated { get; set; } 
        public double superCalculated { get; set; }
        public double payNetCalculated { get; set; }
     
        
    }
}
