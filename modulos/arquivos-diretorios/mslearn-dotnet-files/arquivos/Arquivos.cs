using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace mslearn_dotnet_files
{
    public class Arquivos : IArquivos
    {
        /// <summary>
        /// Contem todas as extensoes disponiveis a serem localizadas dentros dos diretorios.
        /// </summary>
        public IDictionary<int, string> Extensao { get; }

        /// <summary>
        /// Retorna o caminho completo para o local atual.
        /// </summary>
        public string CurrentDirectory { get; }

        private List<string> _files;

        public Arquivos()
        {
            _files = new List<string>();

            Extensao = new Dictionary<int, string>()
            {
                { 1, ".json" },
                { 2, ".txt" },
                { 3, ".doc" },
                { 4, ".xls" }
            };

            CurrentDirectory = Directory.GetCurrentDirectory();
        }

        public IEnumerable<string> FindFiles(string folderName)
        {
            var foundFiles = FilesDirectory(folderName);

            foreach(var file in foundFiles)
            {
                if(file.EndsWith("sales.json"))
                    _files.Add(file);
            }

            return _files;
        }

        public IEnumerable<string> FindFiles(string folderName, string fileNameExtension)
        {
            var foundFiles = FilesDirectory(folderName); 

            if (!string.IsNullOrWhiteSpace(fileNameExtension))
            {
                foreach(var file in foundFiles)
                {
                    var extension = Path.GetExtension(file);

                    if (extension == fileNameExtension)
                        _files.Add(file);    
                }    
            }

            return _files;
        }

        IEnumerable<string> FilesDirectory(string folderName)
        {
            return Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);
        }

        public double CalculateSalesTotal(IEnumerable<string> salesFiles)
        {
            double salesTotal = 0;

            // Loop over each file path in salesFiles.
            foreach (var file in salesFiles)
            {
                // Read the contents of the file.
                string salesJson = File.ReadAllText(file);

                // Parse the contents as JSON.
                SalesData data = JsonConvert.DeserializeObject<SalesData>(salesJson);

                // Add the amount found in the Total field to the salesTotal variable.
                salesTotal += data?.Total ?? 0;
            }

            return salesTotal;
        }
    }
}