using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;

using iPH.Commons.Forms;
using iPH.Commons.Functions;

using LAC.ContextInformation;

namespace iPH.Commons.Context.Timer
{
    public class ContribuitorContextTimer : BaseContextTimer
    {
        #region Constructor

        public ContribuitorContextTimer(InteractivePresentationForm theForm, long theInterval)
            : base(theForm, theInterval)
        {
        }

        #endregion

        #region Method

        protected override void myTimerTick(object sender, EventArgs e)
        {
            Thread contextFunctionThread = new Thread(new ThreadStart(ContextAccessThread));
            contextFunctionThread.Name = "Contribuitor Context Timer - Context Access Thread";
            contextFunctionThread.IsBackground = true;
            contextFunctionThread.Start();
        }

        private void ContextAccessThread()
        {
            List<BaseFunction> functions = new List<BaseFunction>();

            ContextWrapper contextWrapper = null;
            bool connected = false;

            //Used to access MoCA Web Service            
            try
            {
                contextWrapper = new ContextWrapper(this.Form.Configuration.MocaWebServiceURL);
                connected = contextWrapper.isConnected();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error has occurred while creating the wrapper object to connect to the MoCA/WS: " + ex.Message, "Information");
            }

            lock (this.Form.ContextInformationManager.List)
            {
                foreach (ContextInformationRule c in this.Form.ContextInformationManager.List)
                {
                    //Getting the specific device context...
                    try
                    {
                        DeviceContext dvcContext = null;

                        if (connected)
                        {
                           String area = contextWrapper.GetAreaFromDevice(this.Form.Participant.MacAddress);
                            if (area == null)
                                this.Form.InsertMessage("Area unavailable for retrieval.");
                            dvcContext = contextWrapper.GetDeviceContext(this.Form.Participant.MacAddress);
                            if (dvcContext == null)
                                this.Form.InsertMessage("Device Context Information unavailable for retrieval.");
                            if (c.Evaluate(dvcContext, area) && (!functions.Contains(c.Function)))
                            {
                                functions.Add(c.Function);
                            }

                            dvcContext = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        Console.WriteLine("Error while recovering device context information.\n" + ex.Message, "Information");
                        this.Form.InsertMessage("Error while recovering device context information.\n" + ex.Message);
                    }
                }
            }

            contextWrapper = null;

            //
            this.AvailableFunctions(functions.ToArray());
        }

        #endregion
    }
}
