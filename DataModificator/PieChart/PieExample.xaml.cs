using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Microsoft.Win32;
using OverUnderSample;

namespace DataModificator.PieChart
{
    public partial class PieExample
    {
        private FileLoader _fileLoader;
        private List<List<string>> _csv;

        public PieExample()
        {
            InitializeComponent();

            //adding values or series will update and animate the chart automatically
            //SeriesCollection.Add(new PieSeries());
            //SeriesCollection[0].Values.Add(5);
            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Chrome",
                    Values = new ChartValues<double> { 8 },
                    DataLabels = true
                }
            };


            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            string path = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                _fileLoader = new FileLoader(path, ',');
                _csv = _fileLoader.GetCsv();

                OverUnderSample.DataModificator modificator = new OverUnderSample.DataModificator();
                modificator.ProcessData(_csv);

                SeriesCollection.Clear();

                foreach (var info in modificator.ClassInfo)
                {
                    SeriesCollection.Add(new PieSeries()
                    {
                        Title = info.Key,
                        Values = new ChartValues<double> { info.Value },
                        DataLabels = true
                    });
                }
                PieChart.Visibility = Visibility.Visible;
                OverSampleBox.Visibility = Visibility.Visible;
                UnderSampleBox.Visibility = Visibility.Visible;
            }
        }
        
        private void OverSample(object sender, RoutedEventArgs e)
        {
            OverUnderSample.DataModificator modificator = new OverUnderSample.DataModificator();
            modificator.RadomOverSample(_csv);
            modificator.ProcessData(_csv);

            SeriesCollection.Clear();

            foreach (var info in modificator.ClassInfo)
            {
                SeriesCollection.Add(new PieSeries()
                {
                    Title = info.Key,
                    Values = new ChartValues<double> { info.Value },
                    DataLabels = true
                });
            }

            SaveToDatBox.Visibility = Visibility.Visible;
        }

        private void UnderSample(object sender, RoutedEventArgs e)
        {
            OverUnderSample.DataModificator modificator = new OverUnderSample.DataModificator();
            modificator.RandomUnderSample(_csv);
            modificator.ProcessData(_csv);


            SeriesCollection.Clear();

            foreach (var info in modificator.ClassInfo)
            {
                SeriesCollection.Add(new PieSeries()
                {
                    Title = info.Key,
                    Values = new ChartValues<double> { info.Value },
                    DataLabels = true
                });
            }

            SaveToDatBox.Visibility = Visibility.Visible;
        }

        private void SaveToDat(object sender, RoutedEventArgs e)
        {
            OverUnderSample.DataModificator modificator = new OverUnderSample.DataModificator();
            var stringList = modificator.ToStringList(_csv, ',');
            

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                _fileLoader.SaveToDat(stringList, saveFileDialog.FileName);
        }
    }
}
