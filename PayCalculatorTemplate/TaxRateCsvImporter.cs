using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculatorTemplate
{
    public class TaxRateCsvImporter
    {   
        /// <summary>
        /// Imports Tax records from tax CSV file. 
        /// </summary>
        /// <param name="taxFileName"> This filename is one of two determined between if the employee is with or without tax threshold. </param>
        /// <returns></returns>
        public static List<TaxCsvMap> ImportSomeRecords(string taxFileName)
        {
            var myTaxRecords = new List<TaxCsvMap>();
            using (var reader = new StreamReader(taxFileName))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<TaxCsvMapMap>();


                    int fromPay;
                    int toPay;
                    double a;
                    double b;
                

                    //reads CSV file
                    while (csv.Read())
                    {
                        fromPay = csv.GetField<int>(0);
                        toPay = csv.GetField<int>(1);
                        a = csv.GetField<double>(2);
                        b = csv.GetField<double>(3);
                        myTaxRecords.Add(CreateRecord(fromPay, toPay, a, b));

                    }

                }

            }
            return myTaxRecords;
        }
        /// <summary>
        /// Created Record with CSV read data
        /// </summary>
        /// <param name="fromPay">Starting range of pay for tax calculation amounts </param>
        /// <param name="toPay">End range of pay for tax calculation amounts </param>
        /// <param name="a"> Tax a calculation amount </param>
        /// <param name="b"> Tax b calculation amount</param>
        /// <returns></returns>
        public static TaxCsvMap CreateRecord(int fromPay, int toPay, double a, double b)
        {
            TaxCsvMap record = new TaxCsvMap();

           
            record.fromPay = fromPay;
            record.toPay = toPay;
            record.a = a;
            record.b = b;
        

            return record;
        }
    }

    public class TaxCsvMap
    {
        public int fromPay { get; set; }
        public int toPay { get; set; }
        public double a { get; set; }
        public double b { get; set; }

    }

    public sealed class TaxCsvMapMap : ClassMap<TaxCsvMap>
    {
        public TaxCsvMapMap()
        {
            Map(m => m.fromPay).Index(0);
            Map(m => m.toPay).Index(1);
            Map(m => m.a).Index(2);
            Map(m => m.b).Index(3);

        }
    }
}