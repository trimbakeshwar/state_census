using Newtonsoft.Json;
using NUnit.Framework;
using sate_Censes;
using stateCensusAnaliser;
using stateScensus;

namespace stateCencesTesting
{
    public class TestsForStateCensusData
    {
        //path of file StateCensusData.csv
        static string pathStateCensusData = @"D:\trimbak\state analys\StateCensusData.csv";
        //create a object of stateCensusAnalyser class 
        BaseStateCensus read = new BaseStateCensus(pathStateCensusData);
        [SetUp]
        public void Setup()
        {
          
        }
        /// <summary>
        /// check for number of record 
        /// </summary>
        [Test]
        public void TestForNumberOfRecord()
        {
            //call the readmethod and it return the number of record
            int record = read.ReadMethod(',');
            Assert.AreEqual(29, record);
        }
        /// <summary>
        /// check for when file not found 
        /// </summary>
        [Test]
        public void TestForFileNotFoundException()
        {
            try
            {
                //give the  path of not available csv file
                string path = @"D:\trimbak\state analys\StatesusData.csv";
                //call the readmethod and it return the number of record
                BaseStateCensus ReadForStateCensus = new BaseStateCensus(path);
                int record = ReadForStateCensus.ReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("file is not present on this location", e.Message);
            }
        }
        /// <summary>
        /// check for wrong type of  file
        /// </summary>
        [Test]
        public void TestForWrongTypeException()
        {
            try
            {
                //chenge file type csv to txt and check
                string path = @"D:\trimbak\state analys\StateCensusData.txt";
                //send the file path
                BaseStateCensus ReadForStateCensus = new BaseStateCensus(path);
                //call the readmethod and it return the number of record
                int record = ReadForStateCensus.ReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("enter proper file", e.Message);
            }
        }
        [Test]
        public void TestForWrongDelimeterException()
        {
            try
            {
                int record = read.ReadMethod(';');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("wrong delimeter, please enter proper delimeter", e.Message);
            }
        }
        [Test]
        public void TestForWrongHeaderNamesException()
        {
            try
            {
                //expected output
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                //check for header name not proper
                string[] userHeader = { "State", "Population", "AreaInSqKm", "DensitySqKm" };
                string[] header = read.numberOfHeader(userHeader);
                //if header name is proper then lpass the test if header name not proper then throws exception header name is not proper and catch in catcj
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], header[i]);
                }
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("header name is not same", e.Message);
            }
        }
        /// <summary>
        /// check for same header name for state code
        /// </summary>
        [Test]
        public void checkForHeaderNameSame()
        {

            //expected array
            string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            //pass wrong length array
            string[] userHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            //throws the length not proper exception
            //if length is proper and name is proper then return header names
            //and check with expected output
            string[] header = read.numberOfHeader(userHeader);
            for (int i = 0; i < header.Length; i++)
            {
                Assert.AreEqual(expectedHeader[i], header[i]);
            }
        }
        /// <summary>
        /// check for wrong header length exception
        /// </summary>
        [Test]
        public void CheckForWrongHeaderLengthException()
        {
            try
            {
                //expected array
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                //pass wrong length array
                string[] userHeader = { "State", "Population", "AreaInSqKm" };
                //throws the length not proper exception
                //if length is proper and name is proper then return header names
                //and check with expected output
                string[] header = read.numberOfHeader(userHeader);
               
            }
            catch (StateCensusException e)
            {
                //if string and massage same then pass the test
                Assert.AreEqual("header length is not same", e.Message);
            }

        }
    }

    public class CsvStateCode
    {
        //path of file StateCode.csv
        static string PathOfCsvStateCode = @"D:\trimbak\state analys\StateCode.csv";
        //create object of csvState class
        BaseStateCensus ReadForCsvStateCode = new BaseStateCensus(PathOfCsvStateCode);
        [SetUp]
        public void Setup()
        {
            
        }
        /// <summary>
        /// check for number of record csvstate code
        /// </summary>
        [Test]
        public void TestForNumberOfRecordincsvStateCode()
        {
            //call the readmethod and it return the number of record
            int record = ReadForCsvStateCode.ReadMethod( ',');
            Assert.AreEqual(37, record);
        }
        /// <summary>
        /// check for when file not found for state code csv
        /// </summary>
        [Test]
        public void TestForFileNotFoundExceptionForStateCode()
        {
            try
            {
                //give the  path of not existing csv file
                string Path = @"D:\trimbak\state analys\Statee.csv";
                //create object fo csv reder by using local file path 
                BaseStateCensus ReadForCsvState = new BaseStateCensus(Path);
                //call the readmethod and it return the number of record
                int record = ReadForCsvState.ReadMethod(',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("file is not present on this location", e.Message);
            }
        }
        /// <summary>
        /// check for wrong type of  file
        /// </summary>
        [Test]
        public void TestForWrongTypeExceptionForStateCode()
        {
            try
            {
                //chenge file type csv to txt and check
                string Path = @"D:\trimbak\state analys\StateCode.txt";
                //create object fo csv reder by using local file path 
                BaseStateCensus ReadForCsvState = new BaseStateCensus(Path);
                //call the readmethod and it return the number of record
                int record = ReadForCsvState.ReadMethod( ',');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("enter proper file", e.Message);
            }
        }
        /// <summary>
        /// check for wrong delimeter for state code
        /// </summary>
        [Test]
        public void TestForWrongDelimeterExceptionForStateCode()
        {
            try
            {               
                //call the readmethod and it return the number of record
                //send wrong delimeter for check delimeter exception
                int record = ReadForCsvStateCode.ReadMethod(';');
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("wrong delimeter, please enter proper delimeter", e.Message);
            }
        }
        /// <summary>
        /// check for same header name for state code
        /// </summary>
        [Test]
        public void checkForHeaderNameSameForStateCode()
        {

            //expected output
            string[] expectedHeader = { "SrNo", "StateName", "TIN", "StateCode" };
            //check for header name not proper
            string[] userHeader = { "SrNo", "StateName", "TIN", "StateCode" };
            string[] header = ReadForCsvStateCode.numberOfHeader(userHeader);
            //if header name is proper then lpass the test if header name not proper then throws exception header name is not proper and catch in catcj
             for (int i = 0; i < header.Length; i++)
             {
                 Assert.AreEqual(expectedHeader[i], header[i]);
             }
        }
        /// <summary>
        /// check for wrong header name for state code
        /// </summary>
        [Test]
        public void TestForWrongHeaderNamesExceptionForStateCode()
        {
            try
            {
                //expected output
                string[] expectedHeader = { "SrNo", "StateName", "TIN", "StateCode" };
                //check for header name not proper
                string[] userHeader = { "SrNo", "StateName", "TIN", "StateCo"};
                string[] header = ReadForCsvStateCode.numberOfHeader(userHeader);
                //if header name is proper then lpass the test if header name not proper then throws exception header name is not proper and catch in catcj
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], header[i]);
                }
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("header name is not same", e.Message);
            }
        }
        /// <summary>
        /// check for wrong header length exception
        /// </summary>
        [Test]
        public void CheckForWrongHeaderLengthExceptionForStateCode()
        {
            try
            {
                //expected array
                string[] expectedHeader = { "SrNo", "StateName", "TIN", "StateCode" };
                //pass wrong length array
                string[] userHeader = { "SrNo", "StateName", "TIN" };
                //throws the length not proper exception
                //if length is proper and name is proper then return header names
                //and check with expected output
                string[] header = ReadForCsvStateCode.numberOfHeader(userHeader);
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], header[i]);
                }
            }
            catch (StateCensusException e)
            {
                //if string and massage same then pass the test
                Assert.AreEqual("header length is not same", e.Message);
            }

        }

    }
    public class TestsForCsvStateDataByCsvBuilder
    {
        //path of file StateCensusData.csv 
         static string pathStateCensusData = @"D:\trimbak\state analys\StateCensusData.csv";
        //create a object of stateCensusAnalyser class 
       
        [SetUp]
        public void Setup()
        {

        }
        /// <summary>
        /// check for number of record 
        /// </summary>
        [Test]
        public void checkForHeadersInCsvData()
        {
            //expected headers name
            string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            //assign parameters 1 for not run
            int jasonForm = 1;
            int sort = 1;
            //send sorting column number
            int columnNumber = 0;
            int stringIsCharOrInt = 0;
            //call the read data and retun the output dynamically and store in var
            //return tuple this is new concept to return mulltiple values
            //and get pertcular value Item1,Item2,Item3,Item4
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            var output = state.getHeaders();

            //my itoe three is heeders name
            //if expected output and real output cheack if equal then pass the test
            for (int i = 0; i < expectedHeader.Length; i++)
            {
               
                Assert.AreEqual(expectedHeader[i], output[i]);
            }

        }
        /// <summary>
        /// check for first state
        /// </summary>
        [Test]
        public void checkForFirstStateCsvData()
        {
            //expected output
            var expectedState = "Andhra Pradesh";  
            //send o for sorting and json format
            int jasonForm = 0;
            int sort = 0;
            //sorting apply on this column
            int columnNumber = 0;
            //if it is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 0;
            //call readdata and return output store in var output 
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //var output = builder.readData(pathStateCensusData, jasonForm, sort, columnNumber);
            //second output is store in firststate first sorted record
            int rowNumber = 0;
            int ColumnNumber = 0;
            var firstState = state.getRecord();
            firstState = firstState[rowNumber][ColumnNumber];
            //if equal then pass 
            Assert.AreEqual(expectedState, firstState);
        }

        /// <summary>
        /// check for last state in alphabetical order
        /// </summary>
        [Test]
        public void checkForLastStateCsvData()
        {
            //expected output
            var expectedState = "West Bengal";
            //send 0 for sorting and json format
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 0;
            //if it is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 0;
            //call readdata and return output store in var output 
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort,columnNumber, stringIsCharOrInt);
            //geting number of record
            var lastRecordIndex = state.getNumberOfRecrd();
            //geting sorted record
            var LastState = state.getRecord();
           
            int ColumnNumber = 0;
            LastState = LastState[lastRecordIndex][ColumnNumber];
            //if same then pass
            Assert.AreEqual(expectedState, LastState);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void checkForNumberOfRecordsInCsvData()
        {

            //send 1 for not sorting and not json format
            int jasonForm = 1;
            int sort = 1;
            int columnNumber = 0;
            //if it is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 0;
            //call readdata and return output store in var output 
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //itome three is number of record
            var numberOfRecord = state.getNumberOfRecrd();
            //if same then pass
            Assert.AreEqual(29, numberOfRecord);
           /* string PathOfCsvStateCode = @"D:\trimbak\state analys\StateCode.csv";
            //call the comstructor and send path
            csvData state1 = new csvData(PathOfCsvStateCode, jasonForm, sort, columnNumber);
            var numberOfRecord2 = state1.getNumberOfRecrd();
            //if same then pass
            Assert.AreEqual(37, numberOfRecord2);*/
        }
        /// <summary>
        /// check for json formated first state
        /// </summary>
        [Test]
        public void CheckForJsonFormatFirstState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 0;
            //call the constructor
            int stringIsCharOrInt = 0;
            //call readdata and return output store in var output 
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            int rowNumber = 0;
            int ColumnNumber = 0;
            //get first string of record
            string first = sortedList[rowNumber][ColumnNumber];
            Assert.AreEqual("Andhra Pradesh", first);

        }
        /// <summary>
        /// check for json formated first state
        /// </summary>
        [Test]
        public void CheckForJsonFormatLastState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 0;
            //if it is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 0;
            //call constructor of csv file
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            int ColumnNumber = 0;
            //get last string of record
            string lastState = sortedList[state.getNumberOfRecrd()][ColumnNumber];
            Assert.AreEqual("West Bengal", lastState);

        }
        [Test]
        public void CheckForJsonFormatMostPopulatedState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 1;
            //call the constructor
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            int rowNumber = 29;
            int ColumnNumber = 0;
            //get first string of record
            string first = sortedList[rowNumber][ColumnNumber];
            Assert.AreEqual("Uttar Pradesh", first);

        }
        /// <summary>
        /// check for json formated least populated state state
        /// </summary>
        [Test]
        public void CheckForJsonFormatLeastPopulatedState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 1;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            //call constructor of csv file
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            int ColumnNumber = 0;
            //get last string of record
            string firstLowPopulation = sortedList[1][ColumnNumber];
            Assert.AreEqual("Sikkim", firstLowPopulation);

        }
        [Test]
        public void CheckForJsonFormatMostPopulatedDensityState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 3;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            //call the constructor
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
           // var output=state.getRecord();
             int rowNumber = 29;
             int ColumnNumber = 0;
             //get first string of record
             string highest = sortedList[rowNumber][ColumnNumber];
          
            Assert.AreEqual("Bihar", highest);

        }
        /// <summary>
        /// check for json formated least populated state state
        /// </summary>
        [Test]
        public void CheckForJsonFormatLeastPopulatedDensityState()
        {
            
             int jasonForm = 0;
             int sort = 0;
             int columnNumber = 3;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            //call the constructor
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
             //deserialize objects to list
              var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
              //var output=state.getRecord();
              int ColumnNumber = 0;
              //get last string of record

             string lastState = sortedList[1][ColumnNumber];
             Assert.AreEqual("Mizoram", lastState);

        }
        [Test]
        public void CheckForJsonFormatLargestAreaState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 2;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            //call the constructor
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            // var output=state.getRecord();
            int rowNumber = 29;
            int ColumnNumber = 0;
            //get first string of record
            string highest = sortedList[rowNumber][ColumnNumber];

            Assert.AreEqual("Rajasthan", highest);

        }
        /// <summary>
        /// check for json formated least populated state state
        /// </summary>
        [Test]
        public void CheckForJsonFormatsmallestAreaState()
        {

            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 2;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            //call the constructor
            CsvFactory state = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            //var output=state.getRecord();
            int ColumnNumber = 0;
            //get last string of record

            string lastState = sortedList[1][ColumnNumber];
            Assert.AreEqual("Goa", lastState);

        }




    }
    public class TestsForCsvCodeDataByCsvBuilder
    {
        //path of file StateCensusData.csv 
        static string PathOfCsvStateCode = @"D:\trimbak\state analys\StateCode.csv";

        //create a object of stateCensusAnalyser class 

        [SetUp]
        public void Setup()
        {

        }
        /// <summary>
        /// check for number of record 
        /// </summary>
        [Test]
        public void checkForHeadersInCsvCode()
        {
            //expected headers name
            string[] expectedHeader = { "SrNo", "StateName", "TIN", "StateCode" };
            //assign parameters 1 for not run
            int jasonForm = 1;
            int sort = 1;
            //send sorting column number
            int columnNumber = 3;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 0;
            //call the read data and retun the output dynamically and store in var
            CsvFactory state = new CsvFactory(PathOfCsvStateCode, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //geting heders name by this function
            var output = state.getHeaders();

            //my itoe three is heeders name
            //if expected output and real output cheack if equal then pass the test
            for (int i = 0; i < expectedHeader.Length; i++)
            {

                Assert.AreEqual(expectedHeader[i], output[i]);
            }

        }
        /// <summary>
        /// check for first state
        /// </summary>
        [Test]
        public void checkForFirstStateCsvCode()
        {
            //expected output
            var expectedState = "AD";
            //send o for sorting and json format
            int jasonForm = 0;
            int sort = 0;
            //sorting apply on this column
            int columnNumber = 3;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 0;
            //call the read data and retun the output dynamically and store in var
            CsvFactory state = new CsvFactory(PathOfCsvStateCode, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get sorted record from csv code
            var firstState = state.getRecord();
            int row = 0;
            int column = 3;
            firstState = firstState[row][column];
            //if equal then pass 
            Assert.AreEqual(expectedState, firstState);
        }
        /// <summary>
        /// check for last state in alphabetical order
        /// </summary>
        [Test]
        public void checkForLastStateCsvCode()
        {
            //expected output
            var expectedState = "WB";
            //send 0 for sorting and json format
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 3;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 0;
            //call the read data and retun the output dynamically and store in var
            CsvFactory state = new CsvFactory(PathOfCsvStateCode, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //last record index get from number of record
            var lastRecordIndex = state.getNumberOfRecrd();
            //get sorted list last state in alphabetical order
            var LastState = state.getRecord();
            //get last record from sorted file
            int column = 3;
            LastState = LastState[lastRecordIndex][column];
            //if same then pass
            Assert.AreEqual(expectedState, LastState);
        }
        /// <summary>
        /// check number of record in csv code
        /// </summary>
        [Test]
        public void checkForNumberOfRecordsInCsvCode()
        {
            //send 1 for not sorting and not json format
            int jasonForm = 1;
            int sort = 1;
            int columnNumber = 3;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 0;
            //call the read data and retun the output dynamically and store in var
            CsvFactory state = new CsvFactory(PathOfCsvStateCode, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get number of record from csv code
            var numberOfRecord = state.getNumberOfRecrd();
            //if same then pass
            Assert.AreEqual(37, numberOfRecord);
            string pathStateCensusData = @"D:\trimbak\state analys\StateCensusData.csv";


            //call the read data and retun the output dynamically and store in var
            CsvFactory state2 = new CsvFactory(pathStateCensusData, jasonForm, sort, columnNumber, stringIsCharOrInt);

            var numberOfRecord1 = state2.getNumberOfRecrd();
            //if same then pass
            Assert.AreEqual(29, numberOfRecord1);
        }
        /// <summary>
        /// check for json formated first state
        /// </summary>
        [Test]
        public void CheckForJsonFormatFirstState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 3;
            int stringIsCharOrInt = 0;
            //call the read data and retun the output dynamically and store in var
            CsvFactory state = new CsvFactory(PathOfCsvStateCode, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            //get first string of record
            int row = 0;
            int column = 3;
            string first = sortedList[row][column];
            Assert.AreEqual("AD", first);

        }
        /// <summary>
        /// check for json formated first state
        /// </summary>
        [Test]
        public void CheckForJsonFormatLastState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 3;
            int stringIsCharOrInt = 0;
            //call the read data and retun the output dynamically and store in var
            CsvFactory state = new CsvFactory(PathOfCsvStateCode, jasonForm, sort, columnNumber, stringIsCharOrInt);
             //get json formated output
             var sortedJsonFile = state.getJesonFormatRecord();
             //deserialize objects to list
             var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
             //get last string of record
             int column = 3;
             string lastState = sortedList[state.getNumberOfRecrd()][column];
            
            Assert.AreEqual("WB", lastState);

        }
       // [Test]
          
    }
    public class TestForUsCensusData
    {
        static string Path = @"D:\trimbak\state analys\USCensusData.csv";

        //create a object of stateCensusAnalyser class 

        [SetUp]
        public void Setup()
        {

        }
        /// <summary>
        /// check for number of record in US census
        /// </summary>
        [Test]
        public void checkForNumberOfRecordsInUScensusData()
        {
            //send 1 for not sorting and not json format
            int jasonForm = 1;
            int sort = 1;
            int columnNumber = 3;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 0;
            //call the read data and retun the output dynamically and store in var
            CsvFactory state = new CsvFactory(Path, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get number of record from csv code
            var numberOfRecord = state.getNumberOfRecrd();
            //if same then pass
            Assert.AreEqual(51, numberOfRecord);
            
        }
        [Test]
        public void CheckHighlyPopulatedState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 2;
            int stringIsCharOrInt = 1;
            //call the read data and retun the output dynamically and store in var
            CsvFactory state = new CsvFactory(Path, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            //get first string of record
           // int row = 1;
            int column = 1;
            string first = sortedList[state.getNumberOfRecrd()][column];
            Assert.AreEqual("California", first);
        }
        [Test]
        public void ChecklessPopulatedState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 2;
            int stringIsCharOrInt = 1;
            //call the read data and retun the output dynamically and store in var
            CsvFactory state = new CsvFactory(Path, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            //get first string of record
            int row = 1;
            int column = 1;
            string first = sortedList[row][column];
            Assert.AreEqual("Wyoming", first);
        }
       
        
        [Test]
        public void CheckForJsonFormatMostPopulatedDensityState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 7;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            //call the constructor
            CsvFactory state = new CsvFactory(Path, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            // var output=state.getRecord();
            int rowNumber = state.getNumberOfRecrd();
            int ColumnNumber = 1;
            //get first string of record
            string highest = sortedList[rowNumber][ColumnNumber];

            Assert.AreEqual("District of Columbia", highest);

        }
        /// <summary>
        /// check for json formated least populated state state
        /// </summary>
        [Test]
        public void CheckForJsonFormatLeastPopulatedDensityState()
        {

            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 7;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            //call the constructor
            CsvFactory state = new CsvFactory(Path, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            //var output=state.getRecord();
            int ColumnNumber = 1;
            //get last string of record

            string lastState = sortedList[1][ColumnNumber];
            Assert.AreEqual("Alaska", lastState);

        }
        [Test]
        public void CheckForJsonFormatLargestAreaState()
        {
            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 4;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            //call the constructor
            CsvFactory state = new CsvFactory(Path, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            // var output=state.getRecord();
            int rowNumber = state.getNumberOfRecrd();
            int ColumnNumber = 1;
            //get first string of record
            string highest = sortedList[rowNumber][ColumnNumber];

            Assert.AreEqual("Alaska", highest);

        }
        /// <summary>
        /// check for json formated least populated state state
        /// </summary>
        [Test]
        public void CheckForJsonFormatsmallestAreaState()
        {

            int jasonForm = 0;
            int sort = 0;
            int columnNumber = 4;
            //if sorting column  is alphabetical then send 0 otherwise send 1
            int stringIsCharOrInt = 1;
            //call the constructor
            CsvFactory state = new CsvFactory(Path, jasonForm, sort, columnNumber, stringIsCharOrInt);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            //var output=state.getRecord();
            int ColumnNumber = 1;
            //get last string of record

            string lastState = sortedList[1][ColumnNumber];
            Assert.AreEqual("District of Columbia", lastState);

        }
        [Test]
        public void mostPopulusStateFromIndiaAndUs()
        {
            string pathOfUsCencus= @"D:\trimbak\state analys\USCensusData.csv";
            int columNumberforUSScensus=6;
            string pathofStateScensus= @"D:\trimbak\state analys\StateCensusData.csv";
            int columNumberforIndianScensus=3;
            int StringIsCharOrInt=1;
            CsvBuilder build = new CsvBuilder();
            var outPut=build.SortigOnTwoFile(pathOfUsCencus, columNumberforUSScensus, pathofStateScensus, columNumberforIndianScensus, StringIsCharOrInt);
           
            Assert.AreEqual("District of Columbia", outPut);

        }


    }
}