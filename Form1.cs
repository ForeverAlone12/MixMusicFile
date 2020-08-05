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
        private string dir_with_music = "";
        private string tmp_dir = "";

        private string tmp_windows = @"C:\";
        private string tmp_linux = "/tmp";

        private long files_size = -1;
        private long free_spaces = -1;


        public Form1()
        {
            InitializeComponent();
            getOSName();
            getFreeSpace();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblIsFull.Visible = false;
            lblCountFiles.Visible = false;
            lblFilesSize.Visible = false;
            textBox2.Text = tmp_dir;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            copyFileToTmpDir();
        }

        private void btnOpenFolderWithMusic_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            dir_with_music = folderBrowserDialog1.SelectedPath;
            
            textBox1.Text = dir_with_music;
            getCountAndSizeFilesInFolder();
        }

        private void getCountAndSizeFilesInFolder()
        {
            int count_files = 0;
            
            DirectoryInfo directoryInfo = new DirectoryInfo(dir_with_music);

            SearchOption searchOptions = checkIsScanFolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            if (directoryInfo.Exists)
            {
                count_files = directoryInfo.GetFiles("*.*", searchOptions).Length;
            }

            lblCountFiles.Text = count_files.ToString();
            lblCountFiles.Visible = true;

            lblFilesSize.Text = byteToString(getSizeFileInFolder(dir_with_music));
            lblFilesSize.Visible = true;
        } 

        //private void getSizeFile

        private void getOSName()
        {
           
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            tmp_dir =  name != null ? tmp_windows : tmp_linux;
        }

        private void getFreeSpace()
        {
            DriveInfo di = new DriveInfo(tmp_dir);
            free_spaces = di.AvailableFreeSpace;
            lblFreeSpace.Text = byteToString(di.AvailableFreeSpace);
        }

        private String byteToString(long byteCount)
        {
            string[] suf = { "байт", "Кбайт", "Мбайт", "Гбайт", "Тбайт", "Пбайт", "Эбайт" }; 
            if (byteCount == 0)
                return "Нет свободного места на диске";
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() +" "+suf[place];
        }

        private void copyFileToTmpDir()
        {
            
        }

        private long getSizeFileInFolder(String path_folder)
        {
            long size_files = 0;
            DirectoryInfo DrInfo = new DirectoryInfo(path_folder);
            FileInfo[] Fi = DrInfo.GetFiles();

            foreach (FileInfo fl in Fi)
            {
                size_files += fl.Length;
            }

            if (checkIsScanFolder.Checked)
            {
                DirectoryInfo[] folders = DrInfo.GetDirectories();
                foreach (DirectoryInfo folder in folders)
                {
                    size_files += getSizeFileInFolder(path_folder + "\\" + folder.Name);
                }
            }

            files_size = size_files;
            return size_files;
        }

        private void btnOpenTempFolder_Click(object sender, EventArgs e)
        {
            lblIsFull.Visible = false;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;


            tmp_dir = folderBrowserDialog1.SelectedPath;

            textBox2.Text = tmp_dir;                       
            getFreeSpace();
            lblIsFull.Visible = free_spaces < files_size ? true : false;
        }

        private void checkIsScanFolder_CheckedChanged(object sender, EventArgs e)
        {
            getCountAndSizeFilesInFolder();
        }
    }
}
