using NUnit.Framework;
using sate_Censes;
using stateCensusAnaliser;

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

    class CsvStateCode
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
        /// check for wrong header name for state code
        /// </summary>
        [Test]
        public void TestForWrongHeaderNamesExceptionForStateCode()
        {
            try
            {
                //expected output
                string[] expectedHeader = { "SrNo", "State", "Name", "TIN", "StateCode", "Column5" };
                //check for header name not proper
                string[] userHeader = { "SrNo", "State", "Name", "TIN", "StateCode", "Column" };
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
                string[] expectedHeader = { "SrNo", "State", "Name", "TIN", "StateCode", "Column5" };
                //pass wrong length array
                string[] userHeader = { "SrNo", "State", "Name", "TIN", "StateCode" };
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
}