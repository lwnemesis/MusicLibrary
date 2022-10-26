using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    internal static class MusicManager
    {
        public static void getALLMusic(ObservableCollection<Music> Songs)
        {
            var Music = getMusic();
            Songs.Clear();
            Music.ForEach(Song => Songs.Add(Song));
        }
        public static void getMusicByCategory(ObservableCollection<Music> Songs, MusicCategory Category)
        {
            var Music = getMusic();
            Songs.Clear();

            var filterSongs = Music.Where(song => song.Category == Category).ToList();
            filterSongs.ForEach(Song => Songs.Add(Song));

        }
        public static List<Music> getMusic()
        {
            List<Music> Songs = new List<Music>();
            Songs.Add(new Music("blessed", MusicCategory.Classic));
            Songs.Add(new Music("midnight", MusicCategory.Classic));
            Songs.Add(new Music("nature", MusicCategory.Classic));

            Songs.Add(new Music("sunshine", MusicCategory.Pop));
            Songs.Add(new Music("whip", MusicCategory.Pop));

            Songs.Add(new Music("bounce", MusicCategory.Rap));
            Songs.Add(new Music("snoozing", MusicCategory.Rap));

            Songs.Add(new Music("Powerful", MusicCategory.Rock));
            Songs.Add(new Music("stomping", MusicCategory.Rock));
            Songs.Add(new Music("torn", MusicCategory.Rock));

            return Songs;
        }
    }
}
