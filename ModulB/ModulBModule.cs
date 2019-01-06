using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using ModulB.Views;
using Prism.Regions;
using PEGToolbox.Infrastructure;
using Prism.Events;

namespace ModulB
{
    public class ModulBModule : IModule
    {
        IRegionManager regionManager;
        IEventAggregator eventAggregator;
        ModuleInformation moduleInformation;

        public ModulBModule(IRegionManager RegionManager, IEventAggregator EventAggregator)
        {
            regionManager = RegionManager;
            eventAggregator = EventAggregator;
            moduleInformation = new ModuleInformation();
        }

        public ModuleInformation ModuleInformation
        {
            get { return moduleInformation; }
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(moduleInformation);
            eventAggregator.GetEvent<NavigationFinishedEvent>().Subscribe(NavigationFinished, true);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ModulBView>();
        }

        private void NavigationFinished(Uri uri)
        {

        }
    }
}
