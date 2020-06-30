namespace GoogleClassSorterer
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
            this.lblCsvFile = new System.Windows.Forms.Label();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnNZ = new System.Windows.Forms.Button();
            this.lblNzFile = new System.Windows.Forms.Label();
            this.ClassRoomOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.NZOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblClassRoomFileError = new System.Windows.Forms.Label();
            this.lblNZFileError = new System.Windows.Forms.Label();
            this.btnMatch = new System.Windows.Forms.Button();
            this.lblMatchFileError = new System.Windows.Forms.Label();
            this.btnLoadXml = new System.Windows.Forms.Button();
            this.lblMatchFile = new System.Windows.Forms.Label();
            this.btnSaveXml = new System.Windows.Forms.Button();
            this.MatchOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.matchSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveAsXml = new System.Windows.Forms.Button();
            this.btnMakeXlsx = new System.Windows.Forms.Button();
            this.GradeSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblXLSError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCsvFile
            // 
            this.lblCsvFile.AutoSize = true;
            this.lblCsvFile.Font = new System.Drawing.Font("Montserrat Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCsvFile.Location = new System.Drawing.Point(69, 61);
            this.lblCsvFile.Name = "lblCsvFile";
            this.lblCsvFile.Size = new System.Drawing.Size(403, 37);
            this.lblCsvFile.TabIndex = 0;
            this.lblCsvFile.Text = "Google Clasroom File *.csv";
            // 
            // btnCSV
            // 
            this.btnCSV.Font = new System.Drawing.Font("Montserrat Black", 16F);
            this.btnCSV.Location = new System.Drawing.Point(505, 46);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(67, 66);
            this.btnCSV.TabIndex = 1;
            this.btnCSV.Text = "...";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNZ
            // 
            this.btnNZ.Enabled = false;
            this.btnNZ.Font = new System.Drawing.Font("Montserrat Black", 16F);
            this.btnNZ.Location = new System.Drawing.Point(329, 182);
            this.btnNZ.Name = "btnNZ";
            this.btnNZ.Size = new System.Drawing.Size(67, 66);
            this.btnNZ.TabIndex = 3;
            this.btnNZ.Text = "...";
            this.btnNZ.UseVisualStyleBackColor = true;
            this.btnNZ.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblNzFile
            // 
            this.lblNzFile.AutoSize = true;
            this.lblNzFile.Font = new System.Drawing.Font("Montserrat Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNzFile.Location = new System.Drawing.Point(69, 197);
            this.lblNzFile.Name = "lblNzFile";
            this.lblNzFile.Size = new System.Drawing.Size(225, 37);
            this.lblNzFile.TabIndex = 2;
            this.lblNzFile.Text = "nz.ua File *.xls";
            // 
            // ClassRoomOpenFileDialog
            // 
            this.ClassRoomOpenFileDialog.FileName = "openFileDialog1";
            // 
            // NZOpenFileDialog
            // 
            this.NZOpenFileDialog.FileName = "openFileDialog1";
            // 
            // lblClassRoomFileError
            // 
            this.lblClassRoomFileError.AutoSize = true;
            this.lblClassRoomFileError.Font = new System.Drawing.Font("Montserrat Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClassRoomFileError.ForeColor = System.Drawing.Color.Red;
            this.lblClassRoomFileError.Location = new System.Drawing.Point(69, 107);
            this.lblClassRoomFileError.Name = "lblClassRoomFileError";
            this.lblClassRoomFileError.Size = new System.Drawing.Size(0, 20);
            this.lblClassRoomFileError.TabIndex = 4;
            // 
            // lblNZFileError
            // 
            this.lblNZFileError.AutoSize = true;
            this.lblNZFileError.Font = new System.Drawing.Font("Montserrat Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNZFileError.ForeColor = System.Drawing.Color.Red;
            this.lblNZFileError.Location = new System.Drawing.Point(72, 239);
            this.lblNZFileError.Name = "lblNZFileError";
            this.lblNZFileError.Size = new System.Drawing.Size(0, 20);
            this.lblNZFileError.TabIndex = 5;
            // 
            // btnMatch
            // 
            this.btnMatch.Font = new System.Drawing.Font("Montserrat Black", 16F);
            this.btnMatch.Location = new System.Drawing.Point(73, 128);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(138, 66);
            this.btnMatch.TabIndex = 6;
            this.btnMatch.Text = "match";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Visible = false;
            this.btnMatch.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblMatchFileError
            // 
            this.lblMatchFileError.AutoSize = true;
            this.lblMatchFileError.Font = new System.Drawing.Font("Montserrat Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMatchFileError.ForeColor = System.Drawing.Color.Red;
            this.lblMatchFileError.Location = new System.Drawing.Point(72, 337);
            this.lblMatchFileError.Name = "lblMatchFileError";
            this.lblMatchFileError.Size = new System.Drawing.Size(0, 20);
            this.lblMatchFileError.TabIndex = 9;
            // 
            // btnLoadXml
            // 
            this.btnLoadXml.Enabled = false;
            this.btnLoadXml.Font = new System.Drawing.Font("Montserrat Black", 16F);
            this.btnLoadXml.Location = new System.Drawing.Point(410, 280);
            this.btnLoadXml.Name = "btnLoadXml";
            this.btnLoadXml.Size = new System.Drawing.Size(109, 66);
            this.btnLoadXml.TabIndex = 8;
            this.btnLoadXml.Text = "load";
            this.btnLoadXml.UseVisualStyleBackColor = true;
            this.btnLoadXml.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // lblMatchFile
            // 
            this.lblMatchFile.AutoSize = true;
            this.lblMatchFile.Font = new System.Drawing.Font("Montserrat Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMatchFile.Location = new System.Drawing.Point(69, 295);
            this.lblMatchFile.Name = "lblMatchFile";
            this.lblMatchFile.Size = new System.Drawing.Size(300, 37);
            this.lblMatchFile.TabIndex = 7;
            this.lblMatchFile.Text = "matching File *.xml";
            // 
            // btnSaveXml
            // 
            this.btnSaveXml.Enabled = false;
            this.btnSaveXml.Font = new System.Drawing.Font("Montserrat Black", 16F);
            this.btnSaveXml.Location = new System.Drawing.Point(525, 280);
            this.btnSaveXml.Name = "btnSaveXml";
            this.btnSaveXml.Size = new System.Drawing.Size(109, 66);
            this.btnSaveXml.TabIndex = 10;
            this.btnSaveXml.Text = "save";
            this.btnSaveXml.UseVisualStyleBackColor = true;
            this.btnSaveXml.Click += new System.EventHandler(this.button5_Click);
            // 
            // MatchOpenFileDialog
            // 
            this.MatchOpenFileDialog.FileName = "openFileDialog1";
            // 
            // btnSaveAsXml
            // 
            this.btnSaveAsXml.Enabled = false;
            this.btnSaveAsXml.Font = new System.Drawing.Font("Montserrat Black", 16F);
            this.btnSaveAsXml.Location = new System.Drawing.Point(640, 280);
            this.btnSaveAsXml.Name = "btnSaveAsXml";
            this.btnSaveAsXml.Size = new System.Drawing.Size(180, 66);
            this.btnSaveAsXml.TabIndex = 11;
            this.btnSaveAsXml.Text = "save as...";
            this.btnSaveAsXml.UseVisualStyleBackColor = true;
            this.btnSaveAsXml.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnMakeXlsx
            // 
            this.btnMakeXlsx.Enabled = false;
            this.btnMakeXlsx.Font = new System.Drawing.Font("Montserrat Black", 16F);
            this.btnMakeXlsx.Location = new System.Drawing.Point(236, 406);
            this.btnMakeXlsx.Name = "btnMakeXlsx";
            this.btnMakeXlsx.Size = new System.Drawing.Size(423, 66);
            this.btnMakeXlsx.TabIndex = 12;
            this.btnMakeXlsx.Text = "Make xlsx with grade";
            this.btnMakeXlsx.UseVisualStyleBackColor = true;
            this.btnMakeXlsx.Click += new System.EventHandler(this.button7_Click);
            // 
            // lblXLSError
            // 
            this.lblXLSError.AutoSize = true;
            this.lblXLSError.Font = new System.Drawing.Font("Montserrat Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblXLSError.ForeColor = System.Drawing.Color.Red;
            this.lblXLSError.Location = new System.Drawing.Point(232, 484);
            this.lblXLSError.Name = "lblXLSError";
            this.lblXLSError.Size = new System.Drawing.Size(0, 20);
            this.lblXLSError.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 527);
            this.Controls.Add(this.lblXLSError);
            this.Controls.Add(this.btnMakeXlsx);
            this.Controls.Add(this.btnSaveAsXml);
            this.Controls.Add(this.btnSaveXml);
            this.Controls.Add(this.lblMatchFileError);
            this.Controls.Add(this.btnLoadXml);
            this.Controls.Add(this.lblMatchFile);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.lblNZFileError);
            this.Controls.Add(this.lblClassRoomFileError);
            this.Controls.Add(this.btnNZ);
            this.Controls.Add(this.lblNzFile);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.lblCsvFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCsvFile;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Button btnNZ;
        private System.Windows.Forms.Label lblNzFile;
        private System.Windows.Forms.OpenFileDialog ClassRoomOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog NZOpenFileDialog;
        private System.Windows.Forms.Label lblClassRoomFileError;
        private System.Windows.Forms.Label lblNZFileError;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Label lblMatchFileError;
        private System.Windows.Forms.Button btnLoadXml;
        private System.Windows.Forms.Label lblMatchFile;
        private System.Windows.Forms.Button btnSaveXml;
        private System.Windows.Forms.OpenFileDialog MatchOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog matchSaveFileDialog;
        private System.Windows.Forms.Button btnSaveAsXml;
        private System.Windows.Forms.Button btnMakeXlsx;
        private System.Windows.Forms.SaveFileDialog GradeSaveFileDialog;
        private System.Windows.Forms.Label lblXLSError;
    }
}

