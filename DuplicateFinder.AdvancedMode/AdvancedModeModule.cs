using System.ComponentModel.Composition;
using DuplicateFinder.AdvancedMode.Resources;
using DuplicateFinder.AdvancedMode.Views;
using DuplicateFinder.Infrastructure;
using LocalizationCommons;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder.AdvancedMode
{
    [ModuleExport(typeof(AdvancedModeModule))]
    public class AdvancedModeModule:IModule
    {
        [Import] private IRegionManager regionManager;
        [Import] private ILocalizationService localizationService;
        public void Initialize()
        {
            localizationService.RegisterManager("AdvancedMode", Resource.ResourceManager);
            regionManager.RegisterViewWithRegion(RegionNames.WorkplaceRegion, typeof (AdvancedModeView));
        }
    }
}
