using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace stateScensus
{
    public class CsvFactory : CsvBuilder
    {
        /// <summary>
        /// call csv builde 
        /// </summary>
        /// <param name="path"> path of state scensus data</param>
        /// <param name="jasonForm"> 1 for no 0 for yes choice if u want json formaat or not</param>
        /// <param name="sort">choice 0 for sort 1 for no</param>
        /// <param name="columnNumber">sorting on take place on the basis of column</param>
        public CsvFactory(string path, int jasonForm, int sort, int columnNumber,int stringIsCharOrInt) : base(path, jasonForm, sort, columnNumber, stringIsCharOrInt)
        { }
       
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
       
       
    }
}
