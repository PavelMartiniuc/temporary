//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gitarist.Models.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArtistForeign
    {
        public ArtistForeign()
        {
            this.SongForeigns = new HashSet<SongForeign>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string biography { get; set; }
        public bool deleted { get; set; }
        public bool isPopular { get; set; }
        public string clearUrlName { get; set; }
    
        public virtual ICollection<SongForeign> SongForeigns { get; set; }
    }
}