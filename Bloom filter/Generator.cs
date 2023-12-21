namespace Bloom_filter
{
    public class Generator
    {

        public static string GenerateRandomString(int maxLength)
        {
            Random random = new Random();
            var rand = random.Next(maxLength);
            var result = "";

            for (int i = 0; i < rand; i++)
            {
                result += (char)random.Next(byte.MaxValue);
            }
            return result;
        }
    }
}
