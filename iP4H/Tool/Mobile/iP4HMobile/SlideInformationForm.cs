using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iPH.Tool.Mobile
{
    public partial class SlideInformationForm : Form
    {
        #region Ctor
        private SlideInformationForm(string title, string description)
        {
            InitializeComponent();
            //
            this.lblTitleValue.Text = title;
            this.lblDescriptionValue.Text = description;
        }
        #endregion

        #region Static
        public static void Show(string title, string description)
        {
            SlideInformationForm mySelf = new SlideInformationForm(title, description);
            mySelf.ShowDialog();
            mySelf.Dispose();
        }
        #endregion
    }
}