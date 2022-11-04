using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    internal enum MusicCategory
    {
        Pop,
        Classic,
        Rap,
        Rock
    }  
    internal class Music
    {
        public string Name { get; set; }//music name
        public string AudioFile { get; set; }//music
        public string ImageFile { get; set; } //maybe album cover
        public string Artist { get; set; }
        public string Year { get; set; }
        public string Album { get; set; }
        public MusicCategory Category { get; set; }

        public Music(DataRow dr)
        {
            Name = dr["Name"].ToString();
            Category = (MusicCategory)Enum.Parse(typeof(MusicCategory), dr["Category"].ToString());
            Artist = dr["Artist"].ToString();
            Year = dr["Year"].ToString();
            Album = dr["Album"].ToString();
            AudioFile = $"/Assets/Audio/{Category}/{Name}.mp3";
            ImageFile = $"/Assets/Images/{Category}/{Name}.png";
                     
        }
    }
}