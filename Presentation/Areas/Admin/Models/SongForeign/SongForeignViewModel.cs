using System.Web.Mvc;
using Gitarist.Areas.Admin.Models.Lookup;
using Gitarist.Areas.Admin.ValidationAttributes;
using Gitarist.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gitarist.Models.Lookup;
using Theme = Gitarist.Domain.Theme;

namespace Gitarist.Areas.Admin.Models
{
    public partial class SongForeignViewModel
    {
       
        public long id { get; set; }
        public long? artistId { get; set; }
        public long? themeId { get; set; }
        public bool isNew { get; set; }
        public bool isPopular { get; set; }
        
        [Required(ErrorMessage="Название зарубежной песни обязательно")]
        [SongForeignUniqueName(ErrorMessage="Зарубежная песня с таким именем уже существует")]
        public string name { get; set; }
        
        [Required(ErrorMessage = "Аккорды зарубежной песни обязательны")]
        public string chords { get; set; }
        public bool deleted { get; set; }

        public string ArtistName { get; set; }
        public string ThemeName { get; set; }

        [SongForeignClearUrlUnique(ErrorMessage = "Зарубежная песня с такой Чпу ужес уществует")]
        public string clearUrlName { get; set; }
        
        public List<LookupItem> Artists
        {
            get
            {
                return new Lookup<ArtistForeign>(false, true).GetItems();
            }
        }

        public List<LookupItem> Themes
        {
            get
            {
                return new Lookup<Theme>(false, true).GetItems();
            }
        }

        public List<SelectListItem> ChordKeys
        {
            get
            {
                string[] chordKeys = { "Ab", "A", "A#", "Bb", "B", "C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "Gb", "G", "G#" };

                var result = new List<SelectListItem>();

                foreach (var chord in chordKeys)
                    result.Add(new SelectListItem { Text = chord, Value = chord });

                return result;

            }
        }
    }
}