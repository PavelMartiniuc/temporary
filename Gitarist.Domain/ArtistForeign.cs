using System.Collections.Generic;

namespace Gitarist.Domain
{
    public class ArtistForeign : BaseEntity
    {
        public ArtistForeign()
        {
            SongsForeign = new List<SongForeign>();
        }

        public virtual string Biography { get; set; }

        public virtual bool IsPopular { get; set; }
   
        public virtual IList<SongForeign> SongsForeign { get; set; }
    }
}
