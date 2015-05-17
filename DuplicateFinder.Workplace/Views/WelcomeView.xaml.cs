using System.ComponentModel.Composition;
using System.Windows.Controls;
using DuplicateFinder.Workplace.ViewModels;

namespace DuplicateFinder.Workplace.Views
{
    [Export]
    public partial class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            InitializeComponent();
        }
        [Import]
        public WelcomeViewModel ViewModel {
            get
            {
                return DataContext as WelcomeViewModel;
            }
            set { DataContext = value; } 
        }
    }
}
