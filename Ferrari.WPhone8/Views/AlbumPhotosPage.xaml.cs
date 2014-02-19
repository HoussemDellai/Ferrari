using System;
using System.Diagnostics;
using System.Windows;
using Windows.Phone.System.UserProfile;
using Microsoft.Phone.Controls;

namespace Ferrari.WPhone8.Views
{
    public partial class AlbumPhotosPage
    {
        public AlbumPhotosPage()
        {
            InitializeComponent();
        }

        private void AlbumPhotosPage_OnOrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            const int marginToAppBar = 66;

            if (e.Orientation == PageOrientation.PortraitUp)
            {
                MainGrid.Margin = new Thickness(0, 0, 0, marginToAppBar);
            }
            else if (e.Orientation == PageOrientation.PortraitDown)
            {
                MainGrid.Margin = new Thickness(0, marginToAppBar, 0, 0);
            }
            else if (e.Orientation == PageOrientation.LandscapeLeft)
            {
                MainGrid.Margin  = new Thickness(0,0,marginToAppBar,0);
            }
            else if (e.Orientation == PageOrientation.LandscapeRight)
            {
                MainGrid.Margin = new Thickness(marginToAppBar, 0, 0, 0);
            }
        }
    }
}