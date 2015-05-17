using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuplicateFinder.Infrastructure;

namespace DuplicateFinder.DuplicateSearch.Services
{
    [Export(typeof(IDuplicateSearchService))]
    public class DuplicateSearchService : IDuplicateSearchService
    {
        public DuplicateSearchService()
        {
            var value = 10;
        }
    }
}
