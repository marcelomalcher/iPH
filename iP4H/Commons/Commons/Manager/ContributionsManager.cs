using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO; 
using iPH.Commons.Forms;
using iPH.Commons.Ink;
using iPH.Commons.Presentation;

using LAC.Contribution;
using LAC.Contribution.Enums;

using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Manager
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class ContributionsManager: ICSerializable
    {
        #region Members

        private List<SlideContribution> myList;
        private ActionType myAction = ActionType.InkWriteType;
        private Color myInkColor = Color.Black;
        private int myInkWidth = InkProperties.GetSizeByPlatform(System.Environment.OSVersion.Platform);
        private Font myTextFont = new Font("Arial", 10, FontStyle.Regular);
        private Color myTextColor = Color.Black;
        
        #endregion

        #region Ctor

        public ContributionsManager()
        {
            this.myList = new List<SlideContribution>();           
        }

        #endregion

        #region Properties

        public List<SlideContribution> List
        {
            get
            {
                return this.myList;
            }
        }

        public int Count
        {
            get
            {
                return this.myList.Count;
            }
        }

        public ActionType Action
        {
            get
            {
                return this.myAction;
            }
            set
            {
                this.myAction = value;
                this.SetAction(this.myAction);
            }
        }

        public int InkWidth
        {
            get
            {
                return this.myInkWidth;
            }
            set
            {
                this.myInkWidth = value;
                this.SetInkWidth(this.myInkWidth);
            }
        }

        public Color InkColor
        {
            get
            {
                return this.myInkColor;
            }
            set
            {
                this.myInkColor = value;
                this.SetInkColor(this.myInkColor);
            }
        }

        public Font TextFont
        {
            get
            {
                return this.myTextFont;
            }
            set
            {
                this.myTextFont = value;
                this.SetTextFont(this.myTextFont);
            }
        }

        public Color TextColor
        {
            get
            {
                return this.myTextColor;
            }
            set
            {
                this.myTextColor = value;
                this.SetTextColor(this.myTextColor);
            }
        }

        #endregion

        #region Methods

        public void Clear()
        {
            foreach (SlideContribution sc in this.myList)
            {
                sc.ContributionComponent = null;
            }
            this.myList.Clear();            
        }

        public void Add(Guid slideGuid)
        {
            if (this.GetSlideContribution(slideGuid) == null)
            {
                ContributionComponent contributionComponent = new ContributionComponent();
                contributionComponent.Enabled = false;
                contributionComponent.InkColor = this.InkColor;
                contributionComponent.InkWidth = this.InkWidth;
                contributionComponent.TextFont = this.TextFont;
                contributionComponent.TextColor = this.TextColor;
                this.myList.Add(new SlideContribution(slideGuid, contributionComponent));
            }
        }

        private void Add(SlideContribution slideContribution)
        {
            if (this.GetSlideContribution(slideContribution.SlideGuid) == null && this.GetSlideContribution(slideContribution.ContributionComponent) == null)
            {
                this.myList.Add(slideContribution);
            }
        }

        public void ClearSlideContributions(Guid slideGuid)
        {
            SlideContribution slideContribution = this.GetSlideContribution(slideGuid);
            slideContribution.ContributionComponent.Contributions.Clear();
        }

        public void RemoveSlideContribution(Guid slideGuid)
        {
            SlideContribution slideContribution = this.GetSlideContribution(slideGuid);
            if (slideContribution != null)
            {
                this.myList.Remove(slideContribution);
            }
        }

        public void RemoveSlideContribution(ContributionComponent contributionComponent)
        {
            SlideContribution slideContribution = this.GetSlideContribution(contributionComponent);
            if (slideContribution != null)
            {
                this.myList.Remove(slideContribution);
            }
        }   

        public SlideContribution GetSlideContribution(Guid slideGuid)
        {
            if (slideGuid != Guid.Empty)
            {
                foreach (SlideContribution slideContribution in this.myList)
                {
                    if (slideContribution.SlideGuid.Equals(slideGuid))
                    {
                        return slideContribution;
                    }
                }
            }
            return null;
        }

        public SlideContribution GetSlideContribution(ContributionComponent contributionComponent)
        {
            if (contributionComponent != null)
            {
                return this.GetSlideContributionFromContributionComponent(contributionComponent.Guid);
            }
            return null;
        }

        private SlideContribution GetSlideContributionFromContributionComponent(Guid guid)
        {
            if (guid != Guid.Empty)
            {
                foreach (SlideContribution slideContribution in this.myList)
                {
                    if (slideContribution.ContributionComponent.Guid.Equals(guid))
                    {
                        return slideContribution;
                    }
                }
            }
            return null;
        }

        #region SaveManagerToWriter
        //this method was created for use with SaveDeckSet2, of InteractivePresentationForm,
        //which is currently not working right
        public void SaveManagerToWriter(BinaryWriter bw)
        {
            try
            {
                if ((this != null) || (this.Count > 0))
                {
                    MemoryStream memStream = new MemoryStream();
                    CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                    cf.Serialize(memStream, this);
                    byte[] data = memStream.ToArray();
                    memStream.Close();
                    bw.Write(data.Length);
                    bw.Write(data);
                }
                else
                    bw.Write(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        #endregion


        #region GetManagerFromReader - static

        public static ContributionsManager GetManagerFromReader(BinaryReader br)
        {
            try
            {
                ContributionsManager loadedContributionsManager = null;
                int length = br.ReadInt32();
                if (length > 0)
                {
                    byte[] data = br.ReadBytes(length);
                    CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                    MemoryStream memStream = new MemoryStream(data);
                    Object o = cf.Deserialize(memStream);
                    loadedContributionsManager = (ContributionsManager)o;
                    memStream.Close();
                    System.GC.Collect();
                }
                return loadedContributionsManager;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region Disable

        public void Disable()
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.Enabled = false;
            }
        }

        #endregion

        #region ContributionComponent setting methods

        private void SetAction(ActionType action)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.Action = action;
            }
        }

        private void SetInkWidth(int width)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.InkWidth = width;
            }
        }

        private void SetInkColor(Color color)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.InkColor = color;
            }
        }

        private void SetTextFont(Font font)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.TextFont = font;
            }
        }

        private void SetTextColor(Color color)
        {
            foreach (SlideContribution slideContribution in this.myList)
            {
                slideContribution.ContributionComponent.TextColor = color;
            }
        }

        #endregion

        #region ICSerializable Members

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            int cCount = (int)parent.Deserialize(stream);
            for (int i = 0; i < cCount; i++)
            {
                SlideContribution slideContribution = (SlideContribution)parent.Deserialize(stream);
                this.Add(slideContribution);
            }
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, this.Count);
            foreach (SlideContribution slideContribution in this.myList)
            {
                parent.Serialize(stream, slideContribution);
            }
        }

        #endregion
        
    }

    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class SlideContribution: ICSerializable
    {
        #region Members

        private Guid mySlideGuid;

        private ContributionComponent myContribution;

        #endregion

        #region Ctor

        public SlideContribution()
        {
        }

        public SlideContribution(Guid slideGuid, ContributionComponent contributionComponent)
        {
            this.mySlideGuid = slideGuid;
            this.myContribution = contributionComponent;
        }

        #endregion

        #region Properties

        public Guid SlideGuid
        {
            get
            {
                return this.mySlideGuid;
            }
            set
            {
                this.mySlideGuid = value;
            }
        }

        public ContributionComponent ContributionComponent
        {
            get
            {
                return this.myContribution;
            }
            set
            {
                this.myContribution = value;
            }
        }

        #endregion

        #region ICSerializable Members

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            string cSlideGuid = (string)parent.Deserialize(stream);
            this.mySlideGuid = new Guid(cSlideGuid);
            this.myContribution = (ContributionComponent)parent.Deserialize(stream);
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, this.mySlideGuid.ToString());
            parent.Serialize(stream, this.myContribution);
        }

        #endregion
    }
}
