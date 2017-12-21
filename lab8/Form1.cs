using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool p=true, q=true;
            dataGridView1.ColumnCount = 7;
            dataGridView1.RowCount = 4;
            dataGridView1.Columns[0].HeaderText = "p";
            dataGridView1.Columns[1].HeaderText = "q";
            dataGridView1.Columns[2].HeaderText = "p->q";
            dataGridView1.Columns[3].HeaderText = "!p->q";
            dataGridView1.Columns[4].HeaderText = "!p->!q";
            dataGridView1.Columns[5].HeaderText = "(p->q)^(!p->q)";
            dataGridView1.Columns[6].HeaderText = "[(p->q)^(!p->q)]~(!p->!q)";
            for (int i=0;i<4;i++)
            {
                if (i == 1)
                    q = false;
                else if (i == 2)
                    p = false;
                else
                    q = true;
                dataGridView1[0, i].Value = p;
                dataGridView1[1, i].Value = q;
                dataGridView1[2, i].Value = p==true&&q==false?false:true;
                dataGridView1[3, i].Value = !p == true && q == false ? false : true;
                dataGridView1[4, i].Value = !p == true && !q == false ? false : true;
                dataGridView1[5, i].Value = Convert.ToBoolean(dataGridView1[2, i].Value)&Convert.ToBoolean(dataGridView1[3, i].Value);
                if (Convert.ToBoolean(dataGridView1[5, i].Value) == Convert.ToBoolean(dataGridView1[4, i].Value))
                    dataGridView1[6, i].Value = true;
                else
                    dataGridView1[6, i].Value = false;

            }
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (Convert.ToBoolean(dataGridView1[i, j].Value) == false)
                        dataGridView1[i, j].Value = "F";
                    else
                        dataGridView1[i, j].Value = "T";
                }
        }
    }
}
