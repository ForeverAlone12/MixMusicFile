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
        public String FullPath { get; private set; }
                     
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

        private XMLReader xml = null;

        private Random rnd;

        /// <summary>
        /// Инициализация данных.
        /// </summary>
        /// <param name="pathToFolder">Полный путь до папки</param>
        public Folder(String pathToFolder)
        {
            rnd = new Random();
            xml = new XMLReader();
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
                    int countFiles = 0;
                    foreach (string extension in xml.MusicExtention)
                    {
                        countFiles += directoryInfo.GetFiles("*" + extension, SearchOption.TopDirectoryOnly).Length;
                    }
                    return countFiles;
                }
                return -1;
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch (ArgumentException)
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
                    if (xml.MusicExtention.Contains(file.Extension))
                    {
                        sizeFiles += file.Length;
                    }                                       
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
            try
            {
                 foreach (FileInfo file in new DirectoryInfo(FullPath).GetFiles())
                 {
                    if (xml.MusicExtention.Contains(file.Extension))
                    {
                        File.Move(file.FullName, destFolderPath + "\\" + file.Name);
                    }
                    
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

            String regNotLettersAndDigit = @"[^A-Za-zА-Яа-я\d]*";
            String regUnderscore = @"_";
            String regOnlyLettersOnStartLine = @"^[^a-zA-Zа-яА-Я]*";
            DirectoryInfo drInfo = new DirectoryInfo(FullPath);        
            try
            {
                foreach (FileInfo file in drInfo.GetFiles())
                {
                    newName = Path.GetFileNameWithoutExtension(file.Name);
                    Console.WriteLine("Имя файла: {0}", newName);

                    newName = Regex.Replace(newName, regOnlyLettersOnStartLine, String.Empty);
                    newName = Regex.Replace(newName, regUnderscore, " ");
                    newName = Regex.Replace(newName, regNotLettersAndDigit, String.Empty);
                    Console.WriteLine("Убрали все лишние символы: {0}", newName);

                    newName = rnd.Next(0, drInfo.GetFiles().Length).ToString() + newName;
                    Console.WriteLine("Добавили номер: {0}", newName);

                    newName = Path.Combine(file.DirectoryName, newName + file.Extension);
                    File.Move(file.FullName, newName);
                }
            } catch (Exception)
            {
                throw;
            }       
        }

    }
}
