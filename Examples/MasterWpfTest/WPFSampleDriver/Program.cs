using System.Diagnostics;
using System.Windows.Automation;
using ProdUI.Controls.Static;
using ProdUI.Controls.Windows;
using ProdUI.Logging;

namespace WPFSampleDriver
{
    internal class Program
    {
        const string WIN_TITLE = "WPF Test Form";

        private static void Main(string[] args)
        {          
            //SimpleProdExample();
            LoadConfigFile();
        }

        /// <summary>
        /// Demonstrates creating a simple Prod and how to create and add an external ProdLogger as well as how a 
        /// static Prod can be used to set a checkbox's value.
        /// </summary>
        public static void SimpleProdExample()
        {
            try
            {
                /* Create a logger. Note: You don't need to have a logger at all if you don't want one... */
                ProdLogger def = new ProdLogger(new DebugLogger(), LoggingLevels.Prod, "LogTime,Message Level,Calling Function,Message Text", "T");
                /* Add the new logger to the active loggers */
                LogController.AddActiveLogger(def);

                /* start the application and wait until it exists */
                Process.Start("MasterWPFTest.exe");
                Prod.WinWaitExists(WIN_TITLE);

                /* Get the parent window and add loggers */
                ProdWindow window = new ProdWindow(WIN_TITLE);

                /* here's the control we want to Prod */
                ProdCheckBox chk1 = new ProdCheckBox(window, "testCheckBoxA");

                /* We'll monkey with the slider control */
                ProdSlider slider = new ProdSlider(window, "sliderTest");
                slider.SetValue(3);

                /* here, we use a static Prod to directly set the ToggleState */
                Prod.SetCheckState(window, "testCheckBoxB", ToggleState.On);

                /* and switch tabs */
                ProdTab tabB = new ProdTab(window, "tabControl1");
                tabB.SelectTab(1);

                /* We're still able to set the checkbox on the other tab because we got its control before we changed */
                chk1.SetCheckState(ToggleState.On);

                /* This will break, because the static checkbox can't be referenced, since its not onscreen */
                //Prod.SetCheckState(window, "testCheckBoxC", ToggleState.Off);
            }
            catch (ProdUI.Exceptions.ProdOperationException e)
            {
                /* Show any errors */
                Debug.WriteLine(">>>>>>>" + e.InnerException.Message + "<<<<<<<<");
            }
        }

        /// <summary>
        /// Demonstrates creating a simple Prod using preconfigured loggers from a configuration file
        /// </summary>
        public static void LoadConfigFile()
        {

            try
            {
                /* Loading a set of loggers from a configuration file (located in the /bin directory */
                LoggingConfiguration lc = new LoggingConfiguration();
                /* Adding them to the controller */
                LogController.AddActiveLogger(lc.LoadFromConfiguration(@"loggers.ses"));

                /* start the application and wait until it exists */
                Process.Start("MasterWPFTest.exe");
                Prod.WinWaitExists(WIN_TITLE);

                /* Get the parent window and add loggers */
                ProdWindow window = new ProdWindow(WIN_TITLE);

                /* here's the control we want to Prod */
                ProdCheckBox chk1 = new ProdCheckBox(window, "testCheckBoxA");

                /* We'll monkey with the slider control */
                ProdSlider slider = new ProdSlider(window, "sliderTest");
                slider.SetValue(3);

                chk1.SetCheckState(ToggleState.On);
            }
            catch (ProdUI.Exceptions.ProdOperationException e)
            {
                /* Show any errors */
                Debug.WriteLine(">>>>>>>" + e.InnerException.Message + "<<<<<<<<");
            }
        }
    }
}