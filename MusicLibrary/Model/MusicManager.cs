using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

            DataTable AllSongDetail = GetSongDetails();
            foreach (DataRow dr in AllSongDetail.Rows)
            {
                Songs.Add(new Music(dr));
            }
            return Songs;
        }

        public static DataTable GetSongDetails()
        {
            DataTable SongDetail = new DataTable();

            SongDetail.Columns.Add("SongID", typeof(int));
            SongDetail.Columns.Add("Name", typeof(string));
            SongDetail.Columns.Add("Artist", typeof(string));
            SongDetail.Columns.Add("Year", typeof(string));
            SongDetail.Columns.Add("Album", typeof(string));
            SongDetail.Columns.Add("Category", typeof(string));

            SongDetail.Rows.Add(1, "blessed", "Adelle", "2004", "Love", MusicCategory.Classic);
            SongDetail.Rows.Add(2, "midnight", "Shawn", "2009", "Twilight", MusicCategory.Classic);
            SongDetail.Rows.Add(3, "nature", "Katy Perry", "2004", "Roar", MusicCategory.Classic);

            SongDetail.Rows.Add(4, "sunshine", "Lady gaga ", "2017", "A star is born", MusicCategory.Pop);
            SongDetail.Rows.Add(5, "whip", "Sia", "2017", "Cheap thrills", MusicCategory.Pop);

            SongDetail.Rows.Add(6, "bounce", "Tylor Swift", "2020", "Fashion", MusicCategory.Rap);
            SongDetail.Rows.Add(7, "snoozing", "Adelle", "2004", "Breath", MusicCategory.Rap);

            SongDetail.Rows.Add(8, "Powerful", "Rihanna", "2010", "Diamonds", MusicCategory.Rock);
            SongDetail.Rows.Add(9, "stomping", "Dua Lipa", "2020", "Nostaolgia", MusicCategory.Rock);
            SongDetail.Rows.Add(10, "torn", "Ed Shareen", "2019", "Perfect", MusicCategory.Rock);

            return SongDetail;
        }
    }
}
