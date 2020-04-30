using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace stateScensus
{
    public class csvData : CsvBuilder
    {
        public csvData(string path, int jasonForm, int sort, int columnNumber,int stringIsCharOrInt) : base(path, jasonForm, sort, columnNumber, stringIsCharOrInt)
        {

        }
       
        //call read data and get the record
        public dynamic getRecord()
        {
            var output = readData();
            return output.Item1;
        }
       
        //call the readdata and get heders
        public dynamic getHeaders()
        {
            var output = readData();
            return output.Item3;
        }
        // //call the readdata and return json format output
        public dynamic getJesonFormatRecord()
        {
            var output = readData();
            return output.Item4;
        }
        //call the readdata and get number of record
        public dynamic getNumberOfRecrd()
        {
            var output = readData();
            return output.Item2;
        }
      public dynamic getFirstState()
      {
            var record = readData();
            int count = record.Count;
            for (int i = 0; i < count; i++)
            {
                dynamic recordOne = record[i];
                string valueOne = recordOne[columnNumber];
                for (int j = 0; j < count; j++)
                {
                    dynamic recordTwo = record[j];
                    string valueTwo = recordTwo[columnNumber];

                    if (recordOne[columnNumber].Length < recordTwo[columnNumber].Length)
                    {
                       return record[i];
                    }


                }
            }
            return 0;
      }
        public dynamic getLastState()
        {
            var record = readData();
            int count = record.Count;
            for (int i = 0; i < count; i++)
            {
                dynamic recordOne = record[i];
                string valueOne = recordOne[columnNumber];
                for (int j = 0; j < count; j++)
                {
                    dynamic recordTwo = record[j];
                    string valueTwo = recordTwo[columnNumber];

                    if (recordOne[columnNumber].Length > recordTwo[columnNumber].Length)
                    {
                        return record[i];
                    }


                }
            }
            return 0;
        }
    }
}
