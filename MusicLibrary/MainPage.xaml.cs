using MusicLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> musics;
        public MainPage()
        {
            this.InitializeComponent();
            musics = new ObservableCollection<Music>();
            MusicManager.getALLMusic(musics);
        }
        private void HamburgerButton_click(object sender, RoutedEventArgs e)
        {

        }
        private void BackButton_Click( object sender, RoutedEventArgs e)
        {

        }
        private void MusicGridview_ItemClick(object sender,ItemClickEventArgs e)
        {
            var music = (Music)e.ClickedItem;
            MusciMedia.Source = new Uri(this.BaseUri, music.AudioFile);
        }
    }
}
