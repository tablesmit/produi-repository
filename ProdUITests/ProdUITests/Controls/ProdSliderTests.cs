using NUnit.Framework;
using ProdUI.Controls.Windows;

namespace ProdUITests
{
    [TestFixture]
    class ProdSliderTests
    {
        const string WIN_TITLE = "WPF Test Form";
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            window = new ProdWindow(WIN_TITLE);
        }



            /// <summary>
            ///A test for GetLargeChange
            ///</summary>
            [Test]
            public void GetLargeChangeTest()
            {

                ProdSlider target = new ProdSlider(window, "sliderTest");
                double expected = 0F;
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
                ProdSlider target = new ProdSlider(window, "sliderTest");              
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
                ProdSlider target = new ProdSlider(window, "sliderTest");
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
                ProdSlider target = new ProdSlider(window, "sliderTest");
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
                double expected = 2.0F;

                ProdSlider target = new ProdSlider(window, "sliderTest");
                target.SetValue(expected);

                double actual = target.GetValue();
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            ///A test for SetValue
            ///</summary>
            [Test]
            public void SetValueTest()
            {
                ProdSlider target = new ProdSlider(window, "sliderTest");
                double value = 0F; // TODO: Initialize to an appropriate value
                target.SetValue(value);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }
        
    }
}
