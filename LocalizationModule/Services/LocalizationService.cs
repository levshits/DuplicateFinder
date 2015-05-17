using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Resources;
using System.Threading;
using LocalizationCommons;
using LocalizationCommons.Events;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Localization.Services
{
    [Export(typeof(ILocalizationService))]
    public class LocalizationService : ILocalizationService
    {
        private readonly IEventAggregator eventAggregator;
        private readonly Dictionary<string, WeakReference> managers;

        public string CurrentLocale { get; private set; }

        [ImportingConstructor]
        public LocalizationService(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            managers = new Dictionary<string, WeakReference>();
            ChangeLocale(CultureInfo.CurrentCulture.IetfLanguageTag);
        }


        public string GetResourceString(string managerName, string resourceKey)
        {
            WeakReference reference = null;
            ResourceManager manager = null;

            if (!managers.TryGetValue(managerName, out reference))
                throw new ArgumentException("managerName must be a valid manager");

            manager = reference.Target as ResourceManager;
            if (manager == null)
            {
                UnregisterManager(managerName);
                throw new ArgumentException("managerName must be a valid manager");
            }

            var resource = manager.GetString(resourceKey);

            return resource;
        }

        public void ChangeLocale(string newLocaleName)
        {
            CultureInfo newCultureInfo = new CultureInfo(newLocaleName);
            Thread.CurrentThread.CurrentCulture = newCultureInfo;
            Thread.CurrentThread.CurrentUICulture = newCultureInfo;

            CurrentLocale = newLocaleName;

            eventAggregator.GetEvent<LocaleChangedEvent>().Publish(newLocaleName);
        }


        public void Refresh()
        {
            ChangeLocale(CultureInfo.CurrentCulture.IetfLanguageTag);
        }


        public void RegisterManager(string managerName, ResourceManager manager)
        {
            RegisterManager(managerName, manager, false);
        }

        public void RegisterManager(string managerName, ResourceManager manager, bool refresh)
        {
            WeakReference reference = null;

            managers.TryGetValue(managerName, out reference);

            if (reference == null)
                managers.Add(managerName, new WeakReference(manager));
            else if (reference.Target == null)
                managers[managerName] = new WeakReference(manager);

            if (refresh)
                Refresh();
        }


        public void UnregisterManager(string name)
        {
            WeakReference reference = null;

            managers.TryGetValue(name, out reference);

            if (reference != null)
                managers.Remove(name);
        }
    }
}