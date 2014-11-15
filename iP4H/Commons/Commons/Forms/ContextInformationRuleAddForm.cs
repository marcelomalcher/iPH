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
    public partial class ContextInformationRuleAddForm : Form
    {
        #region Members

        #region Private

        private InteractivePresentationForm myForm;

        private List<ContextRule> myRules;

        private BaseFunction function;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public ContextInformationRuleAddForm(InteractivePresentationForm theForm)
        {
            InitializeComponent();

            this.myForm = theForm;

            this.myRules = new List<ContextRule>();

            this.ShowFunctions();
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public List<ContextRule> Rules
        {
            get
            {
                return this.myRules;
            }
        }

        public BaseFunction Function
        {
            get
            {
                return this.function;
            }
        }


        #endregion

        #endregion

        #region Methods

        #region Private

        private void ShowFunctions()
        {
            this.lbFunctions.Items.Clear();

            foreach (BaseFunction f in this.myForm.FunctionsManager.List)
            {
                if (f.IsEnabled())
                    this.lbFunctions.Items.Add(f);
            }
        }

        private bool Validate()
        {
            if (this.myRules.Count <= 0)
            {
                MessageBox.Show("Please insert at least one condition.", "Rule");
                return false;
            }
            if (this.lbFunctions.SelectedItem == null)
            {
                MessageBox.Show("Please select a function.", "Rule");
                return false;
            }
            return true;
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Validate())
            {                
                this.function = (BaseFunction)this.lbFunctions.SelectedItem;
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion

        private void btnRemoveRule_Click(object sender, EventArgs e)
        {
            ContextRule rule = (ContextRule)lbRules.SelectedItem;
            if (rule != null)
            {
                this.myRules.Remove(rule);
                this.UpdateRules();
            }
        }

        #endregion

        private void btnCreateRule_Click(object sender, EventArgs e)
        {
            ContextRuleAddForm addForm = new ContextRuleAddForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                ContextRule rule = new ContextRule(addForm.Field, addForm.Operator, addForm.Value);
                this.myRules.Add(rule);
                this.UpdateRules();
            }
            addForm.Dispose();
        }

        private void UpdateRules()
        {
            this.lbRules.Items.Clear();

            //Iterating through participants
            foreach (ContextRule c in this.Rules)
            {
                lbRules.Items.Add(c);
            }

            this.lbRules.Refresh();
        }
    }
}