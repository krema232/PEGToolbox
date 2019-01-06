using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEGToolbox.Infrastructure;

namespace ModulA
{
    public class ModuleInformation : IPEGToolboxModule
    {
        private const string MODULE_NAME = "MODULE_A";

        private const string NAVIGATION_ITEM_NAME = "Modul A";

        private const string NAVIGATION_ITEM_GROUP = "Gruppe 1";

        private const bool IS_MULTI_INSTANCING_ALLOWED = true;


        private Type moduleViewType = typeof(Views.ModulAView);
        private Type menuViewType = typeof(Views.ModulAMenuView);

        /// <summary>
        /// Name des Moduls
        /// </summary>
        public string ModuleName
        {
            get { return MODULE_NAME; }
        }

        /// <summary>
        /// Verweis auf den Module-Haupt-View
        /// </summary>
        public Type ModuleViewType
        {
            get { return moduleViewType; }
        }

        /// <summary>
        /// Verweis auf den MenuView
        /// </summary>
        public Type MenuViewType
        {
            get { return menuViewType; }
        }

        /// <summary>
        /// Bezeichnung des NavigationsItems
        /// </summary>
        public string NavigationItemName
        {
            get { return NAVIGATION_ITEM_NAME; }
        }

        /// <summary>
        /// Gruppe, zu der das NagigationsItem gehört
        /// </summary>
        public string NavigationItemGroup
        {
            get { return NAVIGATION_ITEM_GROUP; }
        }

        /// <summary>
        /// Gibt an, ob eine Mehrfachinstanzierung zugelassen ist (=TRUE) oder nicht (=FALSE)
        /// </summary>
        public bool IsMultiInstance
        {
            get { return IS_MULTI_INSTANCING_ALLOWED; }
        }
    }
}
