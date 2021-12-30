using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunctionPoint
{
    public partial class MainForm : Form
    {
        static int di ;
        int UFP;
        double tcf, fp;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public int Calc_UFP()
        {
            int sum = 0;

            // External input
            int EIs = Int32.Parse(textBox1.Text) * 3 + Int32.Parse(textBox2.Text) * 4 + Int32.Parse(textBox3.Text) * 6;

            //External output
            int EOs = Int32.Parse(textBox4.Text) * 4 + Int32.Parse(textBox5.Text) * 5 + Int32.Parse(textBox6.Text) * 7;

            // External Inquiries 
            int EQs = Int32.Parse(textBox7.Text) * 3 + Int32.Parse(textBox8.Text) * 4 + Int32.Parse(textBox9.Text) * 6;

            // External logical Files
            int ILFs = Int32.Parse(textBox10.Text) * 7 + Int32.Parse(textBox11.Text) * 10 + Int32.Parse(textBox12.Text) * 15;

            // External Interface Files 
            int EIFs = Int32.Parse(textBox13.Text) * 5 + Int32.Parse(textBox14.Text) * 7 + Int32.Parse(textBox15.Text) * 10;

            sum = EIs + EOs + EQs + ILFs + EIFs;

            return sum;
        }

        private void UFP_Btn2_Click(object sender, EventArgs e)
        {
            UFP = 0;
            UFP = Calc_UFP();
            UFP_res.Text = UFP.ToString();
        }
        private void DI_Btn3_Click(object sender, EventArgs e)
        {
            //Load DI Form and Get DI value from DI Form
            DIForm calc_DI_Form = new DIForm(this.textBox1.Text)
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            this.pnlFormLoader.Controls.Add(calc_DI_Form);
            calc_DI_Form.Show();
            calc_DI_Form.DataSent += di_DataSent;
            //Return to Main Form
            this.pnlFormLoader.Controls.Add(pnlMain);
        }

        private void di_DataSent (string di_Sum)
        {
            di = Int32.Parse(di_Sum);
            this.di_txt.Text = di.ToString();
        }

        private void TCF_btn4_Click(object sender, EventArgs e)
        {
            if (di_txt.Text.Length == 0)
            {
                MessageBox.Show("Enter DI or calculate it ", "Error");
                di_txt.Text = "0";
            }
            di_lbl.Text = di_txt.Text + " ) = ";
            tcf = 0.65 + (0.01 * Int32.Parse(di_txt.Text));
            tcf_txt.Text = tcf.ToString();
        }

        private void fp_btn_Click(object sender, EventArgs e)
        {
            fp = UFP * tcf;
            fp_txt.Text = fp.ToString();
        }

        private void LOC_Btn5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Choose a Programming language ", "Error");
            }
            int avc = Int32.Parse(Avctxt.Text);
            double Loc = Math.Ceiling(fp * avc);
            loc_txt.Text = Loc.ToString();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(220, 20, 60);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(24, 30, 54);
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Restart();           
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//programming language comboBox
        {
            if (comboBox1.SelectedItem.ToString() == "Assembly language :  320")
            {
                Avctxt.Text = "320";
            }

            if (comboBox1.SelectedItem.ToString() == "C :  128")
            {
                Avctxt.Text = "128";
            }


            if (comboBox1.SelectedItem.ToString() == "COBOL/Fortran :  105")
            {
                Avctxt.Text = "105";
            }


            if (comboBox1.SelectedItem.ToString() == "Pascal :  90")
            {
                Avctxt.Text = "90";
            }


            if (comboBox1.SelectedItem.ToString() == "Ada :  70")
            {
                Avctxt.Text = "70";
            }


            if (comboBox1.SelectedItem.ToString() == "C++ :  64")
            {
                Avctxt.Text = "64";
            }


            if (comboBox1.SelectedItem.ToString() == "Visual Basic :  32")
            {
                Avctxt.Text = "32";
            }

            if (comboBox1.SelectedItem.ToString() == "Object-Oriented Languages :  30")
            {
                Avctxt.Text = "30";
            }

            if (comboBox1.SelectedItem.ToString() == "Smalltalk :  22")
            {
                Avctxt.Text = "22";
            }

            if (comboBox1.SelectedItem.ToString() == "Code Generators (Power Builder) :  15")
            {
                Avctxt.Text = "15";
            }


            if (comboBox1.SelectedItem.ToString() == "SQL/Oracle :  12")
            {
                Avctxt.Text = "12";
            }

            if (comboBox1.SelectedItem.ToString() == "Spreadsheets :  6")
            {
                Avctxt.Text = "6";
            }

            if (comboBox1.SelectedItem.ToString() == "Graphical languages (icons) :  4")
            {
                Avctxt.Text = "4";
            }  
        }
    }
}
//Console.WriteLine("Let's Go");