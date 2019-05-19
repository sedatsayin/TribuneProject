using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Boreass.Models.DbModels
{
    public partial class sedatContext : DbContext
    {
        public sedatContext()
        {
        }

        public sedatContext(DbContextOptions<sedatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<EarningMonthly> EarningMonthly { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }
        public virtual DbSet<Tribunes> Tribunes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Host=localhost;Database=sedat;Username=root;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areas>(entity =>
            {
                entity.ToTable("areas", "sedat");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(9) unsigned");

                entity.Property(e => e.Langitude)
                    .HasColumnName("langitude")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EarningMonthly>(entity =>
            {
                entity.ToTable("earning_monthly", "sedat");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(6) unsigned");

                entity.Property(e => e.Earning)
                    .HasColumnName("earning")
                    .HasColumnType("double(9,0)");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("int(6)");

                entity.Property(e => e.StationId)
                    .HasColumnName("station_id")
                    .HasColumnType("int(6)");
            });

            modelBuilder.Entity<Stations>(entity =>
            {
                entity.ToTable("stations", "sedat");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AreaId)
                    .HasColumnName("area_id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Potential)
                    .HasColumnName("potential")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("int(6)");

                entity.Property(e => e.StartDate).HasColumnName("start_date");
            });

            modelBuilder.Entity<Tribunes>(entity =>
            {
                entity.ToTable("tribunes", "sedat");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(9) unsigned");

                entity.Property(e => e.Altitude)
                    .HasColumnName("altitude")
                    .HasColumnType("double(255,0)");

                entity.Property(e => e.Brand)
                    .HasColumnName("brand")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Potential)
                    .HasColumnName("potential")
                    .HasColumnType("double(255,0)");

                entity.Property(e => e.StationId)
                    .HasColumnName("station_id")
                    .HasColumnType("int(9) unsigned");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
