namespace Bloom_filter
{
    public class PolynomialHash
    {

        public const int t = 50;

        public static ushort GetHash(string input, ushort k)
        {
            string str = input;
            if (input.Length % 2 != 0)
            {
                str += (char)0;
            }

            ushort temp = 1;

            for (int i = 0; i < Math.Min(t, str.Length / 2); i += 2)
            {
                ushort element = (ushort)((byte)str[i] + ((byte)str[i + 1] << 8));

                ushort next = (ushort)(temp * k + element);

                temp = next;
            }
            return temp;
        }

    }
}
