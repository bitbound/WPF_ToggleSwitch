﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToggleSwitch
{
    public partial class ToggleSwitch : UserControl
    {
        private bool isOn = false;
        public bool IsOn
        {
            get
            {
                return isOn;
            }
            set
            {
                isOn = value;
                if (value)
                {
                    buttonToggle.Tag = "On";
                    borderToggle.Background = new SolidColorBrush(Colors.Gray);
                    var ca = new ColorAnimation(Colors.SkyBlue, TimeSpan.FromSeconds(.5));
                    borderToggle.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                    var da = new DoubleAnimation(10, TimeSpan.FromSeconds(.5));
                    translateTransform.BeginAnimation(TranslateTransform.XProperty, da);
                }
                else
                {
                    buttonToggle.Tag = "Off";
                    borderToggle.Background = new SolidColorBrush(Colors.SkyBlue);
                    var ca = new ColorAnimation(Colors.Gray, TimeSpan.FromSeconds(.5));
                    borderToggle.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                    var da = new DoubleAnimation(-10, TimeSpan.FromSeconds(.5));
                    translateTransform.BeginAnimation(TranslateTransform.XProperty, da);
                }
            }
        }
        public ToggleSwitch()
        {
            InitializeComponent();
        }
        
        private void buttonToggle_Click(object sender, RoutedEventArgs e)
        {
            if (buttonToggle.Tag.ToString() == "Off")
            {
                buttonToggle.Tag = "On";
                borderToggle.Background = new SolidColorBrush(Colors.Gray);
                var ca = new ColorAnimation(Colors.SkyBlue, TimeSpan.FromSeconds(.5));
                borderToggle.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                var da = new DoubleAnimation(10, TimeSpan.FromSeconds(.5));
                translateTransform.BeginAnimation(TranslateTransform.XProperty, da);
            }
            else
            {
                buttonToggle.Tag = "Off";
                borderToggle.Background = new SolidColorBrush(Colors.SkyBlue);
                var ca = new ColorAnimation(Colors.Gray, TimeSpan.FromSeconds(.5));
                borderToggle.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                var da = new DoubleAnimation(-10, TimeSpan.FromSeconds(.5));
                translateTransform.BeginAnimation(TranslateTransform.XProperty, da);
            }
        }
    }
}