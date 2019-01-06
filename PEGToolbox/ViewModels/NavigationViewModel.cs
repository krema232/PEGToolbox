using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PEGToolbox.Infrastructure;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using PEGToolbox.Views;
using PEGToolbox.Controls;

namespace PEGToolbox.ViewModels
{
    public class NavigationViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private IApplicationCommands _applicationCommands;
        private ObservableCollection<NavItemControl> _navigationItems = new ObservableCollection<NavItemControl>();
        
        public NavigationViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _applicationCommands = applicationCommands;
            _eventAggregator.GetEvent<ModuleLoadedEvent>().Subscribe(InitSubModules);

        }

        private void InitSubModules(IPEGToolboxModule module)
        {
            InitNavigationItems(module);
        }

        private void InitNavigationItems(IPEGToolboxModule module)
        {
            NavItemControl navItem = new NavItemControl();
            navItem.DisplayName = module.NavigationItemName;
            navItem.TargetViewType = module.ModuleViewType;
            navItem.GroupName = module.NavigationItemGroup;
            navItem.RequestNavigate += NavItem_RequestNavigate;
            _navigationItems.Add(navItem);
        }
        private void NavItem_RequestNavigate(object sender, NavItemEventArgs e)
        {
            Navigate(e.NavItem);
        }

        public ObservableCollection<NavItemControl> NavigationItems
        {
            get { return _navigationItems; }
            set { _navigationItems = value; }
        }

        private void Navigate(INavItem NavItem)
        {
            if (NavItem != null)
                _eventAggregator.GetEvent<NavigationItemClickedEvent>().Publish(NavItem);
        }

        //private void Navigate(string navigatePath)
        //{
        //    if (navigatePath != null)
        //        _regionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath, NavigationComplete);
        //}

        private void NavigationComplete(NavigationResult result)
        {
            _eventAggregator.GetEvent<NavigationFinishedEvent>().Publish(result.Context.Uri);
        }

        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
    }
}
