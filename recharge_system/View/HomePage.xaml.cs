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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace recharge_system.View
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }


        private void homePage_StateChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print(Enum.GetName(homePage.WindowState));
            if (homePage.WindowState == WindowState.Normal)
            {
                VisualStateManager.GoToElementState(maxBtn, "Normal", true);
            }
            else if (homePage.WindowState == WindowState.Maximized)
            {
                VisualStateManager.GoToElementState(maxBtn, "Maximized", true);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame.NavigationService.Navigate(new Uri("../View/DevicePage.xaml",UriKind.Relative));
        }

        // Change the volume of the media.
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }

        // Change the speed of the media.
        private void ChangeMediaSpeedRatio(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.SpeedRatio = (double)speedRatioSlider.Value;
        }

        DispatcherTimer timer;

        // When the media opens, initialize the "Seek To" slider maximum value
        // to the total number of miliseconds in the length of the media clip.
        private void Element_MediaOpened(object sender, EventArgs e)
        {
            timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timelineSlider.Value = myMediaElement.Position.TotalSeconds;
        }

        // When the media playback is finished. Stop() the media to seek to media start.
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }

        // Jump to different parts of the media (seek to).
        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            int SliderValue = (int)timelineSlider.Value;

            // Overloaded constructor takes the arguments days, hours, minutes, seconds, milliseconds.
            // Create a TimeSpan with miliseconds equal to the slider value.
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            myMediaElement.Position = ts;
        }

        void InitializePropertyValues()
        {
            // Set the media's starting Volume and SpeedRatio to the current value of the
            // their respective slider controls.
            myMediaElement.Volume = (double)volumeSlider.Value;
            myMediaElement.SpeedRatio = (double)speedRatioSlider.Value;
        }

        private void MediaTimeline_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            timelineSlider.Value = myMediaElement.Position.TotalSeconds;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.frame.NavigationService.Navigate(new Uri("../View/MediaTimelineExample.xaml", UriKind.Relative));
        }

        private void OnMouseDownPlayMedia(object sender, RoutedEventArgs e)
        {

            // The Play method will begin the media if it is not currently active or
            // resume media if it is paused. This has no effect if the media is
            // already running.
            myMediaElement.Play();
            // Initialize the MediaElement property values.
            InitializePropertyValues();
        }

        private void OnMouseDownPauseMedia(object sender, RoutedEventArgs e)
        {

            // The Pause method pauses the media if it is currently running.
            // The Play method can be used to resume.
            myMediaElement.Pause();
        }

        private void OnMouseDownStopMedia(object sender, RoutedEventArgs e)
        {
            // The Stop method stops and resets the media to be played from
            // the beginning.
            myMediaElement.Stop();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.frame.NavigationService.Navigate(new Uri("../View/DependencyPropertyPage.xaml", UriKind.Relative));
        }
    }
}
