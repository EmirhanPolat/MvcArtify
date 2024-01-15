using Microsoft.EntityFrameworkCore;
using MvcArtify.DataContext;

namespace MvcArtify.Models.SeedData
{

    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcArtifyContext(serviceProvider.GetRequiredService<DbContextOptions<MvcArtifyContext>>()))
            {
                // Check if there is existing data
                /*
                if (context.Galleries.Any() || context.Exhibitions.Any() || context.Users.Any() )
                {
                    return; // Database has been seeded
                }
                */

                // Seed data for each table
                SeedUsers(context);
                SeedGalleries(context);
                SeedExhibitions(context);
                SeedArtists(context);
                SeedArtworks(context);
                SeedCreateArts(context);
                SeedSchedules(context);
                SeedReviews(context);
                SeedUserContacts(context);
                SeedReviewComments(context);
                SeedClosedDays(context);
                context.SaveChanges();
            }
        }

        private static void SeedGalleries(MvcArtifyContext context)
        {
            var galleries = new List<Gallery>
        {
             new Gallery {  GName = "Gallery 1", Address = "Address 1" },
            new Gallery {  GName = "Gallery 2", Address = "Address 2" },
        
            // Add more galleries as needed
        };

            context.Galleries.AddRange(galleries);
            context.SaveChanges();
        }

        private static void SeedExhibitions(MvcArtifyContext context)
        {

            var exhibitions = new List<Exhibition>

    {
        new Exhibition
        {

            ETitle = "Exhibition 1",
            StartDate = new DateTime(2024, 1, 1),
            EndDate = new DateTime(2024, 2, 1),
            Location = "Location 1",
            // Associate with a gallery
            
        },
        new Exhibition
        {

            ETitle = "Exhibition 2",
            StartDate = new DateTime(2024, 3, 1),
            EndDate = new DateTime(2024, 4, 1),
            Location = "Location 2",
            // Associate with a gallery
            
        },
        // Add more exhibitions as needed
    };

            context.Exhibitions.AddRange(exhibitions);
            context.SaveChanges();

        }

        private static void SeedUsers(MvcArtifyContext context)
        {
            var users = new List<User>
        {
            new User { UName = "User 1", DigitalWallet = 100 },
            new User { UName = "User 2", DigitalWallet = 150 },
       
            // Add more users as needed
        };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void SeedArtists(MvcArtifyContext context)
        {
            var users = context.Users.ToList(); // Retrieve all users

            var artists = new List<Artist>
    {
        new Artist
        {
            Bio = "Bio for Artist 1",
            Identifier = "Identifier1",
            ArtistStyle = "Style1",
            User = users.FirstOrDefault(u => u.UName == "User 1")
        },
        new Artist
        {
            Bio = "Bio for Artist 2",
            Identifier = "Identifier2",
            ArtistStyle = "Style2",
            User = users.FirstOrDefault(u => u.UName == "User 2")
        }
    };

            context.Artists.AddRange(artists);
            context.SaveChanges();




        }

        private static void SeedArtworks(MvcArtifyContext context)
        {
            var Gallery1 = context.Galleries.FirstOrDefault(g => g.GName == "Gallery 1");
            var Gallery2 = context.Galleries.FirstOrDefault(g => g.GName == "Gallery 2");
            var Exhibition1 = context.Exhibitions.FirstOrDefault(e => e.ETitle == "Exhibition 1");
            var Exhibition2 = context.Exhibitions.FirstOrDefault(e => e.ETitle == "Exhibition 2");


            var artworks = new List<Artwork>();

            if (Gallery1 != null && Exhibition1 != null)
            {
                var artwork1 = new Artwork
                {
                    ATitle = "Artwork 1",
                    ArtStyle = "Abstract",
                    Type = "Painting",
                    Description = "Description for Artwork 1",

                    ImagePath = "aaa",
                    SaleDate = DateTime.Now,
                    SalePrice = 200.0f,
                    GalleryID = Gallery1.GalleryID, // Replace with the actual GalleryID
                    ExhibitionID = Exhibition1.ExhibitionID, // Replace with the actual ExhibitionID
                                                             // Image = yourByteImageArray, // Set the actual byte array for the image
                };

                artworks.Add(artwork1);
            }

            if (Gallery2 != null && Exhibition2 != null)
            {
                var artwork2 = new Artwork
                {
                    ATitle = "Artwork 2",
                    ArtStyle = "Sculpture",
                    Type = "Metal",
                    Description = "Description for Artwork 2",

                    ImagePath = "bbb",
                    SaleDate = DateTime.Now,
                    SalePrice = 300.0f,
                    GalleryID = Gallery2.GalleryID, // Replace with the actual GalleryID
                    ExhibitionID = Exhibition2.ExhibitionID, // Replace with the actual ExhibitionID
                                                             // Image = yourByteImageArray, // Set the actual byte array for the image
                };

                artworks.Add(artwork2);
            }

            // Add more artworks as needed

            context.Artworks.AddRange(artworks);
            context.SaveChanges();
        }


        private static void SeedCreateArts(MvcArtifyContext context)
        {
            var artist1 = context.Artists.FirstOrDefault(a => a.Identifier == "Identifier1");
            var artwork1 = context.Artworks.FirstOrDefault(aw => aw.ATitle == "Artwork 1");
            var artist2 = context.Artists.FirstOrDefault(a => a.Identifier == "Identifier2");
            var artwork2 = context.Artworks.FirstOrDefault(aw => aw.ATitle == "Artwork 2");

            var createArts = new List<CreateArt>();

            if (artist1 != null && artwork1 != null)
            {
                context.Attach(artist1);
                createArts.Add(new CreateArt
                {
                    ArtistID = artist1.ArtistId,
                    ArtworkID = artwork1.ArtworkID,
                    Artist = artist1,
                    Artwork = artwork1
                });
            }

            if (artist2 != null && artwork2 != null)
            {
                context.Attach(artist2);
                createArts.Add(new CreateArt
                {
                    ArtistID = artist2.ArtistId,
                    ArtworkID = artwork2.ArtworkID,
                    Artist = artist2,
                    Artwork = artwork2
                });
            }

            // Add a check to see if any CreateArt entries were added
            if (createArts.Any())
            {
                context.CreateArts.AddRange(createArts);
                context.SaveChanges();
            }
        }

        private static void SeedSchedules(MvcArtifyContext context)
        {
            var Gallery1 = context.Galleries.FirstOrDefault(g => g.GName == "Gallery 1");
            var Gallery2 = context.Galleries.FirstOrDefault(g => g.GName == "Gallery 2");
            var Exhibition1 = context.Exhibitions.FirstOrDefault(e => e.ETitle == "Exhibition 1");
            var Exhibition2 = context.Exhibitions.FirstOrDefault(e => e.ETitle == "Exhibition 2");

            var schedules = new List<Schedule>();

            if (Gallery1 != null && Exhibition1 != null)
            {
                schedules.Add(new Schedule
                {
                    GalleryID = Gallery1.GalleryID,
                    ExhibitionID = Exhibition1.ExhibitionID
                });
            }

            if (Gallery2 != null && Exhibition2 != null)
            {
                schedules.Add(new Schedule
                {
                    GalleryID = Gallery2.GalleryID,
                    ExhibitionID = Exhibition2.ExhibitionID
                });
            }

            // Add more Schedule entries as needed

            if (schedules.Any())
            {
                context.Schedules.AddRange(schedules);
                context.SaveChanges();
            }
        }

        private static void SeedReviews(MvcArtifyContext context)
        {
            var artist1 = context.Artists.FirstOrDefault(a => a.Identifier == "Identifier1");
            var artwork1 = context.Artworks.FirstOrDefault(aw => aw.ATitle == "Artwork 1");
            var artist2 = context.Artists.FirstOrDefault(a => a.Identifier == "Identifier2");
            var artwork2 = context.Artworks.FirstOrDefault(aw => aw.ATitle == "Artwork 2");

            var reviews = new List<Review>();

            if (artist1 != null && artwork1 != null)
            {
                reviews.Add(new Review
                {
                    UserID = artist1.ArtistId, // Assuming ArtistId is the foreign key for User
                    ArtworkID = artwork1.ArtworkID,
                    Rating = 4,
                });
            }

            if (artist2 != null && artwork2 != null)
            {
                reviews.Add(new Review
                {
                    UserID = artist2.ArtistId, // Assuming ArtistId is the foreign key for User
                    ArtworkID = artwork2.ArtworkID,
                    Rating = 5,
                });
            }

            // Add more Review entries as needed

            if (reviews.Any())
            {
                context.Reviews.AddRange(reviews);
                context.SaveChanges();
            }
        }

        private static void SeedUserContacts(MvcArtifyContext context)
        {
            var artist1 = context.Artists.FirstOrDefault(a => a.Identifier == "Identifier1");
            var artist2 = context.Artists.FirstOrDefault(a => a.Identifier == "Identifier2");

            var userContacts = new List<UserContact>();

            if (artist1 != null)
            {
                userContacts.Add(new UserContact
                {
                    UserID = artist1.ArtistId, // Assuming ArtistId maps to UserID
                    ContactInfo = "user1@example.com"
                });
            }

            if (artist2 != null)
            {
                userContacts.Add(new UserContact
                {
                    UserID = artist2.ArtistId, // Assuming ArtistId maps to UserID
                    ContactInfo = "user2@example.com"
                });
            }

            // Add more UserContact entries as needed

            if (userContacts.Any())
            {
                context.UserContacts.AddRange(userContacts);
                context.SaveChanges();
            }
        }

        private static void SeedReviewComments(MvcArtifyContext context)
        {
            var artist1 = context.Artists.FirstOrDefault(a => a.Identifier == "Identifier1");
            var artwork1 = context.Artworks.FirstOrDefault(aw => aw.ATitle == "Artwork 1");
            var artist2 = context.Artists.FirstOrDefault(a => a.Identifier == "Identifier2");
            var artwork2 = context.Artworks.FirstOrDefault(aw => aw.ATitle == "Artwork 2");
            var reviewComments = new List<ReviewComment> { };



            if (artist1 != null)
            {
                reviewComments.Add(new ReviewComment
                {

                    UserID = artist1.ArtistId, // Replace with the actual UserID
                    ArtworkID = artwork1.ArtworkID, // Replace with the actual ArtworkID
                    Comment = "Great artwork!", // Replace with the actual comment
                });
            }

            if (artist2 != null)
            {
                reviewComments.Add(new ReviewComment
                {

                    UserID = artist2.ArtistId, // Replace with the actual UserID
                    ArtworkID = artwork2.ArtworkID, // Replace with the actual ArtworkID
                    Comment = "Great artwork!", // Replace with the actual comment
                });
            }
            context.ReviewComments.AddRange(reviewComments);
            context.SaveChanges();
        }

        private static void SeedClosedDays(MvcArtifyContext context)
        {
            var gallery1 = context.Galleries.FirstOrDefault(g => g.GName == "Gallery 1");
            var gallery2 = context.Galleries.FirstOrDefault(g => g.GName == "Gallery 2");
            var closedDays = new List<ClosedDay>
            { };
            if (gallery1 != null)
            {
                closedDays.Add(new ClosedDay
                {
                    GalleryID = gallery1.GalleryID, // Replace with the actual GalleryID
                    ClosedDayDate = "2024-01-01", // Replace with the actual closed day date
                });
            }

            if (gallery2 != null)
            {
                closedDays.Add(new ClosedDay
                {
                    GalleryID = gallery2.GalleryID, // Replace with the actual GalleryID
                    ClosedDayDate = "2024-01-01", // Replace with the actual closed day date
                });
            }

            context.ClosedDays.AddRange(closedDays);
            context.SaveChanges();
        }
    }

}
