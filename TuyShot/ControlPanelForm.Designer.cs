﻿
namespace TuyShot
{
    partial class ControlPanelForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTake = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnDonate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDonate);
            this.panel1.Controls.Add(this.btnInfo);
            this.panel1.Controls.Add(this.btnTake);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 106);
            this.panel1.TabIndex = 0;
            // 
            // btnTake
            // 
            this.btnTake.BackColor = System.Drawing.Color.Maroon;
            this.btnTake.FlatAppearance.BorderSize = 0;
            this.btnTake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTake.ForeColor = System.Drawing.Color.White;
            this.btnTake.Location = new System.Drawing.Point(0, 3);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(130, 27);
            this.btnTake.TabIndex = 0;
            this.btnTake.Text = "EKRANI ÇEK";
            this.btnTake.UseVisualStyleBackColor = false;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.Maroon;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Location = new System.Drawing.Point(-2, 36);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(132, 27);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "İLETİŞİM";
            this.btnInfo.UseVisualStyleBackColor = false;
            // 
            // btnDonate
            // 
            this.btnDonate.BackColor = System.Drawing.Color.Maroon;
            this.btnDonate.FlatAppearance.BorderSize = 0;
            this.btnDonate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonate.ForeColor = System.Drawing.Color.White;
            this.btnDonate.Location = new System.Drawing.Point(-2, 69);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(132, 27);
            this.btnDonate.TabIndex = 2;
            this.btnDonate.Text = "BAĞIŞ";
            this.btnDonate.UseVisualStyleBackColor = false;
            // 
            // ControlPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(132, 106);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÜYSHOT";
            this.Load += new System.EventHandler(this.ScreenShotForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.Button btnDonate;
        private System.Windows.Forms.Button btnInfo;
    }
}