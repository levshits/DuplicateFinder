using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Xml.Serialization;
using DuplicateFinderInterfaces;

namespace WpfThemesProvider.Services
{
    [Export(typeof(IWpfThemesProvider))]
    public class ThemeProviderService:IWpfThemesProvider
    {
        private readonly List<Assembly> themeAssemblies = new List<Assembly>();
        private readonly List<string> themes = new List<string>();
        private ResourceDictionary currentDictionary;

        public ReadOnlyCollection<string> Themes
        {
            get
            {
                return new ReadOnlyCollection<string>(themes);
            }
        }

        public void UpdateThemesList()
        {
            themes.Clear();
            themeAssemblies.Clear();
            DirectoryInfo di = new DirectoryInfo("Themes");
            foreach (FileInfo fi in di.GetFiles())
            {
                try
                {
                    themeAssemblies.Add(Assembly.LoadFile(fi.FullName));
                }
                catch { }
            }
            themes.AddRange(themeAssemblies.Select(element => element.GetName().Name));
        }
        public void ApplyTheme(string name)
        {
            if (currentDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(currentDictionary);
            }
            Assembly a = themeAssemblies.SingleOrDefault(p => p.GetName().Name.Equals(name));

            if (a != null)
            {
                foreach (Type t in a.GetTypes())
                {
                    Trace.WriteLine(t.FullName);
                    if (t.IsSubclassOf(typeof(ResourceDictionary)))
                    {
                        ConstructorInfo ci = t.GetConstructor(Type.EmptyTypes);
                        if (ci != null)
                        {
                            currentDictionary = (ResourceDictionary) ci.Invoke(new object[] {});
                            Application.Current.Resources.MergedDictionaries.Add(currentDictionary);
                        }
                        else
                        {
                            currentDictionary = null;
                        }
                    }
                }

            }
        }
    }
}
