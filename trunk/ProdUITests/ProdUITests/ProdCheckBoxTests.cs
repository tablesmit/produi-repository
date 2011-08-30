using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;

namespace ProdUITests
{
    [TestFixture]
    class ProdCheckBoxTests
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
        public void GetCheckStateWhenChecked()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxA");
            TogglePatternHelper.SetToggleState(check.ThisElement, ToggleState.On);
            ToggleState ret = TogglePatternHelper.GetToggleState(check.ThisElement);

            Assert.That(ret, Is.EqualTo(ToggleState.On));
        }

        [Test]
        public void GetCheckStateWhenUnChecked()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxB");
            TogglePatternHelper.SetToggleState(check.ThisElement, ToggleState.Off);
            ToggleState ret = TogglePatternHelper.GetToggleState(check.ThisElement);

            Assert.That(ret, Is.EqualTo(ToggleState.Off));
        }

        public void GetCheckStateWhenIndeterminate()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxC");
            TogglePatternHelper.SetToggleState(check.ThisElement, ToggleState.Indeterminate);
            ToggleState ret = TogglePatternHelper.GetToggleState(check.ThisElement);

            Assert.That(ret, Is.EqualTo(ToggleState.Indeterminate));
        }

        [Test]
        public void SetCheckStateOn()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxB");
            TogglePatternHelper.SetToggleState(check.ThisElement, ToggleState.On);

            Thread.Sleep(1000);

            Assert.That(check.GetCheckState(), Is.EqualTo(ToggleState.On));
        }

        [Test]
        public void SetCheckStateOff()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxB");
            TogglePatternHelper.SetToggleState(check.ThisElement, ToggleState.Off);

            Thread.Sleep(1000);

            Assert.That(check.GetCheckState(), Is.EqualTo(ToggleState.Off));
        }

        [Test]
        public void SetCheckStateIndeterminate()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxC");
            TogglePatternHelper.SetToggleState(check.ThisElement, ToggleState.Indeterminate);

            Thread.Sleep(1000);

            Assert.That(check.GetCheckState(), Is.EqualTo(ToggleState.Indeterminate));
        }

        [Test]
        public void SetCheckStateIndeterminateUnsupported()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxA");
            TogglePatternHelper.SetToggleState(check.ThisElement, ToggleState.Indeterminate);

            Thread.Sleep(1000);

            Assert.That(check.GetCheckState(), Is.EqualTo(ToggleState.Indeterminate));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetCheckStateEventNotification()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxB");
            TogglePatternHelper.SetToggleState(check.ThisElement, ToggleState.Off);

            Thread.Sleep(2000);
            Assert.That(check.eventTriggered,Is.True);
        }

        [Test, Description("Checking Toggle event by verifying its effect on UI")]
        public void ToggleCheckState()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxC");

            ToggleState origState = check.GetCheckState();
            TogglePatternHelper.Toggle(check.ThisElement);
            ToggleState currentState = check.GetCheckState();

            Assert.AreEqual(origState, currentState);

        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void ToggleCheckStateEventNotification()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxC");

            ToggleState origState = check.GetCheckState();
            TogglePatternHelper.Toggle(check.ThisElement);

            Thread.Sleep(2000);
            Assert.That(check.eventTriggered, Is.True);

        }
    }
}
