using System;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using LAC.Contribution.Arguments;
using LAC.Contribution.Enums;
using LAC.Contribution.Objects;
using LAC.Contribution.Controls;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace LAC.Contribution
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class ContributionComponent: ICSerializable
    {
        #region Members
        
        //Guid
        private Guid myGuid;
        //Control owner
        private ContributionBaseControl myOwner = null;
        //Strokes
        private Contributions myContributions;
        //Enabled
        private bool isEnabled = true;
        //Action Type
        private ActionType myAction = ActionType.InkWriteType;
        
        //Ink
        //Color
        private Color myInkColor = Color.Black;
        //Width
        private int myInkWidth = 1;

        //Text
        //Font
        private Font myTextFont = new Font("Arial", 10, FontStyle.Regular);
        //Color
        private Color myTextColor = Color.Black;

        //Controller
        private ActionController myController;

        #endregion

        #region Constructors
        //No-args constructor
        public ContributionComponent()
        {
            this.myGuid = Guid.NewGuid();
            this.myContributions = new Contributions();
            this.myController = new ActionController(this);
        }

        //Main constructor
        public ContributionComponent(ContributionBaseControl owner)
            : this()
        {
            this.Owner = owner;            
        }

        #endregion

        #region Properties

        //Guid
        public Guid Guid
        {
            get
            {
                return this.myGuid;
            }
            set
            {
                this.myGuid = value;
            }
        }

        //Owner 
        public ContributionBaseControl Owner
        {
            get
            {
                return this.myOwner;
            }
            set
            {
                if (this.myOwner != null)
                {
                    this.myController.RemovePaintEvents();
                }
                this.myOwner = value;
                if (value != null)
                {
                    this.myController.AddPaintEvents();
                }
            }
        }

        //Contributions
        public Contributions Contributions
        {
            get
            {
                return this.myContributions;
            }
        }

        //Enabling controller
        public bool Enabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                this.isEnabled = value;
            }
        }

        //Action Type
        public ActionType Action
        {
            get
            {
                return this.myAction;
            }
            set
            {
                this.myAction = value;
            }
        }

        //Current Color
        public Color InkColor
        {
            get
            {
                return this.myInkColor;
            }
            set
            {
                this.myInkColor = value;
            }
        }

        //Width
        public int InkWidth
        {
            get
            {
                return this.myInkWidth;
            }
            set
            {
                this.myInkWidth = value;
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
            }
        }

        //Text Color
        public Color TextColor
        {
            get
            {
                return this.myTextColor;
            }
            set
            {
                this.myTextColor = value;
            }
        }

        #endregion        
    
        #region ICSerializable Members

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
        {
            string cGuid = (string)parent.Deserialize(stream);
            this.myGuid = new Guid(cGuid);
            this.myContributions = (Contributions)parent.Deserialize(stream);
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
        {
            parent.Serialize(stream, this.myGuid.ToString());
            parent.Serialize(stream, this.myContributions);
        }

        #endregion
    }
}