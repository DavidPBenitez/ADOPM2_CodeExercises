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
        public override string ToString()
            => $"Wine {Name} from {Country} is {WineType} and made from grapes {GrapeType}."
            + $" The price is {Price:N2} Sek. ({this.GetType().Name})";

        public IWine Seed(SeedGenerator rnd)
        {
            var ws = new WineAsClass()
            {
                Name = rnd.FromString("Bollibumpa, MumsMumsan, BlubbBlubb, YummyYummy in the evening, GulpGulp, SipSip"),
                Country = rnd.FromEnum<Country>(),
                GrapeType = rnd.FromEnum<GrapeType>(),
                WineType = rnd.FromEnum<WineType>(),
                Price = rnd.NextDecimal(50, 1000)
            };
            return ws;
        }
    }

    
    public struct WineAsStruct : IWine
    {
        public string Name { get; set; }

        public Country Country { get; set; }
        public WineType WineType { get; set; }
        public GrapeType GrapeType { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
            => $"Wine {Name} from {Country} is {WineType} and made from grapes {GrapeType}."
            + $" The price is {Price:N2} Sek. ({this.GetType().Name})";

        public IWine Seed(SeedGenerator rnd)
        {
            var ws = new WineAsStruct()
            {
                Name = rnd.FromString("Bollibumpa, MumsMumsan, BlubbBlubb, YummyYummy in the evening, GulpGulp, SipSip"),
                Country = rnd.FromEnum<Country>(),
                GrapeType = rnd.FromEnum<GrapeType>(),
                WineType = rnd.FromEnum<WineType>(),
                Price = rnd.NextDecimal(50, 1000)
            };
            return ws;
        }
    }


/*    public record WineAsRecord(string Name, Country Country, WineType WineType, GrapeType GrapeType, decimal Price) : IWine
    {
        public WineAsRecord(): this("", Country.France, WineType.Red, GrapeType.Chardonay, 0M) { }
        public IWine Seed(SeedGenerator rnd)
        {
            var wr = new WineAsRecord(
                rnd.FromString("Bollibumpa, MumsMumsan, BlubbBlubb, YummyYummy in the evening, GulpGulp, SipSip"),
                rnd.FromEnum<Country>(),
                rnd.FromEnum<WineType>(),
                rnd.FromEnum<GrapeType>(),
                rnd.NextDecimal(50, 1000)
                );
            return wr;
        }
    }*/

}

