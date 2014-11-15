using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Forms;
using iPH.Commons.User.Role;

namespace iPH.Commons.Context.Timer
{
    public class ContexTimerFactory
    {
        public static BaseContextTimer GetContextTimer(BaseRole theRole, InteractivePresentationForm theForm, long theInterval, bool theEnabled)
        {
            if (theRole is Master)
            {
                return new MasterContextTimer(theForm, theInterval);
            }
            else if (theRole is Contribuitor)
            {
                return new ContribuitorContextTimer(theForm, theInterval);
            }
            else
            {
                return null;
            }
        }
    }
}
