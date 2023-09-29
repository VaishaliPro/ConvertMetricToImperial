using Microsoft.EntityFrameworkCore;

namespace ConvertMetricToImperial
{
    public class ConversionContext : DbContext
    {
        public ConversionContext(DbContextOptions<ConversionContext> options) : base(options)
        {
        }

        public DbSet<ConversionRate> ConversionRates { get; set; }

        public static void SeedData(ConversionContext context)
        {
            context.Database.EnsureCreated();

            if (!context.ConversionRates.Any())
            {
                var conversionRates = new List<ConversionRate>
            {
                new ConversionRate { FromUnit = "meter", ToUnit = "feet", Rate = 3.28084 },
                new ConversionRate { FromUnit = "kilogram", ToUnit = "pound", Rate = 2.20462 },
               
            };

                context.ConversionRates.AddRange(conversionRates);
                context.SaveChanges();
            }
        }

    }
}
