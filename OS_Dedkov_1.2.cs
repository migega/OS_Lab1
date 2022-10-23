using System;
using System.IO;
namespace HelloApp {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\Users\Юрий\Desktop";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists) {
                dirInfo.Create();
            }
            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();
            using (FileStream fstream = new FileStream($"{path}\\testfile.txt", FileMode.OpenOrCreate)) {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
            using (FileStream fstream = File.OpenRead($"{path}\\testfile.txt")) {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
            Console.ReadLine();
            string pathf = $"{path}\\testfile.txt";
            FileInfo fileInf = new FileInfo(pathf);
            if (fileInf.Exists) {
                Console.WriteLine($"Вы хотите удалить файл? 0 - нет 1 - да");
                string ansdel = Console.ReadLine();
                if (ansdel == "0") {
                    Console.WriteLine($"Ок.");
                }
                if (ansdel == "1") {
                    fileInf.Delete();
                    Console.WriteLine($"Файл удален.");
                }
                if (!(ansdel == "1") && !(ansdel == "0")) {
                    fileInf.Delete();
                    Console.WriteLine($"Error.");
                }
            }
        }
    }
}