﻿namespace GoogleClassSorterer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPupilLabel = new System.Windows.Forms.Panel();
            this.pnlNameLabel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlReadyLabel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlPupilLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlNameLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlReadyLabel, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(999, 704);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Montserrat Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(501, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(495, 80);
            this.label3.TabIndex = 7;
            this.label3.Text = "Done";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Montserrat Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(252, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 80);
            this.label2.TabIndex = 6;
            this.label2.Text = "True names";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlPupilLabel
            // 
            this.pnlPupilLabel.AutoScroll = true;
            this.pnlPupilLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPupilLabel.Location = new System.Drawing.Point(3, 83);
            this.pnlPupilLabel.Name = "pnlPupilLabel";
            this.pnlPupilLabel.Size = new System.Drawing.Size(243, 618);
            this.pnlPupilLabel.TabIndex = 0;
            // 
            // pnlNameLabel
            // 
            this.pnlNameLabel.AutoScroll = true;
            this.pnlNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNameLabel.Location = new System.Drawing.Point(252, 83);
            this.pnlNameLabel.Name = "pnlNameLabel";
            this.pnlNameLabel.Size = new System.Drawing.Size(243, 618);
            this.pnlNameLabel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Montserrat Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 80);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pupils without true name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlReadyLabel
            // 
            this.pnlReadyLabel.AutoScroll = true;
            this.pnlReadyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReadyLabel.Location = new System.Drawing.Point(501, 83);
            this.pnlReadyLabel.Name = "pnlReadyLabel";
            this.pnlReadyLabel.Size = new System.Drawing.Size(495, 618);
            this.pnlReadyLabel.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 704);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlPupilLabel;
        private System.Windows.Forms.Panel pnlNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlReadyLabel;
    }
}