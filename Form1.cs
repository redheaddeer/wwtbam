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
        string questions = "";
        int questionsCount = 1;

        string font = "Comic Sans MS";

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
            button0.BackgroundImage = Properties.Resources.getFile;

            label1.BackColor = Color.Transparent;
            label1.BackgroundImage = Properties.Resources.fon1;
        }

        private async Task Rounds(string[] gameData)
        {

            label1.BackColor = Color.Transparent;
            label1.BackgroundImage = Properties.Resources.fon1;

            button13.Visible = false;

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
            label2.BackgroundImage = Properties.Resources.backQuestion;

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
                    button1.BackgroundImage = Properties.Resources.normalAnswer;
                    await Task.Delay(1000);

                    button2.Text = _b;
                    button2.BackgroundImage = Properties.Resources.normalAnswer;
                    await Task.Delay(1000);

                    button3.Text = _c;
                    button3.BackgroundImage = Properties.Resources.normalAnswer;
                    await Task.Delay(1000);

                    button4.Text = _d;
                    button4.BackgroundImage = Properties.Resources.normalAnswer;
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

            MessageBox.Show("А всё... А больше делать надо было...");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Normal text file (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Выберите файл TXT"
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
        private void fixRight()
        {
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
                    button1.Font = new Font(font, 13.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                    button1.BackgroundImage = Properties.Resources.goodAnswer;
                    break;
                case "B":
                    button2.Font = new Font(font, 13.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                    button2.BackgroundImage = Properties.Resources.goodAnswer;
                    break;
                case "C":
                    button3.Font = new Font(font, 13.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                    button3.BackgroundImage = Properties.Resources.goodAnswer;
                    break;
                case "D":
                    button4.Font = new Font(font, 13.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                    button4.BackgroundImage = Properties.Resources.goodAnswer;
                    break;
                default:
                    break;
            }
            if (right != selected)
            {
                switch (selected)
                {
                    case "A":
                        button1.Font = new Font(font, 13.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                        button1.BackgroundImage = Properties.Resources.badAnswer;
                        break;
                    case "B":
                        button2.Font = new Font(font, 13.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                        button2.BackgroundImage = Properties.Resources.badAnswer;
                        break;
                    case "C":
                        button3.Font = new Font(font, 13.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                        button3.BackgroundImage = Properties.Resources.badAnswer;
                        break;
                    case "D":
                        button4.Font = new Font(font, 13.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                        button4.BackgroundImage = Properties.Resources.badAnswer;
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

            button1.Font = new Font(font, 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            button1.ForeColor = Color.Black;
            button2.Font = new Font(font, 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            button2.ForeColor = Color.Black;
            button3.Font = new Font(font, 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            button3.ForeColor = Color.Black;
            button4.Font = new Font(font, 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            button4.ForeColor = Color.Black;

            button1.BackgroundImage = Properties.Resources.emptyField;
            button2.BackgroundImage = Properties.Resources.emptyField;
            button3.BackgroundImage = Properties.Resources.emptyField;
            button4.BackgroundImage = Properties.Resources.emptyField;
        }

        private void resetGame(object sender, EventArgs e)
        {
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
            switch (rightIdx)
            {
                case 0:
                    button2.Text = "";
                    button2.BackgroundImage = Properties.Resources.emptyField;
                    button2.Enabled = false;
                    button3.Text = "";
                    button3.BackgroundImage = Properties.Resources.emptyField;
                    button3.Enabled = false;
                    break;
                case 1:
                    button3.Text = "";
                    button3.BackgroundImage = Properties.Resources.emptyField;
                    button3.Enabled = false;
                    button4.Text = "";
                    button4.BackgroundImage = Properties.Resources.emptyField;
                    button4.Enabled = false;
                    break;
                case 2:
                    button4.Text = "";
                    button4.BackgroundImage = Properties.Resources.emptyField;
                    button4.Enabled = false;
                    button1.Text = "";
                    button1.BackgroundImage = Properties.Resources.emptyField;
                    button1.Enabled = false;
                    break;
                case 3:
                    button2.Text = "";
                    button2.BackgroundImage = Properties.Resources.emptyField;
                    button2.Enabled = false;
                    button1.Text = "";
                    button1.BackgroundImage = Properties.Resources.emptyField;
                    button1.Enabled = false;
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
            ((System.Windows.Forms.Button)sender).FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Button)sender).FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void RadioButton_MouseEnter(object sender, EventArgs e)
        {
            ((System.Windows.Forms.RadioButton)sender).FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void RadioButton_MouseLeave(object sender, EventArgs e)
        {
            ((System.Windows.Forms.RadioButton)sender).FlatAppearance.MouseOverBackColor = Color.Transparent;
        }
        private void button1_CheckedChanged(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.BackColor = Color.Transparent;
            if (button1.Checked)
            {
                button1.BackgroundImage = Properties.Resources.pickedAnswer;
                if (button2.Enabled)
                    button2.BackgroundImage = Properties.Resources.normalAnswer;
                if (button3.Enabled)
                    button3.BackgroundImage = Properties.Resources.normalAnswer;
                if (button4.Enabled)
                    button4.BackgroundImage = Properties.Resources.normalAnswer;
            }
        }
        private void button2_CheckedChanged(object sender, EventArgs e)
        {
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            if (button2.Checked)
            {
                button2.BackgroundImage = Properties.Resources.pickedAnswer;

                if (button1.Enabled)
                    button1.BackgroundImage = Properties.Resources.normalAnswer;
                if (button3.Enabled)
                    button3.BackgroundImage = Properties.Resources.normalAnswer;
                if (button4.Enabled)
                    button4.BackgroundImage = Properties.Resources.normalAnswer;

            }
        }
        private void button3_CheckedChanged(object sender, EventArgs e)
        {
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            if (button3.Checked)
            {
                button3.BackgroundImage = Properties.Resources.pickedAnswer;

                if (button1.Enabled)
                    button1.BackgroundImage = Properties.Resources.normalAnswer;
                if (button2.Enabled)
                    button2.BackgroundImage = Properties.Resources.normalAnswer;
                if (button4.Enabled)
                    button4.BackgroundImage = Properties.Resources.normalAnswer;
            }
        }
        private void button4_CheckedChanged(object sender, EventArgs e)
        {
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
            if (button4.Checked)
            {
                button4.BackgroundImage = Properties.Resources.pickedAnswer;

                if (button1.Enabled)
                    button1.BackgroundImage = Properties.Resources.normalAnswer;
                if (button3.Enabled)
                    button3.BackgroundImage = Properties.Resources.normalAnswer;
                if (button2.Enabled)
                    button2.BackgroundImage = Properties.Resources.normalAnswer;
            }
        }


        private void button13_Click(object sender, EventArgs e)
        {

            // Вырубаем видимость всех стартовых объектов
            label1.Visible = false;
            button0.Visible = false;
            button13.Visible = false;

            // Выводим на экран наши спрятанные по умолчанию поля ввода
            textBox1.Visible = true; // это вопрос
            textBox2.Visible = true; // это ответ A
            textBox3.Visible = true; // это ответ B
            textBox4.Visible = true; // это ответ C
            textBox5.Visible = true; // это ответ D
            radioButton1.Visible = true; // это чтобы определить вариант ответа A как правильный 
            radioButton2.Visible = true; // это чтобы определить вариант ответа B как правильный 
            radioButton3.Visible = true; // это чтобы определить вариант ответа C как правильный 
            radioButton4.Visible = true; // это чтобы определить вариант ответа D как правильный 
            button14.Visible = true; // это чтобы добавить вариант в файл 
            button14.Enabled = false; // это чтобы добавить вариант в файл 
            button15.Visible = true; // это чтобы закончить собирать файл

            checkReadyQuestion();
        }

        private async Task checkReadyQuestion() {
            while (!button14.Enabled)
            {
                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
                {
                    button14.Enabled = true;
                }
                await Task.Delay(100);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string rightAnswer = "";
            if (radioButton1.Checked) rightAnswer = "A";
            if (radioButton2.Checked) rightAnswer = "B";
            if (radioButton3.Checked) rightAnswer = "C";
            if (radioButton4.Checked) rightAnswer = "D";

            questions += questionsCount + ";" + textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text + ";" + textBox4.Text + ";" + textBox5.Text + ";" + rightAnswer + "\n";
            questionsCount++;

            button14.Enabled = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            this.textBox1.Text = "Введите вопрос";
            this.textBox2.Text = "Введите ответ A";
            this.textBox3.Text = "Введите ответ B";
            this.textBox4.Text = "Введите ответ C";
            this.textBox5.Text = "Введите ответ D";

            checkReadyQuestion();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveDialog.Title = "Сохраните файл";
            saveDialog.DefaultExt = ".txt";
            saveDialog.AddExtension = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveDialog.FileName))
                    {
                        sw.Write(questions);
                    }

                    MessageBox.Show("Файл успешно сохранён.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Прячем поля ввода 
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            button14.Visible = false;
            button15.Visible = false;

            // очищаем список вопросов в переменной, вдруг надо будет сделать несколько файлов за один заход?
            questions = "";
            questionsCount = 1;

            // Возввращаем видимость всех стартовых объектов
            label1.Visible = true;
            button0.Visible = true;
            button13.Visible = true;
        }
    }
}