using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using UserControl = System.Windows.Controls.UserControl;

namespace DiederingBV.VsvvPackage
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class VideoControl : UserControl
    {
        /// <summary>
        /// This is the constructor for this class
        /// </summary>
        public VideoControl()
        {
            InitializeComponent();
            IsPlaying(false);
        }

        /// <summary>
        /// Method to set the player active or not
        /// </summary>
        /// <param name="bValue"></param>
        private void IsPlaying(bool bValue)
        {
            btnStop.IsEnabled = bValue;
            btnMoveBackward.IsEnabled = bValue;
            btnMoveForward.IsEnabled = bValue;
            btnPlay.IsEnabled = bValue;
        }

        /// <summary>
        /// This method is for when someone presses the play button
        /// </summary>
        /// <param name="sender">which control started the event</param>
        /// <param name="e">event arguments</param>
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            IsPlaying(true);
            if (imgPlay.Source.ToString().Contains("play"))
            {
                MediaEL.Play();
                imgPlay.Source =
                    new BitmapImage(new Uri(@"/VsvvPackage;component/Resources/pause.png", UriKind.Relative));
            }
            else
            {
                MediaEL.Pause();
                imgPlay.Source = new BitmapImage(new Uri(@"/VsvvPackage;component/Resources/play.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// This method is for when someone presses the stop button
        /// </summary>
        /// <param name="sender">which control started the event</param>
        /// <param name="e">event arguments</param>
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            MediaEL.Stop();
            imgPlay.Source = new BitmapImage(new Uri(@"/VsvvPackage;component/Resources/play.png", UriKind.Relative));
            IsPlaying(false);
            btnPlay.IsEnabled = true;
        }

        /// <summary>
        /// This method is for when someone presses the forward button
        /// </summary>
        /// <param name="sender">which control started the event</param>
        /// <param name="e">event arguments</param>
        private void btnMoveForward_Click(object sender, RoutedEventArgs e)
        {
            //TODO : need to implement holding the forward button, that makes the scrolling in time faster.
            MediaEL.Position = MediaEL.Position + TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// This method is for when someone presses the backward button
        /// </summary>
        /// <param name="sender">which control started the event</param>
        /// <param name="e">event arguments</param>
        private void btnMoveBackward_Click(object sender, RoutedEventArgs e)
        {
            //TODO : need to implement holding the backward button, that makes the scrolling in time faster.
            MediaEL.Position = MediaEL.Position - TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// This method is for when someone presses the open button
        /// </summary>
        /// <param name="sender">which control started the event</param>
        /// <param name="e">event arguments</param>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = @"MPEG-4 Files (*.mpeg;*.mp4)|*.mpeg;*.mp4|AVI Files (*.avi)|*.avi|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MediaEL.Source = new Uri(ofd.FileName);
                btnPlay.IsEnabled = true;
                MediaEL.Play();
                imgPlay.Source =
                    new BitmapImage(new Uri(@"/VsvvPackage;component/Resources/pause.png", UriKind.Relative));
                IsPlaying(true);
            }
        }
    }
}