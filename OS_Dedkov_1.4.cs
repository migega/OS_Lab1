using System;
using System.IO;
using System.IO.Compression;
namespace HelloApp {
    class KLASS {
        static void Main(string[] args) {
            string dirName = @"D:\";
            if (Directory.Exists(dirName)) {
                Console.WriteLine("Подкаталоги диска D:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs) {
                    Console.WriteLine(s);
                }
            }
            string path = @"D:\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists) {
                dirInfo.Create();
            }
            Console.WriteLine();
            Console.WriteLine("Выберете папку: ");
            string folder = Console.ReadLine();
            string sourceFolder = folder; // исходнаяпапка
            string zipFile = @"D:\testarchive.zip"; // сжатыйфайл
            string targetFolder = @"D:\testfolder"; // папка, куда распаковывается файл
            Console.WriteLine();
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            Console.WriteLine($"Выбранная папка, {sourceFolder}, заархивирована в файл{zipFile}");
            Console.WriteLine();
            FileInfo fileInf = new FileInfo(zipFile);
            if (fileInf.Exists) {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
            }
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
            Console.WriteLine($"Файл {zipFile} распакован в папку{targetFolder}");
            Console.WriteLine();
            Console.WriteLine("Файлы из распакованной папки: ");
            string[] files3 = Directory.GetFiles(targetFolder);
            foreach (string s in files3) { Console.WriteLine(s); }
            Console.WriteLine();
            Console.WriteLine("Выберете файл, о котором хотите посмотреть информацию:");
            string file3 = Console.ReadLine();
            Console.WriteLine();
            FileInfo fileInf1 = new FileInfo(file3);
            if (fileInf.Exists) {
                Console.WriteLine("Имя файла: {0}", fileInf1.Name);
                Console.WriteLine("Время создания: {0}", fileInf1.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf1.Length);
            }
            Console.WriteLine();
            string path3 = $"{path}testarchive.zip";
            FileInfo fileInf3 = new FileInfo(path3);
            Console.WriteLine($"После нажатия ENTER файл {path}testarchive.zip будет удалён:");
            string enter = Console.ReadLine();
            if (enter == "") {
                if (fileInf3.Exists)
                { fileInf3.Delete(); }
            }
            Console.WriteLine();
            Console.WriteLine($"После нажатия ENTER файл {path} testfolder будет удалён:");
            string enter1 = Console.ReadLine();
            if (enter1 == "") {
                string path4 = @"D:\testfolder";
                Directory.Delete(path4, true);
            }
        }
    }
}