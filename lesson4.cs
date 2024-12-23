﻿using System;
using System.Collections.Generic;

namespace Homework_Project
{
    public class Lesson4
    {

        //Q1
        public static void SortTwoByComparison<T>(ref T a, ref T b, Comparison<T> comparison)
        {
            if (comparison(a, b) > 0)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        }

        public static void SortTwoByIComparable<T>(ref T a, ref T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        }



        //Q2

        public class GenericOperationTable<T>
        {
            public delegate T Operation(T a, T b);

            Operation op;
            List<T> row_values;
            List<T> col_values;
            public T[,] results = null;

            public GenericOperationTable(List<T> _row_values, List<T> _col_values, Operation _op)
            {
                op = _op;
                row_values = _row_values;
                col_values = _col_values;
                results = new T[_row_values.Count, _col_values.Count];
            }
            public void Calculate()
            {
                for (int row = 0; row < results.GetLength(0); row++)
                {
                    for (int col = 0; col < results.GetLength(1); col++)
                    {
                        results[row, col] = op(row_values[row], col_values[col]);
                    }
                }
            }

            public override string ToString()
            {
                int maxWidth = 0;
                for (int row = 0; row < results.GetLength(0); row++)
                {
                    for (int col = 0; col < results.GetLength(1); col++)
                    {
                        T t = results[row, col];
                        int width;
                        if (t == null)
                        {
                            width = 0;
                        }
                        else
                        {
                            string s = t.ToString();
                            width = s.Length;
                        }

                        maxWidth = Math.Max(maxWidth, width);
                    }
                }

                maxWidth += 2; // להוסיף 2 תווים לרווח נוסף
                string res = "";

                for (int row = 0; row < results.GetLength(0); row++)
                {
                    for (int col = 0; col < results.GetLength(1); col++)
                    {
                        res += results[row, col].ToString().PadLeft(maxWidth, ' ');
                        if (col < results.GetLength(1) - 1)
                        {
                            res += ",";
                        }
                    }
                    res += "\n";
                }
                return res;
            }
        }
    }
}
