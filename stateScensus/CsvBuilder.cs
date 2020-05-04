using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using stateCensusAnaliser;
using System.Collections;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Linq;

namespace stateScensus
{/// <summary>
/// csv bilder class for reding or fetching data from file 
/// </summary>

    public class CsvBuilder: sorting, InterfaceForStateCensus
    {
        private string Path;
        public int jsonForm;
        public int sort;
        public int columnNumber;
        public int stringIsCharOrInt;
        public CsvBuilder()
        {

        }
        public CsvBuilder(string path, int jsonForm, int sort, int columnNumber,int stringIsCharOrInt)
        {
            this.Path = path;
            this.jsonForm = jsonForm;
            this.sort = sort;
            this.columnNumber = columnNumber;
            this.stringIsCharOrInt = stringIsCharOrInt;
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
                using StreamReader streamread = new StreamReader(Path);
                //lode stream reader data on csv reder
                using CsvReader csv = new CsvReader(streamread, true);
                //number of field present in file
                int fieldCount = csv.FieldCount;
                //geting header name
                string[] headers = csv.GetFieldHeaders();

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
                    record = SortTheList(record, columnNumber, fieldCount, stringIsCharOrInt);

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
        
    

        public dynamic readData(string Path, string classDAOname,int jsonForm, int sort, int columnNumber,int stringIsCharOrInt)
        {
            //declear number of record is 0
            int numberOfRecord = 0;
            try
            {
                //steramreader read the data from file
                using StreamReader streamread = new StreamReader(Path);
                //lode stream reader data on csv reder
                using CsvReader csv = new CsvReader(streamread, true);
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
                        record = SortTheList(record, columnNumber, fieldCount, stringIsCharOrInt);

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
                        record = SortTheList(record, columnNumber, fieldCount, stringIsCharOrInt);

                    }
                    //if user send 0 for output in json format otherwise no
                    if (jsonForm == 0)
                    {


                        string jsonFormdata = JsonSerializer.Serialize(record.Values);
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
        /// <summary>
        /// load two files at a time
        /// </summary>
        /// <param name="pathOfUsCencus"> path of us sensus</param>
        /// <param name="columNumberforUSScensus"> sorting takes on column number</param>
        /// <param name="pathofStateScensus"> path of indian sensus</param>
        /// <param name="columNumberforIndianScensus">sorting takes on column number</param>
        /// <param name="StringIsCharOrInt">if data in column is string then 0 other wise 1</param>
        /// <returns></returns>
        public dynamic SortigOnTwoFile(string pathOfUsCencus,int columNumberforUSScensus, string pathofStateScensus, int columNumberforIndianScensus,int StringIsCharOrInt)
        {
            //load us data
            StreamReader readUsData = new StreamReader(pathOfUsCencus);
            CsvReader UsData = new CsvReader(readUsData, true);
            //count field
            int fieldCount = UsData.FieldCount;
            //load indian scensus data
            StreamReader readIndiaData = new StreamReader(pathofStateScensus);
            CsvReader IndiaData = new CsvReader(readIndiaData, true);
            //number of field
            int numberOfField = IndiaData.FieldCount;
            int i = -1;
            //store data in dictionary
            dynamic USdataList = UsData.ToDictionary(y => i = i + 1, y => new UScensusDataDAO(y));
             i = -1;
            //store data in dictionary
            dynamic IndiadataList = IndiaData.ToDictionary(y => i = i + 1, y => new stateScencesDataDAO(y));
            //call sorting method and store sorted data in file
            dynamic SortedUSList = SortTheList(USdataList, columNumberforUSScensus, fieldCount, StringIsCharOrInt);
            //call sorting method and store sorted data in file
            dynamic SortedIndianList = SortTheList(IndiadataList, columNumberforIndianScensus, numberOfField, StringIsCharOrInt);
            //sorted first input density onvert in double for comarision
            double USMostPopulusDensity =double.Parse(SortedUSList[1][6]);
            //sorted first input density onvert in double for comarision
            double IndianMostPopulusDensity = double.Parse(SortedIndianList[1][3]);
            //if us data greter then return us state otherwise return indian state
            if(USMostPopulusDensity> IndianMostPopulusDensity)
            {
                return SortedUSList[1][1];
            }
            else
            {
                return SortedIndianList[1][0];
            }
            
                
        }
       
    }
}