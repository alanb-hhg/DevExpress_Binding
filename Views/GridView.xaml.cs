using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Example.Views
{

    public partial class GridView : UserControl, INotifyPropertyChanged
    {
        static string path = @"..\..\..\Resources\Contacts.xml";

        public int _counter;

        public int Counter
        {
            get { return _counter; }
            set
            {
                _counter = value;
                OnPropertyChanged();
            }
        }


        public GridView()
        {
            InitializeComponent();
            grid.ItemsSource = GetDataFromXML();
            txtCounter.DataContext = Counter;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DataTable GetDataFromXML()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            return ds.Tables[0];
        }
                private void table_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Counter = grid.VisibleRowCount;
        }
    }
}
