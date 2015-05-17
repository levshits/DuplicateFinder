using System.ComponentModel.Composition;
using System.Windows.Controls;
using DuplicateFinder.SimpleMode.ViewModels;

namespace DuplicateFinder.SimpleMode.Views
{
    [Export("SimpleModeView")]
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        [Import]
        public WelcomePageViewModel ViewModel
        {
            get
            {
                return DataContext as WelcomePageViewModel;
            }
            set { DataContext = value; }
        }
    }
}
