using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
    public partial class Calculator2 : Form
    {
        public Calculator2()
        {
            InitializeComponent();
        }

        private double _result = 0;
        private string _operation = "";
        private bool _operationPerformed = false;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Calculator2_Load(object sender, EventArgs e)
        {

        }

        #region Number Button
        private void btn_number_Click(object sender, EventArgs e)
        {
            if (_operationPerformed)
            {
                textBoxDisplay.Clear();
                _operationPerformed = false;
            }
            Button button = (Button)sender;
            textBoxDisplay.Text += button.Text;
        }
        #endregion
        #region Operation Button
        private void btn_operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _operation = button.Text;
            _result = Convert.ToDouble(textBoxDisplay.Text);
            _operationPerformed = true;
            textBoxDisplay.Clear();
        }
        #endregion
        #region Equal_Operation
        private void btn_equal_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBoxDisplay.Text);
            double result = 0;


            switch (_operation)
            {
                case "+":
                    result = _result + num2;
                    break;
                case "-":
                    result = _result - num2;
                    break;
                case "*":
                    result = _result * num2;
                    break;
                case "/":
                    result = _result / num2;
                    break;
            }

            textBoxDisplay.Text = result.ToString();
            dataGridViewHistory.Rows.Add($"{_result} {_operation} {num2}", result);
            _operationPerformed = false;
        }

        private void btn_op_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _operation = button.Text;
            _result = Convert.ToDouble(textBoxDisplay.Text);
            _operationPerformed = true;
            textBoxDisplay.Clear();

            switch (comboBoxOperator.SelectedItem.ToString())
            {
                case "Plus (+)":
                    _operation = "+";
                    break;
                case "Minus (-)":
                    _operation = "-";
                    break;
                case "Multiply (*)":
                    _operation = "*";
                    break;
                case "Divide (/)":
                    _operation = "/";
                    break;
            }
        }

        #endregion
        #region Clear Button
        private void btn_clear_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Clear();
            dataGridViewHistory.Rows.Clear();
            _result = 0;
            _operation = "";
            _operationPerformed = false;
        }
        private void btn_c_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Clear();
            _result = 0;
            _operation = "";
            _operationPerformed = false;
        }

        #endregion
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.Title = "Save CSV File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (DataGridViewRow row in dataGridViewHistory.Rows)
                    {
                        string operation = row.Cells[0].Value.ToString();
                        string result = row.Cells[1].Value.ToString();
                        writer.WriteLine($"{operation},{result}");
                    }
                }
            } */
        }
    }
}
