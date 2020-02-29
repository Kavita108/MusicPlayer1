using mediaplayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MusicLibrary.Model;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace mediaplayer
{
   
    public sealed partial class MainPage : Page
    {
     
       private ObservableCollection<Sound> sounds;
        private List<MenuItem> menuItems;
        private MediaPlayer player;
        private PlaylistManager playlistManager;
        private ObservableCollection<Playlist> playlists;

        public MainPage()
        {
            this.InitializeComponent();
            player = new MediaPlayer();
            songs = new ObservableCollection<Song>();
            playlistManager = new PlaylistManager();
            playlists = new ObservableCollection<Playlist>(playlistManager.Playlists.Values);
            SongManager.GetAllSongs(songs);
            menuItems = new List<MenuItem>();

            //Load pane
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/adele.png",
                Category = SoundCategory.Adele
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/Justin.png",
                Category = SoundCategory.Justin
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/sia.png",
                Category = SoundCategory.Sia
            });
            menuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/taylor.png",
                Category = SoundCategory.Taylor
            });
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetAllSounds(sounds);
            CategoryTextBlock.Text = "All Sounds";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, sound.AudioFile);
        }

        private void FavoriteList_Click(object sender, ItemClickEventArgs e)
        {
            Playlist playlist = (Playlist)e.ClickedItem;
            songs.Clear();
            var songsInPlaylist = playlistManager.Playlists[playlist.Name].Songs;
            songsInPlaylist.ForEach(s => songs.Add(s));
            CategoryTextBlock.Text = "Play List";
            MenuItemsListView.SelectedItem = null;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            SoundManager.GetSoundsByCategory(sounds, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;
        }

        private void AddToPlaylist_Click(object sender, ItemClickEventArgs e)
        {
            Playlist playlist = (Playlist)e.ClickedItem;
            var allSongs = new List<Song>(songs);
            var selectedSongs = allSongs.Where(s => s.SelectedForPlaylist == true).ToList();
            foreach (var song in selectedSongs)
            {
                playlistManager.Playlists[playlist.Name].Songs.Add(song);
                song.SelectedForPlaylist = false;
            }
        }

        private void PlayList_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetSoundsByPlaylist(sounds);
            CategoryTextBlock.Text = "Play List";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Visible;
        }
    }
}