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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace recharge_system.View
{
    /// <summary>
    /// MediaTimelineExample.xaml 的交互逻辑
    /// </summary>
    public partial class MediaTimelineExample : Page
    {
        public MediaTimelineExample()
        {
            InitializeComponent();
        }


        // When the media opens, initialize the "Seek To" slider maximum value
        // to the total number of miliseconds in the length of the media clip.
        private void Element_MediaOpened(object sender, EventArgs e)
        {
            timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void MediaTimeChanged(object sender, EventArgs e)
        {
            timelineSlider.Value = myMediaElement.Position.TotalMilliseconds;
        }
    }
}
