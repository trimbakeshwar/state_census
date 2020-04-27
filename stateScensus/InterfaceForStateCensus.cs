using System;
using System.Collections.Generic;
using System.Text;

namespace stateScensus
{
    public interface InterfaceForStateCensus
    {
        
        public dynamic readData(string Path,int jsonForm,int sort,int columnNumber);
    }
}
