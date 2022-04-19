namespace Simulation_of_life
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.WorkPlace = new System.Windows.Forms.GroupBox();
            this.textBoxHuman = new System.Windows.Forms.TextBox();
            this.textBoxSizeWorld = new System.Windows.Forms.TextBox();
            this.textBoxCellSize = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBoxNOO = new System.Windows.Forms.TextBox();
            this.textBoxNOC = new System.Windows.Forms.TextBox();
            this.textBoxNOH = new System.Windows.Forms.TextBox();
            this.textBoxNOIPWTB = new System.Windows.Forms.TextBox();
            this.textBoxNOIPWB = new System.Windows.Forms.TextBox();
            this.textBoxNONPWTB = new System.Windows.Forms.TextBox();
            this.textBoxNONPWB = new System.Windows.Forms.TextBox();
            this.textBoxNOTPWTB = new System.Windows.Forms.TextBox();
            this.ButtonMinus = new System.Windows.Forms.Button();
            this.ButtonPlus = new System.Windows.Forms.Button();
            this.textBoxNOTPWB = new System.Windows.Forms.TextBox();
            this.bStart = new System.Windows.Forms.Button();
            this.GamePlace = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Timers.Timer();
            this.WorkPlace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.GamePlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkPlace
            // 
            this.WorkPlace.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.WorkPlace.Controls.Add(this.textBoxHuman);
            this.WorkPlace.Controls.Add(this.textBoxSizeWorld);
            this.WorkPlace.Controls.Add(this.textBoxCellSize);
            this.WorkPlace.Controls.Add(this.textBox1);
            this.WorkPlace.Controls.Add(this.textBox12);
            this.WorkPlace.Controls.Add(this.textBox11);
            this.WorkPlace.Controls.Add(this.textBoxNOO);
            this.WorkPlace.Controls.Add(this.textBoxNOC);
            this.WorkPlace.Controls.Add(this.textBoxNOH);
            this.WorkPlace.Controls.Add(this.textBoxNOIPWTB);
            this.WorkPlace.Controls.Add(this.textBoxNOIPWB);
            this.WorkPlace.Controls.Add(this.textBoxNONPWTB);
            this.WorkPlace.Controls.Add(this.textBoxNONPWB);
            this.WorkPlace.Controls.Add(this.textBoxNOTPWTB);
            this.WorkPlace.Controls.Add(this.ButtonMinus);
            this.WorkPlace.Controls.Add(this.ButtonPlus);
            this.WorkPlace.Controls.Add(this.textBoxNOTPWB);
            this.WorkPlace.Controls.Add(this.bStart);
            this.WorkPlace.ForeColor = System.Drawing.Color.White;
            this.WorkPlace.Location = new System.Drawing.Point(9, 9);
            this.WorkPlace.Margin = new System.Windows.Forms.Padding(0);
            this.WorkPlace.Name = "WorkPlace";
            this.WorkPlace.Padding = new System.Windows.Forms.Padding(0);
            this.WorkPlace.Size = new System.Drawing.Size(329, 1003);
            this.WorkPlace.TabIndex = 0;
            this.WorkPlace.TabStop = false;
            // 
            // textBoxHuman
            // 
            this.textBoxHuman.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxHuman.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxHuman.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxHuman.Location = new System.Drawing.Point(13, 461);
            this.textBoxHuman.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxHuman.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxHuman.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxHuman.Name = "textBoxHuman";
            this.textBoxHuman.Size = new System.Drawing.Size(300, 26);
            this.textBoxHuman.TabIndex = 19;
            this.textBoxHuman.Text = "Number of humans";
            this.textBoxHuman.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxHuman.Click += new System.EventHandler(this.textBoxHuman_Click);
            this.textBoxHuman.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHuman_KeyPress);
            // 
            // textBoxSizeWorld
            // 
            this.textBoxSizeWorld.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSizeWorld.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxSizeWorld.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxSizeWorld.Location = new System.Drawing.Point(4, 560);
            this.textBoxSizeWorld.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxSizeWorld.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxSizeWorld.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxSizeWorld.Name = "textBoxSizeWorld";
            this.textBoxSizeWorld.Size = new System.Drawing.Size(300, 26);
            this.textBoxSizeWorld.TabIndex = 18;
            this.textBoxSizeWorld.Text = "The size of the world";
            this.textBoxSizeWorld.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSizeWorld.Click += new System.EventHandler(this.textBoxSizeWorld_Click);
            this.textBoxSizeWorld.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSizeWorld_KeyPress);
            // 
            // textBoxCellSize
            // 
            this.textBoxCellSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCellSize.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxCellSize.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxCellSize.Location = new System.Drawing.Point(4, 524);
            this.textBoxCellSize.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxCellSize.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxCellSize.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxCellSize.Name = "textBoxCellSize";
            this.textBoxCellSize.Size = new System.Drawing.Size(300, 26);
            this.textBoxCellSize.TabIndex = 17;
            this.textBoxCellSize.Text = "Cell Size";
            this.textBoxCellSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCellSize.Click += new System.EventHandler(this.textBoxCellSize_Click);
            this.textBoxCellSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCellSize_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Location = new System.Drawing.Point(67, 495);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 25);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = " World Settings";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox12.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox12.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBox12.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox12.Location = new System.Drawing.Point(67, 320);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(178, 25);
            this.textBox12.TabIndex = 15;
            this.textBox12.Text = "Animal Settings";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox11.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBox11.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox11.Location = new System.Drawing.Point(67, 73);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(178, 25);
            this.textBox11.TabIndex = 14;
            this.textBox11.Text = "Plant Settings";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxNOO
            // 
            this.textBoxNOO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNOO.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNOO.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxNOO.Location = new System.Drawing.Point(14, 425);
            this.textBoxNOO.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNOO.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxNOO.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxNOO.Name = "textBoxNOO";
            this.textBoxNOO.Size = new System.Drawing.Size(300, 26);
            this.textBoxNOO.TabIndex = 13;
            this.textBoxNOO.Text = "Number of omnivores";
            this.textBoxNOO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNOO.Click += new System.EventHandler(this.textBoxNOO_Click);
            this.textBoxNOO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNOO_KeyPress);
            // 
            // textBoxNOC
            // 
            this.textBoxNOC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNOC.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNOC.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxNOC.Location = new System.Drawing.Point(14, 389);
            this.textBoxNOC.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNOC.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxNOC.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxNOC.Name = "textBoxNOC";
            this.textBoxNOC.Size = new System.Drawing.Size(300, 26);
            this.textBoxNOC.TabIndex = 12;
            this.textBoxNOC.Text = "Number of carnivores";
            this.textBoxNOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNOC.Click += new System.EventHandler(this.textBoxNOC_Click);
            this.textBoxNOC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNOC_KeyPress);
            // 
            // textBoxNOH
            // 
            this.textBoxNOH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNOH.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNOH.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxNOH.Location = new System.Drawing.Point(14, 353);
            this.textBoxNOH.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNOH.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxNOH.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxNOH.Name = "textBoxNOH";
            this.textBoxNOH.Size = new System.Drawing.Size(300, 26);
            this.textBoxNOH.TabIndex = 11;
            this.textBoxNOH.Text = "Number of herbivores";
            this.textBoxNOH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNOH.Click += new System.EventHandler(this.textBoxNOH_Click);
            this.textBoxNOH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNOH_KeyPress);
            // 
            // textBoxNOIPWTB
            // 
            this.textBoxNOIPWTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNOIPWTB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNOIPWTB.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxNOIPWTB.Location = new System.Drawing.Point(14, 142);
            this.textBoxNOIPWTB.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNOIPWTB.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxNOIPWTB.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxNOIPWTB.Name = "textBoxNOIPWTB";
            this.textBoxNOIPWTB.Size = new System.Drawing.Size(300, 26);
            this.textBoxNOIPWTB.TabIndex = 9;
            this.textBoxNOIPWTB.Text = "Number of inedible plants without berries";
            this.textBoxNOIPWTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNOIPWTB.Click += new System.EventHandler(this.textBoxNOIPWTB_Click);
            this.textBoxNOIPWTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNOIPWTB_KeyPress);
            // 
            // textBoxNOIPWB
            // 
            this.textBoxNOIPWB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNOIPWB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNOIPWB.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxNOIPWB.Location = new System.Drawing.Point(14, 106);
            this.textBoxNOIPWB.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNOIPWB.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxNOIPWB.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxNOIPWB.Name = "textBoxNOIPWB";
            this.textBoxNOIPWB.Size = new System.Drawing.Size(300, 26);
            this.textBoxNOIPWB.TabIndex = 8;
            this.textBoxNOIPWB.Text = "Number of inedible plants with berries";
            this.textBoxNOIPWB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNOIPWB.Click += new System.EventHandler(this.textBoxNOIPWB_Click);
            this.textBoxNOIPWB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNOIPWB_KeyPress);
            // 
            // textBoxNONPWTB
            // 
            this.textBoxNONPWTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNONPWTB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNONPWTB.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxNONPWTB.Location = new System.Drawing.Point(14, 286);
            this.textBoxNONPWTB.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNONPWTB.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxNONPWTB.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxNONPWTB.Name = "textBoxNONPWTB";
            this.textBoxNONPWTB.Size = new System.Drawing.Size(300, 26);
            this.textBoxNONPWTB.TabIndex = 7;
            this.textBoxNONPWTB.Text = "Number of nontoxic plants without berries";
            this.textBoxNONPWTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNONPWTB.Click += new System.EventHandler(this.textBoxNONPWTB_Click);
            this.textBoxNONPWTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNONPWTB_KeyPress);
            // 
            // textBoxNONPWB
            // 
            this.textBoxNONPWB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNONPWB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNONPWB.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxNONPWB.Location = new System.Drawing.Point(14, 250);
            this.textBoxNONPWB.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNONPWB.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxNONPWB.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxNONPWB.Name = "textBoxNONPWB";
            this.textBoxNONPWB.Size = new System.Drawing.Size(300, 26);
            this.textBoxNONPWB.TabIndex = 6;
            this.textBoxNONPWB.Text = "Number of nontoxic plants with berries";
            this.textBoxNONPWB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNONPWB.Click += new System.EventHandler(this.textBoxNONPWB_Click);
            this.textBoxNONPWB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNONPWB_KeyPress);
            // 
            // textBoxNOTPWTB
            // 
            this.textBoxNOTPWTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNOTPWTB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNOTPWTB.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxNOTPWTB.Location = new System.Drawing.Point(14, 214);
            this.textBoxNOTPWTB.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNOTPWTB.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxNOTPWTB.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxNOTPWTB.Name = "textBoxNOTPWTB";
            this.textBoxNOTPWTB.Size = new System.Drawing.Size(300, 26);
            this.textBoxNOTPWTB.TabIndex = 5;
            this.textBoxNOTPWTB.Text = "Number of toxic plants without berries";
            this.textBoxNOTPWTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNOTPWTB.Click += new System.EventHandler(this.textBoxNOTPWTB_Click);
            this.textBoxNOTPWTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNOTPWTB_KeyPress);
            // 
            // ButtonMinus
            // 
            this.ButtonMinus.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("ButtonMinus.BackgroundImage")));
            this.ButtonMinus.Location = new System.Drawing.Point(67, 16);
            this.ButtonMinus.Name = "ButtonMinus";
            this.ButtonMinus.Size = new System.Drawing.Size(56, 51);
            this.ButtonMinus.TabIndex = 4;
            this.ButtonMinus.UseVisualStyleBackColor = true;
            this.ButtonMinus.Click += new System.EventHandler(this.ButtonMinus_Click);
            // 
            // ButtonPlus
            // 
            this.ButtonPlus.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("ButtonPlus.BackgroundImage")));
            this.ButtonPlus.Location = new System.Drawing.Point(5, 16);
            this.ButtonPlus.Name = "ButtonPlus";
            this.ButtonPlus.Size = new System.Drawing.Size(56, 51);
            this.ButtonPlus.TabIndex = 3;
            this.ButtonPlus.UseVisualStyleBackColor = true;
            this.ButtonPlus.Click += new System.EventHandler(this.ButtonPlus_Click);
            // 
            // textBoxNOTPWB
            // 
            this.textBoxNOTPWB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNOTPWB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNOTPWB.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxNOTPWB.Location = new System.Drawing.Point(14, 178);
            this.textBoxNOTPWB.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNOTPWB.MaximumSize = new System.Drawing.Size(300, 50);
            this.textBoxNOTPWB.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBoxNOTPWB.Name = "textBoxNOTPWB";
            this.textBoxNOTPWB.Size = new System.Drawing.Size(300, 26);
            this.textBoxNOTPWB.TabIndex = 1;
            this.textBoxNOTPWB.Text = "Number of toxic plants with berries";
            this.textBoxNOTPWB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNOTPWB.Click += new System.EventHandler(this.textBoxNOTPWB_Click);
            this.textBoxNOTPWB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNOTPWB_KeyPress);
            // 
            // bStart
            // 
            this.bStart.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.bStart.ForeColor = System.Drawing.Color.Black;
            this.bStart.Location = new System.Drawing.Point(57, 596);
            this.bStart.Margin = new System.Windows.Forms.Padding(5);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(188, 25);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseMnemonic = false;
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // GamePlace
            // 
            this.GamePlace.BackColor = System.Drawing.SystemColors.Control;
            this.GamePlace.Location = new System.Drawing.Point(358, 9);
            this.GamePlace.Margin = new System.Windows.Forms.Padding(20);
            this.GamePlace.Name = "GamePlace";
            this.GamePlace.Size = new System.Drawing.Size(0, 0);
            this.GamePlace.TabIndex = 1;
            this.GamePlace.TabStop = false;
            this.GamePlace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GamePlace_MouseClick);
            // 
            // timer1
            // 
            this.timer1.AutoReset = false;
            this.timer1.Interval = 200D;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1528, 925);
            this.Controls.Add(this.GamePlace);
            this.Controls.Add(this.WorkPlace);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "The Game of Life";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.WorkPlace.ResumeLayout(false);
            this.WorkPlace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.GamePlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.timer1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox textBoxHuman;

        private System.Windows.Forms.TextBox textBoxCellSize;
        private System.Windows.Forms.TextBox textBoxSizeWorld;

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.TextBox textBoxNOO;

        private System.Windows.Forms.TextBox textBoxNOC;

        private System.Windows.Forms.TextBox textBoxNOTPWTB;

        private System.Windows.Forms.TextBox textBoxNONPWTB;

        private System.Windows.Forms.TextBox textBoxNONPWB;

        private System.Windows.Forms.TextBox textBoxNOTPWB;

        private System.Windows.Forms.TextBox textBoxNOIPWTB;

        private System.Windows.Forms.TextBox textBoxNOIPWB;

        private System.Windows.Forms.TextBox textBoxNOH;

        private System.Windows.Forms.TextBox textBox12;

        private System.Windows.Forms.TextBox textBox11;

        private System.Windows.Forms.Button ButtonPlus;
        private System.Windows.Forms.Button ButtonMinus;

        private System.Windows.Forms.PictureBox GamePlace;

        private System.Windows.Forms.Button bStart;

        public System.Timers.Timer timer1;

        private System.Windows.Forms.GroupBox WorkPlace;

        #endregion
    }
}