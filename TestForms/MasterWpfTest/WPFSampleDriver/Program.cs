using System.Diagnostics;
using System.Windows.Automation;
using ProdUI.Controls.Static;
using ProdUI.Controls.Windows;
using ProdUI.Logging;

namespace WPFSampleDriver
{
    class Program
    {

        const string WIN_TITLE = "WPF Test Form";

        static void Main(string[] args)
        {
            SimpleProdNoSession();
        }

        /// <summary>
        /// Demonstrates creting a simple Prod using a blank session (no config file)
        /// It also shows how to create and add an external ProdLogger as well as how a static Prod can be used
        /// to set a checkbox's value.
        /// </summary>
        public static void SimpleProdNoSession()
        {
            try
            {

                /* Create the logger and add it */
                ProdLogger def = new ProdLogger(new DebugLogger(), LoggingLevels.Prod, "LogTime,Message Level,Calling Function,Message Text", "T");
                LogController.AddActiveLogger(def);

                /* start the application and wait until it exists */
                Process.Start("MasterWPFTest.exe");
                Prod.WinWaitExists(WIN_TITLE);

                /* Get the parent window and add loggers */
                ProdWindow window = new ProdWindow(WIN_TITLE);

                /* here's the control we want to Prod */
                ProdCheckBox chk1 = new ProdCheckBox(window, "testCheckBoxA");

                /* toggle state */
                chk1.SetCheckState(ToggleState.On);

                /* here, we use a static Prod to directly set the ToggleState */
                /* All you really need to create is an empty session and get the parent window */
                Prod.SetCheckState(window, "testCheckBoxB", ToggleState.On);
            }
            catch (ProdUI.Exceptions.ProdOperationException e)
            {
                /* Show any errors */
                Debug.WriteLine(">>>>>>>" + e.InnerException.Message + "<<<<<<<<");
            }
        }




    }
}
