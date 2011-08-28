using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Automation;
using ProdUI.Controls;
using ProdUI.Logging;
using ProdUI.Session;

namespace WPFSampleDriver
{
    class Program
    {

        const string WIN_TITLE = "WPF Test Form";

        static void Main(string[] args)
        {
            //SimpleProdNoSession();
            SimpleProdUsingConfiguration();
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
                List<ProdLogger> loggers = new List<ProdLogger>();

                /* setup a blank session. This will not create any loggers */
                ProdSession session = new ProdSession();

                /* we're still going to add a logger, so we need to set up a config */
                ProdSessionConfig cfg = new ProdSessionConfig();

                /* Create the logger and add it */
                ProdLogger def = ProdLogger.CreateLogger(new DebugLogger(), LoggingLevels.Prod, "LogTime,Message Level,Calling Function,Message Text", "T");
                loggers.Add(def);

                /* start the application and wait until it exists */
                Process.Start("MasterWPFTest.exe");
                Prod.WinWaitExists(WIN_TITLE);

                /* Get the parent window and add loggers */
                ProdWindow window = new ProdWindow(WIN_TITLE, loggers);

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


        /// <summary>
        /// Demonstrates creating a simple Prod by loading a config file
        /// It also shows how a static Prod can be used to click a button
        /// One thing to note: the .ses file for this example is located in the /bin directory
        /// of the form application for simplicity.
        /// </summary>
        public static void SimpleProdUsingConfiguration()
        {
            try
            {
                /* setup a session.  This file contains the specs for a DebugLogger*/
                ProdSession session = new ProdSession("test.ses");

                /* start the application and wait until it exists */
                Process.Start("MasterWPFTest.exe");
                Prod.WinWaitExists(WIN_TITLE);

                /* Get the parent window and add loggers */
                ProdWindow window = new ProdWindow(WIN_TITLE, session.Loggers);

                /* here's the control we want to Prod */
                ProdButton button = new ProdButton(window, "button1");

                /* clicking this button will enable Button B */
                button.Click();

                /* here, we use a static Prod to directly click the button */
                /* The label in the center of the form will change */
                Prod.ButtonClick(window, "button2");
            }
            catch (ProdUI.Exceptions.ProdOperationException e)
            {
                /* Show any errors */
                Debug.WriteLine(">>>>>>>" + e.InnerException.Message + "<<<<<<<<");
            }
        }

        public static void DrivingSomeControls()
        {
        }

    }
}
