using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;

namespace ProdUITests
{
    [TestFixture,RequiresSTA]
    class ProdEditTests
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
        public void GetLength()
        {
            const string testString = "Random Text";
            ProdEdit edit = new ProdEdit(window, "textBoxText");

            ValuePatternHelper.SetValue(edit.ThisElement, testString);
            string result = edit.GetText();

            Assert.That(result.Length, Is.EqualTo(testString.Length));
        }

        [Test]
        public void GetText()
        {
            const string testString = "Random Text";
            ProdEdit edit = new ProdEdit(window, "textBoxText");

            ValuePatternHelper.SetValue(edit.ThisElement, testString);

            string result = edit.GetText();
            Assert.That(result, Is.EqualTo(testString));
        }

        [Test]
        public void SetText()
        {
            const string testString = "Random Text three";
            ProdEdit edit = new ProdEdit(window, "textBoxText");

            edit.SetText(testString);

            string currentText = ValuePatternHelper.GetValue(edit.ThisElement);

            Assert.That(currentText, Is.EqualTo(testString));

        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetTextEventNotification()
        {
            const string testString = "Random Text three";
            ProdEdit edit = new ProdEdit(window, "textBoxText");

            edit.SetText(testString);

            Thread.Sleep(2000);
            Assert.That(edit.eventTriggered, Is.True);

        }

        [Test]
        public void Clear()
        {
            ProdEdit edit = new ProdEdit(window, "textBoxText");

            edit.Clear();

            string result = ValuePatternHelper.GetValue(edit.ThisElement);

            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public void ClearEventNotification()
        {
            ProdEdit edit = new ProdEdit(window, "textBoxText");
            Thread.Sleep(500);
            edit.SetText("targetstring");
            edit.Clear();

            Thread.Sleep(2000);
            Assert.That(edit.eventTriggered);
        }

        [Test]
        public void AppendText()
        {
            const string testString = " Appended";

            ProdEdit edit = new ProdEdit(window, "textBoxText");

            string original = ValuePatternHelper.GetValue(edit.ThisElement);
            int len = original.Length;

            edit.AppendText(testString);

            string newString = ValuePatternHelper.GetValue(edit.ThisElement);
            int newlen = len + 9;

            Assert.That(newString.Length == newlen);
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void AppendTextEventNotification()
        {
            const string testString = " Appended";

            ProdEdit edit = new ProdEdit(window, "textBoxText");

            edit.AppendText(testString);

            Thread.Sleep(2000);
            Assert.That(edit.eventTriggered);
        }

        [Test]
        public void InsertText()
        {
            const string testString = " Inserted ";
            const string targetstring = "Here is some base text";
            
            ProdEdit edit = new ProdEdit(window, "textBoxText");

            edit.SetText(targetstring);
            int len = edit.GetLength();

            edit.InsertText(testString, len - 9);
            int newL = edit.GetText().Length;
            int t = newL - testString.Length;
            Assert.That(t == len);
        }

        [Test]
        [ExpectedException("System.ArgumentOutOfRangeException")]
        public void InsertTextFail()
        {
            const string testString = " Inserted ";
            const string targetstring = "Here is";
            ProdEdit edit = new ProdEdit(window, "textBoxText");

            edit.SetText("Here is");
            int len = edit.GetLength();
            edit.InsertText(testString, len - 9);

        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void InsertTextEventNotification()
        {
            const string testString = " Inserted ";
            const string targetstring = "Here is some Inserted base text";

            ProdEdit edit = new ProdEdit(window, "textBoxText");
            edit.SetText(targetstring);
            int len = edit.GetLength();
            Thread.Sleep(500);
            edit.InsertText(testString, len);

            Thread.Sleep(2000);
            Assert.That(edit.eventTriggered);

        }

        [Test]
        public void PasteFromClipboard()
        {
            const string cptxt = "Clipboard Text";
            Clipboard.SetText(cptxt);
            ProdEdit edit = new ProdEdit(window, "textBoxText");

            edit.SetText(Clipboard.GetText());

            Assert.That(edit.GetText(), Is.EqualTo(cptxt));
        }

        [Test]
        public void PasteFromClipboardInvalidDataType()
        {
            ProdEdit edit = new ProdEdit(window, "textBoxText");
            Clipboard.SetDataObject(edit);

            edit.SetText(Clipboard.GetText());
        }
    }
}
