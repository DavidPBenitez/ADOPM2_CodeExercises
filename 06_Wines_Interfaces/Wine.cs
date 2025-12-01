using System;
using Seido.Utilities.SeedGenerator;

namespace _05_Wines_Interfaces
{

    public class WineAsClass : IWine
    {
        public string Name { get; set; }

        public Country Country { get; set; }
        public WineType WineType { get; set; }
        public GrapeType GrapeType { get; set; }

        public decimal Price { get; set; }

        public IWine Seed(SeedGenerator rnd)
        {
            this.Name = rnd.FromString("Starkt Kran Vatten, Kanel Kamel, Chateau Lafite, Billigt Brännvin");
            this.Country = rnd.FromEnum<Country>();
            this.WineType = rnd.FromEnum<WineType>();
            this.GrapeType = rnd.FromEnum<GrapeType>();
            this.Price = rnd.NextDecimal(50, 1000);

            return this;
        }
    }
}

