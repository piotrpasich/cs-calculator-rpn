using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{

    public partial class Form1 : Form
    {
        private StringPresenter presenter = new StringPresenter();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);
            //FocusElement.Visible = false;
            FocusElement.Focus();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            ResultLabel.Text = "0";
        }

        private void number1_Click(object sender, EventArgs e)
        {
            add("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add("+");
        }

        private void add(string stringToAdd)
        {
            Computations.Text += stringToAdd;
            FocusElement.Focus();
            //Computations.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showResult();
        }

        private void showResult(bool addToHistory = true)
        {
            try {
                RPNCalculator calculator = new RPNCalculator();
                double result = calculator.Calculate(Computations.Text);
                ResultLabel.Text = result.ToString();
                if (addToHistory) {
                    this.addToHistory(Computations.Text);
                    Computations.Text = ResultLabel.Text;
                }
            } catch (Exception error) {
                ResultLabel.Text = "Cannot parse string";
            }
        }

        private void addToHistory(string calculation)
        {
            History.Items.Add(calculation);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            add("-");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            add("3");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            add("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            add("5");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add("6");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            add("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            add("8");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            add("9");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            add("0");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            add("*");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            add("/");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Computations.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar) {
                case (char)40:
                case (char)41:
                case (char)42:
                case (char)43:
                case (char)45:
                case (char)47:
                case (char)48:
                case (char)49:
                case (char)50:
                case (char)51:
                case (char)52:
                case (char)53:
                case (char)54:
                case (char)55:
                case (char)56:
                case (char)57:
                    add(e.KeyChar.ToString());
                    e.Handled = true;
                    break;
                case (char)13: //enter
                    showResult();
                    e.Handled = true;
                    break;
                case (char)8: //backspace
                    removeLastChar();
                    e.Handled = true;
                    break;
            }
            FocusElement.Focus();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            removeLastChar();
        }

        private void removeLastChar()
        {
            if (Computations.Text.Length > 0) {
                Computations.Text = Computations.Text.Remove(Computations.Text.Length - 1);
            }
        }

        private void FocusElement_Click(object sender, EventArgs e)
        {
            showResult();
        }

        private void History_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = History.SelectedIndex;
            Computations.Text = History.Items[index].ToString();
            showResult(false);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            History.Items.Clear();
        }
    }
}
