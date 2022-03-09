using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriparaSE
{
    internal class GetByteValue
    {
        byte[] byte1 = new byte[1];
        byte[] byte2 = new byte[2];
        byte[] byte4 = new byte[4];
        int[] intArray;
        int[,] intArrayMatrix;
        public int ExtractByteToInt(Stream str, int initialOffset, int count) 
        {
            switch (count)
            {
                case 1:
                    str.Seek(initialOffset, SeekOrigin.Begin);
                    str.Read(byte1, 0, 1);
                    return Convert.ToInt32(BitConverter.ToString(byte1, 0),16);
                case 2:
                    str.Seek(initialOffset, SeekOrigin.Begin);
                    str.Read(byte2, 0, 2);
                    return BitConverter.ToUInt16(byte2, 0);
                case 4:
                    str.Seek(initialOffset, SeekOrigin.Begin);
                    str.Read(byte4, 0, 4);
                    return BitConverter.ToInt32(byte4, 0);
                default:
                    return 00;
            }
        }

        public string ExtractByteToString(Stream str, int initialOffset, int count)
        {
            byte[] byteString = new byte[count];
            str.Seek(initialOffset, SeekOrigin.Begin);
            str.Read(byteString, 0, count);
            return Encoding.UTF8.GetString(byteString);
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
        public int[] ExtractBytetoIntArray(Stream str, int initialOffset, int count, int arrayLenght)
        {
            switch (count)
            {
                case 1:
                    intArray = new int[arrayLenght];
                    for (int i = 0; i < arrayLenght; i++)
                    {
                        str.Seek(initialOffset, SeekOrigin.Begin);
                        str.Read(byte1, 0, 1);
                        intArray[i] = Convert.ToInt32(BitConverter.ToString(byte1, 0), 16);
                        initialOffset = initialOffset + 1;
                    }
                    return intArray;
                case 2:
                    intArray = new int[arrayLenght];
                    for (int i = 0; i < arrayLenght; i++)
                    {
                        str.Seek(initialOffset, SeekOrigin.Begin);
                        str.Read(byte2, 0, 2);
                        intArray[i] = BitConverter.ToUInt16(byte2, 0);
                        initialOffset = initialOffset + 2;
                    }
                    return intArray;
                case 4:
                    intArray = new int[arrayLenght];
                    for (int i = 0; i < arrayLenght; i++)
                    {
                        str.Seek(initialOffset, SeekOrigin.Begin);
                        str.Read(byte4, 0, 4);
                        intArray[i] = BitConverter.ToInt32(byte4, 0);
                        initialOffset = initialOffset + 4;
                    }
                    return intArray;
                default:
                    return intArray = new int[arrayLenght];
            }
        }
    }
}
