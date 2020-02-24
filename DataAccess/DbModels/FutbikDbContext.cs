using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.DbModels
{
    public partial class FutbikDbContext : DbContext
    {
        public FutbikDbContext()
        {
        }

        public FutbikDbContext(DbContextOptions<FutbikDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=FutbikDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.PkMessage);

                entity.Property(e => e.PkMessage)
                    .HasColumnName("PK_Message")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.FkUser).HasColumnName("FK_User");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasColumnName("Message")
                    .HasMaxLength(1000);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.PkUser);

                entity.Property(e => e.PkUser)
                    .HasColumnName("PK_User")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
