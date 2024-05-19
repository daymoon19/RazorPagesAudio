using Microsoft.EntityFrameworkCore;
using RazorPagesAudio.Data;
using RazorPagesAudio.Models;
using RazorPagesAudio.Data;

namespace RazorPagesAudio.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesAudioContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesAudioContext>>()))
        {
            if (context == null || context.Audio == null)
            {
                throw new ArgumentNullException("Null RazorPagesAudioContext");
            }

            // Look for any Audio.
            if (context.Audio.Any())
            {
                return;   // DB has been seeded
            }

            context.Audio.AddRange(
                new Audio
                {
                    Title = "Thriller",
                    Singer = "Michael Jackson",
                    NumberOfSongs = 9,
                    Time = 42,
                    ReleaseDate = DateTime.Parse("1982-11-29"),
                    Genre = "Pop",
                    Price = 7.99M,
                    Rating = "G"
                },

                new Audio
                {
                    Title = "21",
                    Singer = "Adel",
                    NumberOfSongs = 11,
                    Time = 48,
                    ReleaseDate = DateTime.Parse("2011-1-24"),
                    Genre = "Pop",
                    Price = 7.99M,
                    Rating = "G"
                },

                new Audio
                {
                    Title = "Medieval Groove",
                    Singer = "Gilead",
                    NumberOfSongs = 13,
                    Time = 61,
                    ReleaseDate = DateTime.Parse("2017-12-17"),
                    Genre = "Medieval",
                    Price = 1.99M,
                    Rating = "G"
                },

                new Audio   
                {
                    Title = "reality in BLACK",
                    Singer = "MAMAMOO",
                    NumberOfSongs = 11,
                    Time = 36,
                    ReleaseDate = DateTime.Parse("2019-11-14"),
                    Genre = "K-pop",
                    Price = 7.99M,
                    Rating = "G"
                }
            );
            context.SaveChanges();
        }
    }
}