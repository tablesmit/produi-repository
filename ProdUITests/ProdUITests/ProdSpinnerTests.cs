using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.AutomationPatterns;
using ProdUI.Controls;
using ProdUI.Session;
using ProdUI.Exceptions;

//WPF does not have equivelant
namespace ProdUITests
{
    [TestFixture]
    class ProdSpinnerTests
    {
        const string WIN_TITLE = "Winforms Test Form";
        private static ProdSession session;
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            session = new ProdSession("test.ses");
            window = new ProdWindow(WIN_TITLE, session.Loggers);
        }

        [Test]
        public void SetValue([Values(1.0, 12, 20)]double value)
        {
            ProdSpinner spin = new ProdSpinner(window, "testCheckBoxA");
            spin.SetValue(value);
            Assert.That(RangeValuePatternHelper.GetValue(spin.ThisElement), Is.EqualTo(value));
        }

        [Test]
        public void SetValueEventNotification([Values(1.0, 12, 20)]double value)
        {
            ProdSpinner spin = new ProdSpinner(window, "testCheckBoxA");
            spin.SetValue(value);

            Thread.Sleep(2000);
            Assert.That(spin.eventTriggered);
        }

        [Test]
        public void GetValue([Values(1.0, 12, 20)]double value)
        {
            ProdSpinner spin = new ProdSpinner(window, "testCheckBoxA");
            RangeValuePatternHelper.SetValue(spin.ThisElement, value);

            Assert.That(spin.GetValue(), Is.EqualTo(value));
        }

        [Test]
        public void GetMaxValue()
        {
            ProdSpinner spin = new ProdSpinner(window, "testCheckBoxA");
            Assert.That(spin.GetMaxValue(), Is.GreaterThan(0));
        }

        [Test]
        public void GetMinValue()
        {
            ProdSpinner spin = new ProdSpinner(window, "testCheckBoxA");
            Assert.That(spin.GetMinValue(), Is.GreaterThan(0));
        }

    }

}
