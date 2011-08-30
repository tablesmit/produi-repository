using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;

namespace ProdUITests
{
    [TestFixture]
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
            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            ValuePatternHelper.SetValue(edit.ThisElement, testString);
            string result = edit.GetText();

            Assert.That(result.Length, Is.EqualTo(testString.Length));
        }

        [Test]
        public void GetText()
        {
            const string testString = "Random Text";
            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            ValuePatternHelper.SetValue(edit.ThisElement, testString);

            string result = edit.GetText();
            Assert.That(result, Is.EqualTo(testString));
        }

        [Test]
        public void SetText()
        {
            const string testString = "Random Text three";
            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            edit.SetText(testString);

            string currentText = ValuePatternHelper.GetValue(edit.ThisElement);

            Assert.That(currentText, Is.EqualTo(testString));

        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetTextEventNotification()
        {
            const string testString = "Random Text three";
            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            edit.SetText(testString);

            Thread.Sleep(2000);
            Assert.That(edit.eventTriggered, Is.True);

        }

        [Test]
        public void Clear()
        {
            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            edit.Clear();

            string result = ValuePatternHelper.GetValue(edit.ThisElement);

            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void ClearEventNotification()
        {
            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            edit.Clear();

            Thread.Sleep(2000);
            Assert.That(edit.eventTriggered, Is.True);
        }

        [Test]
        public void AppendText()
        {
            const string testString = " Appended";

            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            string original = ValuePatternHelper.GetValue(edit.ThisElement);
            edit.AppendText(testString);

            string newString = ValuePatternHelper.GetValue(edit.ThisElement);

            Assert.That(newString, Is.EqualTo(original + testString));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void AppendTextEventNotification()
        {
            const string testString = " Appended";

            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            edit.AppendText(testString);

            Thread.Sleep(2000);
            Assert.That(edit.eventTriggered, Is.True);
        }

        [Test]
        public void InsertText()
        {
            const string testString = " Inserted ";
            const string targetstring = "Here is some Inserted base text";
            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            edit.SetText("Here is some base text");
            int len = edit.GetLength();
            edit.InsertText(testString, len - 9);

            Assert.That(edit.GetText(), Is.EqualTo(targetstring));

        }

        [Test]
        public void InsertTextFail()
        {
            const string testString = " Inserted ";
            const string targetstring = "Here is";
            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            edit.SetText("Here is");
            int len = edit.GetLength();
            edit.InsertText(testString, len - 9);

            Assert.That(edit.GetText(), Is.EqualTo(targetstring));

        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void InsertTextEventNotification()
        {
            const string testString = " Inserted ";
            const string targetstring = "Here is some Inserted base text";

            ProdEdit edit = new ProdEdit(window, "textBoxTest");
            edit.SetText(targetstring);
            int len = edit.GetLength();

            edit.InsertText(testString, len);

            Thread.Sleep(2000);
            Assert.That(edit.eventTriggered, Is.True);

        }

        [Test]
        public void PasteFromClipboard()
        {
            const string cptxt = "Clipboard Text";
            Clipboard.SetText(cptxt);
            ProdEdit edit = new ProdEdit(window, "textBoxTest");

            edit.SetText(Clipboard.GetText());

            Assert.That(edit.GetText(), Is.EqualTo(cptxt));
        }

        [Test]
        public void PasteFromClipboardInvalidDataType()
        {

            ProdEdit edit = new ProdEdit(window, "textBoxTest");
            Clipboard.SetDataObject(edit);

            edit.SetText(Clipboard.GetText());
        }
    }
}
