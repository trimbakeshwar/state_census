using System;
using System.Collections.Generic;
using System.Text;

namespace stateScensus
{
    public class sorting
    {
      
        public dynamic SortTheList(dynamic record, int columnNumber, int fieldCount, int stringIsCharOrInt)
        {
            //number of record present in record
            int count = record.Count;
            if (stringIsCharOrInt == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    dynamic recordOne = record[i];
                    string valueOne = recordOne[columnNumber];
                    for (int j = 0; j < count; j++)
                    {
                        dynamic recordTwo = record[j];
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
                    dynamic recordOne = record[i];
                    string valueOne = recordOne[columnNumber];
                    double x = double.Parse(valueOne);
                    for (int j = 1; j < count; j++)
                    {
                        dynamic recordTwo = record[j];
                        string valueTwo = recordTwo[columnNumber];
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
