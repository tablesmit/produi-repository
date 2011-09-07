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
    class ProdSliderTests
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
            ///A test for ProdSlider Constructor
            ///</summary>
            [Test]
            public void ProdSliderConstructorTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdSlider target = new ProdUI.Controls.ProdSlider(prodWindow, controlHandle);
                Assert.Inconclusive("TODO: Implement code to verify target");
            }

            /// <summary>
            ///A test for ProdSlider Constructor
            ///</summary>
            [Test]
            public void ProdSliderConstructorTest1()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                int treePosition = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdSlider target = new ProdUI.Controls.ProdSlider(prodWindow, treePosition);
                Assert.Inconclusive("TODO: Implement code to verify target");
            }

            /// <summary>
            ///A test for ProdSlider Constructor
            ///</summary>
            [Test]
            public void ProdSliderConstructorTest2()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdSlider target = new ProdUI.Controls.ProdSlider(prodWindow, automationId);
                Assert.Inconclusive("TODO: Implement code to verify target");
            }

            /// <summary>
            ///A test for GetLargeChange
            ///</summary>
            [Test]
            public void GetLargeChangeTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdSlider target = new ProdUI.Controls.ProdSlider(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = target.GetLargeChange();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetMaxValue
            ///</summary>
            [Test]
            public void GetMaxValueTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdSlider target = new ProdUI.Controls.ProdSlider(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = target.GetMaxValue();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetMinValue
            ///</summary>
            [Test]
            public void GetMinValueTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdSlider target = new ProdUI.Controls.ProdSlider(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = target.GetMinValue();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetSmallChange
            ///</summary>
            [Test]
            public void GetSmallChangeTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdSlider target = new ProdUI.Controls.ProdSlider(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = target.GetSmallChange();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for GetValue
            ///</summary>
            [Test]
            public void GetValueTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdSlider target = new ProdUI.Controls.ProdSlider(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
                double expected = 0F; // TODO: Initialize to an appropriate value
                double actual;
                actual = target.GetValue();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            /// <summary>
            ///A test for SetValue
            ///</summary>
            [Test]
            public void SetValueTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdSlider target = new ProdUI.Controls.ProdSlider(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
                double value = 0F; // TODO: Initialize to an appropriate value
                target.SetValue(value);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }
        
    }
}
