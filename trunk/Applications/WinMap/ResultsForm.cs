// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MapLib;

namespace WinMap
{
    /// <summary>
    /// Shows the results of a comparison of 2 maps
    /// </summary>
    public partial class ResultsForm : Form
    {
        private double _controlScore;
        private int _ctrlctr;
        private double _finalScore;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultsForm"/> class.
        /// </summary>
        public ResultsForm()
        {
            InitializeComponent();
            LoadedWindow = new MappedWindow();
            Results = new ArrayList();
        }

        public ArrayList Results { get; set; }

        public MappedWindow LoadedWindow { get; set; }

        private void DisplayResults()
        {
            _finalScore = (24 * Results.Count) * 10;
            foreach (List<CompareResult> items in Results)
            {
                if (_ctrlctr >= LoadedWindow.AllFormsControls.Count)
                {
                    break;
                }
                ListViewItem lv = new ListViewItem
                {
                    Text = @"Custom Id"
                };
                lv.SubItems.Add(LoadedWindow.AllFormsControls[_ctrlctr].CustomId);

                if (_ctrlctr % 2 == 0)
                    lv.BackColor = Color.LightGray;
                else
                    lv.BackColor = Color.White;

                LvResults.Items.Add(lv);

                CreateListItems(items);
                _ctrlctr++;
            }

            double avg = (_controlScore / _finalScore) * 100;
            LblWindowScore.Text = @"Window Result: " + (int)avg + @"%";
        }

        private void CreateListItems(IEnumerable<CompareResult> items)
        {
            foreach (CompareResult result in items)
            {
                int score = 24;

                ListViewItem lvi = new ListViewItem
                {
                    Text = result.Category
                };
                lvi.SubItems.Add(result.LoadedValue);
                lvi.SubItems.Add(result.LiveValue);
                lvi.SubItems.Add(result.Passed.ToString(CultureInfo.CurrentCulture));
                score += result.Score;

                if (_ctrlctr % 2 == 0)
                    lvi.BackColor = Color.LightGray;
                else
                    lvi.BackColor = Color.White;

                if (!result.Passed)
                {
                    lvi.BackColor = Color.Red;
                }

                LvResults.Items.Add(lvi);
                _controlScore += score;
            }
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            DisplayResults();
        }
    }
}