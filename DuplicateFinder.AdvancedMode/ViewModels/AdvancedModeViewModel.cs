using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;
using DuplicateFinder.AdvancedMode.Annotations;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder.AdvancedMode.ViewModels
{
    [Export]
    public class AdvancedModeViewModel : INotifyPropertyChanged, INavigationAware
    {
        private ICommand addDirectoryCommand;
        private ObservableCollection<string> directories;
        private ICommand removeDirectoryCommand;
        private ObservableCollection<string> extensions;
        private ICommand addExtensionCommand;
        private string extension;
        private ICommand removeExtensionCommand;
        private string selectedExtension;
        private readonly string[] sizeMeasures = new string[] { "byte", "KB", "MB", "GB" };
        private int minSizeMeasure;
        private int maxSizeMeasure;
        private double minSize;
        private double maxSize;
        private IRegionNavigationJournal navigationJournal;
        private ICommand goHomeCommand;

        public ObservableCollection<string> Directories { get
        {
            return directories ?? (directories = new ObservableCollection<string>());
        }}
        public string CurrentDirectory { get; set; }
        public ICommand AddDirectoryCommand { get
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
        }}
        public ICommand RemoveDirectoryCommand { get
        {
            return removeDirectoryCommand ?? (removeDirectoryCommand = new DelegateCommand(() =>
            {
                if (!string.IsNullOrEmpty(CurrentDirectory))
                {
                    Directories.Remove(CurrentDirectory);
                }
            }));
        } }

        public ObservableCollection<string> Extensions
        {
            get
            {
                return extensions ?? (extensions = new ObservableCollection<string>());
            }
        }

        public String Extension
        {
            get
            {
                return extension;
            }
            set
            {
                extension = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddExtensionCommand { get
        {
            return addExtensionCommand ?? (addExtensionCommand = new DelegateCommand(
                () =>
                {
                    if (!string.IsNullOrEmpty(extension))
                    {
                        Extensions.Add(extension);
                        extension = String.Empty;
                    }
                }));
        } }

        public string SelectedExtension
        {
            get { return selectedExtension; }
            set
            {
                selectedExtension = value;
                OnPropertyChanged();
            }
        }

        public ICommand RemoveExtensionCommand
        {
            get
            {
                return removeExtensionCommand ?? (removeExtensionCommand = new DelegateCommand(
                    () =>
                    {
                        if (!string.IsNullOrEmpty(SelectedExtension))
                        {
                            Extensions.Remove(SelectedExtension);
                        }
                    }));
            }
        }
        public List<string> SizeMeasures { get { return sizeMeasures.ToList(); }}
        public int MinSizeMeasure
        {
            get { return minSizeMeasure; }
            set
            {
                minSizeMeasure = value;
                OnPropertyChanged();
            }
        }
        public int MaxSizeMeasure
        {
            get { return maxSizeMeasure; }
            set
            {
                maxSizeMeasure = value;
                OnPropertyChanged();
            }
        }
        public double MinSize
        {
            get { return minSize; }
            set
            {
                minSize = value;
                OnPropertyChanged();
            }
        }
        public double MaxSize
        {
            get { return maxSize; }
            set
            {
                maxSize = value;
                OnPropertyChanged();
            }
        }

        public ICommand GoHomeCommand
        {
            get { return goHomeCommand ?? (goHomeCommand = new DelegateCommand(() =>
            {
                if (navigationJournal.CanGoBack)
                {
                    navigationJournal.GoBack();
                }
            })); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
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
