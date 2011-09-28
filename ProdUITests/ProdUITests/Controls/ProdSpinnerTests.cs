using System.Threading;
using NUnit.Framework;
using ProdUI.Controls.Windows;

//WPF does not have equivalent
namespace ProdUITests
{
    [TestFixture]
    class ProdSpinnerTests
    {
        const string WIN_TITLE = "Winforms Test Form";

        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            window = new ProdWindow(WIN_TITLE;
        }

        [Test]
        public void SetValue([Values(1.0, 12, 20)]double value)
        {
            ProdSpinner spin = new ProdSpinner(window, "testCheckBoxA");
            spin.SetValue(value);
            Assert.That(spin.GetValue(), Is.EqualTo(value));
        }

        [Test]
        public void SetValueEventNotification([Values(1.0, 12, 20)]double value)
        {
            ProdSpinner spin = new ProdSpinner(window, "testCheckBoxA");
            spin.SetValue(value);

            Thread.Sleep(2000);
            Assert.That(spin.EventVerified);
        }

        [Test]
        public void GetValue([Values(1.0, 12, 20)]double value)
        {
            ProdSpinner spin = new ProdSpinner(window, "testCheckBoxA");
            spin.SetValue(value);

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
