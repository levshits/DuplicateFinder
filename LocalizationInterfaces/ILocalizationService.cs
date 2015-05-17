using System.Resources;

namespace LocalizationCommons
{
   public interface ILocalizationService
    {
        string CurrentLocale { get; }
        string GetResourceString(string managerKey, string resourceKey);
        void ChangeLocale(string newLocaleName);
        void RegisterManager(string managerName, ResourceManager manager);
        void RegisterManager(string managerName, ResourceManager manager, bool refresh);
        void UnregisterManager(string name);
    }
}