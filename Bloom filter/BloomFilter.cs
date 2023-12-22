namespace Bloom_filter
{
    internal class BloomFilter
    {
        public const int N = ushort.MaxValue;

        private List<ushort> randomInts;

        public ulong[] bitArray;


        public BloomFilter(int s)
        {
            bitArray = new ulong[(N >> 6) + 1];
            var rand = new Random();
            randomInts = new List<ushort>();

            while(randomInts.Count != s)
            {
                var generatedNumber = rand.Next(ushort.MaxValue);

                if (randomInts.Contains((ushort)generatedNumber))
                {
                    continue;
                }
                randomInts.Add((ushort)generatedNumber);
            }
        }

        public bool GetElement(ushort pos)
        {
            int count = pos/64;
            int shift = pos % 64;

            
            ulong result = bitArray[count] >> shift;

            return (result & 1) == 1;
        }
        public void SetElement(ushort pos)
        {
            int count = pos/64;
            int shift = pos % 64;

            bitArray[count] |= (ulong)1 << shift;
        }
        public void Add(string s)
        {
            foreach(var k in randomInts)
            {
                ushort pos = PolynomialHash.GetHash(s, k);
                SetElement(pos);
            }
        }
        public bool Check(string s)
        {
            foreach(var k in randomInts)
            {
                ushort pos = PolynomialHash.GetHash(s, k);
                if (!GetElement(pos))
                {
                    return false;
                }
            }
            return true;
        }

        public void Clear()
        {
            bitArray = new ulong[(N >> 6) + 1];
        }
    }
}
