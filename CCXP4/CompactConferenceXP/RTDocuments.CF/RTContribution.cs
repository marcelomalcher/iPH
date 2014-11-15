using System;
using System.Diagnostics;
using System.IO;

/// $CompactConferenceXP:
/// Removed System.Runtime.Serialization
/// Compact Framework does not support native serialization
/// Commented
//using System.Runtime.Serialization;

/// $CompactConferenceXP:
/// Removed System.Runtime.Serialization.Formatters.Binary
/// Compact Framework does not support native serialization and binary formatter
/// Commented
//using System.Runtime.Serialization.Formatters.Binary;

/// $CompactConferenceXP:
/// Added reference to CompactFormatter.Attributes for Serializable attribute
using CompactFormatter.Attributes;

/// $CompactConferenceXP:
/// Added reference to CompactFormatter.Intergaces for ICSerializable interface
using CompactFormatter.Interfaces;

// Removed Microsoft.Ink
// Microsoft.Ink is specific for .NET Framework and does not work at Compact version
//using Microsoft.Ink;

// Added reference to LAC.Contribution for ink collection
using LAC.Contribution;

// Added reference to LAC.Contribution.Object
using LAC.Contribution.Objects;

namespace CF.MSR.LST.RTDocuments
{
    /// <summary>
    /// Common ConferenceXP ink specification
    /// </summary>
    [CompactFormatter.Attributes.Serializable]
    /// $CompactConferenceXP:
    /// Changed ISerializable by ICSerializable
    /// > public class RTStroke : ISerializable
    public class RTContribution : ICSerializable
    {
        public readonly static Guid ExtendedPropertyStrokeIdentifier = new Guid("{179222D6-BCC1-4570-8D8F-7E8834C1DD2A}");

        private ContributionComponent man = null;
        private byte[] data = null;

        [NonSerialized()]
        private Guid contributionIdentifier = Guid.Empty;

        /// <summary>
        /// The ID of the document where this ink was created.  By default, it is set to Guid.Empty and the current document
        /// of the Capability channel is assumed.
        /// </summary>
        public Guid DocumentIdentifier = Guid.Empty;

        /// <summary>
        /// Page where this stroke resides.  This is set by default to the current page identifier as determined from RTObjectStatics
        /// <summary>
        public Guid PageIdentifier = Guid.Empty;

        /// <summary>
        /// This is an object you can stick additional information into to store your own extensions to this structure.
        /// 
        /// Note: Object was used rather than Hashtable to be consistent with the rest of the Extension tags contained in
        /// RTDocument.  The Object can always contain a name/value pair hashtable.
        /// <summary>
        public object Extension = null;

        /// <summary>
        /// The identifier of the stroke. Unique and persistent to each stroke.  This is automatically set upon construction.
        /// </summary>
        public Guid ContributionIdentifier
        {
            get
            {
                if (contributionIdentifier != Guid.Empty)
                {
                    return contributionIdentifier;
                }

                if (Contribution == null)
                {
                    return Guid.Empty;
                }
                else
                {
                    return this.Contribution.Guid;
                }                
            }
        }

        public ContributionBaseObject Contribution
        {
            get
            {
                if (man == null)
                {
                    if (data == null)
                    {
                        return null;
                    }

                    man = new ContributionComponent();
                    CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                    MemoryStream memStream = new MemoryStream(data);
                    man = (ContributionComponent)cf.Deserialize(memStream);
                    memStream.Close();
                }

                if (man.Contributions.Count == 0)
                {
                    return null;
                }

                Trace.Assert(man.Contributions.Count == 1);
                
                return man.Contributions[0];
            }
        }

        public Contributions Contributions
        {
            get
            {
                if (man == null)
                {
                    if (data == null)
                    {
                        return null;
                    }

                    man = new ContributionComponent();
                    CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                    MemoryStream memStream = new MemoryStream(data);
                    man = (ContributionComponent)cf.Deserialize(memStream);
                    memStream.Close();
                }

                if (man.Contributions.Count == 0)
                {
                    return null;
                }

                Trace.Assert(man.Contributions.Count == 1);

                return man.Contributions;
            }
        }

        #region Custom Serialization code

