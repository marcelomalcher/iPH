using System;
using System.Reflection;
using System.Diagnostics;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;

/// $CompactConferenceXP:
/// Adding reference to OpenNETCF.Diagnostics for EventLog class.
using OpenNETCF.Diagnostics;


// Investigate using Watson reporting

namespace CF.MSR.LST
{
    public class UnhandledExceptionHandler
    {
        public static void Register()
        {
            // Register our unhandled exception handler with the app domain
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(Handler);
        }

        private static void Handler(object sender, UnhandledExceptionEventArgs args)
        {
            // Wrap it all in a try catch, so as not to generate any extra errors at this point
            try
            {
                // The information to display or log
                string info;

                // Special case ThreadAbortExceptions during finalization
                ThreadAbortException tae = args.ExceptionObject as ThreadAbortException;
                if (tae != null)
                {
                    if (!args.IsTerminating)
                    {
                        return;
                    }
                }

                // Retrieve the exception object from the EventArgs
                Exception e = args.ExceptionObject as Exception;

                // Determine type of exception - CLS / Non-CLS
                if (e != null)
                {
                    // CLS-compliant - can access any Exception field (StackTrace, InnerException, etc.)
                    info = e.ToString();
                }
                else
                {
                    // Non-CLS compliant - can access methods defined by Object (ToString, GetType, etc.)
                    info = string.Format("Non-CLS compliant exception: ExceptionType:{0}, ExceptionString:{1}",
                        args.ExceptionObject.GetType(), args.ExceptionObject.ToString());
                }

                // List type and string of Sender
                info += "\n\nSender type: " + sender.GetType();
                info += "\nSender string: " + sender.ToString();

                // Determine what type of thread caused the error
                info += "\nThread type: ";
                if (!args.IsTerminating)
                {
                    info += "pool or finalizer";
                }
                else
                {
                    info += "main or manual";
                }

                // Log version of product
                               
                /// $CompactConferenceXP:
                /// Removed reference to ProductVersion. 
                /// info += "\nProduct version: " + Application.ProductVersion.ToString();
                info += "\nProduct version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();

                // Log it to the event log
                try
                {
                    /// $CompactConferenceXP:
                    /// OpenNETCF's EventLog has others constructor params
                    /// > EventLog eventLog = new EventLog("UnEx", ".", "MSR.LST.UnEx");
                    EventLog eventLog = new EventLog("UnEx", "MSR.LST.UnEx", EventLogWriterType.XML);

                    /// $CompactConferenceXP:
                    /// OpenNETCF's EventLog WriteEntry method. Same parameters...
                    /// > eventLog.WriteEntry(info, EventLogEntryType.Error, 999);
                    eventLog.WriteEntry(info, EventLogEntryType.Error, 999);
                }
                catch (Exception) { }

                // Compose message to user
                string msg = string.Format("{0} has encountered the following error:\n\n{1}",
                    AppDomain.CurrentDomain.FriendlyName, info);

                // Read user's preference from configuration file
                bool showMsg = true;
                
                /// $CompactConferenceXP:
                /// Removed reference to ConfigurationManager.AppSettings. 
                /// All commented.
                
                // if (ConfigurationManager.AppSettings[AppConfig.LST_ShowErrors] != null)
                // {
                //   showMsg = bool.Parse(ConfigurationManager.AppSettings[AppConfig.LST_ShowErrors]);
                // }
                
                if (showMsg)
                {
                    MessageBox.Show(msg);
                }
            }
            catch (Exception) { }
        }
    }
}
