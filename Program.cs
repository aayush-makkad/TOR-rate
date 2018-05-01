using System;
using MathNet.Numerics.Statistics;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace rate
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] first = new int[1000];
            //int[] second = new int[1000];
            var values1 = new List<double>();
            var values2 = new List<double>();
            double xi = 0;
            double y = 0;
            Program p = new Program();
            Console.WriteLine("i=80000");


            var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            var buff = new byte[2];

            int[] randomvalue = new int[] {10,7,9,9,5,66,20,13,4 };
            double ctrx =0, ctry = 0;
            int ctr = 0;
            double a = 1;
            Console.WriteLine(randomvalue);
            for (int i = 0; i < randomvalue.Length; i++)
            {
                rng.GetBytes(buff);
               
                //randomvalue = BitConverter.ToInt16(buff, 0);
                //randomvalue = randomvalue % 250;
                ////randomvalue = randomvalue + 700;
                //randomvalue = Math.Abs(randomvalue);
                values1.Add(randomvalue[i]);
                ctrx = ctrx + randomvalue[i];
                xi = randomvalue[i] %12;

                y = Math.Abs(Math.Ceiling(Math.Sin(randomvalue[i]) * p.fib(xi)));
                //if ((y / randomvalue) * 100 > 60)
                //{
                //    y = Math.Ceiling(y + randomvalue * 0.7);
                //}

                //a = Math.Abs((9 * Math.Sin(Math.Pow(y, 2) + 9)));
                //a = Math.Ceiling(a % 10);

                if (y > randomvalue[i])
                {
                    ctr++;
                    y = y % randomvalue[i];
                }
                Console.WriteLine("x : {0} and y : {1} fibonacci : {2}",randomvalue[i],y,p.fib(xi));
                values2.Add(y);
                ctry = ctry + y;
            }
            double d = values2.Maximum();
            Console.WriteLine("Maximum number of packets sent by the hop to server : {0}", d);
            Console.WriteLine(" total number of overflow : {0}", ctr);
            Console.WriteLine("total X : {0}", ctrx);
            Console.WriteLine("total y : {0}", ctry);
            double correlation = Correlation.Pearson(values1, values2);
            Console.WriteLine("Corrrelation coeffeccient : {0}",correlation);
            Console.WriteLine("Percentage of Y over X : {0}",ctry / ctrx * 100);
            Console.Read();
        }

        // Fibonacci Series using Space Optimized Method

        double fib(double n)
        {
            double a = 0, b = 1, c, i;
            if (n == 0)
                return a;
            for (i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return b;
        }
    }
    }
