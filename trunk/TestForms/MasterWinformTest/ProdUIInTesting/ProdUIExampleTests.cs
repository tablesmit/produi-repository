using System.Windows.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdUI.Controls.Windows;

namespace ProdUIInTesting
{
    /* This is an example of using ProdUI in an MSTest Unit test */

    /// <summary>
    ///This is a test class for Form1Test and is intended
    ///to contain all Form1Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Form1Test
    {
        private TestContext testContextInstance;
        private static ProdWindow testWindow;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            /* Use this to get/set the working ProdWindow */
            testWindow = new ProdWindow("WinForms Sample");
        }


        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for button1_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MasterWinformTest.exe")]
        public void button1_ClickTest()
        {
            const string test = "123456789";
            ProdButton but1 = new ProdButton(testWindow,"Button1");
            ProdEdit maskedTextBox = new ProdEdit(testWindow, "maskedTextBoxTest");
            but1.Click();

            Assert.AreEqual(test, maskedTextBox.GetText());
        }

        /// <summary>
        ///A test for button2_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MasterWinformTest.exe")]
        public void button2_ClickTest()
        {

            ProdButton but2 = new ProdButton(testWindow, "button2");
            ProdCheckBox chk = new ProdCheckBox(testWindow,"checkBox3");
            but2.Click();

            Assert.IsTrue(chk.GetCheckState() == ToggleState.On);
        }
    }
}
