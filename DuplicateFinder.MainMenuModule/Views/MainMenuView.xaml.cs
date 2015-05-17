using System.ComponentModel.Composition;
using System.Windows.Controls;
using DuplicateFinder.MainMenu.ViewModels;

namespace DuplicateFinder.MainMenu.Views
{
    [Export]
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        [Import]
        public MainMenuViewModel ViewModel
        {
            get { return (MainMenuViewModel) this.DataContext; }
            set { DataContext = value; }
        }
    }
}
