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


        public Form1()
        {
            InitializeComponent();
            getOSName();
            getFreeSpace();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblIsFull.Visible = false;
            lblCountFiles.Visible = false;
            textBox2.Text = tmp_dir;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenFolderWithMusic_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            String path_folder = folderBrowserDialog1.SelectedPath;
            
            textBox1.Text = path_folder;
            countFilesInFolder(path_folder);
        }

        private void countFilesInFolder(String path_folder)
        {
            int count_files = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(path_folder);
            if (directoryInfo.Exists)
            {
                count_files = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories).Length;
            }

            lblCountFiles.Text = count_files.ToString();
            lblCountFiles.Visible = true;
        } 

        private void getOSName()
        {
           
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            tmp_dir =  name != null ? tmp_windows : tmp_linux;
        }

        private void getFreeSpace()
        {
            DriveInfo di = new DriveInfo(tmp_windows);
            double Ffree = (di.AvailableFreeSpace / 1024) / 1024;
            lblFreeSpace.Text = Ffree.ToString("#,##") + " MB";
        }
    }
}
