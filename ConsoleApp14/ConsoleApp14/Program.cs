class Program
{
    static void Main(string[] args)
    {
        // Путь к папке, которую нужно очистить
        string folderPath = @"C:\path\to\folder";

        // Получаем размер папки до очистки
        long folderSizeBeforeClean = GetFolderSize(folderPath);
        Console.WriteLine($"Размер папки до очистки: {folderSizeBeforeClean} байт");

        // Выполняем очистку
        int filesDeleted = CleanFolder(folderPath);
        long spaceFreed = GetFolderSize(folderPath) - folderSizeBeforeClean;

        // Выводим результаты
        Console.WriteLine($"Удалено {filesDeleted} файлов, освобождено {spaceFreed} байт");

        // Получаем размер папки после очистки
        long folderSizeAfterClean = GetFolderSize(folderPath);
        Console.WriteLine($"Размер папки после очистки: {folderSizeAfterClean} байт");
    }

    static long GetFolderSize(string path)
    {
        long size = 0;
        try
        {
            foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
            {
                size += new FileInfo(file).Length;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении размера папки: {ex.Message}");
        }
        return size;
    }

    static int CleanFolder(string path)
    {
        int filesDeleted = 0;
        try
        {
            foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
            {
                File.Delete(file);
                filesDeleted++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при очистке папки: {ex.Message}");
        }
        return filesDeleted;
    }
}