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
            if (empNum.Text == "" || firstName.Text == "" || surname.Text == "" || basicRate.Text == "" || basicNumhrs.Text == "")
            {
                MessageBox.Show("Please fill out the Employee Details and Basic Pay.", "Input Required");
                return;
            }

            try
            {
                double basicRatePerHour = double.Parse(basicRate.Text);
                double basicHoursWorked = double.Parse(basicNumhrs.Text);
                double totalBasicIncome = basicRatePerHour * basicHoursWorked;

                basicIncome.Text = totalBasicIncome.ToString("0.00");

                double honorariumRate = 0;
                double honorariumHours = 0;
                if (honoRate.Text != "") honorariumRate = double.Parse(honoRate.Text);
                if (honoNumhrs.Text != "") honorariumHours = double.Parse(honoNumhrs.Text);

                double totalHonorariumIncome = honorariumRate * honorariumHours;

                honoIncome.Text = totalHonorariumIncome.ToString("0.00");

                double otherRatePerHour = 0;
                double otherHoursWorked = 0;
                if (otherRate.Text != "") otherRatePerHour = double.Parse(otherRate.Text);
                if (otherNumhrs.Text != "") otherHoursWorked = double.Parse(otherNumhrs.Text);

                double totalOtherIncome = otherRatePerHour * otherHoursWorked;

                otherIncome.Text = totalOtherIncome.ToString("0.00");

                double overallGrossIncome = totalBasicIncome + totalHonorariumIncome + totalOtherIncome;

                grossIncome.Text = overallGrossIncome.ToString("0.00");

                double sssContributionValue = 0;
                double philHealthValue = 0;
                double pagibigContributionValue = 0;
                double calculatedTaxAmount = overallGrossIncome * 0.01;

                if (sssContrib.Text != "") sssContributionValue = double.Parse(sssContrib.Text);
                if (ph.Text != "") philHealthValue = double.Parse(ph.Text);
                if (pagibigContrib.Text != "") pagibigContributionValue = double.Parse(pagibigContrib.Text);

                tax.Text = calculatedTaxAmount.ToString("0.00");

                double sssLoanValue = 0;
                double pagibigLoanValue = 0;
                double facultySavingsDepositValue = 0;
                double facultySavingsLoanValue = 0;
                double salaryLoanValue = 0;
                double miscellaneousDeductionsValue = 0;

                if (sssLoan.Text != "") sssLoanValue = double.Parse(sssLoan.Text);
                if (pagibigLoan.Text != "") pagibigLoanValue = double.Parse(pagibigLoan.Text);
                if (fsDeposit.Text != "") facultySavingsDepositValue = double.Parse(fsDeposit.Text);
                if (fsLoan.Text != "") facultySavingsLoanValue = double.Parse(fsLoan.Text);
                if (salaryLoan.Text != "") salaryLoanValue = double.Parse(salaryLoan.Text);
                if (others_txtbox.Text != "") miscellaneousDeductionsValue = double.Parse(others_txtbox.Text);

                double totalDeductionsAmount =
                    sssContributionValue + philHealthValue +
                    pagibigContributionValue + calculatedTaxAmount +
                    sssLoanValue + pagibigLoanValue +
                    facultySavingsDepositValue + facultySavingsLoanValue +
                    salaryLoanValue + miscellaneousDeductionsValue;

                totalDeduc.Text = totalDeductionsAmount.ToString("0.00");

                double finalNetIncomeValue = overallGrossIncome - totalDeductionsAmount;
                netIncome.Text = finalNetIncomeValue.ToString("0.00");
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input detected. Please enter numbers only.", "Format Error");
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