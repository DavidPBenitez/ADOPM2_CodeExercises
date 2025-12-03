using Seido.Utilities.SeedGenerator;
using _15_polymorphism.Models;

/*Console.WriteLine("Hello Polymorphism!");

var seeder = new SeedGenerator();
var animal = new Animal().Seed(seeder);
System.Console.WriteLine(animal);

var animals = seeder.ItemsToList<Animal>(5);
foreach (var a in animals)
{
    System.Console.WriteLine(a);
}*/

var seeder = new SeedGenerator();

//var nordicAnimal = new NordicAnimal().Seed(seeder);
//var africanAnimal = new AfricanAnimal().Seed(seeder);

var zoo = new Zoo() { Name = "Kolmården"};
zoo.ListOfAnimal.AddRange(seeder.ItemsToList<NordicAnimal>(5));
zoo.ListOfAnimal.AddRange(seeder.ItemsToList<AfricanAnimal>(5));
//zoo.ListOfAnimal.AddRange(seeder.ItemsToList<HunterBird>(5));




