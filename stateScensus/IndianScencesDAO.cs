using System;
using System.Collections.Generic;
using System.Text;

namespace stateScensus
{
    class stateScencesDataDAO
    {
        private string State;
        private string Population;
        private string AreaInSqKm;
        private string DensityPerSqKm;

        public string state { set=> State = value; get=> State; }
        public string population { set => Population = value; get => Population; }
        public string areaInSqKm { set => AreaInSqKm = value; get => AreaInSqKm; }
        public string densityPerSqKm { set => DensityPerSqKm = value; get => DensityPerSqKm; }


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
        private string SrNo;
        private string StateName;
        private string TIN;
        private string StateCode; 
        //attributes can access by set and get
        public string srNo { set=> SrNo = value; get=> SrNo; }
        public string stateName { set=> StateName = value; get=> StateName; }
        public string tIN { set=> TIN = value; get=> TIN; }
        public string stateCode { set => StateCode = value; get=> StateCode; }
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
    class UScensusDataDAO
    {
        private string State_Id;
        private string State;
        private string Population;
        private string Housing_Units;
        private string Total_Area;
        private string Water_Area;
        private string Land_Area;
        private string Population_Density;
        private string Housing_Density;
        public string StateId { set => State_Id = value; get => State_Id; }
        public string state { set => State = value; get => State; }
        public string population { set => Population = value; get => Population; }
        public string HousingUnits { set => Housing_Units = value; get => Housing_Units; }
        public string TotalArea { set => Total_Area = value; get => Total_Area; }
        public string WaterArea { set => Water_Area = value; get => Water_Area; }
        public string LandArea { set => Land_Area = value; get => Land_Area; }
        public string PopulationDensity { set => Population_Density = value; get => Population_Density; }
        public string HousingDensity { set => Housing_Density = value; get => Housing_Density; }

        public  UScensusDataDAO(string[] attributs)
        {
            this.State_Id = attributs[0];
            this.State = attributs[1];
            this.Population = attributs[2];
            this.Housing_Units = attributs[3];
            this.Total_Area = attributs[4];
            this.Water_Area = attributs[5];
            this.Land_Area = attributs[6];
            this.Population_Density = attributs[7];
            this.Housing_Density = attributs[8];
        }
    }
}
