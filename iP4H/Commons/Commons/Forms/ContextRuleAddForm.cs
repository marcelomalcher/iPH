using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using iPH.Commons.Functions;
using iPH.Commons.Context;

namespace iPH.Commons.Forms
{
    public partial class ContextRuleAddForm : Form
    {
        #region Members

        #region Private

        private int field;

        private int oper;

        private string value;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public ContextRuleAddForm()
        {
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public int Field
        {
            get
            {
                return this.field ;
            }
        }

        public int Operator
        {
            get
            {
                return this.oper;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Private

        private bool Validate()
        {
            if (this.cbField.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a field.", "Rule");
                return false;
            }
            if (this.cbOperator.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an operator.", "Rule");
                return false;
            }
            if (this.tbValue.Text.Length <= 0)
            {
                MessageBox.Show("Please insert the value.", "Rule");
                return false;
            }
            return true;
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Validate())
            {
                this.field = cbField.SelectedIndex;
                this.oper = cbOperator.SelectedIndex;
                this.value = tbValue.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion
        #endregion

    }
}