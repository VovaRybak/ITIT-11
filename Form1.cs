using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        Stack<double> st = new Stack<double>();
        string act;
        double val1, val2;
        double res;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 5;
            dataGridView2.RowCount = 5;
            dataGridView3.RowCount = 5;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView3.BackgroundColor = Color.White;
            this.button29.Click += new System.EventHandler(this.action_button);
            this.button31.Click += new System.EventHandler(this.action_button);
            this.button25.Click += new System.EventHandler(this.action_button);
            this.button23.Click += new System.EventHandler(this.action_button);

            this.button30.Click += new System.EventHandler(this.number_button);
            this.button35.Click += new System.EventHandler(this.number_button);
            this.button34.Click += new System.EventHandler(this.number_button);
            this.button28.Click += new System.EventHandler(this.number_button);
            this.button33.Click += new System.EventHandler(this.number_button);
            this.button36.Click += new System.EventHandler(this.number_button);
            this.button22.Click += new System.EventHandler(this.number_button);
            this.button32.Click += new System.EventHandler(this.number_button);
            this.button37.Click += new System.EventHandler(this.number_button);
            this.button24.Click += new System.EventHandler(this.number_button);
            this.button26.Click += new System.EventHandler(this.number_button);
            this.button38.Click += new System.EventHandler(this.number_button);
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (Equals(textBox1.Text,"0"))
            {
                textBox1.Text = (sender as Button).Text;
            }
            else
                textBox1.Text += (sender as Button).Text;
        }
        private void button_Backspace(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }
        private void button_Action(object sender, EventArgs e)
        {
            act = (sender as Button).Text;
            val1 = Convert.ToDouble(textBox1.Text);
            label1.Text= (sender as Button).Text;
            textBox1.Text = "0";
        }
        private void action_button(object sender, EventArgs e)
        {
            double op2;
            switch ((sender as Button).Text)
            {
                case "+":
                    st.Push(st.Pop() + st.Pop());
                    break;
                case "X":
                    st.Push(st.Pop() * st.Pop());
                    break;
                case "-":
                    op2 = st.Pop();
                    st.Push(st.Pop() - op2);
                    break;
                case "/":
                    op2 = st.Pop();
                    if (op2 != 0.0)
                        st.Push(st.Pop() / op2);
                    else
                        MessageBox.Show("Ділення на нуль");
                    break;  
                default:
                    Console.WriteLine("Ошибка. Неизвестная команда");
                    break;
            }
        }

        private void number_button(object sender, EventArgs e)
        {
            if (Equals(textBox2.Text, "0"))
            {
                textBox2.Text = (sender as Button).Text;
            }
            else
                textBox2.Text += (sender as Button).Text;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            val1 = 0;
            val2 = 0;
            label1.Text = "";
            textBox1.Text = "0";
            act = "";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            st.Push(Convert.ToDouble(textBox2.Text));
            textBox2.Text = "";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Результат: " + st.Pop();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            st.Clear();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            for(int i=0;i<dataGridView1.RowCount;i++)
            {
                for(int k=0;k<dataGridView1.ColumnCount;k++)
                {
                    int sum = 0;
                    for (int j = 0; j < dataGridView1.ColumnCount;j++)
                        sum += (Convert.ToInt32(dataGridView1[i, j].Value)) * (Convert.ToInt32(dataGridView2[j, k].Value));
                    dataGridView3[i, k].Value = sum;
                }
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int k = 0; k < dataGridView1.ColumnCount; k++)
                {
                    if (k>=i)
                    {
                        dataGridView1[i, k].Value = 0;
                        dataGridView2[i, k].Value = 0;
                    }
                    else
                    {
                        dataGridView1[i, k].Value = rand.Next() % 10;
                        dataGridView2[i, k].Value = rand.Next() % 10;
                    }
                }
            }

        }

        private void button42_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int k = 0; k < dataGridView1.ColumnCount; k++)
                {
                       dataGridView3[i, k].Value =(Convert.ToInt32(dataGridView1[i, k].Value)) + (Convert.ToInt32(dataGridView2[i, k].Value));
                }
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int k = 0; k < dataGridView1.ColumnCount; k++)
                {
                    dataGridView3[i, k].Value = (Convert.ToInt32(dataGridView1[i, k].Value)) - (Convert.ToInt32(dataGridView2[i, k].Value));
                }
            }
        }

        private void button_Equal(object sender, EventArgs e)
        {

            val2 = Convert.ToDouble(textBox1.Text);
            switch (act)
            {
                case "+": res = val1 + val2; break;
                case "—": res = val1 - val2; break;
                case "X": res = val1 * val2; break;
                case "/": res = (double)val1 / (double)val2; break;
            }
            label1.Text = (sender as Button).Text;
            textBox1.Text = Convert.ToString(Math.Round(res, 5));
        }
    }
}
