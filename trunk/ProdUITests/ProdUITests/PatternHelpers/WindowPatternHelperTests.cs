using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;
using ProdUI.Exceptions;

namespace ProdUITests
{
    [TestFixture]
    class WindowPatternHelperTests
    {
        const string WIN_TITLE = "WPF Test Form";
        private static ProdSession session;
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            session = new ProdSession("test.ses");
            window = new ProdWindow(WIN_TITLE, session.Loggers);
        }


            /// <summary>
            ///A test for CloseWindow
            ///</summary>
            [Test]       
            public void CloseWindowTest()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.AutomationPatterns.WindowPatternHelper_Accessor.CloseWindow(control);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            ///A test for GetInteractionState
            ///</summary>
            [Test]
            public void GetInteractionStateTest()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowInteractionState expected = new System.Windows.Automation.WindowInteractionState(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowInteractionState actual;
                actual = ProdUI.AutomationPatterns.WindowPatternHelper_Accessor.GetInteractionState(control);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            ///A test for GetIsModal
            ///</summary>
            [Test]
            public void GetIsModalTest()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                System.Nullable<bool> expected = new System.Nullable<bool>(); // TODO: Initialize to an appropriate value
                System.Nullable<bool> actual;
                actual = ProdUI.AutomationPatterns.WindowPatternHelper_Accessor.GetIsModal(control);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            ///A test for GetIsTopmost
            ///</summary>
            [Test]          
            public void GetIsTopmostTest()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                System.Nullable<bool> expected = new System.Nullable<bool>(); // TODO: Initialize to an appropriate value
                System.Nullable<bool> actual;
                actual = ProdUI.AutomationPatterns.WindowPatternHelper_Accessor.GetIsTopmost(control);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            ///A test for GetVisualState
            ///</summary>
            [Test]            
            public void GetVisualStateTest()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowVisualState expected = new System.Windows.Automation.WindowVisualState(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowVisualState actual;
                actual = ProdUI.AutomationPatterns.WindowPatternHelper_Accessor.GetVisualState(control);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            ///A test for SetState
            ///</summary>
            [Test]            
            public void SetStateTest()
            {
                System.Windows.Automation.WindowVisualState state = new System.Windows.Automation.WindowVisualState(); // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowPattern wp = null; // TODO: Initialize to an appropriate value
                ProdUI.AutomationPatterns.WindowPatternHelper_Accessor.SetState(state, wp);
            }

            /// <summary>
            ///A test for SetVisualState
            ///</summary>
            [Test]           
            public void SetVisualStateTest()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowVisualState state = new System.Windows.Automation.WindowVisualState(); // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.AutomationPatterns.WindowPatternHelper_Accessor.SetVisualState(control, state);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            ///A test for VerifyState
            ///</summary>
            [Test]           
            public void VerifyStateTest()
            {
                System.Windows.Automation.WindowPattern pattern = null; // TODO: Initialize to an appropriate value
                System.Windows.Automation.WindowVisualState state = new System.Windows.Automation.WindowVisualState(); // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = ProdUI.AutomationPatterns.WindowPatternHelper_Accessor.VerifyState(pattern, state);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            ///A test for WaitForInputIdle
            ///</summary>
            [Test]            
            public void WaitForInputIdleTest()
            {
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                int delay = 0; // TODO: Initialize to an appropriate value
                System.Nullable<bool> expected = new System.Nullable<bool>(); // TODO: Initialize to an appropriate value
                System.Nullable<bool> actual;
                actual = ProdUI.AutomationPatterns.WindowPatternHelper_Accessor.WaitForInputIdle(control, delay);
                Assert.AreEqual(expected, actual);
            }
        
    }
}
