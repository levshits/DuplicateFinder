using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace DuplicateFinder.SimpleMode.ViewModels
{
    [Export]
    public class FileParametersPageViewModel: INotifyPropertyChanged, INavigationAware
    {
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

        public ICommand AddExtensionCommand
        {
            get
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
            }
        }

        private string selectedExtension;

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

        private string[] sizeMeasures = new string[] { "byte", "KB", "MB", "GB" };
        public List<string> SizeMeasures { get { return sizeMeasures.ToList(); } }
        private int minSizeMeasure;

        public int MinSizeMeasure
        {
            get { return minSizeMeasure; }
            set
            {
                minSizeMeasure = value;
                OnPropertyChanged();
            }
        }

        private int maxSizeMeasure;

        public int MaxSizeMeasure
        {
            get { return maxSizeMeasure; }
            set
            {
                maxSizeMeasure = value;
                OnPropertyChanged();
            }
        }
        private double minSize;
        public double MinSize
        {
            get { return minSize; }
            set
            {
                minSize = value;
                OnPropertyChanged();
            }
        }
        private double maxSize;
        private ICommand removeExtensionCommand;
        private ICommand addExtensionCommand;
        private string extension;
        private ObservableCollection<string> extensions;
        private IRegionNavigationJournal navigationJournal;

        public double MaxSize
        {
            get { return maxSize; }
            set
            {
                maxSize = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
