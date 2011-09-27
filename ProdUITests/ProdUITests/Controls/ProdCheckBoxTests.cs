using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.Controls.Windows;

namespace ProdUITests
{
    [TestFixture]
    class ProdCheckBoxTests
    {

        const string WIN_TITLE = "WPF Test Form";
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            window = new ProdWindow(WIN_TITLE);
        }

        [Test]
        public void GetCheckStateWhenChecked()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxA");
            check.SetCheckState(ToggleState.On);
            ToggleState ret = check.GetCheckState();

            Assert.That(ret, Is.EqualTo(ToggleState.On));
        }

        [Test]
        public void GetCheckStateWhenUnChecked()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxB");
            check.SetCheckState(ToggleState.Off);
            ToggleState ret = check.GetCheckState();

            Assert.That(ret, Is.EqualTo(ToggleState.Off));
        }

        public void GetCheckStateWhenIndeterminate()
        {
            ProdCheckBox check = new ProdCheckBox(window, "3StateCheckBox");
            check.SetCheckState(ToggleState.Indeterminate);
            ToggleState ret = check.GetCheckState();

            Assert.That(ret, Is.EqualTo(ToggleState.Indeterminate));
        }

        [Test]
        public void SetCheckStateOn()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxB");
            check.SetCheckState(ToggleState.On);

            Thread.Sleep(1000);

            Assert.That(check.GetCheckState(), Is.EqualTo(ToggleState.On));
        }

        [Test]
        public void SetCheckStateOff()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxB");
            check.SetCheckState(ToggleState.Off);

            Thread.Sleep(1000);

            Assert.That(check.GetCheckState(), Is.EqualTo(ToggleState.Off));
        }

        [Test]
        public void SetCheckStateIndeterminate()
        {
            ProdCheckBox check = new ProdCheckBox(window, "3StateCheckBox");
            check.SetCheckState(ToggleState.Indeterminate);

            Thread.Sleep(1000);

            Assert.That(check.GetCheckState(), Is.EqualTo(ToggleState.Indeterminate));
        }

        [Test]
        public void SetCheckStateIndeterminateUnsupported()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxA");
            check.SetCheckState(ToggleState.Indeterminate);

            Thread.Sleep(1000);

            Assert.That(check.GetCheckState(), Is.Not.EqualTo(ToggleState.Indeterminate));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetCheckStateEventNotification()
        {
            ProdCheckBox check = new ProdCheckBox(window, "testCheckBoxB");
            check.SetCheckState((ToggleState.On));

            Thread.Sleep(2000);
            Assert.That(check.EventVerified);
        }

        [Test, Description("Checking Toggle event by verifying its effect on UI")]
        public void ToggleCheckState()
        {
            ProdCheckBox check = new ProdCheckBox(window, "3StateCheckBox");

            ToggleState origState = check.GetCheckState();
            check.ToggleCheckState();
            ToggleState currentState = check.GetCheckState();

            Assert.AreNotEqual(origState, currentState);

        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void ToggleCheckStateEventNotification()//TODO SHould throw exception to IF UNSUPPORTED
        {
            ProdCheckBox check = new ProdCheckBox(window, "3StateCheckBox");
            check.ToggleCheckState();

            Thread.Sleep(2000);
            Assert.That(check.EventVerified);

        }
    }
}
