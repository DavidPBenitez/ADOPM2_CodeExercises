using System;
using Seido.Utilities.SeedGenerator;
namespace _15_polymorphism.Models;

public enum NordicAnimalKind { Moose, Wolf, Deer, Bear, Fox}
public enum AfricanAnimalKind { Aligator, Elephant, Lion, Donkey, Monkey}
public enum HunterBirdKind {Eagle, Hawk, Owl, Falcon}

public enum AnimalMood { Happy, Sleepy, Sad, Hungry, Lazy, Quick, Slow }
public class Animal: ISeed<Animal>
{
	public AnimalMood Mood { get; set; }
	public int Age { get; set; }
	public string Name { get; set; }
	public bool CanSwim { get; set; }
	public override string ToString() => $"{Name} the {Mood} {Age}yr";
	public virtual string MakeSound() => "Animal sounds!";
	
	public bool Seeded {get; set;} = false;
	public Animal Seed(SeedGenerator _seeder)
	{
		Mood = _seeder.FromEnum<AnimalMood>();
		Age = _seeder.Next(0, 10);
		Name = _seeder.PetName;
		Seeded = true;
		return this;
	}
	public Animal() { }
	public Animal(Animal org)
	{
		Mood = org.Mood;
		Age = org.Age;
		Name = org.Name;
	}
}

public class NordicAnimal: Animal, ISeed<NordicAnimal>
{
	public NordicAnimalKind Kind { get; set; }
	public override string ToString() => $"{Name} the {Mood} {Age}yr, Kind of Animal: {Kind}, Can the animal swim? {CanSwim}.";
	    public override string MakeSound() => Kind switch
	{
		NordicAnimalKind.Bear => "Bear sounds!",
		NordicAnimalKind.Deer => "Deer sounds!",
		NordicAnimalKind.Fox => "Fox sounds!",
		NordicAnimalKind.Moose => "Moose sounds!",
		NordicAnimalKind.Wolf => "Wolf sounds!",
		_ => "Animal sounds!"
	};
    public new NordicAnimal Seed(SeedGenerator _seeder)
	{
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<NordicAnimalKind>();
		CanSwim = _seeder.Bool;
		return this;
	}
	public NordicAnimal() { }
	public NordicAnimal(NordicAnimal org) : base(org)
    {
		Kind = org.Kind;
		CanSwim = org.CanSwim;
    }
}
public class AfricanAnimal : Animal, ISeed<AfricanAnimal>
{
    public AfricanAnimalKind Kind { get; set; }
	decimal Weight { get; set; }
    public override string ToString() => $"{Name} the {Mood} {Age}yr, Kind of Animal: {Kind}, Weighs {Weight}kg.";
    public override string MakeSound() => Kind switch
	{
		AfricanAnimalKind.Aligator => "Alligator sounds!",
		AfricanAnimalKind.Donkey => "Donkey sounds!",
		AfricanAnimalKind.Elephant => "Elephant sounds!",
		AfricanAnimalKind.Lion => "Lion sounds!",
		AfricanAnimalKind.Monkey => "Monkey sounds!",
		_ => "Animal sounds!"
	};
	    public new AfricanAnimal Seed(SeedGenerator _seeder)
	{
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<AfricanAnimalKind>();
		Weight = _seeder.NextDecimal(20, 1000);
		return this;
	}
	public AfricanAnimal() {}
	public AfricanAnimal(AfricanAnimal org) : base(org)
    {
        Kind = org.Kind;
		Weight = org.Weight;
    }
}

public class HunterBird: Animal, ISeed<HunterBird>
{
    public HunterBirdKind Kind { get; set; }
    public int WingspanCm { get; set; }
    public bool CanHuntAtNight { get; set; }
 
    public new HunterBird Seed(SeedGenerator _seeder)
    {
        base.Seed(_seeder);
        Kind = _seeder.FromEnum<HunterBirdKind>();
        WingspanCm = _seeder.Next(50, 250);
        CanHuntAtNight = _seeder.Next(0, 2) == 1;
        return this;
    }
    public override string ToString() => $"{base.ToString()} the {Kind} (WingspanCm: {WingspanCm})";
	public override string MakeSound() => Kind switch
	{
		HunterBirdKind.Eagle => "Eagle sounds!",
		HunterBirdKind.Falcon => "Falcon sounds!",
		HunterBirdKind.Hawk => "Hawk sounds!",
		HunterBirdKind.Owl => "Owl sounds!",
		_ => "Animal sounds!"
	};    
   
    public HunterBird() { }
    public HunterBird(HunterBird org): base(org)
    {
        Kind = org.Kind;
        WingspanCm = org.WingspanCm;
        CanHuntAtNight = org.CanHuntAtNight;
    }
 
    public HunterBird Hunt()
    {
        this.Mood = AnimalMood.Quick;  
        System.Console.WriteLine($"{Name} is hunting!");
        return this;
    }
    public HunterBird Fly()
    {
        this.Mood = AnimalMood.Happy;  
        System.Console.WriteLine($"{Name} is flying!");
        return this;
    }
    public HunterBird Rest()
    {
        this.Mood = AnimalMood.Sleepy;  
        System.Console.WriteLine($"{Name} is resting!");
        return this;
    }  
}


