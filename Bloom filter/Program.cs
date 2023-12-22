using System.Numerics;
using System.Runtime.Intrinsics;

namespace Bloom_filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<(double alpha, int s, double iterations)> array = new List<(double, int, double)>();
            int numOfIterations = 100;
            for (double alpha = 0.05; alpha <= 0.5; alpha += 0.05)
            {
                double coef = (1 / alpha) * Math.Log(2);
                int s = (int)Math.Floor(coef);
                int[] arrayS = [1, 5, 10,  20, s];
                
                foreach (int a in arrayS) {
                    var filter = new BloomFilter(a);
                    double averageIterations = 0;
                    for (int i = 0; i < numOfIterations; i++)
                    {
                        for (int j = 0; j < alpha * BloomFilter.N; j++)
                        {
                            string str = Generator.GenerateRandomString(100);
                            filter.Add(str);
                        }

                        bool b = false;
                        int itr = 0;
                        while (!b)
                        {
                            string str = Generator.GenerateRandomString(100);
                            b = filter.Check(str);
                            itr++;
                        }
                        Console.WriteLine($"alpha = {alpha}, s = {a} itr = {itr}");
                        averageIterations += (double)itr;
                        filter.Clear();
                    }
                    array.Add((alpha, a, averageIterations));
                    Console.WriteLine($"for alpha = {String.Format("{0:0.00}", alpha) } s = {a},p_err = 1 / {averageIterations / numOfIterations} = {numOfIterations / averageIterations}");
                } 
                
               
            }
            foreach(var vector in array)
            {
                Console.WriteLine($"for alpha = {String.Format("{0:0.00}", vector.alpha)} and s = {vector.s} p_err = 1 / {vector.iterations / numOfIterations} = {numOfIterations / vector.iterations}");
            }

            string[] stra = new string[5];

            for(int i = 0; i < array.Count - 5 ; i += 5)
            { 
                for(int j = 0; j < 5; j++)
                {
                    stra[j] += $"& {String.Format("{0:0.000}", (numOfIterations/ array[i + j].iterations))} "; 
                }
            }
            foreach(var s in stra)
            {
                Console.WriteLine(s);
            }


        }
    }
}
