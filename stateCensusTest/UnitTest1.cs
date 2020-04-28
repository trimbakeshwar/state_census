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
        stateCensusAnalyser read = new stateCensusAnalyser(pathStateCensusData);
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
                stateCensusAnalyser ReadForStateCensus = new stateCensusAnalyser(path);
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
                stateCensusAnalyser ReadForStateCensus = new stateCensusAnalyser(path);
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
        CsvState ReadForCsvStateCode = new CsvState(PathOfCsvStateCode);
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
                CsvState ReadForCsvState = new CsvState(Path);
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
                CsvState ReadForCsvState = new CsvState(Path);
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
            //call the read data and retun the output dynamically and store in var
            //return tuple this is new concept to return mulltiple values
            //and get pertcular value Item1,Item2,Item3,Item4
            csvData state = new csvData(pathStateCensusData, jasonForm, sort, columnNumber);
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
            //call readdata and return output store in var output 
            csvData state = new csvData(pathStateCensusData, jasonForm, sort, columnNumber);
            //var output = builder.readData(pathStateCensusData, jasonForm, sort, columnNumber);
            //second output is store in firststate first sorted record
            int rowNumber = 0;
            int ColumnNumber = 0;
            var firstState = state.getSortedRecord();
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
            //call readdata and return output store in var output 
            csvData state = new csvData(pathStateCensusData, jasonForm, sort,columnNumber);
            //geting number of record
            var lastRecordIndex = state.getNumberOfRecrd();
            //geting sorted record
            var LastState = state.getSortedRecord();
           
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
            //call readdata and return output store in var output 
            csvData state = new csvData(pathStateCensusData, jasonForm, sort, columnNumber);
            //itome three is number of record
            var numberOfRecord = state.getNumberOfRecrd();
            //if same then pass
            Assert.AreEqual(29, numberOfRecord);
            string PathOfCsvStateCode = @"D:\trimbak\state analys\StateCode.csv";
            csvData state1 = new csvData(PathOfCsvStateCode, jasonForm, sort, columnNumber);
            var numberOfRecord2 = state1.getNumberOfRecrd();
            //if same then pass
            Assert.AreEqual(37, numberOfRecord2);
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
            csvData state = new csvData(pathStateCensusData, jasonForm, sort, columnNumber);
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
            //call constructor of csv file
            csvData state = new csvData(pathStateCensusData, jasonForm, sort, columnNumber);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            int ColumnNumber = 0;
            //get last string of record
            string lastState = sortedList[state.getNumberOfRecrd()][ColumnNumber];
            Assert.AreEqual("West Bengal", lastState);

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
            //call the read data and retun the output dynamically and store in var
           
            CsvCode state = new CsvCode(PathOfCsvStateCode, jasonForm, sort, columnNumber);
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
            //call readdata and return output store in var output 
            CsvCode state = new CsvCode(PathOfCsvStateCode, jasonForm, sort, columnNumber);
            //get sorted record from csv code
            var firstState = state.getSortedRecord();
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
            //call readdata and return output store in var output 
            CsvCode state = new CsvCode(PathOfCsvStateCode, jasonForm, sort, columnNumber);
            //last record index get from number of record
            var lastRecordIndex = state.getNumberOfRecrd();
            //get sorted list last state in alphabetical order
            var LastState = state.getSortedRecord();
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
            //call readdata and return output store in var output 
            CsvCode state = new CsvCode(PathOfCsvStateCode, jasonForm, sort, columnNumber);
            //get number of record from csv code
            var numberOfRecord = state.getNumberOfRecrd();
            //if same then pass
            Assert.AreEqual(37, numberOfRecord);
             string pathStateCensusData = @"D:\trimbak\state analys\StateCensusData.csv";
            CsvCode state2 = new CsvCode(pathStateCensusData, jasonForm, sort, columnNumber);
            //get number of record from csv code
            var numberOfRecord2 = state.getNumberOfRecrd();
            //if same then pass
            Assert.AreEqual(37, numberOfRecord2);

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
           //call the constructor
            CsvCode state = new CsvCode(PathOfCsvStateCode, jasonForm, sort, columnNumber);
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
            //call constructor of csv file
            CsvCode state = new CsvCode(PathOfCsvStateCode, jasonForm, sort, columnNumber);
            //get json formated output
            var sortedJsonFile = state.getJesonFormatRecord();
            //deserialize objects to list
            var sortedList = JsonConvert.DeserializeObject(sortedJsonFile);
            //get last string of record
            int column = 3;
            string lastState = sortedList[state.getNumberOfRecrd()][column];
            Assert.AreEqual("WB", lastState);

        }
    }
}