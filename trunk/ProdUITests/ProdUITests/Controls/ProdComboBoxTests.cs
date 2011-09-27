using System.Collections;
using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;
using ProdUI.Controls.Windows;
using ProdUI.Interaction.UIAPatterns;

namespace ProdUITests
{
    [TestFixture]
    class ProdComboBoxTests
    {
        const string WIN_TITLE = "WPF Test Form";
        private static ProdWindow window;

        [SetUp]
        public static void Init()
        {
            window = new ProdWindow(WIN_TITLE);
        }

        [Test]
        public void GetItemCount()
        {
            /* there are currently 3 items in the test-forms ComboBox */
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");


            Assert.That(3, Is.EqualTo(combo.GetItemCount()));
        }

        [Test]
        public void GetSelectedItem([Values("New", "Old", "Used")] string itemText)
        {
            /* Initially, the selected Items text is "New" (index 0) */
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedItem(itemText);

            Assert.That(combo.GetSelectedItem().Current.Name, Is.EqualTo(itemText));
        }

        [Test]
        public void GetSelectedIndex([Values(1, 2, 0)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedIndex(index);

            Assert.That(combo.GetSelectedIndex(), Is.EqualTo(index));
        }

        [Test]
        public void SetSelectedIndex([Values(1, 2, 0)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedIndex(index);

            int ret = combo.GetSelectedIndex();
            Assert.That(ret, Is.EqualTo(index));
        }

        [Test, Description("Tests to see if invalid indexes will throw")]
        public void SetSelectedIndexFail([Values(-1, 3)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedIndex(index);

            int ret = combo.GetSelectedIndex();
            Assert.That(ret, Is.EqualTo(index));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetSelectedIndexEventNotification([Values(1, 2, 0)] int index)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedIndex(index);

            Thread.Sleep(2000);
            Assert.That(combo.EventVerified);
        }

        [Test]
        public void SetSelectedItem([Values("New", "Old", "Used")] string itemText)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedItem(itemText);

            Assert.That(combo.GetSelectedItem().Current.Name, Is.EqualTo(itemText));
        }

        [Test, Description("Checks to see selection of item in list")]
        public void SetSelectedItemFail([Values("Nuts")] string itemText)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedItem(itemText);

            Assert.That(combo.GetSelectedItem().Current.Name, Is.EqualTo(itemText));
        }

        [Test, Description("Verifying the the UIA event was fired")]
        public void SetSelectedItemEventNotification([Values("New", "Old", "Used")] string itemText)
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedItem(itemText);

            Thread.Sleep(2000);
            Assert.That(combo.EventVerified);
        }

        [Test]
        public void IsSelectedByIndex()
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedItem("New");

            Assert.That(combo.IsSelected(0));
        }

        [Test]
        public void IsSelectedByText()
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            combo.SetSelectedItem("New");

            Assert.That(combo.IsSelected("New"));
        }

        [Test]
        public void GetItems()//Note: This is bordering on redundancy.
        {
            ArrayList hardCodedItems = new ArrayList() { "New", "Old", "Used" };

            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            Assert.AreEqual(hardCodedItems, combo.GetItems());
        }

        #region Textbox Methods

        [Test]
        public void Length()
        {
            const string testString = "Random Text";
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");

            /* Make sure ComboBox supports this pattern */
            object pattern;
            Assert.That(combo.UIAElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern), Is.True, "Control doesnt support ValuePattern");

            combo.SetText(testString);

            string result = combo.GetText();
            Assert.That(result.Length, Is.EqualTo(testString.Length));
        }

        [Test]
        public void GetText()
        {
            const string testString = "Random Text two";
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");

            /* Make sure ComboBox supports this pattern */
            object pattern;
            Assert.That(combo.UIAElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern), Is.True, "Control doesnt support ValuePattern");

            ValuePatternHelper.SetValue(combo.UIAElement, testString);

            string result = combo.GetText();
            Assert.That(result, Is.EqualTo(testString));
        }

        [Test]
        public void SetText()
        {
            const string testString = "Random Text three";
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");

            /* Make sure ComboBox supports this pattern */
            object pattern;
            Assert.That(combo.UIAElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern), Is.True, "Control doesnt support ValuePattern");

            combo.SetText(testString);

            string currentText = combo.GetText();

            Assert.That(currentText,Is.EqualTo(testString));

        }

        [Test]
        public void SetTextEventNotification()
        {
            const string testString = "Random Text three";
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");

            /* Make sure ComboBox supports this pattern */
            object pattern;
            Assert.That(combo.UIAElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern), Is.True, "Control doesnt support ValuePattern");

            combo.SetText(testString);

            Thread.Sleep(2000);
            Assert.That(combo.EventVerified);

        }

        [Test]
        public void Clear()
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");

            /* Make sure ComboBox supports this pattern */
            object pattern;
            Assert.That(combo.UIAElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern), Is.True, "Control doesnt support ValuePattern");

            combo.Clear();

            string result = combo.GetText();

            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public void ClearEventNotification()
        {
            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");

            /* Make sure ComboBox supports this pattern */
            object pattern;
            Assert.That(combo.UIAElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern), Is.True, "Control doesnt support ValuePattern");

            combo.Clear();

            Thread.Sleep(2000);
            Assert.That(combo.EventVerified);
        }

        [Test]
        public void AppendText()
        {
            const string testString = " Appended";

            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");

            /* Make sure ComboBox supports this pattern */
            object pattern;
            Assert.That(combo.UIAElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern), Is.True, "Control doesnt support ValuePattern");

            string original = ValuePatternHelper.GetValue(combo.UIAElement);
            combo.AppendText(testString);

            string newString = ValuePatternHelper.GetValue(combo.UIAElement);

            Assert.That(newString, Is.EqualTo(original + testString));
        }

        [Test]
        public void AppendTextEventNotification()
        {
            const string testString = " Appended";

            ProdComboBox combo = new ProdComboBox(window, "comboBoxTest");
            object pattern;
            Assert.That(combo.UIAElement.TryGetCurrentPattern(ValuePattern.Pattern, out pattern), Is.True, "Control doesnt support ValuePattern");

            combo.AppendText(testString);

            Thread.Sleep(2000);
            Assert.That(combo.EventVerified);
        }

        #endregion
    }
}
