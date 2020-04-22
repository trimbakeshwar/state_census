using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace stateScensus
{
    class CsvBuilder : InterfaceForStateCensus
    {
        public dynamic readData(string Path)
        {
            //path of file StateCensusData.csv
            // Path = @"D:\trimbak\state analys\StateCensusData.csv";
            try
            {
                using StreamReader read = new StreamReader(Path);
                //and load the data on csvreader by using CsvReader
                using CsvReader csvreader = new CsvReader(read, true);
                Console.WriteLine(csvreader);
                //count field
                int fieldCount = csvreader.FieldCount;
                //get fields of files
                string[] headers = csvreader.GetFieldHeaders();
                //add array list 
                List<string[]> record = new List<string[]>();
                int numberOfRecords = 0;
                while (csvreader.ReadNextRecord())
                {
                    string[] tempRecord = new string[fieldCount];
                    csvreader.CopyCurrentRecordTo(tempRecord);
                    record.Add(tempRecord);
                    numberOfRecords++;
                    foreach (string[] Record in record)
                    {
                        Console.WriteLine(" ", Record);
                    }
                  
                }
                return (record, headers, numberOfRecords);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }

    }
}