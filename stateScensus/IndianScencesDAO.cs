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
        public string this[int i]
        {
            get
            {
                if (i == 0)
                {
                    return State;
                }
                else if (i == 1)
                {

                    return Population;
                }
                else if (i == 2)
                {

                    return AreaInSqKm;
                }
                else if (i == 3)
                {

                    return DensityPerSqKm;
                }
                return "";
            }
            set
            {
                if (i == 0)
                {
                    State = value;
                }
                else if (i == 1)
                {

                    Population = value;
                }
                else if (i == 2)
                {

                    AreaInSqKm = value;
                }
                else if (i == 3)
                {

                    DensityPerSqKm = value;
                }
            }
        }


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
        public string this[int i]
        {
            get
            {
                if (i == 0)
                {
                    return SrNo;
                }
                else if (i == 1)
                {

                    return StateName;
                }
                else if (i == 2)
                {

                    return TIN;
                }
                else if (i == 3)
                {

                    return StateCode;
                }
                return "";
            }
            set
            {
                if (i == 0)
                {
                    SrNo = value;
                }
                else if (i == 1)
                {

                    StateName = value;
                }
                else if (i == 2)
                {

                    TIN = value;
                }
                else if (i == 3)
                {

                    StateCode = value;
                }
            }
        }


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

        public string this[int i]
        {
            get
            {
                if (i == 0)
                {
                    return State_Id;
                }
                else if (i == 1)
                {

                    return State;
                }
                else if (i == 2)
                {

                    return Population;
                }
                else if (i == 3)
                {

                    return Housing_Units;
                }
                else if (i == 4)
                {

                    return Total_Area;
                }
                else if (i == 5)
                {

                    return Water_Area;
                }
                else if (i == 6)
                {

                    return Land_Area;
                }
                else if (i == 7)
                {

                    return Population_Density;
                }
                else if (i == 8)
                {

                    return Housing_Density;
                }
                return "";

            }
            set
            {
                if (i == 0)
                {
                    State_Id = value;
                }
                else if (i == 1)
                {

                    State = value;
                }
                else if (i == 2)
                {

                    Population = value;
                }
                else if (i == 3)
                {

                    Housing_Units = value;
                }
                else if (i == 4)
                {

                    Total_Area = value;
                }
                else if (i == 5)
                {

                    Water_Area = value;
                }
                else if (i == 6)
                {

                    Land_Area = value;
                }
                else if (i == 7)
                {

                    Population_Density = value;
                }
                else if (i == 8)
                {

                    Housing_Density = value;
                }
            }
        }

        public UScensusDataDAO(string[] attributs)
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
