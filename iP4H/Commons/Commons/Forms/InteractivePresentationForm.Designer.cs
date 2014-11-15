namespace iPH.Commons.Forms
{
    partial class InteractivePresentationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InteractivePresentationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(572, 320);
            this.Name = "InteractivePresentationForm";
            this.Text = "InteractivePresentationForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.InteractivePresentationForm_Closing);
            this.Load += new System.EventHandler(this.InteractivePresentationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

    }
}