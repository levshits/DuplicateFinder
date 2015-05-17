using System.ComponentModel.Composition;
using System.Windows.Controls;
using DuplicateFinder.SimpleMode.ViewModels;

namespace DuplicateFinder.SimpleMode.Views
{
    /// <summary>
    /// Interaction logic for SimpleModeFileParametersPage.xaml
    /// </summary>
    public partial class FileParametersPage : UserControl
    {
        public FileParametersPage()
        {
            InitializeComponent();
        }
        [Import]
        public FileParametersPageViewModel ViewModel
        {
            get
            {
                return DataContext as FileParametersPageViewModel;
            }
            set { DataContext = value; }
        }
    }
}
