using System;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using stateCensusAnaliser;

namespace sate_Censes
{
    public class stateCensusAnalyser:BaseStateCensus
    {
        /// <summary>
        /// call base class and send path of state scences data
        /// </summary>
        /// <param name="Path"></param>
        public stateCensusAnalyser(string Path) : base(Path) { }
    }
}

