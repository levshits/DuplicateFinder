﻿using System.ComponentModel.Composition;
using System.Windows;

namespace DuplicateFinder
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    
    [Export]
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
        }
    }
}
