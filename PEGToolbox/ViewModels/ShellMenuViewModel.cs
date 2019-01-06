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
using Prism.Modularity;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using PEGToolbox.Views;
using PEGToolbox.Controls;
using Prism.Ioc;
using Unity;

namespace PEGToolbox.ViewModels
{
    public class ShellMenuViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private IApplicationCommands _applicationCommands;
        private IUnityContainer _container;
        private ObservableCollection<MenuItem> _menuItems;
        public DelegateCommand CloseApplicationCommand { get; private set; }

        public ShellMenuViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands, IEventAggregator eventAggregator, IUnityContainer container)
        {
            _menuItems = new ObservableCollection<MenuItem>();
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _applicationCommands = applicationCommands;
            _container = container;
            CloseApplicationCommand = new DelegateCommand(CloseApplication);
            _eventAggregator.GetEvent<ModuleLoadedEvent>().Subscribe(InitSubModules);

            var menuItem = _container.Resolve(typeof(ShellMenuItem));
            MenuItems.Add((MenuItem)menuItem);
        }

        private void InitSubModules(IPEGToolboxModule module)
        {
            
            var menuItem = _container.Resolve(module.MenuViewType);
            MenuItems.Add((MenuItem)menuItem);
        }


        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }
        private void CloseApplication()
        {
            _applicationCommands.CloseApplicationCommand.Execute(null);
        }
    }
}
