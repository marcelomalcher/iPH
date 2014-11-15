using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using iPH.Commons.Functions;

using iPH.Commons.Forms;

namespace iPH.Commons.Context.Timer
{
    public abstract class BaseContextTimer
    {
        #region Members

        private InteractivePresentationForm myForm;

        private long myInterval;
       
        private System.Windows.Forms.Timer myTimer;

        #endregion

        #region Constructors

        public BaseContextTimer(InteractivePresentationForm theForm, long theInterval)
        {
            this.myForm = theForm;
            this.myInterval = theInterval;

            this.CreateTimer();
        }

        #endregion

        #region Properties

        protected InteractivePresentationForm Form
        {
            get
            {
                return this.myForm;
            }
        }

        #endregion

        #region Methods

        private void CreateTimer()
        {
            this.myTimer = new System.Windows.Forms.Timer();
            this.myTimer.Interval = (int)this.myInterval;
            this.myTimer.Tick += new EventHandler(myTimerTick);            
        }

        protected void AvailableFunctions(BaseFunction[] functions)
        {
            this.myForm.AvailableAllFunctions();

            foreach (BaseFunction f in functions)
            {
                this.myForm.AvailableFunction(f, false);
            }
        }

        public void Tick(object sender)
        {
            this.myTimerTick(sender, new EventArgs());
        }

        protected virtual void myTimerTick(object sender, EventArgs e)
        {
            //procurar por sessão aqui!
        }


        #region IContextTimer Members

        public void Start()
        {
            this.myTimer.Enabled = true;
        }

        public void Stop()
        {
            this.myTimer.Enabled = false;
        }

        public bool IsRunning()
        {
            return this.myTimer.Enabled;
        }

        public void SetInterval(int theInterval)
        {
            if (this.myTimer != null)
                this.myTimer.Interval = theInterval;
            this.myInterval = theInterval;
        }

        #endregion

        #endregion
    }
}
