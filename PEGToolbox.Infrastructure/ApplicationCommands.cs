using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace PEGToolbox.Infrastructure
{
    public interface IApplicationCommands
    {
        CompositeCommand InitModuleCommand { get; }
        CompositeCommand CloseApplicationCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _initModuleCommand = new CompositeCommand();
        public CompositeCommand InitModuleCommand
        {
            get { return _initModuleCommand; }
        }

        private CompositeCommand _closeApplicationCommand = new CompositeCommand();

        public CompositeCommand CloseApplicationCommand
        {
            get { return _closeApplicationCommand; }
        }
    }
}
