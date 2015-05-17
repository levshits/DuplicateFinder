using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace DuplicateFinder.Workplace.Views
{
    [Export]
    public partial class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            InitializeComponent();
        }
    }
}
