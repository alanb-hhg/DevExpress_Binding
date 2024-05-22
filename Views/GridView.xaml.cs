using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Example.Views
{

    public partial class GridView : UserControl, INotifyPropertyChanged
    {
        static string path = @"..\..\..\Resources\Contacts.xml";
        //public int countRows { get { return Counter; } }
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

        //        CountModel countModel = new CountModel();
        public GridView()
        {
            InitializeComponent();
            grid.ItemsSource = GetDataFromXML();
            txtCounter.DataContext = Counter;
        }

        //public class CountModel : INotifyPropertyChanged


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
