using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace WpfThemesProvider
{
    [ModuleExport(typeof(WpfThemesProviderModule))]
    public class WpfThemesProviderModule : IModule
    {
        public void Initialize()
        {
            
        }
    }
}
