using System.Collections.Generic;
using System.IO;

namespace OverUnderSample
{
    public class FileLoader
    {
        private readonly char _dataSeparator;
        private readonly string _filePath;


        public FileLoader(string dataSetsLocalistaion, string dataSetName, string fileExtension, char dataSeparator)
        {
            _dataSeparator = dataSeparator;
            _filePath = dataSetsLocalistaion + "\\" + dataSetName + fileExtension;
        }

        public FileLoader(string filePath, char dataSeparator)
        {
            _filePath = filePath;
            _dataSeparator = dataSeparator;
        }


        public List<List<string>> GetCsv()
        {
            var reader = new StreamReader(File.OpenRead(_filePath));
            var twoDimensionalList = new List<List<string>>();
            var lineNumber = 0;

            var line = reader.ReadLine();
            var values = line.Split(_dataSeparator);


            var arrayWidht = values.Length;
            twoDimensionalList.Add(new List<string>(arrayWidht));
            FillElement(values, arrayWidht, twoDimensionalList, lineNumber);


            while (!reader.EndOfStream)
            {
                lineNumber++;
                line = reader.ReadLine();
                values = line.Split(_dataSeparator);

                twoDimensionalList.Add(new List<string>(arrayWidht));

                FillElement(values, arrayWidht, twoDimensionalList, lineNumber);
            }

            return twoDimensionalList;
        }

        private static void FillElement(string[] values, int arrayWidht, List<List<string>> twoDimensionalList,
            int lineNumber)
        {
            for (var i = 0; i < values.Length && values.Length == arrayWidht; i++)
            {
                twoDimensionalList[lineNumber].Add(values[i]);
            }
        }


        public void SaveToDat(IEnumerable<string> stringList, string path)
        {
            using (var outputFile = new StreamWriter(path))
            {
                foreach (var line in stringList)
                    outputFile.WriteLine(line);
            }
        }
    }
}