        /// $CompactConferenceXP:
        /// Changed to support CompactFormatter values
        /// > protected RTStroke(SerializationInfo info, StreamingContext context)
        ///   {
        ///     this.ReceiveObjectData(parent, stream);
        ///     ink = new Ink();
        ///     ink.Load((byte[])info.GetValue("Ink", typeof(byte[])));
        ///     DocumentIdentifier = new Guid(info.GetString("DocumentIdentifier"));
        ///     PageIdentifier = new Guid(info.GetString("PageIdentifier"));
        ///     Extension = info.GetValue("Extension", typeof(object));
        ///     }
        protected RTContribution(CompactFormatter.CompactFormatter parent, Stream stream)
        {
            this.ReceiveObjectData(parent, stream);
        }

        /// $CompactConferenceXP:
        /// There is no GetObjectData
        /// Commented all
        /*
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ink", InkData);
            info.AddValue("DocumentIdentifier", DocumentIdentifier.ToString());
            info.AddValue("PageIdentifier", PageIdentifier.ToString());
            info.AddValue("Extension", Extension);
        }
        */ 
        #endregion

        public RTContribution(Guid documentIdentifier, Guid pageIdentifier, ContributionBaseObject contribution, object extension)
        {
            DocumentIdentifier = documentIdentifier;
            PageIdentifier = pageIdentifier;
            Extension = extension;            

            // Strokes ourStroke = stroke.Ink.CreateStrokes(strokeIds);
            // Ink fromInk = stroke.Ink;
            // ink = fromInk.ExtractStrokes(ourStroke, ExtractFlags.CopyFromOriginal);                       

            this.contributionIdentifier = contribution.Guid;
            man = new ContributionComponent();
            man.Contributions.InsertContribution(contribution, false);
        }

        public RTContribution(Guid documentIdentifier, Guid pageIdentifier, Guid contributionIdentifier, byte[] data, object extension)
        {
            DocumentIdentifier = documentIdentifier;
            PageIdentifier = pageIdentifier;
            Extension = extension;
            this.contributionIdentifier = contributionIdentifier;
            this.data = data;
        }

        public byte[] Data
        {
            get
            {
                if (data == null)
                {
                    if (man == null)
                    {
                        return null;
                    }

                    CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                    MemoryStream memStream = new MemoryStream();
                    cf.Serialize(memStream, man);
                    data = memStream.ToArray();
                    memStream.Close();
                }
                return data;
            }
        }

        public override string ToString()
        {
            return "RTContribution " +
                "{ DocumentIdentifier: " + DocumentIdentifier.ToString() +
                ", PageIdentifier: " + PageIdentifier.ToString() +
                ", ContributionIdentifier: " + ContributionIdentifier.ToString() +
                ", Data Size: " + Data.Length +
                " }";
        }

        #region ICSerializable Members
        /// $CompactConferenceXP:
        /// Implements interface ICSerializable
        /// Deserializing object
        public virtual void ReceiveObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
        {
            man = (ContributionComponent)parent.Deserialize(stream);
            DocumentIdentifier = new Guid((String)parent.Deserialize(stream));
            PageIdentifier = new Guid((String)parent.Deserialize(stream));
            Extension = (object)parent.Deserialize(stream);
        }

        /// $CompactConferenceXP:
        /// Implements interface ICSerializable
        /// Serializing object
        public virtual void SendObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
        {
            parent.Serialize(stream, man);
            parent.Serialize(stream, DocumentIdentifier.ToString());
            parent.Serialize(stream, PageIdentifier.ToString());
            parent.Serialize(stream, Extension);
        }

        #endregion
    }

    [CompactFormatter.Attributes.Serializable]
    public class RTContributionAdd : RTContribution, ICSerializable
    {
        /// <summary>
        /// This is the time the stroke was created. You only need to set this field if you resend strokes (rather than only sending newly created strokes).
        /// </summary>
        public DateTime CreationTime;

        #region Custom Serialization code
        /// $CompactConferenceXP:
        /// Changed to support CompactFormatter values
        /// > protected RTStrokeAdd(SerializationInfo info, StreamingContext context)
        ///   : base(info, context)
        ///   {
        ///     CreationTime = info.GetDateTime("CreationTime");
        ///   }
        protected RTContributionAdd(CompactFormatter.CompactFormatter parent, Stream stream)
            : base(parent, stream)
        {
            this.ReceiveObjectData(parent, stream);            
        }

        /// $CompactConferenceXP:
        /// There is no GetObjectData
        /// Commented all
        /*
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CreationTime", CreationTime);
            base.GetObjectData(info, context);
        }
        */ 
        #endregion

