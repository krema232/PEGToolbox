using System;
using System.Drawing;
using System.Windows.Media;

namespace PEGToolbox.Infrastructure
{
    public interface IPEGToolboxModule
    {
        string ModuleName { get; }

        Type ModuleViewType { get; }

        Type MenuViewType { get; } 

        string NavigationItemName { get; }

        string NavigationItemGroup { get; }

        bool IsMultiInstance { get; }

    }
}
