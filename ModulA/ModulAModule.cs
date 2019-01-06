using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using ModulA.Views;
using Prism.Regions;
using PEGToolbox.Infrastructure;
using System.Windows;
using Prism.Mvvm;
using Prism.Events;
using System.Windows.Controls;

namespace ModulA
{
    public class ModulAModule : IModule
    {
        IRegionManager regionManager;
        IEventAggregator eventAggregator;
        ModuleInformation moduleInformation;
        public ModulAModule (IRegionManager RegionManager, IEventAggregator EventAggregator)
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
            eventAggregator.GetEvent<NavigationFinishedEvent>().Subscribe(NavigationFinished,true);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ModulAView>();
            containerRegistry.Register<ModulAMenuView>();
            
        }

        private void NavigationFinished(Uri uri)
        {

        }
    }
}
