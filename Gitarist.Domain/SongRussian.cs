using System;

namespace Gitarist.Domain
{
    public  class SongRussian : BaseEntity
    {
        public virtual bool IsNew { get; set; }
        
        public virtual string Chords { get; set; }
        
        public virtual bool IsPopular { get; set; }
        public virtual DateTime DateCreate { get; set; }
   
        public virtual ArtistRussian ArtistRussian { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
