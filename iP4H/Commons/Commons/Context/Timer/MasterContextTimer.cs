using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Forms;

namespace iPH.Commons.Context.Timer
{
    public class MasterContextTimer : BaseContextTimer
    {
        public MasterContextTimer(InteractivePresentationForm theForm, long theInterval)
            : base(theForm, theInterval)
        {
        }

        protected override void myTimerTick(object sender, EventArgs e)
        {
            this.Form.SendContextInformationRules();
        }
    }
}
