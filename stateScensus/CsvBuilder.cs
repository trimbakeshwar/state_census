using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using stateCensusAnaliser;
using System.Collections;
using System.Text.Json;

namespace stateScensus
{/// <summary>
/// csv bilder class for reding or fetching data from file 
/// </summary>
    public class CsvBuilder : InterfaceForStateCensus
    {

        /// <summary>
        /// read the data from csv file
        /// </summary>
        /// <param name="Path">path of file</param>
        /// <param name="jsonForm">if u want jsonformat then print in json format by sending 0</param>
        /// <param name="sort">if user want be sorted output then sort by sending 0</param>
        /// <param name="columnNumber">send the column number u want to sirt</param>
        /// <returns>it return 4 values diff datatype </returns>
        public dynamic readData(string Path, int jsonForm, int sort, int columnNumber)
        {
            //declear number of record is 0
            int numberOfRecord = 0;
            try
            {
                //steramreader read the data from file
                using StreamReader read = new StreamReader(Path);
                //lode stream reader data on csv reder
                using CsvReader csv = new CsvReader(read, true);
                //number of field present in file
                int fieldCount = csv.FieldCount;
                //geting header name
                string[] headers = csv.GetFieldHeaders();
                //for add record csv file to list
                List<string[]> record = new List<string[]>();
                //use for storing sorted output 
                List<string> sortelist = new List<string>();
                //headers name add at starting 
                record.Add(headers);
                //geting delimeter
                char delimeter = csv.Delimiter;
                //add record csv file to list
                while (csv.ReadNextRecord())
                {
                    //create temp array for storing data tempararily
                    string[] temp = new string[fieldCount];
                    //copy data from csv file to temp list
                    csv.CopyCurrentRecordTo(temp);
                    //add temp data to record list
                    record.Add(temp);
                    //calculate number of record
                    numberOfRecord++;
                }
                //if number of record is zero then throw exception file is empty
                if (numberOfRecord == 0)
                {
                    throw new StateCensusException(StateCensusException.ExceptionType.FILE_HAS_NO_DATA, "file has not any data");
                }
                //if user send 0 for sorting then  data otherwise no
                if (sort == 0)
                {
                    //call the sorting function
                    sortelist=SortTheList(record, columnNumber);
                   
                }
                //if user send 0 for output in json format otherwise no
                if (jsonForm == 0)
                {
                    var jsonFormdata = JsonSerializer.Serialize(sortelist);  
                    //return data dynamically
                    return (record, sortelist, numberOfRecord, headers, jsonFormdata);
                   
                }
                return (record, numberOfRecord, headers);

            }
            //all exceptions catch below 
            catch (StateCensusException e)
            {
                throw new StateCensusException(StateCensusException.ExceptionType.FILE_HAS_NO_DATA, e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        ///sort the data in ascending order
        /// </summary>
        /// <param name="record">list of record </param>
        /// <param name="columnNumber">sorting apply on this column</param>
        /// <returns></returns>
        public List<string> SortTheList(List<string[]> record, int columnNumber)
        {
            //number of record present in record
            int count = record.Count;
            //list for sorting output store
            List<string> sortlist = new List<string>();
            //add perticular column data in this list
            for (int i = 0; i < count; i++)
            {
                //assign the one record to recordOne 
                dynamic recordOne = record[i];
                //and perticular this record column number data assign to value one
                //suppose record one is   { "State", "Population", "AreaInSqKm", "DensityPerSqKm" }
                //and iam send column number 1 the it  on the population data
                string valueOne = recordOne[columnNumber];
                //then add in list
                sortlist.Add(valueOne);
            }
            //sort the data 
            for (int i = 0; i < count; i++)
            {                
                for (int j = 0; j < count; j++)
                {         
                    //compare which one is greter and swap 
                    if (sortlist[j].CompareTo(sortlist[i]) > 0)
                    {
                        string[] temp = new string[1];
                        temp[0] = sortlist[i];
                        sortlist[i] = sortlist[j];
                        sortlist[j] = temp[0];                                                  
                    }
                }
            }
            //display the sorted list
            foreach (string Record in sortlist)
            {
                Console.WriteLine(Record);
            }
            return sortlist;
        }
        
    }   
}