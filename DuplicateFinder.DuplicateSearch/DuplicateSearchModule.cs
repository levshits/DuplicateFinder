using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace DuplicateFinder.DuplicateSearch
{
    [ModuleExport(typeof(DuplicateSearchModule))]
    public class DuplicateSearchModule:IModule
    {
        public void Initialize()
        {
            
        }
    }
}
