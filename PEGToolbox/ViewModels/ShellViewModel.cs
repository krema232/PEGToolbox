using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PEGToolbox.Infrastructure;
using Prism.Events;
using PEGToolbox.Views;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using PEGToolbox.Controls;
using Unity;

namespace PEGToolbox.ViewModels
{
    public class ShellViewModel: BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IUnityContainer _unityContainer;

        private string _title = "PEG Toolbox";
        private ObservableCollection<TabPageControl> _tabPages;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ObservableCollection<TabPageControl> TabItems
        {
            get { return _tabPages; }
            set { SetProperty(ref _tabPages, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }


        public ShellViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands, IEventAggregator eventAggregator, IUnityContainer container)
        {
            _tabPages = new ObservableCollection<TabPageControl>();

            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _unityContainer = container;
            ApplicationCommands = applicationCommands;
            
            NavigateCommand = new DelegateCommand<string>(Navigate);
           
            _eventAggregator.GetEvent<ModuleLoadedEvent>().Subscribe(InitSubModules);
            _eventAggregator.GetEvent<NavigationItemClickedEvent>().Subscribe(NavigationItemClicked);
            _regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(NavigationView));
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(ShellMenuView));
            _applicationCommands.CloseApplicationCommand.RegisterCommand(new DelegateCommand(CloseApplication));
               
        }

        private void NavigationItemClicked(INavItem NavItem)
        {
            TabPageControl tpc = new TabPageControl();
            tpc.Header = NavItem.DisplayName;
            var item = _unityContainer.Resolve(NavItem.TargetViewType);
            //tpc.ViewItem = (Control)item;
            var txt = new TextBlock();
            txt.Text = "skdjfhksdjfhksjjdf";
            tpc.ViewItem = txt;
            TabItems.Add(tpc);
        }


        private void CloseApplication()
        {
            App.Current.Shutdown();
        }

        private void InitSubModules(IPEGToolboxModule module)
        {

        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath, NavigationComplete);
        }

        private void NavigationComplete(NavigationResult result)
        {
           
        }

     
        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
    }
}
