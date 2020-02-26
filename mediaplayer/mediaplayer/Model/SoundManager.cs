using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediaplayer.Model
{
    public static class SoundManager
    {
        private static List<Sound> allSounds = getSounds();

        private static List<Sound> getSounds()
        {
            var sounds = new List<Sound>();

            sounds.Add(new Sound("Hello", SoundCategory.Adele));
            sounds.Add(new Sound("Someone", SoundCategory.Adele));

            sounds.Add(new Sound("What", SoundCategory.Justin));
            sounds.Add(new Sound("yummy", SoundCategory.Justin));

            sounds.Add(new Sound("Chandelier", SoundCategory.Sia));
            sounds.Add(new Sound("Cheap", SoundCategory.Sia));

            sounds.Add(new Sound("Look", SoundCategory.Taylor));
            sounds.Add(new Sound("Shake", SoundCategory.Taylor));

            return sounds;
        }

        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            sounds.Clear();
            allSounds.ForEach(s => sounds.Add(s));
        }

        public static void GetSoundsByCategory(
            ObservableCollection<Sound> sounds, SoundCategory category)
        {
            var filteredSounds = allSounds.Where(s => s.Category == category).ToList();
            sounds.Clear();
            filteredSounds.ForEach(s => sounds.Add(s));
        }

        public static void GetSoundsByPlaylist(ObservableCollection<Sound> sounds)
        {
            var filteredSounds = allSounds.Where(s => s.playList == true).ToList();
            sounds.Clear();
            filteredSounds.ForEach(s => sounds.Add(s));
        }
    }
}
