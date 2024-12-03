using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Project
{
    internal class lesson2
    {
        public struct PointStruct
        {
            public int X;
            public int Y;

            public PointStruct(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        //Q1
        static void MeasureStructMemory()
        {
            Console.WriteLine("-------q1--------");
            long before = GC.GetAllocatedBytesForCurrentThread();
            PointStruct pointStruct = new PointStruct(5, 10);
            long after = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"MeasureStructMemory: Allocated Memory={after - before} bytes");
        }


        //Q2

        static void MeasureStringMemory()
        {
            Console.WriteLine("-------q2--------");
            long before = GC.GetAllocatedBytesForCurrentThread();
            string s = new string("hello world");
            long after = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"MeasureStringMemory: Allocated Memory={after - before} bytes");
        }


        //Q3

        static void CreateStringUsingStringBuilder()
        {
            Console.WriteLine("-------q3--------");

            long before = GC.GetAllocatedBytesForCurrentThread();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.Append(i + " ");
            }

            long after = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"Allocated Memory with StringBuilder: {after} - {before} = {after - before} bytes");
        }

        static void CreateStringUsingString()
        {
            long before = GC.GetAllocatedBytesForCurrentThread();

            string result = "";
            for (int i = 1; i <= 100; i++)
            {
                result += i + " ";
            }

            long after = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"Allocated Memory with String: {after} - {before} = {after - before} bytes");
        }



        //Q4


        static void GCGenerationsExperiment()
        {
            Console.WriteLine("-------q4--------");

            var gen0Object = new object();
            Console.WriteLine($"Generation of gen0Object before GC: {GC.GetGeneration(gen0Object)}");
            GC.Collect(0);
            Console.WriteLine("Garbage Collection for Gen 0 performed.");
            Console.WriteLine($"Generation of gen0Object after Gen 0 GC: {GC.GetGeneration(gen0Object)}");
        }



         public static void RunLesson2()
        {
            MeasureStructMemory();

            MeasureStringMemory();

            CreateStringUsingStringBuilder();

            CreateStringUsingString();

            GCGenerationsExperiment();

        }
    }
}
