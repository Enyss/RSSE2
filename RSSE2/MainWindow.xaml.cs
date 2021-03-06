﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace RSSE2
{
    /// <summary>

    /// Interaction logic for MainWindow.xaml

    /// </summary>

    public partial class MainWindow : Window
    {
        public Application App { get { return Application.Instance; } }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            App.CurrentlyLoaded = new MainMenuViewModel();
        }
    }
}