using System.ComponentModel;
using System.Windows.Forms;

namespace Simulation_of_life.Gaming_Tools
{
    partial class InformationFormAboutHuman
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.textBoxHP = new System.Windows.Forms.TextBox();
            this.textBoxSatiety = new System.Windows.Forms.TextBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBoxNameType = new System.Windows.Forms.TextBox();
            this.textBoxInvInfo = new System.Windows.Forms.TextBox();
            this.listBoxInfoInventory = new System.Windows.Forms.ListBox();
            this.textBoxTAnimal = new System.Windows.Forms.TextBox();
            this.listBoxTamedAnimal = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBoxPartner = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBoxHP
            // 
            this.textBoxHP.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxHP.Enabled = false;
            this.textBoxHP.Location = new System.Drawing.Point(142, 12);
            this.textBoxHP.Name = "textBoxHP";
            this.textBoxHP.Size = new System.Drawing.Size(100, 20);
            this.textBoxHP.TabIndex = 0;
            // 
            // textBoxSatiety
            // 
            this.textBoxSatiety.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxSatiety.Enabled = false;
            this.textBoxSatiety.Location = new System.Drawing.Point(142, 38);
            this.textBoxSatiety.Name = "textBoxSatiety";
            this.textBoxSatiety.Size = new System.Drawing.Size(100, 20);
            this.textBoxSatiety.TabIndex = 1;
            // 
            // textBoxType
            // 
            this.textBoxType.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxType.Enabled = false;
            this.textBoxType.Location = new System.Drawing.Point(142, 64);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(100, 20);
            this.textBoxType.TabIndex = 2;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(12, 12);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(116, 20);
            this.textBox6.TabIndex = 6;
            this.textBox6.Text = "HP";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(12, 38);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(116, 20);
            this.textBox7.TabIndex = 7;
            this.textBox7.Text = "Satiety";
            // 
            // textBoxNameType
            // 
            this.textBoxNameType.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxNameType.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxNameType.Enabled = false;
            this.textBoxNameType.Location = new System.Drawing.Point(12, 64);
            this.textBoxNameType.Name = "textBoxNameType";
            this.textBoxNameType.Size = new System.Drawing.Size(116, 20);
            this.textBoxNameType.TabIndex = 8;
            this.textBoxNameType.Text = "Type";
            // 
            // textBoxInvInfo
            // 
            this.textBoxInvInfo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxInvInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxInvInfo.Enabled = false;
            this.textBoxInvInfo.Location = new System.Drawing.Point(12, 162);
            this.textBoxInvInfo.Name = "textBoxInvInfo";
            this.textBoxInvInfo.Size = new System.Drawing.Size(116, 20);
            this.textBoxInvInfo.TabIndex = 9;
            this.textBoxInvInfo.Text = "Inventory Information";
            // 
            // listBoxInfoInventory
            // 
            this.listBoxInfoInventory.Location = new System.Drawing.Point(142, 162);
            this.listBoxInfoInventory.Name = "listBoxInfoInventory";
            this.listBoxInfoInventory.Size = new System.Drawing.Size(100, 108);
            this.listBoxInfoInventory.TabIndex = 10;
            // 
            // textBoxTAnimal
            // 
            this.textBoxTAnimal.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxTAnimal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxTAnimal.Enabled = false;
            this.textBoxTAnimal.Location = new System.Drawing.Point(12, 276);
            this.textBoxTAnimal.Name = "textBoxTAnimal";
            this.textBoxTAnimal.Size = new System.Drawing.Size(116, 20);
            this.textBoxTAnimal.TabIndex = 11;
            this.textBoxTAnimal.Text = "A tamed animal";
            // 
            // listBoxTamedAnimal
            // 
            this.listBoxTamedAnimal.Enabled = false;
            this.listBoxTamedAnimal.Location = new System.Drawing.Point(142, 276);
            this.listBoxTamedAnimal.Name = "listBoxTamedAnimal";
            this.listBoxTamedAnimal.Size = new System.Drawing.Size(100, 43);
            this.listBoxTamedAnimal.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Partner";
            // 
            // listBoxPartner
            // 
            this.listBoxPartner.Location = new System.Drawing.Point(142, 90);
            this.listBoxPartner.Name = "listBoxPartner";
            this.listBoxPartner.Size = new System.Drawing.Size(100, 56);
            this.listBoxPartner.TabIndex = 14;
            // 
            // InformationFormAboutHuman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(254, 331);
            this.Controls.Add(this.listBoxPartner);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBoxTamedAnimal);
            this.Controls.Add(this.textBoxTAnimal);
            this.Controls.Add(this.listBoxInfoInventory);
            this.Controls.Add(this.textBoxInvInfo);
            this.Controls.Add(this.textBoxNameType);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.textBoxSatiety);
            this.Controls.Add(this.textBoxHP);
            this.Name = "InformationFormAboutHuman";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InformationFormAboutHuman_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public System.Windows.Forms.ListBox listBoxPartner;

        private System.Windows.Forms.TextBox textBoxSatiety;

        private System.Windows.Forms.TextBox textBoxType;

        public System.Windows.Forms.ListBox listBoxInfoInventory;

        public System.Windows.Forms.ListBox listBoxTamedAnimal;

        private System.Windows.Forms.TextBox textBoxTAnimal;

        private System.Windows.Forms.TextBox textBoxInvInfo;

        private System.Windows.Forms.TextBox textBoxNameType;

        private System.Windows.Forms.ListBox listBox2;

        private System.Windows.Forms.TextBox textBox3;

        public System.Windows.Forms.ListBox listBox1;

        private System.Windows.Forms.TextBox textBox9;

        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox6;

        private System.Windows.Forms.TextBox textBoxHP;

        #endregion

        private System.Windows.Forms.TextBox textBox1;
    }
}