        public RTContributionAdd(DateTime creationTime, Guid documentIdentifier, Guid pageIdentifier, ContributionBaseObject contribution, object extension)
            : base(documentIdentifier, pageIdentifier, contribution, extension)
        {
            CreationTime = creationTime;
        }

        /// <remarks>
        /// Remarkable Texts Constructor
        /// </remarks>
        public RTContributionAdd(DateTime creationTime, Guid documentIdentifier, Guid pageIdentifier, Guid contributionIdentifier, byte[] data, object extension)
            : base(documentIdentifier, pageIdentifier, contributionIdentifier, data, extension)
        {
            CreationTime = creationTime;
        }

        public override string ToString()
        {
            return "RTContributionAdd " +
                "{ DocumentIdentifier: " + DocumentIdentifier.ToString() +
                ", PageIdentifier: " + PageIdentifier.ToString() +
                ", ContributionIdentifier: " + ContributionIdentifier.ToString() +
                ", Data Size: " + Data.Length +
                " }";
        }

        #region ICSerializable Members

        /// $CompactConferenceXP:
        /// Implements interface ICSerializable
        /// Deserializing object
        public override void ReceiveObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
        {
            base.ReceiveObjectData(parent, stream);
            CreationTime = (DateTime)parent.Deserialize(stream);
        }

        /// $CompactConferenceXP:
        /// Implements interface ICSerializable
        /// Serializing object
        public override void SendObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
        {
            base.SendObjectData(parent, stream);
            parent.Serialize(stream, CreationTime);
        }

        #endregion
    }

    /// <summary>
    /// </summary>
    /// <remarks>
    /// There can be multiple removals for a single stroke, if it is deleted simultaneously by different people.
    /// </remarks>
    [CompactFormatter.Attributes.Serializable]
    public class RTContributionRemove
    {
        public int SequenceNumber;
        public DateTime DeletionTime;
        /// <summary>
        /// </summary>
        /// <remarks>
        /// This is the StrokeIdentifier of the original RTStrokeAdd, not a new identifier generated for this removal.
        /// </remarks>
        public Guid ContributionIdentifier;
        public object Extension = null;

        /// <summary>
        /// The ID of the document where this ink was created.  By default, it is set to Guid.Empty and the current document
        /// of the Capability channel is assumed.
        /// </summary>
        public Guid DocumentIdentifier = Guid.Empty;
        /// <summary>
        /// Page where this stroke resides.  This is set by default to the current page identifier as determined from RTObjectStatics
        /// <summary>
        public Guid PageIdentifier = Guid.Empty;

        /// <remarks>
        /// If an app stores the RTStroke, it can remove it easily using this ctor
        /// </remarks>
        public RTContributionRemove(DateTime deletionTime, RTContribution rtContribution, object extension)
        {
            DeletionTime = deletionTime;
            DocumentIdentifier = rtContribution.DocumentIdentifier;
            PageIdentifier = rtContribution.PageIdentifier;
            ContributionIdentifier = rtContribution.ContributionIdentifier;
            Extension = extension;
        }

        public RTContributionRemove(DateTime deletionTime, Guid documentIdentifier, Guid pageIdentifier, Guid contributionIdentifier, object extension)
        {
            DeletionTime = deletionTime;
            DocumentIdentifier = documentIdentifier;
            PageIdentifier = pageIdentifier;
            ContributionIdentifier = contributionIdentifier;
            Extension = extension;
        }

        public RTContributionRemove(DateTime deletionTime, Guid documentIdentifier, Guid pageIdentifier, ContributionBaseObject contribution, object extension)
        {
            DeletionTime = deletionTime;
            DocumentIdentifier = documentIdentifier;
            PageIdentifier = pageIdentifier;
            ContributionIdentifier = contribution.Guid;
            Extension = extension;
        }

        public override string ToString()
        {
            return "RTContributionRemove " +
                "{ DocumentIdentifier: " + DocumentIdentifier.ToString() +
                ", PageIdentifier: " + PageIdentifier.ToString() +
                ", ContributionIdentifier: " + ContributionIdentifier.ToString() +
                ", SequenceNumber: " + SequenceNumber +
                " }";
        }
    }

    /* Not in v1.0 of RTObjects
    public class RTStrokeMove (Guid strokeIdentifier, int relativeX, int relativeY, int sequenceNumber )
    */
}
