namespace OverUnderSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var DataSetsLocalistaion = @"D:\Pobrane\OneDrive\Studia\MGR !\I\RSM\Lab\DataSets";
            var DataSetName = @"abalone9-18";
            var FileExtension = @".dat";
            var DataSeparator = ',';


            var fileLoader = new FileLoader(DataSetsLocalistaion, DataSetName, FileExtension, DataSeparator);
            var csv = fileLoader.GetCsv();

            DataModificator modificator = new DataModificator();

            //modificator.RandomUnderSample(csv);
            //modificator.RadomOverSample(csv);

            var list = modificator.ToStringList(csv, DataSeparator);

            fileLoader.SaveToDat(list, @"D:\Pobrane\OneDrive\Studia\MGR !\I\RSM\Lab\DataSets\mydataset.dat");
        }
    }
}