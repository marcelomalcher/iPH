using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAC.Functions.Forms
{
    public partial class AboutForm : Form
    {
        #region Member
        private string myProductName;
        private string myCompanyName;
        private string myAuthorName;
        #endregion

        #region Ctor

        public AboutForm()
        {
            InitializeComponent();
        }

        public AboutForm(string productName, string companyName, string authorName)
        {
            InitializeComponent();
            //Setting values
            this.ProductName = productName;
            this.CompanyName = companyName;
            this.AuthorName = authorName;
        }

        #endregion

        #region Props
        public string ProductName
        {
            get
            {
                return this.myProductName;
            }
            set
            {
                this.myProductName = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return this.myCompanyName;
            }
            set
            {
                this.myCompanyName = value;
            }
        }
        

        public string AuthorName
        {
            get
            {
                return this.myAuthorName;
            }
            set
            {
                this.myAuthorName = value;
            }
        }
        #endregion

        #region Events
        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.lblProductName.Text = this.ProductName;
            this.lblCompanyName.Text = this.CompanyName;
            this.lblAuthorName.Text = this.AuthorName;
        }
        #endregion
    }
}