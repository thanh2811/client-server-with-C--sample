using System;
using System.Collections.Generic;

namespace DongBoTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[13]
         {
            "2021-06-30 01:03:53.520",
            "2021-06-30 01:02:50.750",
            "2021-06-30 01:05:53.540",
            "2021-06-30 01:01:50.770",
            "2021-06-30 01:03:53.550",
            "2021-06-30 01:02:50.720",
            "2021-06-30 01:04:53.500",
            "2021-06-30 01:01:50.710",
            "2021-06-30 01:03:53.580",
            "2021-06-30 01:02:50.690",
            "2021-06-30 01:03:53.490",
            "2021-06-30 01:01:50.680",
            "2021-06-30 01:03:53.610",
         };

            string strIn = input[0].Trim().Split(' ')[0];

            int[] output = new int[13];

            int n = 13;

            int[] arr = new int[n];

            //Đổi sang ms
            for (int i = 0; i < n; i++)
            {
                //Lấy ra chuỗi chứa giờ phút giây
                string str = input[i].Trim().Split(' ')[1];

                arr[i] = Int32.Parse(str.Substring(0, 2)) * 60 * 60 * 1000 //Đổi giờ sang ms
                    + Int32.Parse(str.Substring(3, 2)) * 60 * 1000         //Đổi phút sang ms
                    + Int32.Parse(str.Substring(6, 2)) * 1000              //Đổi giây sang ms
                    + Int32.Parse(str.Substring(9, 3));
            }

            List<int> newArr = new List<int>();

            for (int i = 0; i < n; i++)
            {
                newArr.Clear();
                //Copy các phần từ trừ chính nó
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        newArr.Add(arr[j]);
                    }
                }

                newArr.Sort();

                //Xoá phần tử nhỏ nhất và lớn nhất
                newArr.RemoveAt(0);
                newArr.RemoveAt(newArr.Count - 1);

                double tong = 0;
                int tb = 0;

                for (int k = 0; k < newArr.Count; k++)
                {
                    tong += newArr[k];
                }

                tb = (int)Math.Round(tong / newArr.Count, 0);

                output[i] = tb;
            }

            //Log ra ket qua
            for (int i = 0; i < n; i++)
            {
                int gio = output[i] / (60 * 60 * 1000);
                int phut = output[i] % (60 * 60 * 1000) / (60 * 1000);
                int giay = (output[i] % (60 * 1000)) / 1000;
                int ms = output[i] % 1000;
                Console.WriteLine(strIn + " " + (gio < 10 ? ("0" + gio.ToString()) : gio.ToString()) + ":" +
                    (phut < 10 ? ("0" + phut.ToString()) : phut.ToString()) + ":" +
                    (giay < 10 ? ("0" + giay.ToString()) : giay.ToString()) + "." + ms.ToString()
                );
            }
        }
    }
    }

