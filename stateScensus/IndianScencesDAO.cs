using System;
using System.Collections.Generic;
using System.Text;

namespace stateScensus
{
    class stateScencesDataDAO
    {

        public string State { set; get; }
        public string Population { set; get; }
        public string AreaInSqKm { set; get; }
        public string DensityPerSqKm { set; get; }
     

        public stateScencesDataDAO(string[] attributs)
        {
            State = attributs[0];
            Population = attributs[1];
            AreaInSqKm = attributs[2];
            DensityPerSqKm = attributs[3];
        }

    }
    class stateScensusCodeDAO
    { 
        //attributes can access by set and get
        public string SrNo { set; get; }
        public string StateName { set; get; }
        public string TIN { set; get; }
        public string StateCode { set; get; }
        //constructor for initialize the attributes
        //attributes can send form data builer class
        //assign index data of attribute to the veriable
        public stateScensusCodeDAO(string[] attributs)
        {
            SrNo = attributs[0];
            StateName = attributs[1];
            TIN = attributs[2];
            StateCode = attributs[3];
        }
    }
}
