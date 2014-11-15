using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAC.Functions.Forms
{
    public partial class InputTrackBarForm : Form
    {
        #region Members

        #region Private

        private string myTitle;

        private string myCaption;
        
        private int myValue = 5;

        private int myMaxValue = 10;

        private int myMinValue = 0;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public InputTrackBarForm(string theTitle, string theCaption, int theValue, int theMaxValue, int theMinValue)
        {
            InitializeComponent();

            this.myTitle = theTitle;
            this.myCaption = theCaption;
            
            this.MaximumValue = theMaxValue;
            this.MinimumValue = theMinValue;
            this.CurrentValue = theValue;

            this.UpdateData();
        }

        #endregion

        #endregion

        #region Properties

        #region Private
        private int CurrentValue
        {
            get
            {
                return this.myValue;
            }
            set
            {
                if (value > this.MaximumValue)
                {
                    this.myValue = this.MaximumValue;
                }
                else if (value < this.MinimumValue)
                {
                    this.myValue = this.MinimumValue;
                }
                else
                {
                    this.myValue = value;
                }
            }
        }

        private int MaximumValue
        {
            get
            {
                return this.myMaxValue;
            }
            set
            {
                if (value > 0 && value > this.MinimumValue)
                    this.myMaxValue = value;
            }
        }

        private int MinimumValue
        {
            get
            {
                return this.myMinValue;
            }
            set
            {
                if (value > 0 && value < this.MaximumValue)
                    this.myMinValue = value;
            }
        }
        #endregion

        #region Public

        public int Result
        {
            get
            {
                return this.CurrentValue;
            }
        }

        #endregion
        
        #endregion

        #region Methods

        #region Private

        private void UpdateData()
        {
            //Title 
            this.Text = this.myTitle;
            //Caption
            this.lblCaption.Text = this.myCaption;

            //Value
            this.tbValue.Value = this.CurrentValue;
            //MaxValue
            this.tbValue.Maximum = this.MaximumValue;
            //MinValue
            this.tbValue.Minimum = this.MinimumValue;
        }

        #region GUI

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.CurrentValue = this.tbValue.Value;
        }

        #endregion

        #endregion

        #endregion
    }
}