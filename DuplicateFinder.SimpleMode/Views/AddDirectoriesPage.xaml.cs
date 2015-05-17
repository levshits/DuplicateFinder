using System.ComponentModel.Composition;
using System.Windows.Controls;
using DuplicateFinder.SimpleMode.ViewModels;

namespace DuplicateFinder.SimpleMode.Views
{
    [Export]
    public partial class AddDirectoriesPage : UserControl
    {
        public AddDirectoriesPage()
        {
            InitializeComponent();
        }
        [Import]
        public AddDirectoriesPageViewModel ViewModel
        {
            get
            {
                return DataContext as AddDirectoriesPageViewModel;
            }
            set { DataContext = value; }
        }
    }
}
