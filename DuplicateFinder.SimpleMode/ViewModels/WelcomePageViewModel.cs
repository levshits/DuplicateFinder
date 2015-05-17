using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder.SimpleMode.ViewModels
{
    [Export]
    public class WelcomePageViewModel: INavigationAware
    {
        private readonly IRegionManager regionManager;
        private ICommand navigateToNextCommand;
        private IRegionNavigationJournal navigationJournal;
        private ICommand goHomeCommand;

        public ICommand NavigateToNextCommand { get
        {
            return navigateToNextCommand ?? (navigateToNextCommand = new DelegateCommand(
                () =>
                {
                    regionManager.RequestNavigate("Workplace", new Uri("DirectoriesPage", UriKind.Relative));
                }));
        } }
        public ICommand GoHomeCommand
        {
            get
            {
                return goHomeCommand ?? (goHomeCommand = new DelegateCommand(() =>
                {
                    if (navigationJournal.CanGoBack)
                    {
                        navigationJournal.GoBack();
                    }
                }));
            }
        }

        [ImportingConstructor]
        public WelcomePageViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigationJournal = navigationContext.NavigationService.Journal;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //do nothing
        }
    }
}
