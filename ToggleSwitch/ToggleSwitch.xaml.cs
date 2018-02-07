using System;
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
        public ToggleSwitch()
        {
            InitializeComponent();
            Switched = new EventHandler((send, arg) => { });
        }
        public EventHandler Switched;

        private Color trackBackgroundOnColor = Colors.DeepSkyBlue;
        public Color TrackBackgroundOnColor
        {
            get
            {
                return trackBackgroundOnColor;
            }
            set
            {
                trackBackgroundOnColor = value;
                if (IsOn)
                {
                    borderTrack.Background = new SolidColorBrush(value);
                }
            }
        }

        private Color trackBackgroundOffColor = Colors.Gray;
        public Color TrackBackgroundOffColor
        {
            get
            {
                return trackBackgroundOffColor;
            }
            set
            {
                trackBackgroundOffColor = value;
                if (!IsOn)
                {
                    borderTrack.Background = new SolidColorBrush(value);
                }
            }
        }
        private Color circleBackgroundColor = Colors.SteelBlue;
        public Color CircleBackgroundColor
        {
            get
            {
                return circleBackgroundColor;
            }
            set
            {
                circleBackgroundColor = value;
                ellipseToggle.Fill = new SolidColorBrush(value);
            }
        }

        private Color circleBorderColor = Colors.White;
        public Color CircleBorderColor
        {
            get
            {
                return circleBorderColor;
            }
            set
            {
                circleBorderColor = value;
                ellipseToggle.Stroke = new SolidColorBrush(value);
            }
        }


        public bool IsOn
        {
            get
            {
                if (buttonToggle.Tag.ToString() == "On")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    buttonToggle.Tag = "On";
                    borderTrack.Background = new SolidColorBrush(TrackBackgroundOffColor);
                    var ca = new ColorAnimation(TrackBackgroundOnColor, TimeSpan.FromSeconds(.25));
                    borderTrack.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                    var da = new DoubleAnimation(10, TimeSpan.FromSeconds(.25));
                    translateTransform.BeginAnimation(TranslateTransform.XProperty, da);
                }
                else
                {
                    buttonToggle.Tag = "Off";
                    borderTrack.Background = new SolidColorBrush(TrackBackgroundOnColor);
                    var ca = new ColorAnimation(TrackBackgroundOffColor, TimeSpan.FromSeconds(.25));
                    borderTrack.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
                    var da = new DoubleAnimation(-10, TimeSpan.FromSeconds(.25));
                    translateTransform.BeginAnimation(TranslateTransform.XProperty, da);
                }
                Switched(this, EventArgs.Empty);
            }
        }
        private void buttonToggle_Click(object sender, RoutedEventArgs e)
        {
            IsOn = !IsOn;
        }
    }
}
