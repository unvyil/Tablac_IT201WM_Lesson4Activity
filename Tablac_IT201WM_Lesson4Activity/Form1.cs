using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tablac_IT201WM_Lesson4Activity
{
    public partial class Form1 : Form
    {
        string picpath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            others_cb.Items.Clear();
            others_cb.Items.Add("Other 1");
            others_cb.Items.Add("Other 2");
            others_cb.Items.Add("Other 3");
            others_cb.Items.Add("Other 4");
            others_cb.Text = "Select other deduction";

            cancelBtn.PerformClick();
            empNum.Focus();
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            if (empNum.Text == "" || basicRate.Text == "")
            {
                MessageBox.Show("Please fill in Employee Number and Basic Rate.", "Missing Data");
                return;
            }

            try
            {
                double rate = double.Parse(basicRate.Text);
                double hours = double.Parse(basicNumhrs.Text);
                double basicTotal = rate * hours;
                basicIncome.Text = basicTotal.ToString("0.00");

                double hRate = 0;
                double hHours = 0;
                if (honoRate.Text != "") hRate = double.Parse(honoRate.Text);
                if (honoNumhrs.Text != "") hHours = double.Parse(honoNumhrs.Text);
                double honoTotal = hRate * hHours;
                honoIncome.Text = honoTotal.ToString("0.00");

                double oRate = 0;
                double oHours = 0;
                if (otherRate.Text != "") oRate = double.Parse(otherRate.Text);
                if (otherNumhrs.Text != "") oHours = double.Parse(otherNumhrs.Text);
                double otherTotal = oRate * oHours;
                otherIncome.Text = otherTotal.ToString("0.00");

                double gross = basicTotal + honoTotal + otherTotal;
                grossIncome.Text = gross.ToString("0.00");

                double taxAmount = gross * 0.01;
                tax.Text = taxAmount.ToString("0.00");

                double sssValue = 0;
                double phValue = 0;
                double pagValue = 0;
                if (sssContrib.Text != "") sssValue = double.Parse(sssContrib.Text);
                if (ph.Text != "") phValue = double.Parse(ph.Text);
                if (pagibigContrib.Text != "") pagValue = double.Parse(pagibigContrib.Text);

                double sssL = 0;
                double pagL = 0;
                double fDep = 0;
                double fLoan = 0;
                double salL = 0;
                double othD = 0;

                if (sssLoan.Text != "") sssL = double.Parse(sssLoan.Text);
                if (pagibigLoan.Text != "") pagL = double.Parse(pagibigLoan.Text);
                if (fsDeposit.Text != "") fDep = double.Parse(fsDeposit.Text);
                if (fsLoan.Text != "") fLoan = double.Parse(fsLoan.Text);
                if (salaryLoan.Text != "") salL = double.Parse(salaryLoan.Text);
                if (others_txtbox.Text != "") othD = double.Parse(others_txtbox.Text);

                double totalDeductions = sssValue + phValue + pagValue + taxAmount + sssL + pagL + fDep + fLoan + salL + othD;
                totalDeduc.Text = totalDeductions.ToString("0.00");

                double net = gross - totalDeductions;
                netIncome.Text = net.ToString("0.00");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter numbers only.", "Error");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            basicRate.Text = "0.00"; basicNumhrs.Text = "0.00"; basicIncome.Text = "0.00";
            honoRate.Text = "0.00"; honoNumhrs.Text = "0.00"; honoIncome.Text = "0.00";
            otherRate.Text = "0.00"; otherNumhrs.Text = "0.00"; otherIncome.Text = "0.00";
            sssContrib.Text = "0.00"; ph.Text = "0.00"; pagibigContrib.Text = "0.00"; tax.Text = "0.00";
            sssLoan.Text = "0.00"; pagibigLoan.Text = "0.00"; fsDeposit.Text = "0.00";
            fsLoan.Text = "0.00"; salaryLoan.Text = "0.00"; others_txtbox.Text = "0.00";
            totalDeduc.Text = "0.00"; grossIncome.Text = "0.00"; netIncome.Text = "0.00";
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            empNum.Clear();
            firstName.Clear();
            midName.Clear();
            surname.Clear();
            civilStatus.Clear();
            desig.Clear();
            numDependent.Clear();
            empStatus.Clear();
            deptName.Clear();

            // run cancel button
            cancelBtn.PerformClick();

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            empNum.Focus();
        }

        private void others_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (others_cb.Text == "Other 1") { others_txtbox.Text = "1000.00"; }
            else if (others_cb.Text == "Other 2") { others_txtbox.Text = "23.00"; }
            else if (others_cb.Text == "Other 3") { others_txtbox.Text = "500.00"; }
            else { others_txtbox.Text = "0.00"; }
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picpath = ofd.FileName;
                pictureBox1.Image = Image.FromFile(picpath);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}