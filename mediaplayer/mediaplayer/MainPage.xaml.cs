using mediaplayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace mediaplayer
{
   
    public sealed partial class MainPage : Page
    {
     
       private ObservableCollection<Sound> sounds;
        private List<MenuItem> menuItems;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(sounds);
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

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            SoundManager.GetSoundsByCategory(sounds, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;
        }


        private void PlayList_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetSoundsByPlaylist(sounds);
            CategoryTextBlock.Text = "Play List";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Visible;
        }

        //Switch to Local Music Page(Page2)
        private void HyperLinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LocalMusic), yourName.Text);
        }
    }
}