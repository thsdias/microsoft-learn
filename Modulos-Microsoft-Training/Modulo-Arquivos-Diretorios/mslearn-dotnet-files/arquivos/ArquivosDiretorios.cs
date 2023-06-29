using System;
using System.IO;

namespace mslearn_dotnet_files
{
    public class ArquivosDiretorios: Arquivos
    {
        const string storePath = "stores";
        const string salesPathTotalDir = "salesTotalDir";

        public ArquivosDiretorios()
        {
            var storesDirectory = Path.Combine(CurrentDirectory, storePath);
            var salesTotalDir = Path.Combine(CurrentDirectory, salesPathTotalDir);

            Directory.CreateDirectory(salesTotalDir);

            var salesFiles = FindFiles(storesDirectory);

            var salesTotal = CalculateSalesTotal(salesFiles);

            // Cria aqrquivo vazio dentro do diretorio selecionado.
            //File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), string.Empty);
        
            File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");
        }
    }
}