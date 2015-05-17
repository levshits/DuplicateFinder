using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using DuplicateFinder.SimpleMode.Resources;
using LocalizationCommons;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder.SimpleMode
{
    [ModuleExport(typeof(SimpleModeModule))]
    public class SimpleModeModule: IModule
    {
        [Import] private IRegionManager regionManager;
        [Import] private ILocalizationService localizationService;
        public void Initialize()
        {
            localizationService.RegisterManager("SimpleMode", Resource.ResourceManager);
        }
    }
}
