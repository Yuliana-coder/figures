namespace ООП_6_ЛАБОРАТОРНАЯ
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.undo_unexecute = new System.Windows.Forms.ToolStripButton();
            this.redo_execute = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.section1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.circle2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.triangle3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.rectangle4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.color = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.grouping = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.ungrouping = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.SAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.LOAD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.chosenAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.sticky = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.treeFigure = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undo_unexecute,
            this.redo_execute,
            this.toolStripSeparator13,
            this.section1,
            this.toolStripSeparator1,
            this.circle2,
            this.toolStripSeparator2,
            this.triangle3,
            this.toolStripSeparator3,
            this.rectangle4,
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.toolStripSeparator6,
            this.toolStripButton5,
            this.toolStripSeparator7,
            this.color,
            this.toolStripSeparator5,
            this.grouping,
            this.toolStripSeparator8,
            this.ungrouping,
            this.toolStripSeparator9,
            this.SAVE,
            this.toolStripSeparator10,
            this.LOAD,
            this.toolStripSeparator11,
            this.chosenAll,
            this.toolStripSeparator12,
            this.sticky});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(645, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // undo_unexecute
            // 
            this.undo_unexecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undo_unexecute.Enabled = false;
            this.undo_unexecute.Image = ((System.Drawing.Image)(resources.GetObject("undo_unexecute.Image")));
            this.undo_unexecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undo_unexecute.Name = "undo_unexecute";
            this.undo_unexecute.Size = new System.Drawing.Size(24, 24);
            this.undo_unexecute.Text = "toolStripButton2";
            this.undo_unexecute.ToolTipText = "undo";
            this.undo_unexecute.Click += new System.EventHandler(this.undo_unexecute_Click);
            // 
            // redo_execute
            // 
            this.redo_execute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redo_execute.Enabled = false;
            this.redo_execute.Image = ((System.Drawing.Image)(resources.GetObject("redo_execute.Image")));
            this.redo_execute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redo_execute.Name = "redo_execute";
            this.redo_execute.Size = new System.Drawing.Size(24, 24);
            this.redo_execute.Text = "toolStripButton3";
            this.redo_execute.ToolTipText = "redo";
            this.redo_execute.Click += new System.EventHandler(this.redo_execute_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 27);
            // 
            // section1
            // 
            this.section1.BackColor = System.Drawing.Color.White;
            this.section1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.section1.Image = ((System.Drawing.Image)(resources.GetObject("section1.Image")));
            this.section1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.section1.Name = "section1";
            this.section1.Size = new System.Drawing.Size(24, 24);
            this.section1.Text = "section1";
            this.section1.ToolTipText = "отрезок\r\n";
            this.section1.Click += new System.EventHandler(this.section1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // circle2
            // 
            this.circle2.BackColor = System.Drawing.Color.White;
            this.circle2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.circle2.Image = ((System.Drawing.Image)(resources.GetObject("circle2.Image")));
            this.circle2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circle2.Name = "circle2";
            this.circle2.Size = new System.Drawing.Size(24, 24);
            this.circle2.Text = "circle2";
            this.circle2.ToolTipText = "окружность";
            this.circle2.Click += new System.EventHandler(this.circle2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // triangle3
            // 
            this.triangle3.BackColor = System.Drawing.Color.White;
            this.triangle3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.triangle3.Image = ((System.Drawing.Image)(resources.GetObject("triangle3.Image")));
            this.triangle3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.triangle3.Name = "triangle3";
            this.triangle3.Size = new System.Drawing.Size(24, 24);
            this.triangle3.Text = "triangle3";
            this.triangle3.ToolTipText = "треугольник";
            this.triangle3.Click += new System.EventHandler(this.triangle3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // rectangle4
            // 
            this.rectangle4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangle4.Image = ((System.Drawing.Image)(resources.GetObject("rectangle4.Image")));
            this.rectangle4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangle4.Name = "rectangle4";
            this.rectangle4.Size = new System.Drawing.Size(24, 24);
            this.rectangle4.Text = "rectangle4";
            this.rectangle4.ToolTipText = "прямоугольник";
            this.rectangle4.Click += new System.EventHandler(this.rectangle4_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "указатель";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton5.Text = "DEL";
            this.toolStripButton5.ToolTipText = "удалить выделенные фигуры";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // color
            // 
            this.color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.color.Image = ((System.Drawing.Image)(resources.GetObject("color.Image")));
            this.color.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(24, 24);
            this.color.Text = "toolStripButton2";
            this.color.ToolTipText = "изменить цвет";
            this.color.Click += new System.EventHandler(this.color_Click_1);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // grouping
            // 
            this.grouping.BackColor = System.Drawing.Color.Aquamarine;
            this.grouping.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.grouping.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grouping.Image = ((System.Drawing.Image)(resources.GetObject("grouping.Image")));
            this.grouping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.grouping.Name = "grouping";
            this.grouping.Size = new System.Drawing.Size(63, 24);
            this.grouping.Text = "GROUP";
            this.grouping.ToolTipText = "сгруппировать выделенные";
            this.grouping.Click += new System.EventHandler(this.grouping_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // ungrouping
            // 
            this.ungrouping.BackColor = System.Drawing.Color.Salmon;
            this.ungrouping.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ungrouping.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ungrouping.Image = ((System.Drawing.Image)(resources.GetObject("ungrouping.Image")));
            this.ungrouping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ungrouping.Name = "ungrouping";
            this.ungrouping.Size = new System.Drawing.Size(86, 24);
            this.ungrouping.Text = "UNGROUP";
            this.ungrouping.ToolTipText = "разгруппировать";
            this.ungrouping.Click += new System.EventHandler(this.ungrouping_Click_1);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // SAVE
            // 
            this.SAVE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SAVE.Image = ((System.Drawing.Image)(resources.GetObject("SAVE.Image")));
            this.SAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SAVE.Name = "SAVE";
            this.SAVE.Size = new System.Drawing.Size(24, 24);
            this.SAVE.Text = "SAVE";
            this.SAVE.ToolTipText = "сохранить в файл";
            this.SAVE.Click += new System.EventHandler(this.SAVE_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 27);
            // 
            // LOAD
            // 
            this.LOAD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LOAD.Image = ((System.Drawing.Image)(resources.GetObject("LOAD.Image")));
            this.LOAD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LOAD.Name = "LOAD";
            this.LOAD.Size = new System.Drawing.Size(24, 24);
            this.LOAD.Text = "LOAD";
            this.LOAD.ToolTipText = "загрузить из файла";
            this.LOAD.Click += new System.EventHandler(this.LOAD_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 27);
            // 
            // chosenAll
            // 
            this.chosenAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chosenAll.Image = ((System.Drawing.Image)(resources.GetObject("chosenAll.Image")));
            this.chosenAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chosenAll.Name = "chosenAll";
            this.chosenAll.Size = new System.Drawing.Size(24, 24);
            this.chosenAll.Text = "toolStripButton2";
            this.chosenAll.Click += new System.EventHandler(this.chosenAll_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 27);
            // 
            // sticky
            // 
            this.sticky.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sticky.Image = ((System.Drawing.Image)(resources.GetObject("sticky.Image")));
            this.sticky.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sticky.Name = "sticky";
            this.sticky.Size = new System.Drawing.Size(117, 24);
            this.sticky.Text = "do sticky object";
            this.sticky.Click += new System.EventHandler(this.sticky_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 576);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // treeFigure
            // 
            this.treeFigure.CheckBoxes = true;
            this.treeFigure.Dock = System.Windows.Forms.DockStyle.Right;
            this.treeFigure.Location = new System.Drawing.Point(645, 0);
            this.treeFigure.Name = "treeFigure";
            this.treeFigure.Size = new System.Drawing.Size(242, 603);
            this.treeFigure.TabIndex = 1;
            this.treeFigure.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeFigure_AfterCheck);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 603);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.treeFigure);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton section1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton circle2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton triangle3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton rectangle4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton color;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton grouping;
        private System.Windows.Forms.ToolStripButton ungrouping;
        private System.Windows.Forms.ToolStripButton SAVE;
        private System.Windows.Forms.ToolStripButton LOAD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TreeView treeFigure;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton chosenAll;
        private System.Windows.Forms.ToolStripButton sticky;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton undo_unexecute;
        private System.Windows.Forms.ToolStripButton redo_execute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
    }
}

