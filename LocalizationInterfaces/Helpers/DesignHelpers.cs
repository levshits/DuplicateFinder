using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace LocalizationCommons.Helpers
{
    public static class DesignHelpers
    {
        private static bool? isInDesignMode;

        public static bool IsInDesignModeStatic
        {
            get
            {
                if (!isInDesignMode.HasValue)
                {
                    var prop = DesignerProperties.IsInDesignModeProperty;
                    isInDesignMode = (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;

                    if (!isInDesignMode.Value)
                        if (Process.GetCurrentProcess().ProcessName.StartsWith(@"devenv"))
                            isInDesignMode = true;
                }
                return isInDesignMode.Value;
            }
        }

    }
}
