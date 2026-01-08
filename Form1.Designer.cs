using System;
using System.Drawing;
using System.Windows.Forms;

namespace wwtbam
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(42, 41);
            this.label1.MaximumSize = new System.Drawing.Size(215, 30);
            this.label1.MinimumSize = new System.Drawing.Size(215, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Начало игры";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.BackColor = Color.Transparent;
            this.label1.BackgroundImage = global::wwtbam.Properties.Resources.fon1;
            this.label1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Appearance = System.Windows.Forms.Appearance.Button;
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::wwtbam.Properties.Resources.emptyField;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(46, 285);
            this.button1.MaximumSize = new System.Drawing.Size(350, 50);
            this.button1.MinimumSize = new System.Drawing.Size(350, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(350, 50);
            this.button1.TabIndex = 0;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.CheckedChanged += new System.EventHandler(this.button1_CheckedChanged);
            this.button1.Click += new System.EventHandler(this.button1_CheckedChanged);
            this.button1.MouseEnter += new System.EventHandler(this.RadioButton_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.RadioButton_MouseLeave);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Appearance = System.Windows.Forms.Appearance.Button;
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::wwtbam.Properties.Resources.emptyField;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(46, 364);
            this.button2.MaximumSize = new System.Drawing.Size(350, 50);
            this.button2.MinimumSize = new System.Drawing.Size(350, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(350, 50);
            this.button2.TabIndex = 1;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.CheckedChanged += new System.EventHandler(this.button2_CheckedChanged);
            this.button2.Click += new System.EventHandler(this.button2_CheckedChanged);
            this.button2.MouseEnter += new System.EventHandler(this.RadioButton_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.RadioButton_MouseLeave);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Appearance = System.Windows.Forms.Appearance.Button;
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::wwtbam.Properties.Resources.emptyField;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(495, 285);
            this.button3.MaximumSize = new System.Drawing.Size(350, 50);
            this.button3.MinimumSize = new System.Drawing.Size(350, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(350, 50);
            this.button3.TabIndex = 2;
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.CheckedChanged += new System.EventHandler(this.button3_CheckedChanged);
            this.button3.Click += new System.EventHandler(this.button3_CheckedChanged);
            this.button3.MouseEnter += new System.EventHandler(this.RadioButton_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.RadioButton_MouseLeave);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Appearance = System.Windows.Forms.Appearance.Button;
            this.button4.AutoSize = true;
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::wwtbam.Properties.Resources.emptyField;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(495, 364);
            this.button4.MaximumSize = new System.Drawing.Size(350, 50);
            this.button4.MinimumSize = new System.Drawing.Size(350, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(350, 50);
            this.button4.TabIndex = 3;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.CheckedChanged += new System.EventHandler(this.button4_CheckedChanged);
            this.button4.Click += new System.EventHandler(this.button4_CheckedChanged);
            this.button4.MouseEnter += new System.EventHandler(this.RadioButton_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.RadioButton_MouseLeave);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.AutoSize = true;
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::wwtbam.Properties.Resources.acceptAnswer;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(45, 420);
            this.button5.MaximumSize = new System.Drawing.Size(800, 34);
            this.button5.MinimumSize = new System.Drawing.Size(800, 34);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(800, 34);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button5.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button0
            // 
            this.button0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button0.BackColor = System.Drawing.Color.Transparent;
            this.button0.BackgroundImage = global::wwtbam.Properties.Resources.getFile;
            this.button0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button0.FlatAppearance.BorderSize = 0;
            this.button0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button0.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button0.ForeColor = System.Drawing.Color.Pink;
            this.button0.Location = new System.Drawing.Point(215, 242);
            this.button0.MaximumSize = new System.Drawing.Size(500, 60);
            this.button0.MinimumSize = new System.Drawing.Size(500, 60);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(500, 60);
            this.button0.TabIndex = 7;
            this.button0.UseVisualStyleBackColor = false;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            this.button0.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button0.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.AutoSize = true;
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = global::wwtbam.Properties.Resources.nextQuestion;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(197, 409);
            this.button6.MaximumSize = new System.Drawing.Size(500, 45);
            this.button6.MinimumSize = new System.Drawing.Size(500, 45);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(500, 45);
            this.button6.TabIndex = 8;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button6.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button12
            // 
            this.button12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.BackgroundImage = global::wwtbam.Properties.Resources._50Enabled;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(639, 69);
            this.button12.MaximumSize = new System.Drawing.Size(100, 100);
            this.button12.MinimumSize = new System.Drawing.Size(100, 100);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(100, 100);
            this.button12.TabIndex = 14;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Visible = false;
            this.button12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button12_MouseDown);
            this.button12.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button12.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BackgroundImage = global::wwtbam.Properties.Resources.lifeEnabled;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(533, 69);
            this.button11.MaximumSize = new System.Drawing.Size(100, 100);
            this.button11.MinimumSize = new System.Drawing.Size(100, 100);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 100);
            this.button11.TabIndex = 13;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Visible = false;
            this.button11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button11_MouseDown);
            this.button11.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button11.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.BackgroundImage = global::wwtbam.Properties.Resources.pictureEnabled;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(427, 69);
            this.button10.MaximumSize = new System.Drawing.Size(100, 100);
            this.button10.MinimumSize = new System.Drawing.Size(100, 100);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 100);
            this.button10.TabIndex = 12;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Visible = false;
            this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button10_MouseDown);
            this.button10.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button10.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImage = global::wwtbam.Properties.Resources.phoneEnabled;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(321, 69);
            this.button9.MaximumSize = new System.Drawing.Size(100, 100);
            this.button9.MinimumSize = new System.Drawing.Size(100, 100);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 100);
            this.button9.TabIndex = 11;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button9_MouseDown);
            this.button9.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button9.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = global::wwtbam.Properties.Resources.pplHelpEnabled;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(215, 69);
            this.button8.MaximumSize = new System.Drawing.Size(100, 100);
            this.button8.MinimumSize = new System.Drawing.Size(100, 100);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 100);
            this.button8.TabIndex = 10;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button8_MouseDown);
            this.button8.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button8.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = global::wwtbam.Properties.Resources.pplHelpEnabled;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(109, 69);
            this.button7.MaximumSize = new System.Drawing.Size(100, 100);
            this.button7.MinimumSize = new System.Drawing.Size(100, 100);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 100);
            this.button7.TabIndex = 9;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button7_MouseDown);
            this.button7.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button7.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(96, 194);
            this.label2.MaximumSize = new System.Drawing.Size(700, 80);
            this.label2.MinimumSize = new System.Drawing.Size(700, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(700, 80);
            this.label2.TabIndex = 15;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::wwtbam.Properties.Resources.background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(894, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(910, 500);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Who Wants to Be a Millionaire?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton button1;
        private System.Windows.Forms.RadioButton button2;
        private System.Windows.Forms.RadioButton button3;
        private System.Windows.Forms.RadioButton button4;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
    }

