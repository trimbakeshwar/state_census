﻿using System;
using System.Collections.Generic;
using System.Text;

namespace stateScensus
{
    public interface InterfaceForStateCensus
    {
        
        public dynamic readData();
        public dynamic readData(string Path, string classDAOname, int jsonForm, int sort, int columnNumber, int stringIsCharOrInt);

    }
}
