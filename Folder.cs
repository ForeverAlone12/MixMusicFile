using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MixMusicFile
{
    /// <summary>
    /// Работа с папкой.
    /// </summary>
    class Folder
    {
        /// <summary>
        /// Полный путь до папки.
        /// </summary>
        public String FullPath { get; set; }
                     
        /// <summary>
        /// Количество файлов папке.
        /// </summary>
        public int CountFiles { get; set; }

        /// <summary>
        /// Общий размер файлов.
        /// </summary>
        public long SizeFiles { get; set; }

        /// <summary>
        /// Количество свободного места на диске.
        /// </summary>
        public long FreeSpaceOnDisk { get; set; }

        /// <summary>
        /// Инициализация данных.
        /// </summary>
        /// <param name="pathToFolder">Полный путь до папки</param>
        public Folder(String pathToFolder)
        {
            FullPath = pathToFolder;
            CountFiles = getCountFilesInFolder(FullPath);
            SizeFiles = getSizeFilesInFolder(FullPath);
            FreeSpaceOnDisk = getFreeSpaceOnDisk(FullPath);
        }

        /// <summary>
        /// Получить количество файлов в указанной папке.
        /// </summary>
        /// <param name="pathToFolder">Полный путь до папки</param>
        /// <returns>Количество файлов в указанной папке</returns>
        private int getCountFilesInFolder(String pathToFolder)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(pathToFolder);

                if (directoryInfo.Exists)
                {
                    return directoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).Length;
                }
                return -1;
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Получить общий размер файлов.
        /// </summary>
        /// <param name="pathToFolder">Полный путь до папки</param>
        /// <returns>Общий размер файлов</returns>
        private long getSizeFilesInFolder(String pathToFolder)
        {
            long sizeFiles = 0;
            try {
                DirectoryInfo drInfo = new DirectoryInfo(pathToFolder);
                FileInfo[] files = drInfo.GetFiles();

                foreach (FileInfo file in files)
                {
                    sizeFiles += file.Length;
                }
                /*
                DirectoryInfo[] folders = drInfo.GetDirectories();
                foreach (DirectoryInfo folder in folders)
                {
                    sizeFiles += getSizeFilesInFolder(pathToFolder + "\\" + folder.Name);
                }
                */
                return sizeFiles;
            } catch(UnauthorizedAccessException)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Получить размер свободного места на диске в байтах.
        /// </summary>
        /// <param name="pathToFolder">общий размер файлов</param>
        /// <returns>Размер свободного места на диске в байтах</returns>
        private long getFreeSpaceOnDisk(String pathToFolder)
        {
            DriveInfo di = new DriveInfo(pathToFolder);
            return di.AvailableFreeSpace;
        }

        /// <summary>
        /// Переместить все музыкальные файлы в новое местоположение. 
        /// </summary>
        /// <param name="destFolderPath">Новое местоположение</param>
        public void moveFilesToFolder(String destFolderPath) 
        {
            string[] files = Directory.GetFiles(FullPath);
            try
            {
                 foreach (string file in files)
                 {
                    File.Move(file, destFolderPath + "\\" + Path.GetFileName(file));
                 }
            }
            catch (IOException)
            {
                throw;
            }
        }

        /// <summary>
        /// Переименовать файлы в папке.
        /// </summary>
        public void renameFilesInFolder() 
        {
            string newName = "";

            String regWordsInRoundBrackets = @"\([^)]+\)";
            String regWordsInSquareBrackets = @"\[[^)]+\]";
            String regNotLettersAndSpace = @"[^A-zА-я\s]";
            String regUnderscore = @"_";
            DirectoryInfo drInfo = new DirectoryInfo(FullPath);        
            try
            {
                foreach (FileInfo file in drInfo.GetFiles())
                {                    
                    newName = Path.GetFileNameWithoutExtension(file.Name);
                    newName = Regex.Replace(newName, regWordsInRoundBrackets, String.Empty);
                    newName = Regex.Replace(newName, regWordsInSquareBrackets, String.Empty);
                    newName = Regex.Replace(newName, regNotLettersAndSpace, String.Empty);
                    newName = Regex.Replace(newName, regUnderscore, String.Empty);
                    newName = Path.Combine(file.DirectoryName, newName + file.Extension);
                    File.Move(file.FullName, newName );
                }
            } catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e.ToString());
            }       
        }

    }
}
