using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(@"c:input.txt");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            string fileText = textBox2.Text;
            File.WriteAllText(@"C:output.txt", fileText);

            MessageBox.Show("Данные успешно записаны в файл");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            textBox1.Text = File.ReadAllText(filename);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string fileText = textBox2.Text;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName + ".txt";
            File.WriteAllText(filename, fileText);
            MessageBox.Show("Данные успешно записаны в файл");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите статью!");
            }

            else
            {
                string text = textBox1.Text;

                var res = new Regex("наказыва.тся.*", RegexOptions.IgnoreCase);

                if (res.IsMatch(text))
                {
                    var sanction = res.Match(text).Value;
                    textBox2.Text = sanction;
                }
                else
                {
                    textBox2.Text = "Санкций не найдено";
                }
            }
        }
    }
}
