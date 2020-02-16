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
        private static List<Sound> getSounds()
        {
            var sounds = new List<Sound>();

            sounds.Add(new Sound("Odam", SoundCategory.AmrDiab));
            sounds.Add(new Sound("Youm", SoundCategory.AmrDiab ));

            sounds.Add(new Sound("Hala", SoundCategory.Angham));

            sounds.Add(new Sound("Eish", SoundCategory.HamadaHelal));
            sounds.Add(new Sound("Lala", SoundCategory.HamadaHelal));

            sounds.Add(new Sound("ElMakan", SoundCategory.TamerHosni));


            return sounds;
        }

        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allSounds = getSounds();
            sounds.Clear();
            allSounds.ForEach(s => sounds.Add(s));
        }

        public static void GetSoundsByCategory(
            ObservableCollection<Sound> sounds, SoundCategory category)
        {
            var allSounds = getSounds();
            var filteredSounds = allSounds.Where(s => s.Category == category).ToList();
            sounds.Clear();
            filteredSounds.ForEach(s => sounds.Add(s));
        }

   
}
}
