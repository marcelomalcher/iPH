using System;
using System.IO;
using CF.MSR.LST;
using CompactFormatter;

namespace iP4H.Commons.Communications
{
    public class Utility
    {
        public Utility()
        {
        }

        // Convert an object to a buffer chunk
        public static BufferChunk ToBufferChunk(Object o)
        {

            MemoryStream memoryStream = new MemoryStream();
            CompactFormatter.CompactFormatter compactFormatter = new CompactFormatter.CompactFormatter(CFormatterMode.SAFE);
            compactFormatter.Serialize(memoryStream, o);

            byte[] byteArray = new byte[memoryStream.Length];
            memoryStream.Position = 0;
            memoryStream.Read(byteArray, 0, (int)memoryStream.Length);

            return new BufferChunk(byteArray);

        }

        public static void PackShort(BufferChunk bc, int index, ushort val)
        {
            PackShort(bc.Buffer, index, val);
        }

        public static void PackShort(byte[] ba, int index, ushort val)
        {
            ba[index] = (byte)(val % 256);
            ba[index + 1] = (byte)(val / 256);
        }


        // Pack an int, low order bytes first
        public static void PackInt(BufferChunk bc, int index, uint val)
        {
            PackInt(bc.Buffer, index, val);
        }

        public static void PackInt(byte[] ba, int index, uint val)
        {
            ba[index] = (byte)val;
            ba[index + 1] = (byte)(val >> 8);
            ba[index + 2] = (byte)(val >> 16);
            ba[index + 3] = (byte)(val >> 24);
        }

        // Unpack a short from a buffer chunk
        public static ushort UnpackShort(BufferChunk bc, int index)
        {
            return (ushort)(256 * bc.Buffer[index + 1] + bc.Buffer[index]);
        }

        public static int UnpackSignedInt(BufferChunk bc, int index)
        {
            uint val = UnpackInt(bc, index);
            int rVal;
            if (val > int.MaxValue)
                rVal = -(int)(~val) - 1;
            else
                rVal = (int)val;

            return rVal;
        }

        // Unpack an int from a buffer chunk
        public static uint UnpackInt(BufferChunk bc, int index)
        {
            uint v0 = bc.Buffer[index];
            uint v1 = bc.Buffer[index + 1];
            uint v2 = bc.Buffer[index + 2];
            uint v3 = bc.Buffer[index + 3];
            uint rVal = (v3 << 24) + (v2 << 16) + (v1 << 8) + v0;
            return rVal;
        }

    }
}
