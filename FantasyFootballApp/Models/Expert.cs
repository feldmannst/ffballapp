//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FantasyFootballApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Expert
    {
        public Expert()
        {
            this.Rankings = new HashSet<Ranking>();
        }
    
        public int ExpertID { get; set; }
        public string ExpertName { get; set; }
        public string Source { get; set; }
    
        public virtual ICollection<Ranking> Rankings { get; set; }
    }
}
