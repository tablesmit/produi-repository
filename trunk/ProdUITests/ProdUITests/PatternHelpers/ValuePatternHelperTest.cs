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
    public class ValuePatternHelperTest
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
        ///A test for AppendValue
        ///</summary>
        [Test]
        public void AppendValueTest()
        {
            System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
            string newText = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = ProdUI.AutomationPatterns.ValuePatternHelper_Accessor.AppendValue(control, newText);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetValue
        ///</summary>
        [Test]
        public void GetValueTest()
        {
            System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ProdUI.AutomationPatterns.ValuePatternHelper_Accessor.GetValue(control);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InsertValue
        ///</summary>
        [Test]
        public void InsertValueTest()
        {
            System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
            string newText = string.Empty; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = ProdUI.AutomationPatterns.ValuePatternHelper_Accessor.InsertValue(control, newText, index);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SendKeysAppendText
        ///</summary>
        [Test]
        public void SendKeysAppendTextTest()
        {
            System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            ProdUI.AutomationPatterns.ValuePatternHelper_Accessor.SendKeysAppendText(control, text);
        }

        /// <summary>
        ///A test for SendKeysSetText
        ///</summary>
        [Test]
        public void SendKeysSetTextTest()
        {
            System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            ProdUI.AutomationPatterns.ValuePatternHelper_Accessor.SendKeysSetText(control, text);
        }

        /// <summary>
        ///A test for SetValue
        ///</summary>
        [Test]
        public void SetValueTest()
        {
            System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
            string newText = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = ProdUI.AutomationPatterns.ValuePatternHelper_Accessor.SetValue(control, newText);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for VerifyText
        ///</summary>
        [Test]
        public void VerifyTextTest()
        {
            System.Windows.Automation.AutomationElement control = null; // TODO: Initialize to an appropriate value
            string text = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = ProdUI.AutomationPatterns.ValuePatternHelper_Accessor.VerifyText(control, text);
            Assert.AreEqual(expected, actual);
        }
    }
}
