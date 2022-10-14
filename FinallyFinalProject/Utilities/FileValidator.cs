using System.IO;


namespace FinallyFinalProject.Utilities
{
    public static class FileValidator
    {
        public static void FileDelete(string root, string folder, string image)
        {
            string filePath = Path.Combine(root, folder, image);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }

    }
}
