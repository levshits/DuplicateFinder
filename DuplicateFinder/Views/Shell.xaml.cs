using System;
using System.ComponentModel.Composition;
using System.Windows;
using DuplicateFinder.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    
    [Export]
    public partial class Shell : Window, IPartImportsSatisfiedNotification
    {
        public Shell()
        {
            InitializeComponent();
        }
        [Import(AllowRecomposition = false)]
        private IModuleManager moduleManager;

        [Import(AllowRecomposition = false)]
        private IRegionManager regionManager;

        private const string WorkplaceModule = "WorkplaceModule";
        private static readonly Uri WelcomeView = new Uri("/WelcomeView", UriKind.Relative);

        public void OnImportsSatisfied()
        {
            this.moduleManager.LoadModuleCompleted +=
                (s, e) =>
                {
                    if (e.ModuleInfo.ModuleName == WorkplaceModule)
                    {
                        this.regionManager.RequestNavigate(
                            RegionNames.WorkplaceRegion,
                            WelcomeView);
                    }
                };
        }
    }
}
