using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using iPH.Commons.Context;

namespace iPH.Commons.Forms
{
    public partial class ContextInformationRulesForm : Form
    {
        #region Members

        private InteractivePresentationForm myForm;

        #endregion

        #region Ctor

        private ContextInformationRulesForm()
        {
            InitializeComponent();
        }

        public ContextInformationRulesForm (InteractivePresentationForm form)
            : this()
        {
            this.myForm = form;

            //Calling show rules
            this.ShowRules();
        }

        #endregion

        #region Methods

        private void ShowRules()
        {
            this.lbRules.Items.Clear();
                   
            //Iterating through participants
            foreach (ContextInformationRule c in this.myForm.ContextInformationManager.List)
            {
                lbRules.Items.Add(c);
            }

            this.lbRules.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContextInformationRuleAddForm addForm = new ContextInformationRuleAddForm(this.myForm);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                ContextInformationRule rule = new ContextInformationRule(addForm.Rules, addForm.Function);
                this.myForm.ContextInformationManager.Add(rule);
                this.ShowRules();
            }
            addForm.Dispose();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ContextInformationRule rule = (ContextInformationRule)lbRules.SelectedItem;
            if (rule != null)
            {
                this.myForm.ContextInformationManager.Remove(rule);
                this.ShowRules();
            }
        }

        #endregion

  }
}