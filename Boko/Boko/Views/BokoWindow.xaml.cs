﻿using Boko.Models;
using Boko.Utilities;
using ff14bot;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Application = System.Windows.Application;
using Color = System.Windows.Media.Color;
using MessageBox = System.Windows.MessageBox;

namespace Boko.Views
{
    public partial class BokoWindow : Window
    {
        public BokoWindow()
        {
            InitializeComponent();

            SelectTheme();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #region Theme Switch

        private void SelectTheme()
        {
            switch (MainSettingsModel.Instance.Theme)
            {
                case SelectedTheme.Pink:
                    Pink();
                    break;

                case SelectedTheme.Blue:
                    Blue();
                    break;

                case SelectedTheme.Green:
                    Green();
                    break;

                case SelectedTheme.Red:
                    Red();
                    break;

                case SelectedTheme.Yellow:
                    Yellow();
                    break;

                default:
                    Pink();
                    break;
            }
        }

        private void Pink()
        {
            Resources.MergedDictionaries.Clear();
            AddResourceDictionary("/Boko;component/Views/Styles/BokoStyles.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/BaseColors.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/PinkTheme.xaml");
        }

        private void Blue()
        {
            Resources.MergedDictionaries.Clear();
            AddResourceDictionary("/Boko;component/Views/Styles/BokoStyles.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/BaseColors.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/BlueTheme.xaml");
        }

        private void Yellow()
        {
            Resources.MergedDictionaries.Clear();
            AddResourceDictionary("/Boko;component/Views/Styles/BokoStyles.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/BaseColors.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/YellowTheme.xaml");
        }

        private void Red()
        {
            Resources.MergedDictionaries.Clear();
            AddResourceDictionary("/Boko;component/Views/Styles/BokoStyles.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/BaseColors.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/RedTheme.xaml");
        }

        private void Green()
        {
            Resources.MergedDictionaries.Clear();
            AddResourceDictionary("/Boko;component/Views/Styles/BokoStyles.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/BaseColors.xaml");
            AddResourceDictionary("/Boko;component/Views/Styles/GreenTheme.xaml");
        }

        #endregion Theme Switch

        private void AddResourceDictionary(string source)
        {
            var resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.Relative)) as ResourceDictionary;
            Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            MainSettingsModel.Instance.Save();
            Close();
        }

        private void CmbSwitchTheme(object sender, SelectionChangedEventArgs e)
        {
            SelectTheme();
        }
    }
}