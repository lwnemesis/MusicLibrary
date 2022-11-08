using MusicLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Pickers.Provider;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary> 
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> songs;
        private List<MenuItem> menuItems;

        public MainPage()
        {
            this.InitializeComponent();
            songs = new ObservableCollection<Music>();
            MusicManager.getALLMusic(songs);

            menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Classic.png",
                Category = MusicCategory.Classic
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Pop.png",
                Category = MusicCategory.Pop
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Rap.png",
                Category = MusicCategory.Rap
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Rock.png",
                Category = MusicCategory.Rock
            });

            BackButton.Visibility = Visibility.Collapsed;
        }
        private void HamburgerButton_click(object sender, RoutedEventArgs e)
        {
            ContentSplitView.IsPaneOpen = !ContentSplitView.IsPaneOpen;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            CollapsePlayerConsole();
            MusicManager.getALLMusic(songs);
            CategoryTextBlock.Text = "All Songs";
            BackButton.Visibility = Visibility.Collapsed;
            MenuItemsListView.SelectedItem = null;

        }
        private void MusicGridview_ItemClick(object sender, ItemClickEventArgs e)
        {
            PlayerConsoleGrid.Visibility = Visibility.Visible;
            var music = (Music)e.ClickedItem;
            MusicMedia.Source = new Uri(this.BaseUri, music.AudioFile);
            SongTitleTextBox.Text = music.Name;
            GenereTextBox.Text = music.Category.ToString();
            DurationTextBox.Text = string.Format("{0}:{1:00}", Math.Truncate(MusicMedia.NaturalDuration.TimeSpan.TotalMinutes), MusicMedia.NaturalDuration.TimeSpan.Seconds);
            VolumeSlider.Value = MusicMedia.Volume;
            ArtisttextBox.Text = music.Artist;
            YearTextBox.Text = music.Year;
            AlbumTextBox.Text = music.Album;

            PlayingSongImage.Source = new BitmapImage(new Uri(this.BaseUri, music.ImageFile));
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            MusicMedia.Pause();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            MusicMedia.Play();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            CollapsePlayerConsole();
        }

        public void CollapsePlayerConsole()
        {
            MusicMedia.Stop();
            PlayerConsoleGrid.Visibility = Visibility.Collapsed;
            MusicGridview.SelectedItem = null;
        }

        private void volumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MusicMedia.Volume = VolumeSlider.Value;
        }

        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            MusicMedia.IsMuted = !MusicMedia.IsMuted;
            var testclor = MuteButton.Background;
            MuteButton.Background = MusicMedia.IsMuted ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.LightGray);
        }

        private async void EditCoverImageButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".png");
            openPicker.CommitButtonText = "Select";


            // Open FileOpenPicker    
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                Windows.Storage.Streams.IRandomAccessStream fileStream =
                await file.OpenAsync(FileAccessMode.Read);

                // Create a BitmapImage and Set stream as source    
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(fileStream);

                PlayingSongImage.Source = bitmapImage;
            }
        }

       

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            MusicManager.getMusicByCategory(songs, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;
        }
    }
}
