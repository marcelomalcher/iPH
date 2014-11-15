using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using iPH.Commons.Configuration;

namespace iPH.Tool.Desktop
{
    public partial class ConfigurationForm : iPH.Commons.Forms.ConfigurationForm
    {
        #region Constructor

        public ConfigurationForm(InteractiveConfiguration configuration)
            : base(configuration)
        {
        }

        #endregion

        #region Override virtual method

        public override Color GetColor(Color myCurrentColor)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = false;
            colorDialog.Color = myCurrentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                myCurrentColor = colorDialog.Color;
            }
            colorDialog.Dispose();
            return myCurrentColor;
        }

        #endregion

    }
}

