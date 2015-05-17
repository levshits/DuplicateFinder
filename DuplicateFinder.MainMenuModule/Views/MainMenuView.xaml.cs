using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace DuplicateFinder.MainMenu.Views
{
    [Export]
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
        }
    }
}
