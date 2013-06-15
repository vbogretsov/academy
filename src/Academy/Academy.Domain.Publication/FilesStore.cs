using System;
using System.IO;
using System.Text;

namespace Academy.Domain.Services
{
    public class FilesStore
    {
        private const int SoltSize = 10;

        private static readonly Random random;

        static FilesStore()
        {
            random = new Random();
        }

        public string Upload(Stream fileStream, string folderName, string fileName)
        {
            string path = GetFileName(folderName, fileName);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            using (FileStream target = File.Create(path))
            {
                fileStream.CopyTo(target);
            }
            return Path.GetFileName(path);
        }

        private static string GetFileName(string folderName, string fileName)
        {
            string path = Path.Combine(folderName, fileName);
            if (File.Exists(path))
            {
                path = Path.Combine(
                    folderName,
                    String.Format("{0}_{1}", GetSolt(), fileName));
            }
            return path;
        }

        private static string GetSolt()
        {
            StringBuilder solt = new StringBuilder(SoltSize);
            for (int i = 0; i < SoltSize; i++)
            {
                solt.Append((char)random.Next(97, 123));
            }
            return solt.ToString();
        }
    }
}
