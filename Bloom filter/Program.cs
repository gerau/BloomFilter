namespace Bloom_filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i =0; i< 10; i++)
            {
                Console.WriteLine(Generator.GenerateRandomString(100));
            }
        }
    }
}
