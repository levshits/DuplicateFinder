using System;
using System.ComponentModel;
using LocalizationCommons.Events;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;

namespace LocalizationCommons.Helpers
{
    public class LocalizationHelper : INotifyPropertyChanged
    {
        private readonly ILocalizationService localization;
        private readonly IEventAggregator eventAggregator;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var evt = PropertyChanged;

            if (evt != null)
                evt.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LocalizationHelper()
        {
            if (!DesignHelpers.IsInDesignModeStatic)
            {
                localization = ServiceLocator.Current.GetInstance<ILocalizationService>();
                eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

                eventAggregator.GetEvent<LocaleChangedEvent>().Subscribe((e) =>
                {
                    RaisePropertyChanged(string.Empty);
                });
            }
        }

        public string this[string key]
        {
            get
            {
                if (!ValidKey(key))
                    throw new ArgumentException(@"Key is not in the valid [ManagerName].[ResourceKey] format");

                if (DesignHelpers.IsInDesignModeStatic)
                    throw new Exception("Design mode is not supported");

                return localization.GetResourceString(GetManagerKey(key), GetResourceKey(key));
            }
        }

        #region Private Key Methods
        private static bool ValidKey(string input)
        {
            return input.Contains(".");
        }

        private static string GetManagerKey(string input)
        {
            return input.Split('.')[0];
        }

        private static string GetResourceKey(string input)
        {
            return input.Substring(input.IndexOf('.') + 1);
        }
        #endregion
    }
}
