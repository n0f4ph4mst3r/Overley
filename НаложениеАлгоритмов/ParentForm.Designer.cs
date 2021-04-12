namespace НаложениеАлгоритмов
{
    partial class ParentForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оттенкиСерогоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.частотнопропорциональноеРастяжениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.телевизионныйАлгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наложениеАлгоритмовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.окнаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.ОткрытьToolStripMenuItem_Click);
            // 
            // окнаToolStripMenuItem
            // 
            this.окнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оттенкиСерогоToolStripMenuItem,
            this.частотнопропорциональноеРастяжениеToolStripMenuItem,
            this.телевизионныйАлгоритмToolStripMenuItem,
            this.наложениеАлгоритмовToolStripMenuItem});
            this.окнаToolStripMenuItem.Enabled = false;
            this.окнаToolStripMenuItem.Name = "окнаToolStripMenuItem";
            this.окнаToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.окнаToolStripMenuItem.Text = "Окна";
            // 
            // оттенкиСерогоToolStripMenuItem
            // 
            this.оттенкиСерогоToolStripMenuItem.Name = "оттенкиСерогоToolStripMenuItem";
            this.оттенкиСерогоToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.оттенкиСерогоToolStripMenuItem.Text = "Оттенки серого";
            this.оттенкиСерогоToolStripMenuItem.Click += new System.EventHandler(this.ОттенкиСерогоToolStripMenuItem_Click);
            // 
            // частотнопропорциональноеРастяжениеToolStripMenuItem
            // 
            this.частотнопропорциональноеРастяжениеToolStripMenuItem.Name = "частотнопропорциональноеРастяжениеToolStripMenuItem";
            this.частотнопропорциональноеРастяжениеToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.частотнопропорциональноеРастяжениеToolStripMenuItem.Text = "Частотно-пропорциональное растяжение";
            this.частотнопропорциональноеРастяжениеToolStripMenuItem.Click += new System.EventHandler(this.ЧастотнопропорциональноеРастяжениеToolStripMenuItem_Click);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "openFileDialog1";
            // 
            // телевизионныйАлгоритмToolStripMenuItem
            // 
            this.телевизионныйАлгоритмToolStripMenuItem.Name = "телевизионныйАлгоритмToolStripMenuItem";
            this.телевизионныйАлгоритмToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.телевизионныйАлгоритмToolStripMenuItem.Text = "Телевизионный алгоритм";
            this.телевизионныйАлгоритмToolStripMenuItem.Click += new System.EventHandler(this.телевизионныйАлгоритмToolStripMenuItem_Click);
            // 
            // наложениеАлгоритмовToolStripMenuItem
            // 
            this.наложениеАлгоритмовToolStripMenuItem.Name = "наложениеАлгоритмовToolStripMenuItem";
            this.наложениеАлгоритмовToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.наложениеАлгоритмовToolStripMenuItem.Text = "Наложение алгоритмов";
            this.наложениеАлгоритмовToolStripMenuItem.Click += new System.EventHandler(this.наложениеАлгоритмовToolStripMenuItem_Click);
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ParentForm";
            this.Text = "Главная форма";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окнаToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem оттенкиСерогоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem частотнопропорциональноеРастяжениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem телевизионныйАлгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наложениеАлгоритмовToolStripMenuItem;
    }
}

