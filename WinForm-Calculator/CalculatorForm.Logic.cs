using System;
using System.Threading;
using Timer = System.Threading.Timer;

namespace WinForm_Calculator
{
    partial class CalculatorForm
    {
        private string _numberOne,
                       _numberTwo;
        private OperationType? _operationType;
        private bool _allowInput = true;
        
        private Timer _errorTimer;
        
        private void OnClickButton(int buttonVal)
        {
            if (!_allowInput) return;
            if (textBox1.Text != null && textBox1.Text == "0")  
            {  
                textBox1.Text = buttonVal + "";  
            }  
            else  
            {  
                textBox1.Text += buttonVal;  
            }  
        }

        private void OnClickOperationButton(OperationType operationType)
        {
            if (!_allowInput) return;
            _numberOne = textBox1.Text;
            textBox1.Text = "0";
            _operationType = operationType;
        }

        private void OnClickEquals()
        {
            if (!_allowInput) return;
            _numberTwo = textBox1.Text;
            
            // display number in place of current text
            string displayLine = "No Answer";

            try
            {
                displayLine = EvaluateAnswer(_numberOne, _numberTwo, _operationType) + "";
            }
            catch (ArgumentException e)
            {
                // Nasty looking code to set back to numbers after 2 seconds
                if (_errorTimer == null)
                {
                    _errorTimer = new Timer(state =>
                    {
                        OnClickClearButton();
                    }, null, 2_000, Timeout.Infinite);
                }
                else
                {
                    _errorTimer.Change(2_000, Timeout.Infinite);
                }
                
                displayLine = e.Message;
            }
            
            textBox1.Text = displayLine;
        }

        private void OnClickClearButton()
        {
            _numberOne = null;
            _numberTwo = null;
            _operationType = null;
            textBox1.Text = "0";
            _allowInput = true;
        }

        private int EvaluateAnswer(string numberOne, string numberTwo, OperationType? operationType)
        {
            if (operationType == null) throw new ArgumentException("No Operation Set");

            bool validNum = Int32.TryParse(numberOne, out int numOne);
            validNum &= Int32.TryParse(numberTwo, out int numTwo);
            
            if (!validNum) throw new ArgumentException("An invalid number was given");

            int answer = 0;
            
            switch (operationType)
            {
                case OperationType.ADD:
                    answer = numOne + numTwo;
                    break;
                case OperationType.SUBTRACT:
                    answer = numOne - numTwo;
                    break;
                case OperationType.DIVIDE:
                    if (numOne == 0 && numTwo == 0) throw new ArgumentException("Cannot divide zero by zero");
                    answer = numOne / numTwo;
                    break;
                case OperationType.MULTIPLY:
                    answer = numOne * numTwo;
                    break;
            }

            return answer;
        }
    }

    public enum OperationType
    {
        ADD, SUBTRACT, DIVIDE, MULTIPLY
    }
}