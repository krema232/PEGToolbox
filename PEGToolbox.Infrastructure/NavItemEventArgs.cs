using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGToolbox.Infrastructure
{
    public class NavItemEventArgs:EventArgs
    {
        private INavItem _navItem;
        public NavItemEventArgs(INavItem NavItem)
        {
            _navItem = NavItem;
        }
        public INavItem NavItem
        {
            get { return _navItem; }
        }
    }
}
