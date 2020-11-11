using System;
using Logic;

namespace CircusTrein
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few Animal objects to go through the algorithm with
            // Carnivores
            Animal Bear = new Carnivore("Bear", 5);
            Animal Cheetah = new Carnivore("Cheetah", 3);
            Animal Tarantula = new Carnivore("Tarantula", 1);
            Animal Snake = new Carnivore("Snake", 1);

            // Herbivores
            Animal Chicken = new Herbivore("Chicken", 1);
            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Monkey = new Herbivore("Monkey", 3);
            Animal Squirrel = new Herbivore("Squirrel", 1);
            Animal Antilope = new Herbivore("Antilope", 3);

            // Create a train object in which to add the wagons containing the animals
            Train train = new Train();

            train.AddAnimal(Bear);
            train.AddAnimal(Chicken);
            train.AddAnimal(Cheetah);
            train.AddAnimal(Elephant);
            train.AddAnimal(Tarantula);
            train.AddAnimal(Monkey);
            train.AddAnimal(Squirrel);
            train.AddAnimal(Snake);
            train.AddAnimal(Antilope);

            // In order to show the wagons are used properly create a readable string we can print
            Console.WriteLine(train.FormatWagons());
        }
    }
}
