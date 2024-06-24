﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SpotifyScript2.Data;

#nullable disable

namespace SpotifyScript2.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.Property<string>("AlbumsId")
                        .HasColumnType("text");

                    b.Property<string>("ArtistsId")
                        .HasColumnType("text");

                    b.HasKey("AlbumsId", "ArtistsId");

                    b.HasIndex("ArtistsId");

                    b.ToTable("AlbumArtists", (string)null);
                });

            modelBuilder.Entity("ArtistTrack", b =>
                {
                    b.Property<string>("ArtistsId")
                        .HasColumnType("text");

                    b.Property<string>("TracksId")
                        .HasColumnType("text");

                    b.HasKey("ArtistsId", "TracksId");

                    b.HasIndex("TracksId");

                    b.ToTable("TrackArtists", (string)null);
                });

            modelBuilder.Entity("SpotifyScript2.Models.Album", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Artist", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("SpotifyScript2.Models.AudioBook", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AudioBooks");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Categories", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Chapter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AudioBookId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShowId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AudioBookId");

                    b.HasIndex("ShowId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Episode", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShowId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Playlist", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Show", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Track", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AlbumId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaylistId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("SpotifyScript2.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.HasOne("SpotifyScript2.Models.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotifyScript2.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtistTrack", b =>
                {
                    b.HasOne("SpotifyScript2.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotifyScript2.Models.Track", null)
                        .WithMany()
                        .HasForeignKey("TracksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpotifyScript2.Models.Chapter", b =>
                {
                    b.HasOne("SpotifyScript2.Models.AudioBook", "AudioBook")
                        .WithMany("Chapters")
                        .HasForeignKey("AudioBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotifyScript2.Models.Show", null)
                        .WithMany("Chapters")
                        .HasForeignKey("ShowId");

                    b.Navigation("AudioBook");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Episode", b =>
                {
                    b.HasOne("SpotifyScript2.Models.Show", "Show")
                        .WithMany("Episodes")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Track", b =>
                {
                    b.HasOne("SpotifyScript2.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotifyScript2.Models.Playlist", null)
                        .WithMany("Tracks")
                        .HasForeignKey("PlaylistId");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("SpotifyScript2.Models.AudioBook", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Playlist", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("SpotifyScript2.Models.Show", b =>
                {
                    b.Navigation("Chapters");

                    b.Navigation("Episodes");
                });
#pragma warning restore 612, 618
        }
    }
}
