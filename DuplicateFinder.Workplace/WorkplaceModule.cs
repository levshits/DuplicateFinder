using System.ComponentModel.Composition;
using DuplicateFinder.Infrastructure;
using DuplicateFinder.Workplace.Resources;
using DuplicateFinder.Workplace.Views;
using LocalizationCommons;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder.Workplace
{
    [ModuleExport(typeof(WorkplaceModule))]
    public class WorkplaceModule:IModule
    {
        [Import]
        private ILocalizationService localizationService;
        [Import] 
        private IRegionManager regionManager;
        public void Initialize()
        {
            localizationService.RegisterManager("Workplace", Resource.ResourceManager);
            regionManager.RegisterViewWithRegion(RegionNames.WorkplaceRegion, typeof(WelcomeView));
        }
    }
}
