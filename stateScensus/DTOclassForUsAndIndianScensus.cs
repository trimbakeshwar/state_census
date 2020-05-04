using LumenWorks.Framework.IO.Csv;
using stateCensusAnaliser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace stateScensus
{
    class DTOclassForUsAndIndianScensus:sorting
    {
        dynamic dataFile;
        public dynamic readData(string Path, string classname, int jsonForm, int sort, int columnNumber, int stringIsCharOrInt)
        {
            //declear number of record is 0
            int numberOfRecord = 0;
            try
            {
                int i= 0;
                //steramreader read the data from file
                using StreamReader streamread = new StreamReader(Path);
                //lode stream reader data on csv reder
                using CsvReader csv = new CsvReader(streamread, true);
                int fieldCount = csv.FieldCount;
                if (classname.Contains("USCensusData"))
                {
                    //if clas name contains USCensusData  then add data in datafile 
                    dataFile = csv.ToDictionary(x => i = i + 1, x => new stateScensusCodeDAO(x));
                }
                else if (classname.Contains("StateCode"))
                {
                    //if clas name contains StateCode  then add data in datafile 
                    dataFile = csv.ToDictionary(x => i = i + 1, x => new stateScensusCodeDAO(x));
                }
                else if (classname.Contains("StateCensusData"))
                {
                    //if clas name contains StateCensusData  then add data in datafile 
                    dataFile = csv.ToDictionary(x => i = i + 1, x => new stateScencesDataDAO(x));
                }
                    //if number of record is zero then throw exception file is empty
                    //if number of record is zero then throw exception file is empty
                    if (numberOfRecord == 0)
                    {
                        throw new StateCensusException(StateCensusException.ExceptionType.FILE_HAS_NO_DATA, "file has not any data");
                    }
                    //if user send 0 for sorting then  data otherwise no
                    if (sort == 0)
                    {
                    //call the sorting function
                    dataFile = SortTheList(dataFile, columnNumber, fieldCount, stringIsCharOrInt);

                    }
                    //if user send 0 for output in json format otherwise no
                    if (jsonForm == 0)
                    {
                        var jsonFormdata = JsonSerializer.Serialize(dataFile.Values);
                    //return data dynamically
                    return jsonFormdata;

                    }
                return dataFile.Values;
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
