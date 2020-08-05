namespace MixMusicFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkIsScanFolder = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCountFiles = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOpenFolderWithMusic = new System.Windows.Forms.Button();
            this.btnOpenTempFolder = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblIsFull = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblFilesSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFreeSpace = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Папка с песнями";
            // 
            // checkIsScanFolder
            // 
            this.checkIsScanFolder.AutoSize = true;
            this.checkIsScanFolder.Checked = true;
            this.checkIsScanFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIsScanFolder.Location = new System.Drawing.Point(22, 83);
            this.checkIsScanFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkIsScanFolder.Name = "checkIsScanFolder";
            this.checkIsScanFolder.Size = new System.Drawing.Size(225, 27);
            this.checkIsScanFolder.TabIndex = 1;
            this.checkIsScanFolder.Text = "Включая вложенные папки";
            this.checkIsScanFolder.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 44);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(638, 29);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "По указанному пути обнаружено:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Файлов :";
            // 
            // lblCountFiles
            // 
            this.lblCountFiles.AutoSize = true;
            this.lblCountFiles.Location = new System.Drawing.Point(98, 151);
            this.lblCountFiles.Name = "lblCountFiles";
            this.lblCountFiles.Size = new System.Drawing.Size(52, 23);
            this.lblCountFiles.TabIndex = 6;
            this.lblCountFiles.Text = "label5";
            this.lblCountFiles.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Размер файлов :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(311, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Папка для временного хранения файлов";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(22, 216);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(638, 29);
            this.textBox2.TabIndex = 10;
            // 
            // btnOpenFolderWithMusic
            // 
            this.btnOpenFolderWithMusic.Location = new System.Drawing.Point(667, 44);
            this.btnOpenFolderWithMusic.Name = "btnOpenFolderWithMusic";
            this.btnOpenFolderWithMusic.Size = new System.Drawing.Size(31, 29);
            this.btnOpenFolderWithMusic.TabIndex = 11;
            this.btnOpenFolderWithMusic.Text = "...";
            this.btnOpenFolderWithMusic.UseVisualStyleBackColor = true;
            this.btnOpenFolderWithMusic.Click += new System.EventHandler(this.btnOpenFolderWithMusic_Click);
            // 
            // btnOpenTempFolder
            // 
            this.btnOpenTempFolder.Location = new System.Drawing.Point(667, 216);
            this.btnOpenTempFolder.Name = "btnOpenTempFolder";
            this.btnOpenTempFolder.Size = new System.Drawing.Size(31, 29);
            this.btnOpenTempFolder.TabIndex = 12;
            this.btnOpenTempFolder.Text = "...";
            this.btnOpenTempFolder.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(22, 251);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(146, 30);
            this.btnConvert.TabIndex = 13;
            this.btnConvert.Text = "Конвертировать";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblIsFull
            // 
            this.lblIsFull.AutoSize = true;
            this.lblIsFull.ForeColor = System.Drawing.Color.Red;
            this.lblIsFull.Location = new System.Drawing.Point(354, 190);
            this.lblIsFull.Name = "lblIsFull";
            this.lblIsFull.Size = new System.Drawing.Size(344, 23);
            this.lblIsFull.TabIndex = 14;
            this.lblIsFull.Text = "Недостаточно места для сохранения файлов";
            this.lblIsFull.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblFilesSize
            // 
            this.lblFilesSize.AutoSize = true;
            this.lblFilesSize.Location = new System.Drawing.Point(325, 151);
            this.lblFilesSize.Name = "lblFilesSize";
            this.lblFilesSize.Size = new System.Drawing.Size(52, 23);
            this.lblFilesSize.TabIndex = 15;
            this.lblFilesSize.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Свободно место на диске :";
            // 
            // lblFreeSpace
            // 
            this.lblFreeSpace.AutoSize = true;
            this.lblFreeSpace.Location = new System.Drawing.Point(408, 255);
            this.lblFreeSpace.Name = "lblFreeSpace";
            this.lblFreeSpace.Size = new System.Drawing.Size(52, 23);
            this.lblFreeSpace.TabIndex = 17;
            this.lblFreeSpace.Text = "label7";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 294);
            this.Controls.Add(this.lblFreeSpace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFilesSize);
            this.Controls.Add(this.lblIsFull);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnOpenTempFolder);
            this.Controls.Add(this.btnOpenFolderWithMusic);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCountFiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkIsScanFolder);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "MixMusicFile";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkIsScanFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCountFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnOpenFolderWithMusic;
        private System.Windows.Forms.Button btnOpenTempFolder;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblIsFull;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblFilesSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFreeSpace;
    }
}

