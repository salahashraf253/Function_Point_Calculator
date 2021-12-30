using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunctionPoint
{
    public delegate void DataSentHandler(string di);
    public partial class DIForm : Form
    {
        public event DataSentHandler DataSent;

        const int SIZE = 14;
        int[] di = new int[14];
        public static int sum_DI = 0;

        public DIForm(string sum)
        {
            InitializeComponent();
            sum = textBox1.Text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            add_Rows_TCF();
            dataGridView1.RowCount = 14;
        }

        private void add_Rows_TCF()
        {
            //Add Rows to DataGridView

            ArrayList row = new ArrayList();
            row.Add("Data Communication");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Distribution Data Processing");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Perfomance Criteria");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("heavily Utilized Hardware");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("High Transaction Rates");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Online Data Entery");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Online Updating");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("End-user Efficiency");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Complex Computations");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Ruesability");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Ease of Installation");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Ease of Opeartion");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Portability");
            dataGridView1.Rows.Add(row.ToArray());

            row = new ArrayList();
            row.Add("Maintainabilty");
            dataGridView1.Rows.Add(row.ToArray());
        }

        int TCF_Value(int col)
        {
            //Assign values from 0 to 5 to Checked Cell based on col index
            int value;
            switch (col)
            {
                case 1:
                    value = 0;
                    break;
                case 2:
                    value = 1;
                    break;
                case 3:
                    value = 2;
                    break;
                case 4:
                    value = 3;
                    break;
                case 5:
                    value = 4;
                    break;
                case 6:
                    value = 5;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get current col and row index for checked cell
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            //Keep all other checkboxes unchecked (value = false)
            for (int i = 1; i <= 6; i++)
            {
                if (colIndex != i)
                    dataGridView1.Rows[rowIndex].Cells[i].Value = false;
            }
            //Add TCF value to DI array
            di[rowIndex] = TCF_Value(colIndex);
        }

        private void calc_DI_Btn_Click(object sender, EventArgs e)
        {
            sum_DI = 0;
            for (int i = 0; i < 14; i++)
            {
                sum_DI += di[i];
            }
            textBox1.Text = sum_DI.ToString();
            //Send DI value to Main Form and Close this form after 700 ms
            Task.Delay(700).Wait();
            this.DataSent(textBox1.Text);
            this.Close();
        }

        private void back_Btn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
