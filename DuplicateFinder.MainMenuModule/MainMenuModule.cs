using System.ComponentModel.Composition;
using DuplicateFinder.Infrastructure;
using DuplicateFinder.MainMenu.Resources;
using DuplicateFinder.MainMenu.Views;
using LocalizationCommons;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder.MainMenu
{
    [ModuleExport(typeof(MainMenuModule))]
    public class MainMenuModule: IModule
    {
        [Import] private IRegionManager regionManager;
        [Import] private ILocalizationService localizationService;

        public void Initialize()
        {
            localizationService.RegisterManager("MainMenu", Resource.ResourceManager);
            regionManager.RegisterViewWithRegion(RegionNames.MainMenuRegion, typeof(MainMenuView));
        }
    }
}
