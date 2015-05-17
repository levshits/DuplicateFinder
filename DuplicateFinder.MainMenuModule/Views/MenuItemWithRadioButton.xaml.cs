using System.Windows;
using System.Windows.Controls;

namespace DuplicateFinder.MainMenu.Views
{
    public partial class MenuItemWithRadioButton
    {
        public MenuItemWithRadioButton()
        {
            InitializeComponent();
        }

        private void MenuItemWithRadioButtons_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item != null)
            {
                RadioButton rb = item.Icon as RadioButton;
                if (rb != null)
                {
                    rb.IsChecked = true;
                }
            }
        }
    }
}
