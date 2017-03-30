using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameLibraryV1.Models
{
    public partial class GameContext : DbContext
    {
        public virtual DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\jhardin\Documents\Visual Studio 2017\Projects\GameLibraryV1\GameLibraryV1\Games.mdf"";Integrated Security=True;Connect Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int");

                entity.Property(e => e.GameId).HasColumnType("varchar(8)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Owned)
                    .HasColumnName("owned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(10)");

            });
        }
    }
}