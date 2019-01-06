using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGToolbox.Infrastructure
{
    public class ModuleLoadedEvent : PubSubEvent<IPEGToolboxModule>
    {
    }

    public class NavigationFinishedEvent : PubSubEvent<Uri>
    {
    }

    public class NavigationItemClickedEvent : PubSubEvent<INavItem>
    {
    }
}
