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
    public partial class ActiveSessionsForm : Form
    {
        #region Members

        private InteractivePresentationForm myForm;

        private SessionService.collaborativeSession[] mySessions;

        private SessionService.collaborativeSession selectedSession;

        #endregion

        #region Ctor

        private ActiveSessionsForm()
        {
            InitializeComponent();
        }

        public ActiveSessionsForm(InteractivePresentationForm form, SessionService.collaborativeSession[] sessions)
            : this()
        {
            this.myForm = form;

            this.mySessions = sessions;

            //Calling show sessions
            this.ShowSessions();
        }

        #endregion

        #region Methods

        private void ShowSessions()
        {
            this.lbSessions.Items.Clear();
                   
            foreach (SessionService.collaborativeSession c in this.mySessions)
            {
                this.lbSessions.Items.Add(c);
            }

            this.lbSessions.Refresh();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            SessionService.collaborativeSession session = (SessionService.collaborativeSession)lbSessions.SelectedItem;
            if (session != null)
            {
                this.selectedSession = session;
                //Dialog Result
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        #endregion

        #region Props

        public SessionService.collaborativeSession SelectedSession
        {
            get
            {
                return selectedSession;
            }
        }

        #endregion

    }
}