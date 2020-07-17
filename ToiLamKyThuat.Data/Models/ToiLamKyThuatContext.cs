using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToiLamKyThuat.Data.DataTranferObjects;
using ToiLamKyThuat.Data.Helpers;

namespace ToiLamKyThuat.Data.Models
{
    public partial class ToiLamKyThuatContext : DbContext
    {
        public ToiLamKyThuatContext()
        {

        }

        public ToiLamKyThuatContext(DbContextOptions<ToiLamKyThuatContext> options)
            : base(options)
        {

        }

        public virtual DbSet<MasterData> MasterData { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostComment> PostComment { get; set; }
        public virtual DbSet<PostContent> PostContent { get; set; }
        public virtual DbSet<User> User { get; set; }

        #region DataTranfers Object
        public virtual DbSet<PostDataTranferForList> PostDataTranferForList { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppGlobal.ConectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterData>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.CodeName).HasMaxLength(4000);

                entity.Property(e => e.Config).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MetaDescription).HasMaxLength(4000);

                entity.Property(e => e.MetaKeyword).HasMaxLength(4000);

                entity.Property(e => e.MetaTitle).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Email).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Phone).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<PostContent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Image).HasMaxLength(4000);

                entity.Property(e => e.ImageDescription).HasMaxLength(4000);

                entity.Property(e => e.ImageMetaDesciption).HasMaxLength(4000);

                entity.Property(e => e.ImageMetaKeyword).HasMaxLength(4000);

                entity.Property(e => e.ImageMetaTitle).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.PostId)
                    .HasColumnName("PostID")
                    .HasMaxLength(4000);

                entity.Property(e => e.Text).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Email).HasMaxLength(4000);

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Password).HasMaxLength(4000);

                entity.Property(e => e.Phone).HasMaxLength(4000);

                entity.Property(e => e.UpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Username).HasMaxLength(4000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
