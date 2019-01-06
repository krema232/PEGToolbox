using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PEGToolbox.Controls
{
    /// <summary>
    /// Interaktionslogik für TabPageControl.xaml
    /// </summary>
    public partial class TabPageControl : TabItem, INotifyPropertyChanged
    {
        TextBlock viewItem;

        public TabPageControl()
        {
            InitializeComponent();
        }

        public TextBlock ViewItem
        {
            get { return viewItem; }
            set
            {
                viewItem = value;
                NotifyPropertyChanged("ViewItem");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private void TabItem_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
