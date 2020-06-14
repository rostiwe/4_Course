namespace WindowsFormsApp2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шифрованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дешифрованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.защитаПКToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лР1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лР3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.защитаОтВПToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лабораторнаяРабота1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лабораторнаяРабота2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обАвтореToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.защитаПКToolStripMenuItem,
            this.защитаОтВПToolStripMenuItem,
            this.обАвтореToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.создатьToolStripMenuItem,
            this.шифрованиеToolStripMenuItem,
            this.дешифрованиеToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // шифрованиеToolStripMenuItem
            // 
            this.шифрованиеToolStripMenuItem.Name = "шифрованиеToolStripMenuItem";
            this.шифрованиеToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.шифрованиеToolStripMenuItem.Text = "Шифрование";
            // 
            // дешифрованиеToolStripMenuItem
            // 
            this.дешифрованиеToolStripMenuItem.Name = "дешифрованиеToolStripMenuItem";
            this.дешифрованиеToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.дешифрованиеToolStripMenuItem.Text = "Дешифрование";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // защитаПКToolStripMenuItem
            // 
            this.защитаПКToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лР1ToolStripMenuItem,
            this.лР3ToolStripMenuItem});
            this.защитаПКToolStripMenuItem.Name = "защитаПКToolStripMenuItem";
            this.защитаПКToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.защитаПКToolStripMenuItem.Text = "Защита РС";
            // 
            // лР1ToolStripMenuItem
            // 
            this.лР1ToolStripMenuItem.Name = "лР1ToolStripMenuItem";
            this.лР1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.лР1ToolStripMenuItem.Text = "ЛР1 и ЛР2";
            this.лР1ToolStripMenuItem.Click += new System.EventHandler(this.лР1ToolStripMenuItem_Click);
            // 
            // лР3ToolStripMenuItem
            // 
            this.лР3ToolStripMenuItem.Name = "лР3ToolStripMenuItem";
            this.лР3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.лР3ToolStripMenuItem.Text = "ЛР3";
            this.лР3ToolStripMenuItem.Click += new System.EventHandler(this.лР3ToolStripMenuItem_Click);
            // 
            // защитаОтВПToolStripMenuItem
            // 
            this.защитаОтВПToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лабораторнаяРабота1ToolStripMenuItem,
            this.лабораторнаяРабота2ToolStripMenuItem});
            this.защитаОтВПToolStripMenuItem.Name = "защитаОтВПToolStripMenuItem";
            this.защитаОтВПToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.защитаОтВПToolStripMenuItem.Text = "Защита от ВП";
            // 
            // лабораторнаяРабота1ToolStripMenuItem
            // 
            this.лабораторнаяРабота1ToolStripMenuItem.Name = "лабораторнаяРабота1ToolStripMenuItem";
            this.лабораторнаяРабота1ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.лабораторнаяРабота1ToolStripMenuItem.Text = "Лабораторная Работа 1";
            this.лабораторнаяРабота1ToolStripMenuItem.Click += new System.EventHandler(this.лабораторнаяРабота1ToolStripMenuItem_Click);
            // 
            // лабораторнаяРабота2ToolStripMenuItem
            // 
            this.лабораторнаяРабота2ToolStripMenuItem.Name = "лабораторнаяРабота2ToolStripMenuItem";
            this.лабораторнаяРабота2ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.лабораторнаяРабота2ToolStripMenuItem.Text = "Лабораторная Работа 2";
            this.лабораторнаяРабота2ToolStripMenuItem.Click += new System.EventHandler(this.лабораторнаяРабота2ToolStripMenuItem_Click);
            // 
            // обАвтореToolStripMenuItem
            // 
            this.обАвтореToolStripMenuItem.Name = "обАвтореToolStripMenuItem";
            this.обАвтореToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.обАвтореToolStripMenuItem.Text = "Об Авторе";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(0, 49);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(800, 379);
            this.textBox2.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шифрованиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дешифрованиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem защитаПКToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лР1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лР2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лР3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem защитаОтВПToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обАвтореToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem лабораторнаяРабота1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лабораторнаяРабота2ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
    }
}