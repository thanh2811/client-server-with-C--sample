using System;
using System.Collections.Generic;

namespace test
{
    internal class DongBoNTP
    {
        static void Main(string[] args)
        {
            byte[] ntpMessage =
            {
                00,00,00,00,00,00,00,00,
                00,00,00,00,00,00,00,00,
                225,72,40,195,105,242,38,249,
                00,00,00,00,00,00,00,00,
                225,72,40,208,41,242,12,33,
                225,72,40,208,41,242,52,101 };

            byte Pos = 16;
            DateTime T1 = DateTimeParser(ntpMessage, Pos).ToLocalTime();
            Pos = 32;
            DateTime T2 = DateTimeParser(ntpMessage,Pos).ToLocalTime();
            Pos = 40;
            DateTime T3 = DateTimeParser(ntpMessage, Pos).ToLocalTime();
            DateTime T4 = new DateTime(2019, 10, 9, 16, 37, 29, 229);

            long theta = (long)Math.Round(((T2.Ticks - T1.Ticks) + (T3.Ticks - T4.Ticks)) / 2.0, 0, MidpointRounding.AwayFromZero);

            T4 = T4.AddTicks(theta);
            string formatDateTime = "dd/MM/yyyy HH:mm:ss.fff";
            Console.WriteLine("T1: " + T1.ToString(formatDateTime));
            Console.WriteLine("T2: " + T2.ToString(formatDateTime));
            Console.WriteLine("T3: " + T3.ToString(formatDateTime));
            Console.WriteLine("T4: " + T4.ToString(formatDateTime));
        }

        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +        // 6 số 0
                ((x & 0x0000ff00) << 8) + ((x & 0x00ff0000) >> 8) + ((x & 0xff000000) >> 24));

        }

        private static DateTime DateTimeParser(byte[] ntpMessage, byte pos)
        {
            DateTime res = new DateTime(1900,1,1,0,0,0,DateTimeKind.Utc);
            try
            {
                ulong intPart = BitConverter.ToUInt32(ntpMessage, pos);
                ulong fractPart = BitConverter.ToUInt32(ntpMessage, pos + 4);

                intPart = SwapEndianness(intPart);
                fractPart = SwapEndianness(fractPart);

                ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

                res = res.AddMilliseconds((long)milliseconds);
            } catch(Exception e)
            {
                throw;
            }
            return res;
        }
    }
}
