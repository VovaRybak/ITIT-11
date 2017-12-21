using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        char sep;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sep = ' ';
            FileStream CSV_example;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter="Електронні таблиці (*.csv)|*.csv";
            if (fDialog.ShowDialog() != DialogResult.OK)
                return;
            System.IO.FileInfo fInfo = new System.IO.FileInfo(fDialog.FileName);
            string strFileName = fInfo.Name;
            string strFilePath = fInfo.DirectoryName;
            CSV_example = File.OpenRead(strFilePath+"\\"+strFileName);
            byte[] array = new byte[CSV_example.Length];
            CSV_example.Read(array, 0, (int)CSV_example.Length);
            string textFromFile = System.Text.Encoding.Default.GetString(array);
            for (int i = textFromFile.IndexOf("=") + 1; textFromFile[i] != '\n' && textFromFile[i] != '\r'; i++)
            {
                sep = textFromFile[i];
            }
            int k = textFromFile.IndexOf("=") + 1;
            for (int i = textFromFile.IndexOf("=") + 1; textFromFile[i] == '\n' || textFromFile[i] == '\r' || textFromFile[i] == sep; i++, k++)
            { }
            string only_data = textFromFile.Remove(0, k);
            int min;
            if (only_data.IndexOf("\n") < only_data.IndexOf("\r"))
                min = only_data.IndexOf("\n");
            else
                min = only_data.IndexOf("\r");
            string foHeaders = only_data.Substring(0, min);
            only_data = only_data.Remove(0, min+2);
            string[] headers = foHeaders.Split(sep);
            dataGridView1.ColumnCount = headers.Length;
            char[] separ = { sep };
            only_data = only_data.Replace('\n', sep);
            only_data = only_data.Replace("\r", "");
            string[] data_for_table = only_data.Split(separ);

            dataGridView1.RowCount = data_for_table.Count() / headers.Length;
            dataGridView1.RowCount += 1;
            for (int i = 0; i < headers.Length; i++)
            {
                dataGridView1.Columns[i].Name = headers[i];
                dataGridView1.Columns[i].HeaderText = headers[i];
            }
            for (int i = 0, j = 0,l=0; j < (data_for_table.Count() / headers.Length)&&l< data_for_table.Count(); i++,l++)
            {
                if (i != 0 && i % headers.Length == 0&&j+1< (data_for_table.Count() / headers.Length))
                { j++; i = 0;}
                dataGridView1[i, j].Value = data_for_table[l];
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текст|*.txt|Таблиця|*.csv";
            saveFileDialog1.Title = "Збережіть файл";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        string filename = saveFileDialog1.FileName;
                        string toFile="";
                        fs.Close();
                        for (int i = 0; i < dataGridView1.RowCount-1; i++)
                        {
                            for (int k = 0; k < dataGridView1.ColumnCount; k++)
                            {
                                toFile += dataGridView1[k,i].Value.ToString() + " ";
                                
                            }
                                toFile += "\r\n";

                        }
                        System.IO.File.WriteAllText(filename, toFile);
                        break;

                    case 2:
                        filename = saveFileDialog1.FileName;
                        toFile = "sep ="+sep+"\r\n";
                        fs.Close();
                        for (int k = 0; k < dataGridView1.ColumnCount; k++)
                        {
                            toFile += dataGridView1.Columns[k].HeaderText + sep;

                        }
                        toFile +="\r\n";
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int k = 0; k < dataGridView1.ColumnCount; k++)
                            {
                                toFile += dataGridView1[k, i].Value.ToString() + sep;

                            }
                            toFile += "\r\n";

                        }
                        System.IO.File.WriteAllText(filename, toFile);
                        break;
                }

                fs.Close();
            }
        }
    }
}
