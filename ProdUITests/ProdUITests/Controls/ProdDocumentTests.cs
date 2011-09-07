using NUnit.Framework;
using ProdUI.Controls;
using ProdUI.Session;

namespace ProdUITests
{
    [TestFixture]
    class ProdDocumentTests
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


            [Test]
            public void ProdDocumentConstructorTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdDocument target = new ProdUI.Controls.ProdDocument(prodWindow, controlHandle);
                Assert.Inconclusive("TODO: Implement code to verify target");
            }

            [Test]
            public void ProdDocumentConstructorTest1()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                int treePosition = 0; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdDocument target = new ProdUI.Controls.ProdDocument(prodWindow, treePosition);
                Assert.Inconclusive("TODO: Implement code to verify target");
            }

            [Test]
            public void ProdDocumentConstructorTest2()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                string automationId = string.Empty; // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdDocument target = new ProdUI.Controls.ProdDocument(prodWindow, automationId);
                Assert.Inconclusive("TODO: Implement code to verify target");
            }

            [Test]
            public void GetAllTextTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdDocument target = new ProdUI.Controls.ProdDocument(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
                System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = target.GetAllText(control);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            [Test]
            public void GetMultiSelectedTextTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdDocument target = new ProdUI.Controls.ProdDocument(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> expected = null; // TODO: Initialize to an appropriate value
                System.Collections.Generic.List<object> actual;
                actual = target.GetMultiSelectedText();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }

            [Test]
            public void GetSelectedTextTest()
            {
                ProdUI.Controls.ProdWindow prodWindow = null; // TODO: Initialize to an appropriate value
                System.IntPtr controlHandle = new System.IntPtr(); // TODO: Initialize to an appropriate value
                ProdUI.Controls.ProdDocument target = new ProdUI.Controls.ProdDocument(prodWindow, controlHandle); // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = target.GetSelectedText();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        
    }
}
