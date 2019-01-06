using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGToolbox.Infrastructure
{
    public interface INavItem
    {
        Type TargetViewType { get; set; }

        string DisplayName { get; set; }

        string GroupName { get; set; }

        bool ItemIsEnabled { get; set; }

    }
}
