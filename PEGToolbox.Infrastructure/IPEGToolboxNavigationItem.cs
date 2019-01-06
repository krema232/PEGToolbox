using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGToolbox.Infrastructure
{
    public interface IPEGToolboxNavigationItem
    {
        string ItemName { get; }

        string GroupName { get; }

        Type ModuleViewType { get; }
    }
}
