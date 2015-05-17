using System.ComponentModel.Composition;
using System.Windows.Controls;
using DuplicateFinder.AdvancedMode.ViewModels;

namespace DuplicateFinder.AdvancedMode.Views
{
    [Export]
    public partial class AdvancedModeView : UserControl
    {
        public AdvancedModeView()
        {
            InitializeComponent();
        }

        [Import]
        public AdvancedModeViewModel View
        {
            get
            {
                return DataContext as AdvancedModeViewModel;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
