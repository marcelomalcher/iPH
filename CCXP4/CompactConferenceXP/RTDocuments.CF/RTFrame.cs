using System;
using System.IO;

/// $CompactConferenceXP:
/// Removed System.Runtime.Serialization.Formatters.Binary
/// Compact Framework does not support native serialization and binary formatter
/// Commented
//using System.Runtime.Serialization.Formatters.Binary;

/// $CompactConferenceXP:
/// Added reference to CompactFormatter.Attributes for Serializable attribute
using CompactFormatter.Attributes;


namespace CF.MSR.LST.RTDocuments
{
    /// <summary>
    /// Extensibility mechanism for RTObjects
    /// </summary>
    [CompactFormatter.Attributes.Serializable]
    public class RTFrame
    {
        public Guid ObjectTypeIdentifier;

        private byte[] serializedObject = null;

        public object Object
        {
            get
            {
                lock (this)
                {
                    /// $CompactConferenceXP:
                    /// There is no BinaryFormatter in Compact Framework
                    /// Changed by CompactFormatter
                    /// > BinaryFormatter bf = new BinaryFormatter();
                    CompactFormatter.CompactFormatter bf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                    MemoryStream ms = new MemoryStream(serializedObject);
                    return bf.Deserialize(ms);
                }
            }
        }

        public RTFrame(Guid objectTypeIdentifier, object o)
        {
            lock (this)
            {
                ObjectTypeIdentifier = objectTypeIdentifier;

                // the object o could be null if it's a datalist 
                // message with a guid, but no byte array
                if (o != null)
                {
                    MemoryStream ms = new MemoryStream();
                    /// $CompactConferenceXP:
                    /// There is no BinaryFormatter in Compact Framework
                    /// Changed by CompactFormatter
                    /// > BinaryFormatter bf = new BinaryFormatter();
                    CompactFormatter.CompactFormatter bf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);

                    bf.Serialize(ms, o);

                    // Get a byte[] of the serialized object
                    int numBytes = (int)ms.Position; // record the number of "useful bytes"
                    serializedObject = new Byte[numBytes];
                    ms.Position = 0; // set the pointer back to 0, so we can read from that point
                    ms.Read(serializedObject, 0, numBytes); // read all the useful bytes
                }
            }
        }

        public override string ToString()
        {
            return "RTFrame " +
                "{ ObjectTypeIdentifier: " + ObjectTypeIdentifier.ToString() +
                " }";
        }

    }
}
