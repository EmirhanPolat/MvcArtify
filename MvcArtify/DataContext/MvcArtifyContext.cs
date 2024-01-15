using Microsoft.EntityFrameworkCore;
using MvcArtify.Models;

namespace MvcArtify.DataContext
{
    public class MvcArtifyContext : DbContext
    {
        public MvcArtifyContext(DbContextOptions<MvcArtifyContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasKey(a => a.ArtistId);

            modelBuilder.Entity<Artwork>()
            .HasOne(a => a.Exhibition)
            .WithMany(e => e.Artworks)
            .HasForeignKey(a => a.ExhibitionID)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ClosedDay>()
                .HasKey(cd => new { cd.GalleryID, cd.ClosedDayDate });

            modelBuilder.Entity<CreateArt>()
                .HasKey(ca => new { ca.ArtistID, ca.ArtworkID });

            modelBuilder.Entity<CreateArt>()
                .HasOne(ca => ca.Artist)
                .WithMany(a => a.CreatedArt)
                .HasForeignKey(ca => ca.ArtistID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CreateArt>()
                .HasOne(ca => ca.Artwork)
                .WithMany(aw => aw.Creators)
                .HasForeignKey(ca => ca.ArtworkID)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.UserID, r.ArtworkID });

            modelBuilder.Entity<Review>()
               .HasOne(r => r.User)
               .WithMany(u => u.Reviews)
               .HasForeignKey(r => r.UserID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Artwork)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.ArtworkID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<ReviewComment>()
                .HasKey(rc => new { rc.UserID, rc.ArtworkID, rc.Comment });

            modelBuilder.Entity<ReviewComment>()
                .HasOne(rc => rc.User)
                .WithMany(u => u.ReviewComments)
                .HasForeignKey(rc => rc.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReviewComment>()
                .HasOne(rc => rc.Artwork)
                .WithMany(a => a.Comments)
                .HasForeignKey(rc => rc.ArtworkID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Schedule>()
               .HasKey(s => new { s.GalleryID, s.ExhibitionID });

            modelBuilder.Entity<UserContact>()
                .HasKey(uc => new { uc.UserID, uc.ContactInfo });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<CreateArt> CreateArts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<ReviewComment> ReviewComments { get; set; }
        public DbSet<ClosedDay> ClosedDays { get; set; }
    }
}
