using System.Threading;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;

namespace ProdUITests
{
    [TestFixture]
    class ProdRadioButtonTests
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
        public void GetCheckedWhenChecked()
        {
            ProdRadioButton radio = new ProdRadioButton(window, "radioButtonTestB");
            SelectionPatternHelper.Select(radio.ThisElement);

            Assert.That(radio.GetChecked(),Is.EqualTo(true));
        }

        [Test]
        public void GetCheckedWhenUnChecked()
        {
            ProdRadioButton radio = new ProdRadioButton(window, "radioButtonTestA");
            ProdRadioButton radioB = new ProdRadioButton(window, "radioButtonTestB");
            radio.Select();

            Assert.That(!radioB.GetChecked());
        }


        [Test]
        public void Select()
        {
            ProdRadioButton radio = new ProdRadioButton(window, "radioButtonTestC");
            radio.Select();

            Assert.That(radio.GetChecked(), Is.EqualTo(true));
        }

        [Test]
        public void SelectEventNotification()
        {
            ProdRadioButton radio = new ProdRadioButton(window, "radioButtonTestA");
            ProdRadioButton radioB = new ProdRadioButton(window, "radioButtonTestB");
            radio.Select();
            Thread.Sleep(200);
            radioB.Select();

            Thread.Sleep(2000);
            Assert.That(radioB.eventTriggered, Is.True);
        }
    }
}
