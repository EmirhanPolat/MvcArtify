﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcArtify.DataContext;

#nullable disable

namespace MvcArtify.Migrations
{
    [DbContext(typeof(MvcArtifyContext))]
    [Migration("20240115130207_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MvcArtify.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("ArtistStyle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId");

                    b.HasIndex("UserId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MvcArtify.Models.Artwork", b =>
                {
                    b.Property<int>("ArtworkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtworkID"));

                    b.Property<string>("ATitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ArtStyle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ExhibitionID")
                        .HasColumnType("int");

                    b.Property<int>("GalleryID")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("SalePrice")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VisitorID")
                        .HasColumnType("int");

                    b.HasKey("ArtworkID");

                    b.HasIndex("ExhibitionID");

                    b.HasIndex("GalleryID");

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("MvcArtify.Models.ClosedDay", b =>
                {
                    b.Property<int>("GalleryID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("ClosedDayDate")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnOrder(1);

                    b.HasKey("GalleryID", "ClosedDayDate");

                    b.ToTable("ClosedDays");
                });

            modelBuilder.Entity("MvcArtify.Models.CreateArt", b =>
                {
                    b.Property<int>("ArtistID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ArtworkID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ArtistID", "ArtworkID");

                    b.HasIndex("ArtworkID");

                    b.ToTable("CreateArts");
                });

            modelBuilder.Entity("MvcArtify.Models.Exhibition", b =>
                {
                    b.Property<int>("ExhibitionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExhibitionID"));

                    b.Property<string>("ETitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ExhibitionID");

                    b.ToTable("Exhibitions");
                });

            modelBuilder.Entity("MvcArtify.Models.Gallery", b =>
                {
                    b.Property<int>("GalleryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GalleryID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GalleryID");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("MvcArtify.Models.Review", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ArtworkID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("UserID", "ArtworkID");

                    b.HasIndex("ArtworkID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MvcArtify.Models.ReviewComment", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ArtworkID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Comment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(2);

                    b.HasKey("UserID", "ArtworkID", "Comment");

                    b.HasIndex("ArtworkID");

                    b.ToTable("ReviewComments");
                });

            modelBuilder.Entity("MvcArtify.Models.Schedule", b =>
                {
                    b.Property<int>("GalleryID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ExhibitionID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("GalleryID", "ExhibitionID");

                    b.HasIndex("ExhibitionID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("MvcArtify.Models.User", b =>
                {
                    b.Property<int>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UId"));

                    b.Property<int>("DigitalWallet")
                        .HasColumnType("int");

                    b.Property<string>("UName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MvcArtify.Models.UserContact", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("ContactInfo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnOrder(1);

                    b.HasKey("UserID", "ContactInfo");

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("MvcArtify.Models.Visitor", b =>
                {
                    b.Property<int>("VisitorID")
                        .HasColumnType("int");

                    b.HasKey("VisitorID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("MvcArtify.Models.Artist", b =>
                {
                    b.HasOne("MvcArtify.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MvcArtify.Models.Artwork", b =>
                {
                    b.HasOne("MvcArtify.Models.Exhibition", "Exhibition")
                        .WithMany("Artworks")
                        .HasForeignKey("ExhibitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcArtify.Models.Gallery", "Gallery")
                        .WithMany()
                        .HasForeignKey("GalleryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exhibition");

                    b.Navigation("Gallery");
                });

            modelBuilder.Entity("MvcArtify.Models.ClosedDay", b =>
                {
                    b.HasOne("MvcArtify.Models.Gallery", "Gallery")
                        .WithMany()
                        .HasForeignKey("GalleryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gallery");
                });

            modelBuilder.Entity("MvcArtify.Models.CreateArt", b =>
                {
                    b.HasOne("MvcArtify.Models.Artist", "Artist")
                        .WithMany("CreatedArt")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MvcArtify.Models.Artwork", "Artwork")
                        .WithMany("Creators")
                        .HasForeignKey("ArtworkID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Artwork");
                });

            modelBuilder.Entity("MvcArtify.Models.Review", b =>
                {
                    b.HasOne("MvcArtify.Models.Artwork", "Artwork")
                        .WithMany("Reviews")
                        .HasForeignKey("ArtworkID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MvcArtify.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Artwork");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MvcArtify.Models.ReviewComment", b =>
                {
                    b.HasOne("MvcArtify.Models.Artwork", "Artwork")
                        .WithMany("Comments")
                        .HasForeignKey("ArtworkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcArtify.Models.User", "User")
                        .WithMany("ReviewComments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Artwork");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MvcArtify.Models.Schedule", b =>
                {
                    b.HasOne("MvcArtify.Models.Exhibition", "Exhibition")
                        .WithMany()
                        .HasForeignKey("ExhibitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcArtify.Models.Gallery", "Gallery")
                        .WithMany()
                        .HasForeignKey("GalleryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exhibition");

                    b.Navigation("Gallery");
                });

            modelBuilder.Entity("MvcArtify.Models.UserContact", b =>
                {
                    b.HasOne("MvcArtify.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MvcArtify.Models.Visitor", b =>
                {
                    b.HasOne("MvcArtify.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("VisitorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MvcArtify.Models.Artist", b =>
                {
                    b.Navigation("CreatedArt");
                });

            modelBuilder.Entity("MvcArtify.Models.Artwork", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Creators");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MvcArtify.Models.Exhibition", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("MvcArtify.Models.User", b =>
                {
                    b.Navigation("ReviewComments");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
