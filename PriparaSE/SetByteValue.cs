using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriparaSE
{
    internal class SetByteValue
    {
        byte[] byte1 = new byte[1];
        byte[] byte2 = new byte[2];
        byte[] byte4 = new byte[4];
        public MemoryStream InjectByteFromInt(MemoryStream str, int value, int initialOffset, int count)
        {
            switch (count)
            {
                case 1:
                    byte1 = BitConverter.GetBytes(value);
                    //Array.Reverse(byte1);
                    str.Seek(initialOffset, SeekOrigin.Begin);
                    str.Write(byte1, 0, 1);
                    return str;
                case 2:
                    byte2 = BitConverter.GetBytes(value);
                    //Array.Reverse(byte2);
                    str.Seek(initialOffset, SeekOrigin.Begin);
                    str.Write(byte2, 0, 2);
                    return str;
                case 4:
                    byte4 = BitConverter.GetBytes(value);
                    //Array.Reverse(byte2);
                    str.Seek(initialOffset, SeekOrigin.Begin);
                    str.Write(byte4, 0, 4);
                    return str;
                default:
                    return str;
            }
        }

        public MemoryStream InjectByteFromString(MemoryStream str, string value, int initialOffset, int count)
        {
            byte[] byteString = new byte[count];
            byteString = Encoding.UTF8.GetBytes(value);
            //Array.Reverse(byte1);
            str.Seek(initialOffset, SeekOrigin.Begin);
            str.Write(byteString, 0, count);
            return str;
        }

        public byte[] ExtractByteArray(Stream str, int initialOffset, int count)
        {
            switch (count)
            {
                case 1:
                    str.Seek(initialOffset, SeekOrigin.Begin);
                    str.Read(byte1, 0, 1);
                    return byte1;
                case 2:
                    str.Seek(initialOffset, SeekOrigin.Begin);
                    str.Read(byte2, 0, 2);
                    return byte2;
                case 4:
                    str.Seek(initialOffset, SeekOrigin.Begin);
                    str.Read(byte4, 0, 4);
                    return byte4;
                default:
                    return new byte[0x00];
            }
        }
    }
}
