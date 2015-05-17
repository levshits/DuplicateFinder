using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder.SimpleMode.ViewModels
{
    [Export]
    public class AddDirectoriesPageViewModel
    {
        private ICommand addDirectoryCommand;
        private ObservableCollection<string> directories;
        private ICommand removeDirectoryCommand;
        private ICommand navigateToNextCommand;
        private readonly IRegionManager regionManager;

        public AddDirectoriesPageViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public ObservableCollection<string> Directories
        {
            get
            {
                return directories ?? (directories = new ObservableCollection<string>());
            }
        }
        public string CurrentDirectory { get; set; }
        public ICommand AddDirectoryCommand
        {
            get
            {
                return addDirectoryCommand ?? (addDirectoryCommand = new DelegateCommand(() =>
                {
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Directories.Add(dialog.SelectedPath);
                    }
                }));
            }
        }
        public ICommand RemoveDirectoryCommand
        {
            get
            {
                return removeDirectoryCommand ?? (removeDirectoryCommand = new DelegateCommand(() =>
                {
                    if (!string.IsNullOrEmpty(CurrentDirectory))
                    {
                        Directories.Remove(CurrentDirectory);
                    }
                }));
            }
        }
        public ICommand NavigateToNextCommand
        {
            get
            {
                return navigateToNextCommand ?? (navigateToNextCommand = new DelegateCommand(
                    () =>
                    {
                        regionManager.RequestNavigate("Workplace", new Uri("FileParametersPage", UriKind.Relative));
                    }));
            }
        }
    }
}
