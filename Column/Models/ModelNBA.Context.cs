﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NBAEntities : DbContext
    {
        public NBAEntities()
            : base("name=NBAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActionType> ActionType { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Conference> Conference { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Matchup> Matchup { get; set; }
        public virtual DbSet<MatchupDetail> MatchupDetail { get; set; }
        public virtual DbSet<MatchupLog> MatchupLog { get; set; }
        public virtual DbSet<MatchupType> MatchupType { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerInTeam> PlayerInTeam { get; set; }
        public virtual DbSet<PlayerStatistics> PlayerStatistics { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<PostSeason> PostSeason { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Team> Team { get; set; }
    }
}