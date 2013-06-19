using System;
using System.IO;

namespace Academy.Domain.Interface
{
    public interface IFileService
    {
        string Upload(Stream fileStream, string folderName, string fileName);
    }
}
