﻿using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace stateCensusAnaliser
{
    public class CsvState
    {
        /// <summary>
        /// load the file and find number of record 
        /// check for delimeter and handle delimeter exception
        /// </summary>
        /// <param name="path">path of file</param>
        /// <returns></returns>
        public int ReadMethod(string path, char userdelimeter)
        {
            try
            {

                //get file information from path
                FileInfo e = new FileInfo(path);
                Console.WriteLine(e);
                //find the type of file
                string fileType = e.Extension;
                Console.WriteLine(fileType);
                string expectedType = ".csv";
                //if filetype not same .csv then throws exception
                if (fileType != expectedType)
                {
                    throw new stateCensusException(stateCensusException.ExceptionType.WRONG_FILE, "enter proper file");
                }

                int numberOfRecord = 0;
                //using stream reader read the data from csv file
                using StreamReader read = new StreamReader(path);
                //and load the data on csvreader by using CsvReader
                using CsvReader csvreader = new CsvReader(read, true);
                //iterate number of record present in the csv file
                //ReadNextRecord() it can return true if next record present if it return false then next record not present and break the loop
                while (csvreader.ReadNextRecord())
                {
                    //numberOfRecord count how many recorrd present in csv file
                    numberOfRecord++;
                }
                //return delimeter of csv file
                char csvDelimeter = csvreader.Delimiter;

                //if userdelimeter and csv delimeter not same then throw exception
                if (!csvDelimeter.Equals(userdelimeter))
                {
                    throw new stateCensusException(stateCensusException.ExceptionType.WRONG_DELIMETER, "wrong delimeter, please enter proper delimeter");
                }
                //return total number of record
                return numberOfRecord;
            }
            catch (FileNotFoundException e)
            {
                throw new stateCensusException(stateCensusException.ExceptionType.FILE_NOT_FOUND, "file is not present on this location");
            }
            catch (stateCensusException e)
            {
                throw new stateCensusException(stateCensusException.ExceptionType.WRONG_FILE, e.Message);
            }
        }
        /// <summary>
        /// geting number of heders and handle header related exception
        /// </summary>
        /// <param name="path">path of csv file</param>
        /// <param name="userHeader">send by user heder file name</param>
        /// <returns> csv file heder name</returns>
        public string[] numberOfHeader(string path, string[] userHeader)
        {
            try
            {
                //using stream reader read the data from csv file
                using StreamReader read = new StreamReader(path);
                //and load the data on csvreader by using CsvReader
                using CsvReader csvreader = new CsvReader(read, true);
                //get the csv file headers
                string[] headers = csvreader.GetFieldHeaders();
                //if length not same then throw HEADER_LENGTH_NOT_SAME exception
                if (userHeader.Length != headers.Length)
                {
                    throw new stateCensusException(stateCensusException.ExceptionType.HEADER_LENGTH_NOT_SAME, "header length is not same");
                }
                //check for header string is same with user string then run normal if not same then throw exception
                for (int i = 0; i < headers.Length; i++)
                {
                     if (!userHeader[i].Equals(headers[i]))
                     {
                         throw new stateCensusException(stateCensusException.ExceptionType.HEADER_NAME_NOT_SAME, "header name is not same");
                     }
                }
                return headers;
            }
            catch (stateCensusException e)
            {
                throw new stateCensusException(stateCensusException.ExceptionType.HEADER_NAME_NOT_SAME, e.Message);
            }

        }
    }
}

