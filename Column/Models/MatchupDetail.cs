//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Column.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MatchupDetail
    {
        public int Id { get; set; }
        public int MatchupId { get; set; }
        public int Quarter { get; set; }
        public int Team_Away_Score { get; set; }
        public int Team_Home_Score { get; set; }
    
        public virtual Matchup Matchup { get; set; }
    }
}
