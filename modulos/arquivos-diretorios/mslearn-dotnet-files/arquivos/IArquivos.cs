using System.Collections.Generic;

namespace mslearn_dotnet_files
{
    public interface IArquivos
    {
        public IEnumerable<string> FindFiles(string folderName);

        public IEnumerable<string> FindFiles(string folderName, string fileNameExtension);
    }
}