using LumenWorks.Framework.IO.Csv;
using stateCensusAnaliser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace stateScensus
{
    public class UScensusData: sorting, IinterfaceForUsScensus
    {
        public dynamic ReadData(string Path, string classDAOname, int jsonForm, int sort, int columnNumber, int stringIsCharOrInt)
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
                if (classDAOname.Equals("UScensusDataDAO"))
                {
                    //create dictionary to store object of stateScensusCodeDAO class
                    Dictionary<int, UScensusDataDAO> record = new Dictionary<int, UScensusDataDAO>();


                    //headers name add at starting as object
                    record.Add(numberOfRecord, new UScensusDataDAO(headers));
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
                        record.Add(numberOfRecord, new UScensusDataDAO(temp));

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
