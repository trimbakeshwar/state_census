using System;
using System.Collections.Generic;
using System.Text;

namespace stateScensus
{
    interface IinterfaceForUsScensus
    {
        //create abstract method of read data
        public dynamic ReadData(string Path, string classDAOname, int jsonForm, int sort, int columnNumber, int stringIsCharOrInt);

    }
}
