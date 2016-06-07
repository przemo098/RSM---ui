using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DataModificator.PieChart;
using Wpf.Annotations;

namespace DataModificator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private UserControl _pieView;

        public UserControl PieView
        {
            get { return _pieView; }
            set
            {
                _pieView = value;
                OnPropertyChanged();
            }
        }


        public List<UserControl> PieExamples { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            PieExamples = new List<UserControl>
            {
                new PieExample()
            };

            Func<List<UserControl>, UserControl> getView = x => x != null && x.Count > 0 ? x[0] : null;
            
            PieView = getView(PieExamples);

            DataContext = this;

        }

        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
