using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            label1.Text = "Начало игры";
            label2.Visible = false;
            // кнопки выбора ответа 
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            // кнопка подтверждения выбора 
            button5.Visible = false;
            // кнопки с подсказками
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;

            button0.Visible = true;
            button0.BackColor = Color.Transparent;
            button0.BackgroundImage = global::wwtbam.Properties.Resources.getFile;
        }

        private async Task Rounds(string[] gameData)
        {

            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;

            button1.Appearance = Appearance.Button;
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.TabStop = false;

            button2.Appearance = Appearance.Button;
            button2.BackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.TabStop = false;

            button3.Appearance = Appearance.Button;
            button3.BackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.TabStop = false;

            button4.Appearance = Appearance.Button;
            button4.BackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.TabStop = false;

            // какая-то мистика происходит: фон для лейбла то и дело пропадает из класса, который генерирует конструктор сам, поэтому выношу сюда дубль присвоения фона
            label2.BackgroundImage = global::wwtbam.Properties.Resources.backQuestion;

            // дальше уже начинается перебор вопросов, поэтому всё происходящее в рамках рануда должно регулироваться изнутри этого цикла
            foreach (var roundData in gameData)
            {
                if (roundData != null)
                {
                    resetState();

                    nextStep = new TaskCompletionSource<bool>();
                    string[] data = roundData.Split(';');
                    string round = data[0];

                    string question = data[1];
                    string _a = data[2];
                    string _b = data[3];
                    string _c = data[4];
                    string _d = data[5];
                    right = data[6];
                    fixRight();
                    selected = "";


                    label1.Text = "Раунд " + round;
                    label2.Visible = true;
                    label2.Text = question;

                    await Task.Delay(2000);

                    button1.Text = _a;
                    button1.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                    await Task.Delay(1000);

                    button2.Text = _b;
                    button2.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                    await Task.Delay(1000);

                    button3.Text = _c;
                    button3.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                    await Task.Delay(1000);
                    
                    button4.Text = _d;
                    button4.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                    await Task.Delay(1000);

                    while (!button5.Enabled)
                    {
                        if (button1.Checked || button2.Checked || button3.Checked || button4.Checked)
                        {
                            button5.Enabled = true;
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

            button6.Text = "Вопросы закончились, начать сначала?";
            button6.Enabled = true;
            button6.Click += new System.EventHandler(resetGame);
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
                    gameData = File.ReadAllLines(openFileDialog.FileName, Encoding.UTF8);

                    MessageBox.Show("Файл успешно загружен!");
                    if (gameData[0].StartsWith("Раунд"))
                    {
                        string[] dataNoHead = new string[gameData.Length];
                        int i = 0;
                        foreach (var item in gameData)
                        {
                            if (!item.StartsWith("Раунд"))
                            {
                                dataNoHead[i] = item;
                                i++;
                            }
                        }
                        gameData = dataNoHead;
                    }
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
            if (button1.Checked)
            {
                selected = "A";
            }
            else if (button2.Checked)
            {
                selected = "B";
            }
            else if (button3.Checked)
            {
                selected = "C";
            }
            else if (button4.Checked)
            {
                selected = "D";
            }
            showRight(selected);
            button5.Visible = false;
            button6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1.Checked = false;
            button2.Checked = false;
            button3.Checked = false;
            button4.Checked = false;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

            button5.Visible = false;
            button6.Visible = true;
            nextStep.TrySetResult(true);
        }

        // унифицируем букафку для определения правильного ответа
        private void fixRight() {
            switch (right)
            {
                case "A":
                case "А":
                    right = "A";
                    break;
                case "B":
                case "Б":
                    right = "B";
                    break;
                case "C":
                case "В":
                    right = "C";
                    break;
                case "D":
                case "Г":
                    right = "D";
                    break;
                default:
                    break;
            }
        }
        // подсвечиваем правильный ответ 
        private void showRight(string selected)
        {
            switch (right)
            {
                case "A":
                    button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button1.BackgroundImage = global::wwtbam.Properties.Resources.goodAnswer;
                    break;
                case "B":
                    button2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button2.BackgroundImage = global::wwtbam.Properties.Resources.goodAnswer;
                    break;
                case "C":
                    button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button3.BackgroundImage = global::wwtbam.Properties.Resources.goodAnswer;
                    break;
                case "D":
                    button4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    button4.BackgroundImage = global::wwtbam.Properties.Resources.goodAnswer;
                    break;
                default:
                    break;
            }
            if (right != selected)
            {
                switch (selected)
                {
                    case "A":
                        button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        button1.BackgroundImage = global::wwtbam.Properties.Resources.badAnswer;
                        break;
                    case "B":
                        button2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        button2.BackgroundImage = global::wwtbam.Properties.Resources.badAnswer;
                        break;
                    case "C":
                        button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        button3.BackgroundImage = global::wwtbam.Properties.Resources.badAnswer;
                        break;
                    case "D":
                        button4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        button4.BackgroundImage = global::wwtbam.Properties.Resources.badAnswer;
                        break;
                    default:
                        break;
                }
            }
        }

        // приводим все визуальные элементы к исходному состоянию
        private void resetState()
        {
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
            button6.Visible = true;
            button0.Visible = false;

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";

            button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button1.ForeColor = System.Drawing.Color.Black;
            button2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button2.ForeColor = System.Drawing.Color.Black;
            button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button3.ForeColor = System.Drawing.Color.Black;
            button4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button4.ForeColor = System.Drawing.Color.Black;

            button1.BackgroundImage = global::wwtbam.Properties.Resources.emptyField;
            button2.BackgroundImage = global::wwtbam.Properties.Resources.emptyField;
            button3.BackgroundImage = global::wwtbam.Properties.Resources.emptyField;
            button4.BackgroundImage = global::wwtbam.Properties.Resources.emptyField;
        }

        private void resetGame(object sender, EventArgs e) {
            Rounds(gameData);
        }

        private void remove2Answers()
        {
            string[] answers = new string[4];
            answers[0] = "A";
            answers[1] = "B";
            answers[2] = "C";
            answers[3] = "D";
            // получаем индекс правильного ответа 
            int rightIdx = Array.IndexOf(answers, right);
            // Если правильный ответ 0, выключаем 1 и 2 (Батон идёт с + 1)
            // Если правильный ответ 1, выключаем 2 и 3
            // Если правильный ответ 2, выключаем 3 и 4
            // Если правильный ответ 3, выключаем 1 и 4
            switch (rightIdx) {
                case 0:
                    button2.Visible = false;
                    button3.Visible = false;
                    break;
                case 1:
                    button3.Visible = false;
                    button4.Visible = false;
                    break;
                case 2:
                    button4.Visible = false;
                    button1.Visible = false;
                    break;
                case 3:
                    button2.Visible = false;
                    button1.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            button7.BackgroundImage = Properties.Resources.pplHelpDisabled;
            button7.Enabled = false;
        }
        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            button7.BackgroundImage = Properties.Resources.pplHelpEnabled;
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            button8.BackgroundImage = Properties.Resources.pplHelpDisabled;
            button8.Enabled = false;
        }
        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            button8.BackgroundImage = Properties.Resources.pplHelpEnabled;
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            button9.BackgroundImage = Properties.Resources.phoneDisabled;
            button9.Enabled = false;
        }
        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            button9.BackgroundImage = Properties.Resources.phoneEnabled;
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            button10.BackgroundImage = Properties.Resources.pictureDisabled;
            button10.Enabled = false;
        }
        private void button10_MouseUp(object sender, MouseEventArgs e)
        {
            button10.BackgroundImage = Properties.Resources.pictureEnabled;
        }

        private void button11_MouseDown(object sender, MouseEventArgs e)
        {
            button11.BackgroundImage = Properties.Resources.lifeDisabled;
            button11.Enabled = false;
        }
        private void button11_MouseUp(object sender, MouseEventArgs e)
        {
            button11.BackgroundImage = Properties.Resources.lifeEnabled;
        }

        private void button12_MouseDown(object sender, MouseEventArgs e)
        {
            button12.BackgroundImage = Properties.Resources._50Disabled;
            button12.Enabled = false;
            remove2Answers();
            // button12.BackgroundImage = Properties.Resources._50Enabled;
        }


        private void Button_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void RadioButton_MouseEnter(object sender, EventArgs e)
        {
            ((RadioButton)sender).FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void RadioButton_MouseLeave(object sender, EventArgs e)
        {
            ((RadioButton)sender).FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void button1_CheckedChanged(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.BackColor = Color.Transparent;
            if (button1.Checked)
            {
                button1.BackgroundImage = global::wwtbam.Properties.Resources.pickedAnswer;
                button2.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                button3.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                button4.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
            }
        }
        private void button2_CheckedChanged(object sender, EventArgs e)
        {
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            if (button2.Checked)
            {
                button1.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                button2.BackgroundImage = global::wwtbam.Properties.Resources.pickedAnswer;
                button3.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                button4.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
            }
        }
        private void button3_CheckedChanged(object sender, EventArgs e)
        {
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            if (button3.Checked)
            {
                button1.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                button2.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                button3.BackgroundImage = global::wwtbam.Properties.Resources.pickedAnswer;
                button4.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
            }
        }
        private void button4_CheckedChanged(object sender, EventArgs e)
        {
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
            if (button4.Checked)
            {
                button1.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                button2.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                button3.BackgroundImage = global::wwtbam.Properties.Resources.normalAnswer;
                button4.BackgroundImage = global::wwtbam.Properties.Resources.pickedAnswer;
            }
        }
    }
}
