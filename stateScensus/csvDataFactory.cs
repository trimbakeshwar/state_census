using System;
using System.Collections.Generic;
using System.Text;

namespace stateScensus
{
    class csvDataFactory:CsvBuilder
    {
        string path;
        int sort;
        int columnNumber;
        int JsonForm;
        public  csvDataFactory(string path, int JsonForm, int sort, int columnNumber)
        {
            this.path = path;
            this.sort = sort;
            this.columnNumber = columnNumber;
            this.JsonForm = JsonForm;
        }
        public void getHeader()
        {
            var output = readData(path, JsonForm, sort, columnNumber);
            Console.WriteLine(output.Item3);

        }
    }
}
