using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AnimeData
{
    public partial class WatchListContext : DbContext
    {
        public WatchListContext()
        {
        }

        public WatchListContext(DbContextOptions<WatchListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anime> Animes { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WatchList;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Anime>(entity =>
            {
                entity.Property(e => e.AnimeId)
                    .ValueGeneratedNever()
                    .HasColumnName("AnimeID");

                entity.Property(e => e.AnimeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("animeName");

                entity.Property(e => e.Episode).HasColumnName("episode");

                entity.Property(e => e.Genre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("genre");

                entity.Property(e => e.Language)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("language");

                entity.Property(e => e.Rank).HasColumnName("rank");

                entity.Property(e => e.ReleaseYear).HasColumnName("releaseYear");

                entity.Property(e => e.Restriction).HasColumnName("restriction");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Summary)
                    .IsUnicode(false)
                    .HasColumnName("summary");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__Profiles__AA2FFB855DD7F05B");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PersonID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Watchlist>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.AnimeId })
                    .HasName("PK__Watchlis__10D7DA9557DB0008");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PersonID");

                entity.Property(e => e.AnimeId).HasColumnName("AnimeID");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Watching)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("watching");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
