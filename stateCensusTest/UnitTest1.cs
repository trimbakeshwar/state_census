using NUnit.Framework;
using sate_Censes;
using stateCensusAnaliser;

namespace stateCencesTesting
{
    public class Tests
    {
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
            //create a object of stateCensusAnalyser class 
            stateCensusAnalyser read = new stateCensusAnalyser();
            //give the  path of csv file
            string path = @"D:\trimbak\state analys\StateCensusData.csv";
            //call the readmethod and it return the number of record
            int record = read.ReadMethod(path, ',');
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
                //create a object of stateCensusAnalyser class 
                stateCensusAnalyser read = new stateCensusAnalyser();
                //give the  path of csv file
                string path = @"D:\trimbak\state analys\StateCensusData.csv";
                //call the readmethod and it return the number of record
                int record = read.ReadMethod(path, ',');
            }
            catch (stateCensusException e)
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
                //create a object of stateCensusAnalyser class 
                stateCensusAnalyser read = new stateCensusAnalyser();
                //chenge file type csv to txt and check
                string path = @"D:\trimbak\state analys\StateCensusData.txt";
                //call the readmethod and it return the number of record
                int record = read.ReadMethod(path, ',');
            }
            catch (stateCensusException e)
            {
                Assert.AreEqual("enter proper file", e.Message);
            }
        }
        [Test]
        public void TestForWrongDelimeterException()
        {
            try
            {
                //create a object of stateCensusAnalyser class 
                stateCensusAnalyser read = new stateCensusAnalyser();
                //chenge file type csv to txt and check
                string path = @"D:\trimbak\state analys\StateCensusData.csv";
                //call the readmethod and it return the number of record
                int record = read.ReadMethod(path, ';');
            }
            catch (stateCensusException e)
            {
                Assert.AreEqual("wrong delimeter, please enter proper delimeter", e.Message);
            }
        }
        [Test]
        public void TestForWrongHeaderNamesException()
        {
            try
            {
                //create a object of stateCensusAnalyser class 
                stateCensusAnalyser read = new stateCensusAnalyser();
                //chenge file type csv to txt and check
                string path = @"D:\trimbak\state analys\StateCensusData.csv";
                //call the numberofheder and it return the heder
                //expected output
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                //check for header name not proper
                string[] userHeader = { "State", "Population", "AreaInSqKm", "DensitySqKm" };
                string[] header = read.numberOfHeader(path, userHeader);
                //if header name is proper then lpass the test if header name not proper then throws exception header name is not proper and catch in catcj
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], header[i]);
                }
            }
            catch (stateCensusException e)
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
                //create a object of stateCensusAnalyser class 
                stateCensusAnalyser read = new stateCensusAnalyser();
                //chenge file type csv to txt and check
                string path = @"D:\trimbak\state analys\StateCensusData.csv";
                //call the readmethod and it return the number of record
                //expected array
                string[] expectedHeader = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
                //pass wrong length array
                string[] userHeader = { "State", "Population", "AreaInSqKm" };
                //throws the length not proper exception
                //if length is proper and name is proper then return header names
                //and check with expected output
                string[] header = read.numberOfHeader(path, userHeader);
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], header[i]);
                }
            }
            catch (stateCensusException e)
            {
                //if string and massage same then pass the test
                Assert.AreEqual("header length is not same", e.Message);
            }

        }
        /// <summary>
        /// check for number of record csvstate code
        /// </summary>
        [Test]
        public void TestForNumberOfRecordincsvStateCode()
        {
            //create a object of stateCensusAnalyser class 
            CsvState read = new CsvState();
            //give the  path of csv file
            string path = @"D:\trimbak\state analys\StateCode.csv";
            //call the readmethod and it return the number of record
            int record = read.ReadMethod(path, ',');
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
                //create a object of stateCensusAnalyser class 
                CsvState read = new CsvState();
                //give the  path of csv file
                string path = @"D:\trimbak\state analys\StateCode.csv";
                //call the readmethod and it return the number of record
                int record = read.ReadMethod(path, ',');
            }
            catch (stateCensusException e)
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
                //create a object of stateCensusAnalyser class 
                CsvState read = new CsvState();
                //chenge file type csv to txt and check
                string path = @"D:\trimbak\state analys\StateCode.txt";
                //call the readmethod and it return the number of record
                int record = read.ReadMethod(path, ',');
            }
            catch (stateCensusException e)
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
                //create a object of stateCensusAnalyser class 
                CsvState read = new CsvState();
                //chenge file type csv to txt and check
                string path = @"D:\trimbak\state analys\StateCode.csv";
                //call the readmethod and it return the number of record
                int record = read.ReadMethod(path, ';');
            }
            catch (stateCensusException e)
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
                //create a object of stateCensusAnalyser class 
                CsvState read = new CsvState();
                //chenge file type csv to txt and check
                string path = @"D:\trimbak\state analys\StateCode.csv";
                //call the numberofheder and it return the heder
                //expected output
                string[] expectedHeader = { "SrNo", "State", "Name", "TIN", "StateCode", "Column5" };
                //check for header name not proper
                string[] userHeader = { "SrNo", "State", "Name", "TIN", "StateCode", "Column" };
                string[] header = read.numberOfHeader(path, userHeader);
                //if header name is proper then lpass the test if header name not proper then throws exception header name is not proper and catch in catcj
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], header[i]);
                }
            }
            catch (stateCensusException e)
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
                //create a object of stateCensusAnalyser class 
                CsvState read = new CsvState();
                //chenge file type csv to txt and check
                string path = @"D:\trimbak\state analys\StateCode.csv";
                //call the readmethod and it return the number of record
                //expected array
                string[] expectedHeader = { "SrNo", "State", "Name", "TIN", "StateCode", "Column5" };
                //pass wrong length array
                string[] userHeader = { "SrNo", "State", "Name", "TIN", "StateCode" };
                //throws the length not proper exception
                //if length is proper and name is proper then return header names
                //and check with expected output
                string[] header = read.numberOfHeader(path, userHeader);
                for (int i = 0; i < header.Length; i++)
                {
                    Assert.AreEqual(expectedHeader[i], header[i]);
                }
            }
            catch (stateCensusException e)
            {
                //if string and massage same then pass the test
                Assert.AreEqual("header length is not same", e.Message);
            }

        }
    }
}