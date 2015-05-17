using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace Localization
{
    [ModuleExport(typeof(LocalizationModule))]
    public class LocalizationModule : IModule
    {
        public void Initialize()
        {
            
        }
    }
}
