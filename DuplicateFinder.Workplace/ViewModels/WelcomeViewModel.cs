using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using DuplicateFinder.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder.Workplace.ViewModels
{
    [Export]
    public class WelcomeViewModel
    {
        private readonly IRegionManager regionManager;
        private ICommand advancedCommand;
        private ICommand simpleCommand;

        public ICommand NavigateToAdvancedViewCommand
        {
            get
            {
                return advancedCommand ?? (advancedCommand = new DelegateCommand((() =>
                {
                    regionManager.RequestNavigate(RegionNames.WorkplaceRegion, new Uri("AdvancedModeView", UriKind.Relative));
                })));
            }
        }
        public ICommand NavigateToSimpleViewCommand
        {
            get
            {
                return simpleCommand ?? (simpleCommand = new DelegateCommand((() =>
                {
                    regionManager.RequestNavigate(RegionNames.WorkplaceRegion, new Uri("SimpleModeView", UriKind.Relative));
                })));
            }
        }
        [ImportingConstructor]
        public WelcomeViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
    }
}
