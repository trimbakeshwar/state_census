using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using stateCensusAnaliser;

namespace stateScensus
{/// <summary>
/// csv bilder class for reding or fetching data from file 
/// </summary>
    public class CsvBuilder : InterfaceForStateCensus
    {
        public string[] record;
        public string[] headers;
        public int numberOfRecords;
        /// <summary>
        /// read the data from file
        /// </summary>
        /// <param name="Path">path of file</param>

        /// <returns>record</returns>
        public void readData(string Path)
        {
            
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
                //iterate the record from csv file to temp record line by line
                while (csvreader.ReadNextRecord())
                {
                    string[] tempRecord = new string[fieldCount];
                    //copy csv file record in temp record line by line
                    csvreader.CopyCurrentRecordTo(tempRecord);
                    //add temprecord in array list
                    record.Add(tempRecord);
                    numberOfRecords++;                  
                }
                if(numberOfRecords==0)
                {
                    throw new StateCensusException(StateCensusException.ExceptionType.FILE_HAS_NO_DATA, "file has not any data or record");
                }
            }
            catch(StateCensusException e)
            {
                Console.WriteLine(e.Message);
                throw new StateCensusException(StateCensusException.ExceptionType.FILE_HAS_NO_DATA, e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                throw new FileNotFoundException(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw new IndexOutOfRangeException(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
        public string[] GetRecord()
        {
            return record;
        }
        public string[] GetHeader()
        {
            return headers;
        }
        public int GetNumberOfRecord()
        {
            return numberOfRecords;
        }


    }
}