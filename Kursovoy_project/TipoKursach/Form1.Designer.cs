namespace TipoKursach
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartStopButton = new System.Windows.Forms.Button();
            this.NextStepButton = new System.Windows.Forms.Button();
            this.PbMain = new System.Windows.Forms.PictureBox();
            this.ParticlesCounter = new System.Windows.Forms.NumericUpDown();
            this.ParticlesCountLabel = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.GenerationBarLabel = new System.Windows.Forms.Label();
            this.GenerationBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.PbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticlesCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenerationBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(735, 365);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(75, 65);
            this.StartStopButton.TabIndex = 0;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // NextStepButton
            // 
            this.NextStepButton.Location = new System.Drawing.Point(816, 365);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(75, 65);
            this.NextStepButton.TabIndex = 3;
            this.NextStepButton.Text = "Шаг";
            this.NextStepButton.UseVisualStyleBackColor = true;
            this.NextStepButton.Click += new System.EventHandler(this.NextStepButton_Click);
            // 
            // PbMain
            // 
            this.PbMain.Location = new System.Drawing.Point(12, 12);
            this.PbMain.Name = "PbMain";
            this.PbMain.Size = new System.Drawing.Size(717, 421);
            this.PbMain.TabIndex = 4;
            this.PbMain.TabStop = false;
            this.PbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // ParticlesCounter
            // 
            this.ParticlesCounter.Location = new System.Drawing.Point(735, 12);
            this.ParticlesCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ParticlesCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ParticlesCounter.Name = "ParticlesCounter";
            this.ParticlesCounter.Size = new System.Drawing.Size(156, 20);
            this.ParticlesCounter.TabIndex = 9;
            this.ParticlesCounter.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // ParticlesCountLabel
            // 
            this.ParticlesCountLabel.AutoSize = true;
            this.ParticlesCountLabel.Location = new System.Drawing.Point(735, 44);
            this.ParticlesCountLabel.Name = "ParticlesCountLabel";
            this.ParticlesCountLabel.Size = new System.Drawing.Size(103, 13);
            this.ParticlesCountLabel.TabIndex = 10;
            this.ParticlesCountLabel.Text = "Количество частиц";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.InfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoLabel.Location = new System.Drawing.Point(22, 59);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 16);
            this.InfoLabel.TabIndex = 8;
            this.InfoLabel.Visible = false;
            // 
            // GenerationBarLabel
            // 
            this.GenerationBarLabel.AutoSize = true;
            this.GenerationBarLabel.Location = new System.Drawing.Point(740, 118);
            this.GenerationBarLabel.Name = "GenerationBarLabel";
            this.GenerationBarLabel.Size = new System.Drawing.Size(166, 13);
            this.GenerationBarLabel.TabIndex = 12;
            this.GenerationBarLabel.Text = "Симуляция в обратную сторону";
            // 
            // GenerationBar
            // 
            this.GenerationBar.Location = new System.Drawing.Point(735, 70);
            this.GenerationBar.Maximum = 0;
            this.GenerationBar.Name = "GenerationBar";
            this.GenerationBar.Size = new System.Drawing.Size(171, 45);
            this.GenerationBar.TabIndex = 11;
            this.GenerationBar.Scroll += new System.EventHandler(this.GenerationBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 442);
            this.Controls.Add(this.GenerationBarLabel);
            this.Controls.Add(this.GenerationBar);
            this.Controls.Add(this.ParticlesCountLabel);
            this.Controls.Add(this.ParticlesCounter);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.PbMain);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.StartStopButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Курсовой проект";
            ((System.ComponentModel.ISupportInitialize)(this.PbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticlesCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenerationBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Button NextStepButton;
        private System.Windows.Forms.PictureBox PbMain;
        private System.Windows.Forms.NumericUpDown ParticlesCounter;
        private System.Windows.Forms.Label ParticlesCountLabel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label GenerationBarLabel;
        private System.Windows.Forms.TrackBar GenerationBar;
    }
}

