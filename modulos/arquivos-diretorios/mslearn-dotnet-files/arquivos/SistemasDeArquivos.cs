using System;

namespace mslearn_dotnet_files
{
    public class SistemasDeArquivos : Arquivos
    {
        public SistemasDeArquivos()
        {
            var salesFiles = FindFiles("stores");

            foreach (var file in salesFiles) 
                Console.WriteLine(file);
        }
    }
}