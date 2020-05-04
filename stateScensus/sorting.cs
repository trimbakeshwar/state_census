using System;
using System.Collections.Generic;
using System.Text;

namespace stateScensus
{
    /// <summary>
    /// sorting the list
    /// </summary>
    public class sorting
    {
      /// <summary>
      /// sort the list 
      /// </summary>
      /// <param name="record">data of csv file in dictonary form</param>
      /// <param name="columnNumber">sorting column</param>
      /// <param name="fieldCount">number of coulmn</param>
      /// <param name="stringIsCharOrInt">if string then send 0 column then send 1</param>
      /// <returns></returns>
        public dynamic SortTheList(dynamic record, int columnNumber, int fieldCount, int stringIsCharOrInt)
        {
            //number of record present in record
            int count = record.Count;
            //stringIsCharOrInt == 0 then if condition run 
            if (stringIsCharOrInt == 0)
            {
                //comper one record with all record then increment record and compare
                for (int i = 0; i < count; i++)
                {
                    //one record get on record one
                    dynamic recordOne = record[i];
                    //value fo this record in column number add on value one
                    string valueOne = recordOne[columnNumber];
                    for (int j = 0; j < count; j++)
                    {
                        //next record get on record two
                        dynamic recordTwo = record[j];
                        //value fo this record in column number add on value Two
                        string valueTwo = recordTwo[columnNumber];
                        //compare which one is greter and swap 
                        if (valueOne.CompareTo(valueTwo) < 0)
                        {

                            dynamic temp = record[i];
                            record[i] = record[j];
                            record[j] = temp;
                        }
                    }
                }
            }

            else
            {
                for (int i = 1; i < count; i++)
                {
                    //one record get on record one
                    dynamic recordOne = record[i];
                    //value fo this record in column number add on value one
                    string valueOne = recordOne[columnNumber];
                    //if this string is numeric then convert in double
                    double x = double.Parse(valueOne);
                    for (int j = 1; j < count; j++)
                    {
                        //next record get on record one
                        dynamic recordTwo = record[j];
                        //value fo this record in column number add on value Two
                        string valueTwo = recordTwo[columnNumber];
                        //if this string is numeric then convert in double
                        double y = double.Parse(valueTwo);
                        //compare which one is greter and swap 
                        if (x.CompareTo(y) < 0)
                        {

                            dynamic temp = record[i];
                            record[i] = record[j];
                            record[j] = temp;
                        }
                    }
                }

            }

            //display the sorted list
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < fieldCount; j++)
                {
                    Console.Write("-" + record[i][j]);
                }
                Console.WriteLine();
            }
            return record;
        }

    }
}
