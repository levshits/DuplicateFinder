using System.Collections.ObjectModel;

namespace DuplicateFinderInterfaces
{
    public interface IWpfThemesProvider
    {
        ReadOnlyCollection<string> Themes { get; }
        void UpdateThemesList();
        void ApplyTheme(string name);
    }
}