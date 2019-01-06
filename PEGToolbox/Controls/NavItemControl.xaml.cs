using System;
using System.Collections.Generic;
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
using Prism.Commands;
using Prism.Mvvm;
using PEGToolbox.Infrastructure;

namespace PEGToolbox.Controls
{
    /// <summary>
    /// Interaktionslogik für NavItemControl.xaml
    /// </summary>
    public partial class NavItemControl : UserControl, INavItem
    {
        public event EventHandler<NavItemEventArgs> RequestNavigate;
        public NavItemControl()
        {
            InitializeComponent();
        }

 
        public string TargetViewName { get; set; }

        public string DisplayName { get; set; }

        public string GroupName { get; set; }

        public bool ItemIsEnabled { get; set; }

        public Type TargetViewType { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RequestNavigate!=null)
            {
                RequestNavigate(this, new NavItemEventArgs((INavItem)this));
            }

        }
    }
}
