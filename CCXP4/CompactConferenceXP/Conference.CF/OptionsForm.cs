using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/// $CompactConferenceXP:
/// Changes in MessageBox.Show in .NET CF

namespace CF.MSR.LST.ConferenceXP
{
    internal partial class OptionsForm : Form
    {
        public enum FormState
        {
            clean,
            create,
            edit
        }

        public FormState State = FormState.clean;
        private bool initializing = true;
        
        public OptionsForm(FormState state)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            State = state;
            ShowParticipant();
            
            if (State == FormState.create)
            {
                EnableOK(this, null);
            }

            /// $CompactConferenceXP:
            /// This version does not contain link to privacy policiy
            /// Commented

            /*
            if (Conference.VenueServiceWrapper.VenueService.PrivacyPolicyUrl() != null)
            {
                linkPrivacyPolicy.Visible = true;                    
                linkPrivacyPolicy.Links.Add(0, 14, Conference.VenueServiceWrapper.VenueService.PrivacyPolicyUrl());
            }
             */ 
        }


        private void ShowParticipant()
        {
            Participant p = Conference.LocalParticipant;

            if (p != null)
            {
                IDLabel.Text = p.Identifier;
                NameTextBox.Text = p.Name;
                EmailTextBox.Text = p.Email;

                /// $CompactConferenceXP:
                /// This version does not contain participant's icon
                /// Commented
                /*
                if (p.Icon != null)
                {
                    ParticipantImage.Image = p.Icon;
                }
                 */ 
            }
            else
            {
                IDLabel.Text = Identity.Identifier;
            }

            initializing = false;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Bitmap bm = null;

            /// $CompactConferenceXP:
            /// This version does not send a bitmap to venue as icon
            /// Commented
            
            /*
            if (ParticipantImage.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                ParticipantImage.Image.Save(ms, ImageFormat.Png);
                bm = new Bitmap(ms);
            }
             */ 

            try
            {
                if (State == FormState.create)
                {
                    Conference.AddProfileOnServer(NameTextBox.Text, null, EmailTextBox.Text, bm, false);
                }
                else
                {
                    Conference.UpdateProfileOnServer(NameTextBox.Text, null, EmailTextBox.Text, bm, false);
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show(
                    "Your profile could not be updated on the server. \n" +
                    "Check that you have a connection to the venue server. \n",
                    "Error Connecting to Venue Server", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1 );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred connecting to the venue server. \n" +
                    "Try again when you have a connection to the venue server. \n" +
                    "\nException:\n" + ex.ToString(),
                    "Error Connecting to Venue Server", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void EnableOK(object sender, System.EventArgs e)
        {
            if (!initializing)
            {
                btnOK.Enabled = true;
            }
        }
    }
}