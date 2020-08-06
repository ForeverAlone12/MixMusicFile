using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;

namespace MixMusicFile
{
    public partial class Form1 : Form
    {
        private string tmp_dir = "";

        private string tmp_windows = @"C:\";
        private string tmp_linux = "/tmp";

        private Folder FolderWithMusic;
        private Folder TmpFolder;


        public Form1()
        {
            InitializeComponent();
            getOSName();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblIsFull.Visible = false;
            lblCountFiles.Visible = false;
            lblFilesSize.Visible = false;
            textBox2.Text = tmp_dir;
            try
            {
                TmpFolder = new Folder(tmp_dir);
            }catch(UnauthorizedAccessException argNullEx)
            {
                MessageBox.Show(argNullEx.ToString());
            }
           
        }

        private void btnMixMusic_Click(object sender, EventArgs e)
        {
            try
            {
                FolderWithMusic.moveFilesToFolder(TmpFolder.FullPath);
                TmpFolder.renameFilesInFolder();
                TmpFolder.moveFilesToFolder(FolderWithMusic.FullPath);
            }catch (IOException ioEx)
            {
                MessageBox.Show(ioEx.ToString());
            }
            
        }

        private void btnOpenFolderWithMusic_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            textBox1.Text = folderBrowserDialog1.SelectedPath;

            try
            {
                FolderWithMusic = new Folder(folderBrowserDialog1.SelectedPath);
            }catch(UnauthorizedAccessException argNullEx)
            {
                MessageBox.Show(argNullEx.ToString());
            }


    lblCountFiles.Text = FolderWithMusic.CountFiles.ToString();
            lblCountFiles.Visible = true;

            lblFilesSize.Text = byteToString(FolderWithMusic.SizeFiles);
            lblFilesSize.Visible = true;
        }     

        private void getOSName()
        {           
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            tmp_dir =  name != null ? tmp_windows : tmp_linux;
        }

        /// <summary>
        /// ??? Размер файл(а/ов) в произвольных величинах ???
        /// </summary>
        /// <param name="byteCount">Размер файл(а/ов) в байтах </param>
        /// <returns></returns>
        public String byteToString(long byteCount)
        {
            string[] suf = { "байт", "Кбайт", "Мбайт", "Гбайт", "Тбайт" };
            if (byteCount == 0)
                return "Нет свободного места на диске";
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }

        private void btnOpenTempFolder_Click(object sender, EventArgs e)
        {
            lblIsFull.Visible = false;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            TmpFolder = new Folder(folderBrowserDialog1.SelectedPath);

         
            textBox2.Text = folderBrowserDialog1.SelectedPath;      

            lblIsFull.Visible = TmpFolder.FreeSpaceOnDisk < FolderWithMusic.SizeFiles ? true : false;
        }

        private void checkIsScanFolder_CheckedChanged(object sender, EventArgs e)
        {
          //  getCountAndSizeFilesInFolder();
        }
    }
}
