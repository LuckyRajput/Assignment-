using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Movies.Data.Models
{
    public partial class moviesEntities : DbContext
    {
        public moviesEntities()
        {
        }

        public moviesEntities(DbContextOptions<moviesEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Movieactor> Movieactors { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=ibz123;database=moviesdb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.2.17-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actor");

                entity.Property(e => e.ActorId).HasMaxLength(36);

                entity.Property(e => e.ActorName).HasMaxLength(200);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender).HasMaxLength(15);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.HasIndex(e => e.ProducerId, "FK_Movie_Producer_MovieProducerId");

                entity.Property(e => e.MovieId).HasMaxLength(36);

                entity.Property(e => e.DateOfRelease).HasColumnType("datetime");

                entity.Property(e => e.MovieName).HasColumnType("mediumtext");

                entity.Property(e => e.MoviePoster).HasColumnType("blob");

                entity.Property(e => e.ProducerId).HasMaxLength(36);

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ProducerId)
                    .HasConstraintName("FK_Movie_Producer_MovieProducerId");
            });

            modelBuilder.Entity<Movieactor>(entity =>
            {
                entity.ToTable("movieactor");

                entity.HasIndex(e => e.ActorId, "FK_Actor_Movie");

                entity.HasIndex(e => e.MovieId, "FK_Movie_Actor");

                entity.Property(e => e.MovieActorId).HasMaxLength(36);

                entity.Property(e => e.ActorId).HasMaxLength(36);

                entity.Property(e => e.MovieId).HasMaxLength(36);

                entity.Property(e => e.Role).HasMaxLength(100);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Movieactors)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_Actor_Movie");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Movieactors)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_Movie_Actor");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("producer");

                entity.Property(e => e.ProducerId).HasMaxLength(36);

                entity.Property(e => e.Company).HasMaxLength(300);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender).HasMaxLength(15);

                entity.Property(e => e.ProducerName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
