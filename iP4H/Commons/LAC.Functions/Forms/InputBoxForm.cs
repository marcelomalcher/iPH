using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAC.Functions.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InputBoxForm : Form
    {
        #region Members

        #region Private

        private const int DELTA_HEIGHT = 50;

        //Title - this string will appears in the form's text
        private string myTitle;
        //Prompt - the text that will tell the user what to input
        private string myPrompt;
        //Result - the value that the user entered at the text box.
        private string myResult;

        //
        private bool isMultiline;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public InputBoxForm(string title, string prompt, string result, bool multiLine)
        {
            InitializeComponent();

            //Setting contructing values
            this.myTitle = title;
            this.myPrompt = prompt;
            this.myResult = result;

            this.isMultiline = multiLine;

            //Updating Data
            this.UpdateData();
        }

        #endregion

        #endregion

        #region Properties

        public string Result
        {
            get
            {
                return this.myResult;
            }
        }

        #endregion

        #region Methods

        #region Private

        private void Confirm()
        {
            this.myResult = this.tbResult.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateData()
        {
            //Setting form's values
            this.Text = this.myTitle;
            this.lblPrompt.Text = this.myPrompt;
            this.tbResult.Text = this.myResult;

            //if multiline, increases form's size and text box's size
            if (this.isMultiline)
            {
                tbResult.Multiline = true;
                this.Height = this.Height + DELTA_HEIGHT;
                tbResult.Height = tbResult.Height + DELTA_HEIGHT;
            }
        }

        #region GUI

        private void FrmInputBox_Load(object sender, EventArgs e)
        {
            tbResult.Focus();
        }

        private void tbResult_KeyDown(object sender, KeyEventArgs e)
        {
            //Pressing Enter
            if (e.KeyCode == Keys.Enter)
            {
                this.Confirm();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Cancel();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Confirm();
        }

        private void btbCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        #endregion

        #endregion

        #endregion
    }
}