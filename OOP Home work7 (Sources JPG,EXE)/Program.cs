using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceDirectory = "Directory";
        string destinationDirectory = "Ddirectory";

        // Проверка наличия исходной папки
        if (!Directory.Exists(sourceDirectory))
        {
            Console.WriteLine("Исходная папка не существует.");
            return;
        }

        // Создание папки назначения, если она не существует
        if (!Directory.Exists(destinationDirectory))
        {
            Directory.CreateDirectory(destinationDirectory);
        }

        // Получение списка файлов в исходной папке
        string[] files = Directory.GetFiles(sourceDirectory);

        foreach (string file in files)
        {
            // Получение расширения файла
            string extension = Path.GetExtension(file);

            // Проверка наличия расширения
            if (!string.IsNullOrEmpty(extension))
            {
                // Формирование пути к папке назначения
                string destinationPath = Path.Combine(destinationDirectory, extension.TrimStart('.'));

                // Создание папки назначения, если она не существует
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                // Перемещение файла в папку назначения
                string fileName = Path.GetFileName(file);
                string destinationFile = Path.Combine(destinationPath, fileName);
                File.Move(file, destinationFile);
            }
        }

        Console.WriteLine("Файлы были успешно рассортированы.");
    }
}