using System;
using System.Collections.Generic;
using System.Text;

namespace stateScensus
{
    interface IinterfaceForUsScensus
    {
        public dynamic ReadData(string Path, string classDAOname, int jsonForm, int sort, int columnNumber, int stringIsCharOrInt);

    }
}
