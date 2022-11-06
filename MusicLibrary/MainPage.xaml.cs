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
        private void BackButton_Click( object sender, RoutedEventArgs e)
        {
            MusicManager.getALLMusic(songs);
            CategoryTextBlock.Text = "All songs";
            BackButton.Visibility = Visibility.Collapsed;
            MenuItemsListView.SelectedItem = null;
        }
        private void MusicGridview_ItemClick(object sender,ItemClickEventArgs e)
        {
            var music = (Music)e.ClickedItem;
            MusicMedia.Source = new Uri(this.BaseUri, music.AudioFile);
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
