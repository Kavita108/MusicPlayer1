using mediaplayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace mediaplayer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LocalMusic : Page
    {
      
                          
        public LocalMusic()
        {
            this.InitializeComponent();
            ShowFilesAsync();

            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                greeting.Text = $"Hi, {e.Parameter.ToString()}";
            }
            else
            {
                greeting.Text = "Hi!";
            }
            base.OnNavigatedTo(e);          
        }

        private void HyperlinkButton_Click1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        public IReadOnlyList<Windows.Storage.StorageFile> files;

        async void ShowFilesAsync()
        {
            //StorageFolder object that represent music folder
            Windows.Storage.StorageFolder folder = Windows.Storage.KnownFolders.MusicLibrary;


            //Get a list of file in the folder 
            //Asynchronous API
            //IReadOnlyList<Windows.Storage.StorageFile> files = await folder.GetFilesAsync();
            files = await folder.GetFilesAsync();


            //Sort by extention name and get file name only
            IEnumerable<string> fileNames = files.OrderBy(f => f.FileType).Select(f => f.Name);

            //Display file names inside of Listview block named "DisplaySongListHere".
            AllLocalSongsListView.ItemsSource = fileNames;

        }


        // string file.Name needs to find a file that matchs the file.name.
        private void AllLocalSongsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

            //var source = e.ClickedItem as IStorageFile;
            var filename = e.ClickedItem as string;
            foreach(Windows.Storage.StorageFile file in files)
            {
                if(file.Name == filename)
                {
                    MyMediaElement1.Source = MediaSource.CreateFromStorageFile(file);
                }
            }
            //MyMediaElement1.Source = MediaSource.CreateFromStorageFile(source);
            MyMediaElement1.MediaPlayer.Play();
        }

        private async void image_Click(object sender, RoutedEventArgs e)
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

            openPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;

            openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");

            var file = await openPicker.PickSingleFileAsync();
            if (file == null)
                return;

            using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                var bitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage();

                bitmap.SetSource(stream);

                Image1.Source = bitmap;
            }
        }

    }
}
