using System;
using System.Collections.Generic;
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
        public MusicCategory Category { get; set; }
        public Music(string name, MusicCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = $"/Assets/Audio/{category}/{name}.mp3";
            ImageFile = $"/Assets/Images/{category}/{name}.png";
        }
    }
}