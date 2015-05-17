using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using DuplicateFinderInterfaces;
using LocalizationCommons;
using Microsoft.Practices.Prism.Commands;

namespace DuplicateFinder.MainMenu.ViewModels
{
    [Export]
    public class MainMenuViewModel
    {
        private readonly ILocalizationService localizationService;
        private readonly IWpfThemesProvider themesProvider;
        private ICommand languageChangeCommand;
        private ICommand themeChangeCommand;

        [ImportingConstructor]
        public MainMenuViewModel(ILocalizationService localizationService, IWpfThemesProvider themesProvider)
        {
            this.localizationService = localizationService;
            this.themesProvider = themesProvider;
        }

        public ICommand LanguageChangeCommand
        {
            get
            {
                return languageChangeCommand ?? (languageChangeCommand = new DelegateCommand<string>((locale) =>
                {
                    localizationService.ChangeLocale(locale);
                }));
            }
        }
        public IEnumerable<MenuItem> Themes
        {
            get
            {
                themesProvider.UpdateThemesList();

                return
                    themesProvider.Themes.Select(
                        element =>
                            new MenuItem()
                            {
                                Header = element,
                                Command = ThemeChangeCommand,
                                CommandParameter = element
                            });
            }
        }
        public ICommand ThemeChangeCommand
        {
            get
            {
                return themeChangeCommand ?? (themeChangeCommand = new DelegateCommand<string>(
                    (name) =>
                    {
                        themesProvider.ApplyTheme(name);
                    }));
            }
        }
    }
}
