//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinFormRow.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlayerInTeam
    {
        public int PlayerInTeamId { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int SeasonId { get; set; }
        public string ShirtNumber { get; set; }
        public decimal Salary { get; set; }
        public int StarterIndex { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual Season Season { get; set; }
        public virtual Team Team { get; set; }
    }
}
