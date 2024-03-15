using HelpingHands.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HelpingHands
{
    public class Seed
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            Debug.WriteLine("!!!!! SEED INITIALIZER RUNNING !!!!!");

            using (var context = new HelpingHandsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HelpingHandsContext>>()))
            {
                if (context == null || context.WorkerProfile_CLASS == null)
                {
                    throw new ArgumentException("Null HelpingHandsContext");
                }

                // Look for any worker profiles.
                if (context.WorkerProfile_CLASS.Any())
                {
                    return; // DB has been seeded
                }

                // else, create random data and seed that into database:
                context.AddRange(PopulateSeed());
                context.SaveChanges();
            }
        }


        private static List<WorkerProfile_CLASS> PopulateSeed()
        {
            List<WorkerProfile_CLASS> SeedProfiles = new List<WorkerProfile_CLASS>();
            int seedSize = 100000;

            for (int i = 0; i < seedSize; i++)
            {
                WorkerProfile_CLASS profile = new()
                {
                    Name = Faker.Name.FullName(),
                    Bio = Faker.Lorem.Paragraph(),
                    Handle = Faker.User.Email(),
                    Location = Faker.Address.Province(),
                    Tags = RandomTag()
                };

                SeedProfiles.Add(profile);
            }

            return SeedProfiles;
        }

        private static string RandomTag()
        {            
            List<string> tags = ["Building", "Painting", "Electrical", "Plumbing", "Carpentry"];

            Random random = new Random();
            int randomIndex = random.Next(0, tags.Count);

            string tag = tags[randomIndex];

            return tag;
        }

    }
}
