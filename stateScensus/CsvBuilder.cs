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

    public class CsvBuilder 
    {
        private string Path;
        public int jsonForm;
        public int sort;
        public int columnNumber;
       
        public CsvBuilder(string path, int jsonForm, int sort, int columnNumber)
        {
            this.Path = path;
            this.jsonForm = jsonForm;
            this.sort = sort;
            this.columnNumber = columnNumber;
        }
        /// <summary>
        /// read the data from csv file
        /// </summary>
        /// <param name="Path">path of file</param>
        /// <param name="jsonForm">if u want jsonformat then print in json format by sending 0</param>
        /// <param name="sort">if user want be sorted output then sort by sending 0</param>
        /// <param name="columnNumber">send the column number u want to sirt</param>
        /// <returns>it return 4 values diff datatype </returns>
        public dynamic readData()
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
                //use for storing sorted output   
                Dictionary<int, string[]> sortelist = new Dictionary<int, string[]>();
                //for add record csv file to list
                Dictionary<int, string[]> record = new Dictionary<int, string[]>();
                //headers name add at starting 
                record.Add(numberOfRecord, headers);
                //geting delimeter
                char delimeter = csv.Delimiter;
                //add record csv file to list
                while (csv.ReadNextRecord())
                {
                    //calculate number of record
                    numberOfRecord++;
                    //create temp array for storing data tempararily
                    string[] temp = new string[fieldCount];
                    //copy data from csv file to temp list
                    csv.CopyCurrentRecordTo(temp);
                    //add temp data to record list
                    record.Add(numberOfRecord, temp);

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
                    record = SortTheList(record, columnNumber, fieldCount);

                }
                //if user send 0 for output in json format otherwise no
                if (jsonForm == 0)
                {
                    var jsonFormdata = JsonSerializer.Serialize(record.Values);
                    //return data dynamically
                    return (record, numberOfRecord, headers, jsonFormdata);

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
        ///sort the data in ascending order
        /// </summary>
        /// <param name="record">list of record </param>
        /// <param name="columnNumber">sorting apply on this column</param>
        /// <returns></returns>
        public dynamic SortTheList(dynamic record, int columnNumber,int fieldCount)
        {
            //number of record present in record
            int count = record.Count;
           
            //sort the data 
            for (int i = 0; i < count; i++)
            {
                dynamic recordOne = record[i];
                string valueOne = recordOne[columnNumber];
                for (int j = 0; j < count; j++)
                {
                    dynamic recordTwo = record[j];
                    string valueTwo = recordTwo[columnNumber];
                    //compare which one is greter and swap 
                    if (valueOne.CompareTo(valueTwo) < 0)
                    {

                        dynamic temp = record[i];
                        record[i] = record[j];
                        record[j] = temp;                                                 
                    }
                }
            }
            //display the sorted list
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < fieldCount; j++)
                {
                    Console.Write("-" + record[i][j]);
                }
                Console.WriteLine();
            }
            return record;
        }
        public dynamic readData(string Path, string classDAOname,int jsonForm, int sort, int columnNumber)
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
                //get headers
                dynamic headers = csv.GetFieldHeaders();
                //if class name is same of stateScensusCodeDAO then it goes inside
                if (classDAOname.Equals("stateScensusCodeDAO"))
                {
                    //create dictionary to store object of stateScensusCodeDAO class
                    Dictionary<int, stateScensusCodeDAO> record = new Dictionary<int, stateScensusCodeDAO>();


                    //headers name add at starting as object
                    record.Add(numberOfRecord, new stateScensusCodeDAO(headers));
                    //geting delimeter
                    char delimeter = csv.Delimiter;
                    //add record csv file to list
                    while (csv.ReadNextRecord())
                    {
                        //calculate number of record
                        numberOfRecord++;
                        //create temp array for storing data tempararily
                        string[] temp = new string[fieldCount];
                        //copy data from csv file to temp list
                        csv.CopyCurrentRecordTo(temp);
                        //add temp data to Dictionary as object
                        record.Add(numberOfRecord, new stateScensusCodeDAO(temp));

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
                        record = SortTheList(record, columnNumber, fieldCount);

                    }
                    //if user send 0 for output in json format otherwise no
                    if (jsonForm == 0)
                    {
                        var jsonFormdata = JsonSerializer.Serialize(record.Values);
                        //return data dynamically
                        return (record, numberOfRecord, headers, jsonFormdata);

                    }
                    return (record, numberOfRecord, headers);
                }
                //
                if (classDAOname.Equals("stateScencesDataDAO"))
                {
                    //create dictonary for storing stateScencesDataDAO
                    Dictionary<int, stateScencesDataDAO> record = new Dictionary<int, stateScencesDataDAO>();


                    //headers name add at starting as object
                    record.Add(numberOfRecord, new stateScencesDataDAO(headers));
                    //geting delimeter
                    char delimeter = csv.Delimiter;
                    //add record csv file to list
                    while (csv.ReadNextRecord())
                    {
                        //calculate number of record
                        numberOfRecord++;
                        //create temp array for storing data tempararily
                        string[] temp = new string[fieldCount];
                        //copy data from csv file to temp list
                        csv.CopyCurrentRecordTo(temp);
                        //add temp data to record list as object
                        record.Add(numberOfRecord, new stateScencesDataDAO(temp));

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
                        record = SortTheList(record, columnNumber, fieldCount);

                    }
                    //if user send 0 for output in json format otherwise no
                    if (jsonForm == 0)
                    {
                        var jsonFormdata = JsonSerializer.Serialize(record.Values);
                        //return data dynamically
                        return (record, numberOfRecord, headers,  jsonFormdata);

                    }
                    return (record, numberOfRecord, headers);
                }
                return 0;
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



    }
}