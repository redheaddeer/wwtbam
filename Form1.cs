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
using System.Threading;

namespace wwtbam
{
    public partial class Form1 : Form
    {
        private string[] gameData = null;
        private TaskCompletionSource<bool> nextStep;

        private string right = "";
        private string selected = "";

        public Form1()
        {
            InitializeComponent();
            Console.Out.Write("\nНачало игры\n");
            label1.Text = "Начало игры";
            textBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button0.Visible = true;
            button0.Text = "Выберите файл для начала игры";
        }

        private async Task Rounds(string[] gameData) {
            foreach (var roundData in gameData)
            {
                nextStep = new TaskCompletionSource<bool>();
                string[] data = roundData.Split(';');
                string round = data[0];

                string question = data[1];
                string _a = data[2];
                string _b = data[3];
                string _c = data[4];
                string _d = data[5];
                right = data[6];
                selected = "";

                label1.Text = "Раунд " + round;
                textBox1.Visible = true;
                textBox1.Text = question;

                resetState();

                button1.Text = _a;
                button2.Text = _b;
                button3.Text = _c;
                button4.Text = _d;


                while (!button5.Enabled)
                {
                    if (button1.Checked)
                    {
                        button5.Enabled = true;
                        selected = "A";
                    } else if (button2.Checked)
                    {
                        button5.Enabled = true;
                        selected = "B";
                    }
                    else if (button3.Checked)
                    {
                        button5.Enabled = true;
                        selected = "C";
                    }
                    else if ( button4.Checked)
                    {
                        button5.Enabled = true;
                        selected = "D";
                    }
                    await Task.Delay(100);
                }

                while (!button6.Visible)
                {
                    await Task.Delay(100);
                }
                await nextStep.Task;
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*",
                Title = "Выберите файл CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Читаем строки из выбранного файла
                    gameData = File.ReadAllLines(openFileDialog.FileName, Encoding.UTF8);

                    MessageBox.Show("Файл успешно загружен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка чтения файла: {ex.Message}");
                }
            }
            Rounds(gameData);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showRight(right, selected);
            button5.Visible = false;
            button6.Visible = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            button1.Checked = false;
            button2.Checked = false;
            button3.Checked = false;
            button4.Checked = false;
            button5.Visible = false;
            button6.Visible = true;
            nextStep.TrySetResult(true);
        }

        private void showRight(string right, string selected) {
            string fixedRight = "";
            switch (right)
            {
                case "A":
                case "А":
                    fixedRight = "A";
                    break;
                case "B":
                case "Б":
                    fixedRight = "B";
                    break;
                case "C":
                case "В":
                    fixedRight = "C";
                    break;
                case "D":
                case "Г":
                    fixedRight = "D";
                    break;
                default:
                    fixedRight = right;
                    break;
            }
            switch (fixedRight)
            {
                case "A":
                    button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button1.ForeColor = System.Drawing.Color.Green;
                    break;
                case "B":
                    button2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button2.ForeColor = System.Drawing.Color.Green;
                    break;
                case "C":
                    button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button3.ForeColor = System.Drawing.Color.Green;
                    break;
                case "D":
                    button4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button4.ForeColor = System.Drawing.Color.Green;
                    break;
                default:
                    break;
            }
            if (fixedRight != selected) {
                switch (selected)
                {
                    case "A":
                        button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        button1.ForeColor = System.Drawing.Color.Red;
                        break;
                    case "B":
                        button2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        button2.ForeColor = System.Drawing.Color.Red;
                        break;
                    case "C":
                        button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        button3.ForeColor = System.Drawing.Color.Red;
                        break;
                    case "D":
                        button4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        button4.ForeColor = System.Drawing.Color.Red;
                        break;
                    default:
                        break;
                }
            }
        }

        private void resetState() {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;

            button1.Checked = false;
            button2.Checked = false;
            button3.Checked = false;
            button4.Checked = false;

            button5.Visible = true;
            button5.Enabled = false;
            button5.Visible = true;
            button6.Visible = true;
            button0.Visible = false;

            button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button1.ForeColor = System.Drawing.Color.Black;
            button2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button2.ForeColor = System.Drawing.Color.Black;
            button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button3.ForeColor = System.Drawing.Color.Black;
            button4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button4.ForeColor = System.Drawing.Color.Black;
        }
    }
}
