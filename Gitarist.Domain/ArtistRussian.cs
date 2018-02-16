using System.Collections.Generic;

namespace Gitarist.Domain
{
    public class ArtistRussian : BaseEntity
    {
        public ArtistRussian()
        {
            SongRussians = new List<SongRussian>();
        }

        public virtual string Biography { get; set; }
        
        public virtual bool IsPopular { get; set; }

        public virtual IList<SongRussian> SongRussians { get; set; }
    }
}
