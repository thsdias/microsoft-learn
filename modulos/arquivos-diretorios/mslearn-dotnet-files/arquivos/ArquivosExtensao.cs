using System;
using System.IO;

namespace mslearn_dotnet_files
{
    public class ArquivosExtensao : Arquivos
    {
        public ArquivosExtensao()
        {
            var storesDirectory = Path.Combine(CurrentDirectory, "stores");
            var salesFiles = FindFiles(storesDirectory, ".json");

            foreach (var file in salesFiles)
                Console.WriteLine(file);
        }
    }
}