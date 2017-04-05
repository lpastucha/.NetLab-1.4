using System;
using System.Text;
using System.Windows.Forms;

namespace Kalkulator
{
    

    public partial class Form1 : Form
    {
        private enum Operacja
        {
            ADD,ODD,DIV,MULT,SQRT,POW,EQUALS,NONE
        }

        private StringBuilder valueBuildier = new StringBuilder();
        
        private Operacja selectedOperation = Operacja.NONE;

        private Double memoryResult;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            AppendValue("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AppendValue("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AppendValue("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AppendValue("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AppendValue("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AppendValue("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AppendValue("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AppendValue("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AppendValue("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AppendValue("9");
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (!valueBuildier.ToString().Contains(","))
            {
                if (valueBuildier.ToString().Equals("0") || valueBuildier.ToString().Equals(""))
                {
                    valueBuildier.Append("0,");
                }
                else
                    valueBuildier.Append(",");

                resultBox.Text = valueBuildier.ToString(); 
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            valueBuildier.Clear();
            resultBox.Clear();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            CalculateWithCondition();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CalculateWithCondition();
            selectedOperation = Operacja.ADD;
        }

        private void btnOdd_Click(object sender, EventArgs e)
        {
            CalculateWithCondition();
            selectedOperation = Operacja.ODD;
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            CalculateWithCondition();
            selectedOperation = Operacja.MULT;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            CalculateWithCondition();
            selectedOperation = Operacja.DIV;
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            CalculateWithCondition();
            selectedOperation = Operacja.POW;
            Calculate();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            CalculateWithCondition();
            selectedOperation = Operacja.SQRT;
            Calculate();
        }

        private void btnClearEverything_Click(object sender, EventArgs e)
        {
            selectedOperation = Operacja.NONE;
            valueBuildier.Clear();
            resultBox.Clear();
        }

        private void isFloating()
        {
            if (valueBuildier.ToString().Equals("0"))
            {
                valueBuildier.Append(",");
            }
        }

        private  void AppendValue(String number)
        {
            isFloating();
            valueBuildier.Append(number);
            resultBox.Text = valueBuildier.ToString();
        }

        private void Calculate()
        {
                switch (selectedOperation)
                {
                    case Operacja.ADD: AddAction(); break;
                    case Operacja.ODD: OddAction(); break;
                    case Operacja.MULT: MultAction(); break;
                    case Operacja.DIV: DivAction(); break;
                    case Operacja.POW: PowAction(); break;
                    case Operacja.SQRT: SqrtAction(); break;
                    case Operacja.NONE: NoneAction(); break;
                }
        }

        private void AddAction()
        {
            if (!selectedOperation.Equals(Operacja.NONE) && valueBuildier.Length > 0)
            {
                memoryResult = memoryResult + Double.Parse(valueBuildier.ToString());
                selectedOperation = Operacja.ADD;
                resultBox.Text = memoryResult.ToString();
                valueBuildier.Clear();
            }
            else if (valueBuildier.Length > 0)
            {
                memoryResult = Double.Parse(valueBuildier.ToString());
                selectedOperation = Operacja.ADD;
                valueBuildier.Clear();
            }
        }

        private void OddAction()
        {
              if (!selectedOperation.Equals(Operacja.NONE) && valueBuildier.Length > 0)
            {
                memoryResult = memoryResult - Double.Parse(valueBuildier.ToString());
                selectedOperation = Operacja.ODD;
                resultBox.Text = memoryResult.ToString();
                valueBuildier.Clear();
            }
            else if (valueBuildier.Length > 0)
            {
                memoryResult = Double.Parse(valueBuildier.ToString());
                selectedOperation = Operacja.ODD;
                valueBuildier.Clear();
            }
        }

        private void MultAction()
        {
            if (!selectedOperation.Equals(Operacja.NONE) && valueBuildier.Length > 0)
            {
                memoryResult = memoryResult * Double.Parse(valueBuildier.ToString());
                selectedOperation = Operacja.MULT;
                resultBox.Text = memoryResult.ToString();
                valueBuildier.Clear();
            }
            else if(valueBuildier.Length >0)
            {
                memoryResult = Double.Parse(valueBuildier.ToString());
                selectedOperation = Operacja.MULT;
                valueBuildier.Clear();
            }
        }

        private void DivAction()
        {
            if (!selectedOperation.Equals(Operacja.NONE) && valueBuildier.Length > 0)
            {
                if (Double.Parse(valueBuildier.ToString()) != 0)
                {
                    memoryResult = memoryResult / Double.Parse(valueBuildier.ToString());
                    selectedOperation = Operacja.DIV;
                    resultBox.Text = memoryResult.ToString();
                    valueBuildier.Clear();
                }
                else
                {
                    resultBox.Text = "Err";
                }
            }
            else if (valueBuildier.Length > 0)
            {
                memoryResult = Double.Parse(valueBuildier.ToString());
                selectedOperation = Operacja.DIV;
                valueBuildier.Clear();
            }
        }

        private void PowAction()
        {
            try
            {
                if (memoryResult != null)
                {
                    memoryResult = Math.Pow(memoryResult,2);
                    selectedOperation = Operacja.POW;
                    resultBox.Text = memoryResult.ToString();
                }
                else
                {
                    memoryResult = Double.Parse(valueBuildier.ToString());
                    valueBuildier.Clear();
                }
            }
            catch (FormatException)
            {
                resultBox.Text = "err";
            }
        }

        private void SqrtAction()
        {
            try
            {
               if(memoryResult != null && memoryResult > 0)
                {
                    memoryResult = Math.Sqrt(memoryResult);
                    selectedOperation = Operacja.SQRT;
                    resultBox.Text = memoryResult.ToString();
                }
                else
                {
                    memoryResult = Double.Parse(valueBuildier.ToString());
                    valueBuildier.Clear();
                }
            }
            catch (FormatException)
            {
                resultBox.Text = "err";
            }
        }
        
        private void NoneAction()
        {
            if (valueBuildier.Length > 0)
            {
                memoryResult = Double.Parse(valueBuildier.ToString());
                valueBuildier.Clear();
            }
        }


        private void CalculateWithCondition()
        {
            if (selectedOperation != Operacja.POW && selectedOperation != Operacja.SQRT)
            {
                Calculate();
            }
        }
    }


}
