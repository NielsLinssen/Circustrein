using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestsCircusTrein
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void AddAnimal()
        {
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal animal = new Herbivore("Antilope", 3);

            Assert.AreEqual(true, wagon.TryAddAnimal(animal));
        }

        [TestMethod]
        public void AddCarnivoreToHerbivoreWagon()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Antilope = new Herbivore("Antilope", 3);
            Animal Tiger = new Carnivore("Tiger", 3);

            wagon.TryAddAnimal(Antilope);

            train.Wagons.Add(wagon);

            Assert.AreEqual(false, wagon.TryAddAnimal(Tiger));
        }

        [TestMethod]
        public void AddBiggerHerbivorToCarnivoreWagon()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Tiger = new Carnivore("Tiger", 3);

            wagon.TryAddAnimal(Elephant);

            train.Wagons.Add(wagon);

            Assert.AreEqual(true, wagon.TryAddAnimal(Tiger));
        }

        [TestMethod]
        public void TryToAddAnimalWhileHavingFullWagon()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Elephant2 = new Herbivore("Elephant2", 5);

            Animal Giraffe = new Herbivore("Giraffe", 5);

            wagon.TryAddAnimal(Elephant);
            wagon.TryAddAnimal(Elephant2);

            train.Wagons.Add(wagon);

            train.AddAnimal(Giraffe);

            // Expecting total wagon count of 2
            Assert.AreEqual(2, train.Wagons.Count);
        }
        
        [TestMethod]
        public void TryToAddAnimalThatWillNotFit()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Squirrel = new Herbivore("Squirrel", 1);

            Animal Elephant2 = new Herbivore("Elephant2", 5);

            wagon.TryAddAnimal(Elephant);
            wagon.TryAddAnimal(Squirrel);

            bool result = wagon.TryAddAnimal(Elephant2);

            // Expecting false because it won't fit
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AddToSecondWagon()
        {
            // Setup
            Train train = new Train();

            Wagon wagon1 = new Wagon();
            Wagon wagon2 = new Wagon();
            Wagon wagon3 = new Wagon();

            // Wagon 1
            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Giraffe = new Herbivore("Giraffe", 3);

            wagon1.TryAddAnimal(Elephant);
            wagon1.TryAddAnimal(Giraffe);

            // Wagon 2
            Animal Spider = new Carnivore("Spider", 1);
            Animal Antilope = new Herbivore("Antilope", 3);

            wagon2.TryAddAnimal(Spider);
            wagon2.TryAddAnimal(Antilope);

            // Wagon 3
            Animal Bear = new Carnivore("Bear", 3);

            wagon3.TryAddAnimal(Bear);

            train.Wagons.Add(wagon1);
            train.Wagons.Add(wagon2);
            train.Wagons.Add(wagon3);

            // Actual test, expecting it to be added to the 2nd wagon
            Animal Elephant2 = new Herbivore("Elephant2", 5);
            train.AddAnimal(Elephant2);

            // Due to indexing 1 equals the 2nd wagon
            Assert.AreEqual(1, train.Wagons[1].GetSize());
        }

        [TestMethod]
        public void AddBiggerCarnivoreToWagon()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Antilope = new Herbivore("Antilope", 3);
            Animal Bear = new Carnivore("Bear", 5);

            wagon.TryAddAnimal(Antilope);

            train.Wagons.Add(wagon);

            Assert.AreEqual(false, wagon.TryAddAnimal(Bear));
        }

        [TestMethod]
        public void AddEqualSizeCarnivoreToHerbivore()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Bear = new Carnivore("Bear", 5);

            wagon.TryAddAnimal(Elephant);

            train.Wagons.Add(wagon);

            Assert.AreEqual(false, wagon.TryAddAnimal(Bear));
        }

        [TestMethod]
        public void AddEqualSizeHerbivoreToCarnivore()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Bear = new Carnivore("Bear", 5);

            wagon.TryAddAnimal(Bear);

            train.Wagons.Add(wagon);

            Assert.AreEqual(false, wagon.TryAddAnimal(Elephant));
        }
    }
}
