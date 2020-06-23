using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bottlecaps.Models
{
    public partial class BottlecapsContext : DbContext
    {
        public BottlecapsContext()
        {
        }

        public BottlecapsContext(DbContextOptions<BottlecapsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bottlecap> Bottlecap { get; set; }
        public virtual DbSet<Link> Link { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Space> Space { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=CORKYSLAPTOP\\SQLEXPRESS;Initial Catalog=Bottlecaps;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bottlecap>(entity =>
            {
                entity.ToTable("Bottlecap", "dbo");

                entity.Property(e => e.BottlecapId).ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.PositionX)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PositionY)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Bottlecap)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_Bottlecap_Profile");
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.ToTable("Link", "dbo");

                entity.Property(e => e.LinkId).ValueGeneratedNever();

                entity.Property(e => e.LinkText)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.HasOne(d => d.Bottlecap)
                    .WithMany(p => p.Link)
                    .HasForeignKey(d => d.BottlecapId)
                    .HasConstraintName("FK_Link_Bottlecap");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message", "dbo");

                entity.Property(e => e.MessageId).ValueGeneratedNever();

                entity.Property(e => e.Message1)
                    .HasColumnName("Message")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MessageDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_Message_Profile");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_Message_Session");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile", "dbo");

                entity.Property(e => e.ProfileId).ValueGeneratedNever();

                entity.Property(e => e.AuthorizedSpaceId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.AuthorizedUser)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.LockedProfile)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.ProfileCap)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session", "dbo");

                entity.Property(e => e.SessionId).ValueGeneratedNever();

                entity.Property(e => e.SessionEnd).HasColumnType("datetime");

                entity.Property(e => e.SessionStart).HasColumnType("datetime");

                entity.Property(e => e.SuccessfulConnection)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Space)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.SpaceId)
                    .HasConstraintName("FK_Session_Space");
            });

            modelBuilder.Entity<Space>(entity =>
            {
                entity.ToTable("Space", "dbo");

                entity.Property(e => e.SpaceId).ValueGeneratedNever();

                entity.Property(e => e.ActiveStatus)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.BackgroundImage)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.SpaceName)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.PositionX)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PositionY)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Space)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_Space_Profile");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag", "dbo");

                entity.Property(e => e.TagId).ValueGeneratedNever();

                entity.Property(e => e.TagText)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.Bottlecap)
                    .WithMany(p => p.Tag)
                    .HasForeignKey(d => d.BottlecapId)
                    .HasConstraintName("FK_Tag_Bottlecap");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
