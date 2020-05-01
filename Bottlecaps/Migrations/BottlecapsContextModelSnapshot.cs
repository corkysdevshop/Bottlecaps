﻿// <auto-generated />
using System;
using Bottlecaps.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bottlecaps.Migrations
{
    [DbContext(typeof(BottlecapsContext))]
    partial class BottlecapsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bottlecaps.Models.Bottlecap", b =>
                {
                    b.Property<int>("BottlecapId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<string>("PositionX")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<string>("PositionY")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BottlecapId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Bottlecap","dbo");
                });

            modelBuilder.Entity("Bottlecaps.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .HasColumnType("int");

                    b.Property<int?>("BottlecapId")
                        .HasColumnType("int");

                    b.Property<string>("LinkText")
                        .HasColumnType("nchar(150)")
                        .IsFixedLength(true)
                        .HasMaxLength(150);

                    b.HasKey("LinkId");

                    b.HasIndex("BottlecapId");

                    b.ToTable("Link","dbo");
                });

            modelBuilder.Entity("Bottlecaps.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<string>("Message1")
                        .HasColumnName("Message")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<DateTime?>("MessageDateTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("SenderId");

                    b.HasIndex("SessionId");

                    b.ToTable("Message","dbo");
                });

            modelBuilder.Entity("Bottlecaps.Models.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorizedSpaceId")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<string>("AuthorizedUser")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<string>("Fname")
                        .HasColumnName("FName")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<string>("Lname")
                        .HasColumnName("LName")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<string>("LockedProfile")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<string>("Password")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<string>("Phone")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<string>("ProfileCap")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<string>("Username")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.HasKey("ProfileId");

                    b.ToTable("Profile","dbo");
                });

            modelBuilder.Entity("Bottlecaps.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int?>("ConnecteeId")
                        .HasColumnType("int");

                    b.Property<int?>("ConnectorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SessionEnd")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("SessionStart")
                        .HasColumnType("datetime");

                    b.Property<int?>("SpaceId")
                        .HasColumnType("int");

                    b.Property<string>("SuccessfulConnection")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("SessionId");

                    b.HasIndex("SpaceId");

                    b.ToTable("Session","dbo");
                });

            modelBuilder.Entity("Bottlecaps.Models.Space", b =>
                {
                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<string>("ActiveStatus")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<string>("BackgroundImage")
                        .HasColumnType("nchar(150)")
                        .IsFixedLength(true)
                        .HasMaxLength(150);

                    b.Property<int?>("DefaultBottlecapId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("SpaceName")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.HasKey("SpaceId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Space","dbo");
                });

            modelBuilder.Entity("Bottlecaps.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int?>("BottlecapId")
                        .HasColumnType("int");

                    b.Property<string>("TagText")
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.HasKey("TagId");

                    b.HasIndex("BottlecapId");

                    b.ToTable("Tag","dbo");
                });

            modelBuilder.Entity("Bottlecaps.Models.Bottlecap", b =>
                {
                    b.HasOne("Bottlecaps.Models.Profile", "Profile")
                        .WithMany("Bottlecap")
                        .HasForeignKey("ProfileId")
                        .HasConstraintName("FK_Bottlecap_Profile");
                });

            modelBuilder.Entity("Bottlecaps.Models.Link", b =>
                {
                    b.HasOne("Bottlecaps.Models.Bottlecap", "Bottlecap")
                        .WithMany("Link")
                        .HasForeignKey("BottlecapId")
                        .HasConstraintName("FK_Link_Bottlecap");
                });

            modelBuilder.Entity("Bottlecaps.Models.Message", b =>
                {
                    b.HasOne("Bottlecaps.Models.Profile", "Sender")
                        .WithMany("Message")
                        .HasForeignKey("SenderId")
                        .HasConstraintName("FK_Message_Profile");

                    b.HasOne("Bottlecaps.Models.Session", "Session")
                        .WithMany("Message")
                        .HasForeignKey("SessionId")
                        .HasConstraintName("FK_Message_Session");
                });

            modelBuilder.Entity("Bottlecaps.Models.Session", b =>
                {
                    b.HasOne("Bottlecaps.Models.Space", "Space")
                        .WithMany("Session")
                        .HasForeignKey("SpaceId")
                        .HasConstraintName("FK_Session_Space");
                });

            modelBuilder.Entity("Bottlecaps.Models.Space", b =>
                {
                    b.HasOne("Bottlecaps.Models.Profile", "Profile")
                        .WithMany("Space")
                        .HasForeignKey("ProfileId")
                        .HasConstraintName("FK_Space_Profile");
                });

            modelBuilder.Entity("Bottlecaps.Models.Tag", b =>
                {
                    b.HasOne("Bottlecaps.Models.Bottlecap", "Bottlecap")
                        .WithMany("Tag")
                        .HasForeignKey("BottlecapId")
                        .HasConstraintName("FK_Tag_Bottlecap");
                });
#pragma warning restore 612, 618
        }
    }
}
