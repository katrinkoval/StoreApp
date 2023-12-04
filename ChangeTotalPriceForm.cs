using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApp_DB_
{
    public partial class ChangeTotalPriceForm : Form
    {
        public ChangeTotalPriceForm(int consignmentNumber)
        {
            InitializeComponent();

            titleConsignmentLabel.Text = string.Format("Consignment [{0}]", consignmentNumber);
        }

        private void ChangeTotalPriceForm_Load(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(percentageTextBox.Text))
            {
                MessageBox.Show("Input percentage");

                return;
            }

            if (double.Parse(percentageTextBox.Text) > 100.0)
            {
                MessageBox.Show("Incorrect percentage");

                return;
            }

            double percentage = double.Parse(percentageTextBox.Text);

            if (increaseCheckBox.Checked)
            {
                TotalPriceChangeManager.EventHandler(percentage, PriceChanging.Increase);
            }
            if(decreaseCheckBox.Checked)
            {
                TotalPriceChangeManager.EventHandler(percentage, PriceChanging.Decrease);
            }

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IncreaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(increaseCheckBox.Checked)
            {
                decreaseCheckBox.Checked = false;
            }
        }

        private void DecreaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(decreaseCheckBox.Checked)
            {
                increaseCheckBox.Checked = false;
            }
        }

        private void PercentageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
