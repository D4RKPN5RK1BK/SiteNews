using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SiteNews.sakila
{
    public partial class goreftinskyContext : DbContext
    {
        public goreftinskyContext(DbContextOptions<goreftinskyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<ReceptionAdm> ReceptionAdms { get; set; }
        public virtual DbSet<ReceptionOpal> ReceptionOpals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=192.168.0.7;user=news_connection;password=bBnlqBf2;database=goreftinsky");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.IdNews)
                    .HasName("PRIMARY");

                entity.ToTable("news");

                entity.Property(e => e.IdNews)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("id_news");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data");

                entity.Property(e => e.Mark)
                    .HasMaxLength(255)
                    .HasColumnName("mark");

                entity.Property(e => e.NameCategory)
                    .HasColumnType("int(1)")
                    .HasColumnName("name_category");

                entity.Property(e => e.NameLong)
                    .IsRequired()
                    .HasColumnName("name_long");

                entity.Property(e => e.NameShort)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("name_short");

                entity.Property(e => e.Public)
                    .HasColumnType("int(1)")
                    .HasColumnName("public");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("text");
            });

            modelBuilder.Entity<NewsCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("news_category");

                entity.HasIndex(e => e.NewsCategoryId, "news_category_id")
                    .IsUnique();

                entity.Property(e => e.NewsCategoryId)
                    .HasColumnType("int(1)")
                    .HasColumnName("news_category_id");

                entity.Property(e => e.NewsCategoryName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("news_category_name");
            });

            modelBuilder.Entity<ReceptionAdm>(entity =>
            {
                entity.HasKey(e => e.IdReception)
                    .HasName("PRIMARY");

                entity.ToTable("reception_adm");

                entity.Property(e => e.IdReception)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("id_reception");

                entity.Property(e => e.Adr)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("adr");

                entity.Property(e => e.DataObr)
                    .HasColumnType("date")
                    .HasColumnName("data_obr");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FioF)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fio_f");

                entity.Property(e => e.FioI)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fio_i");

                entity.Property(e => e.FioO)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fio_o");

                entity.Property(e => e.Fulnamefile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("fulnamefile");

                entity.Property(e => e.NumObr)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_obr");

                entity.Property(e => e.Sfera)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("sfera");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tel");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("text");

                entity.Property(e => e.TimeObr).HasColumnName("time_obr");
            });

            modelBuilder.Entity<ReceptionOpal>(entity =>
            {
                entity.HasKey(e => e.IdReception)
                    .HasName("PRIMARY");

                entity.ToTable("reception_opal");

                entity.Property(e => e.IdReception)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("id_reception");

                entity.Property(e => e.DataObr)
                    .HasColumnType("date")
                    .HasColumnName("data_obr");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Fulnamefile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("fulnamefile");

                entity.Property(e => e.NumObr)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_obr");

                entity.Property(e => e.Sfera)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("sfera");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("text");

                entity.Property(e => e.TimeObr).HasColumnName("time_obr");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
