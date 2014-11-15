using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iPH.Tool.Mobile
{
    public partial class FormatTextFont : Form
    {

        #region Members

        private Font myFont;

        #endregion

        #region Ctor

        public FormatTextFont(Font currentFont)
        {
            InitializeComponent();
            
            //Name
            rdbArial.Checked = currentFont.Name.Equals("Arial") ? true : false;
            rdbTahoma.Checked = currentFont.Name.Equals("Tahoma") ? true : false;

            //Size
            nupSize.Value = (decimal)currentFont.Size;
        }

        #endregion

        #region Properties

        public Font Result
        {
            get
            {
                return this.myFont;
            }
        }

        #endregion

        #region Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }     

        private void btnOk_Click(object sender, EventArgs e)
        {
            string fontName = "Arial";
            if (rdbTahoma.Checked) 
                fontName = "Tahoma";
            this.myFont = new Font(fontName, (float)nupSize.Value, FontStyle.Regular);
            //
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}