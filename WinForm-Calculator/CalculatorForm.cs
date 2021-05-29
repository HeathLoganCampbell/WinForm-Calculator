using System;
using System.Windows.Forms;

namespace WinForm_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_n1_Click(object sender, EventArgs e)
        {
            OnClickButton(1);
        }

        private void btn_n2_Click(object sender, EventArgs e)
        {
            OnClickButton(2);
        }

        private void btn_n3_Click(object sender, EventArgs e)
        {
            OnClickButton(3);
        }

        private void btn_n4_Click(object sender, EventArgs e)
        {
            OnClickButton(4);
        }

        private void btn_n5_Click(object sender, EventArgs e)
        {
            OnClickButton(5);
        }

        private void btn_n6_Click(object sender, EventArgs e)
        {
            OnClickButton(6);
        }

        private void btn_n7_Click(object sender, EventArgs e)
        {
            OnClickButton(7);
        }

        private void btn_n8_Click(object sender, EventArgs e)
        {
            OnClickButton(8);
        }

        private void btn_n9_Click(object sender, EventArgs e)
        {
            OnClickButton(9);
        }

        private void btn_n0_Click(object sender, EventArgs e)
        {
            OnClickButton(0);
        }

       
        private void btn_add_Click(object sender, EventArgs e)
        {
            OnClickOperationButton(OperationType.ADD);
        }

        private void btn_subtract_Click(object sender, EventArgs e)
        {
            OnClickOperationButton(OperationType.SUBTRACT);
        }
        
        private void btn_multiply_Click(object sender, EventArgs e)
        {
            OnClickOperationButton(OperationType.MULTIPLY);
        }
        private void btn_divide_Click(object sender, EventArgs e)
        {
            OnClickOperationButton(OperationType.DIVIDE);
        }

        private void btn_equals_Click(object sender, EventArgs e)
        {
            OnClickEquals();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            OnClickClearButton();
        }
    }
}