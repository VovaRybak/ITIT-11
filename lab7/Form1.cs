using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7
{
    public partial class Form1 : Form
    {
        bool eqv,no,dos;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
        }
        #region first_task
        private void button2_Click(object sender, EventArgs e)
        {
            if (dos != true)
            {
                if (eqv != true)
                {
                    if (no == true)
                    {
                        label1.Text += "сьогодні не холодно ";
                        label2.Text += "!q ";
                        no = false;
                    }
                    else
                    {
                        label1.Text += "сьогодні холодно ";
                        label2.Text += "q ";
                    }
                }
                else if (no != true)
                {
                    label1.Text += "якщо сьогодні холодно то ";
                    label2.Text += "q -> ";
                    eqv = false;
                    no = false;
                }
                else
                {
                    label1.Text += "якщо сьогодні не холодно то ";
                    label2.Text += "!q -> ";
                    eqv = false;
                    no = false;
                }
            }
            else
            {
                if (no != true)
                {
                    label1.Text += "для того щоб сьогодні було холодно необхідно і достатньо щоб ";
                    label2.Text += "q ~ ";
                    dos = false;
                    no = false;
                }
                else
                {
                    label1.Text += "для того щоб сьогодні було не холодно необхідно і достатньо щоб  ";
                    label2.Text += "!q ~ ";
                    dos = false;
                    no = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dos != true)
            {
                if (eqv != true)
                {
                    if (no == true)
                    {
                        label1.Text += "не падає сніг ";
                        label2.Text += "!p ";
                        no = false;
                    }
                    else
                    {
                        label1.Text += "падає сніг ";
                        label2.Text += "p ";
                    }
                }
                else if (no != true)
                {
                    label1.Text += "якщо падає сніг то ";
                    label2.Text += "p -> ";
                    eqv = false;
                    no = false;
                }
                else
                {
                    label1.Text += "якщо не падає сніг то ";
                    label2.Text += "!p -> ";
                    eqv = false;
                    no = false;
                }
            }
            else
            {
                if (no != true)
                {
                    label1.Text += "для того щоб падав сніг необхідно і достатньо щоб ";
                    label2.Text += "p ~ ";
                    dos = false;
                    no = false;
                }
                else
                {
                    label1.Text += "для того щоб падав не сніг необхідно і достатньо щоб  ";
                    label2.Text += "!p ~ ";
                    dos = false;
                    no = false;
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            no = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text += "i ";
            label2.Text += "v ";
        }

        private void button8_Click(object sender, EventArgs e)
        {

            richTextBox1.Text += label1.Text + " - " + label2.Text+"\n";
            label1.Text = "";label2.Text="";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dos = true;
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text += "або";
            label2.Text += "^ ";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bool p=true, q=false, F;
            dataGridView2.ColumnCount = 10;
            dataGridView2.RowCount = 4;
            dataGridView2.Columns[0].HeaderText = "p";
            dataGridView2.Columns[1].HeaderText = "q";
            dataGridView2.Columns[2].HeaderText = "F";
            dataGridView2.Columns[3].HeaderText = "!p->q";
            dataGridView2.Columns[4].HeaderText = "!q->!p";
            dataGridView2.Columns[5].HeaderText = "p^!q";
            dataGridView2.Columns[6].HeaderText = "(p^!q)->!p";
            dataGridView2.Columns[7].HeaderText = "(p^!q)->q";
            dataGridView2.Columns[8].HeaderText = "(p^!q)->F";
            dataGridView2.Columns[9].HeaderText = "p->q";
            for (int i = 0; i < 10; i++)
                dataGridView2.Columns[i].Width = 5;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0 || i == 1)
                {
                    p = true;
                    q = false;
                }
                else
                {
                    p = false;
                    q = true;         
                }
                dataGridView2[0, i].Value = p.ToString();
                dataGridView2[1, i].Value = q.ToString();
                dataGridView2[2, i].Value = (false).ToString();
                dataGridView2[3, i].Value = (!p==true && q == false ? false : true).ToString();
                dataGridView2[4, i].Value = (!q==true && p == false ? false : true).ToString();
                dataGridView2[5, i].Value = (p|!q).ToString();
                dataGridView2[6, i].Value = (Convert.ToBoolean(dataGridView2[5, i].Value) && !p == false ? false : true).ToString();
                dataGridView2[7, i].Value = (Convert.ToBoolean(dataGridView2[5, i].Value) && q == false ? false : true).ToString();
                dataGridView2[8, i].Value = (Convert.ToBoolean(dataGridView2[5, i].Value) ? false : true).ToString();
                dataGridView2[9, i].Value = (p==true&&q==false ? false : true).ToString();
            }
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (Convert.ToBoolean(dataGridView2[i, j].Value) == false)
                        dataGridView2[i, j].Value = "F";
                    else
                        dataGridView2[i, j].Value = "T";
                }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            int chyslo = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                chyslo *= 10;
                chyslo += (Convert.ToInt32(textBox1.Text[i] - 48) & Convert.ToInt32(textBox2.Text[i]) - 48);
            }
            textBox3.Text = chyslo.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            int chyslo = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                chyslo *= 10;
                chyslo += (Convert.ToInt32(textBox1.Text[i] - 48) | Convert.ToInt32(textBox2.Text[i]) - 48);
            }
            textBox3.Text = chyslo.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            int chyslo = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                chyslo *= 10;
                chyslo += (Convert.ToInt32(textBox1.Text[i] - 48) ^ Convert.ToInt32(textBox2.Text[i]) - 48);
            }
            textBox3.Text = chyslo.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eqv = true;
        }
        #endregion
        private void button9_Click(object sender, EventArgs e)
        {
            bool p, q;
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 4;
            dataGridView1.Columns[0].HeaderText = "p";
            dataGridView1.Columns[1].HeaderText = "q";
            dataGridView1.Columns[2].HeaderText = "!q";
            dataGridView1.Columns[3].HeaderText = "p->!q";
            for (int i = 0; i < 4; i++)
            { for (int j = 0; j < 4; j++)
                {
                    if (j==0||j==1)
                    {
                        p = true;
                        q = false;
                        dataGridView1[0, j].Value = p.ToString();
                        dataGridView1[1, j].Value = q.ToString();
                        dataGridView1[2, j].Value = (!q).ToString();
                        dataGridView1[3, j].Value = (p?!q:q).ToString();

                    }
                    else
                    {
                        p = false;
                        q = true;
                        dataGridView1[0, j].Value = p.ToString();
                        dataGridView1[1, j].Value = q.ToString();
                        dataGridView1[2, j].Value = (!q).ToString();
                        dataGridView1[3, j].Value = (p ? !q : q).ToString();

                    }

                }
            }
        }
    }
}
